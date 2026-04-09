using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using System.Drawing;

namespace sizzlingeropos
{
    public partial class overviewUC : UserControl
    {
        private string connectionString = "Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public overviewUC()
        {
            InitializeComponent();
            this.Load += OverviewUC_Load;
        }

        private void OverviewUC_Load(object sender, EventArgs e)
        {
            //automatic na last 7 days 
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-6); 
            LoadWeeklySalesReport(startDate, endDate);

            LoadInventoryChart();
            LoadTransactions();
        }

        //For chart sa weekly sales report sa overview
        private void LoadWeeklySalesReport(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("GetSalesReportMealsGroceries", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gunaSalesReport.Datasets.Clear();
            gunaSalesReport.Title.Text = $"Weekly Sales Summary ({startDate:MMM dd} - {endDate:MMM dd, yyyy})";
            gunaSalesReport.YAxes.GridLines.Display = true;
            gunaSalesReport.XAxes.GridLines.Display = false;

            var allDates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                .Select(i => startDate.AddDays(i).ToString("MMM dd"))
                .ToList();

            // Dictionaries for each category
            var mealData = new Dictionary<string, double>();
            var groceryData = new Dictionary<string, double>();

            foreach (DataRow row in dt.Rows)
            {
                string date = Convert.ToDateTime(row["Date"]).ToString("MMM dd");
                string category = row["Category"].ToString();
                double total = Convert.ToDouble(row["TotalSales"]);

                if (category.Equals("Meals", StringComparison.OrdinalIgnoreCase))
                    mealData[date] = total;
                else if (category.Equals("Groceries", StringComparison.OrdinalIgnoreCase))
                    groceryData[date] = total;
            }

            // Meals dataset (Orange)
            var mealDataset = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = "Meal Sales (₱)",
            };
            mealDataset.FillColors.Add(System.Drawing.Color.FromArgb(255, 142, 76));
            mealDataset.BorderColors.Add(System.Drawing.Color.FromArgb(255, 142, 76));
            mealDataset.BorderWidth = 1;

            // Groceries dataset (Blue)
            var groceryDataset = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = "Grocery Sales (₱)",
            };
            groceryDataset.FillColors.Add(System.Drawing.Color.FromArgb(0, 113, 179));
            groceryDataset.BorderColors.Add(System.Drawing.Color.FromArgb(0, 113, 179));
            groceryDataset.BorderWidth = 1;

            // Total Sales (Green line)
            var totalDataset = new Guna.Charts.WinForms.GunaLineDataset
            {
                Label = "Total Sales (₱)",
                BorderColor = System.Drawing.Color.FromArgb(60, 179, 113),
                FillColor = System.Drawing.Color.Transparent,
                BorderWidth = 3,
                ShowLine = true,
                PointStyle = Guna.Charts.WinForms.PointStyle.Circle,
                IndexLabelForeColor = System.Drawing.Color.Black
            };

            // Fill data points for each day
            foreach (var date in allDates)
            {
                double meal = mealData.ContainsKey(date) ? mealData[date] : 0;
                double grocery = groceryData.ContainsKey(date) ? groceryData[date] : 0;
                double total = meal + grocery;

                mealDataset.DataPoints.Add(new LPoint(date, meal));
                groceryDataset.DataPoints.Add(new LPoint(date, grocery));
                totalDataset.DataPoints.Add(new LPoint(date, total));
            }

            // Add all datasets to chart
            gunaSalesReport.Datasets.Add(mealDataset);
            gunaSalesReport.Datasets.Add(groceryDataset);
            gunaSalesReport.Datasets.Add(totalDataset);

            gunaSalesReport.Update();
        }

        private void LoadInventoryChart()
        {
            // Clear previous data
            gunaInventory.Datasets.Clear();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@" SELECT Category, SUM(GroceryQuantity) AS TotalItems
                                                FROM GroceriesInformation
                                                GROUP BY Category
                                            ", conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var inventoryDataset = new GunaBarDataset { Label = "Inventory Count" };

            var categoryColors = new Dictionary<string, Color>
            {
                { "BISCUITS", Color.Orange },
                { "PASTRIES", Color.LightBlue },
                { "CHIPS", Color.LightGreen },
                { "DRINKS", Color.Yellow }
            };

            foreach (DataRow row in dt.Rows)
            {
                string category = row["Category"].ToString();
                int quantity = Convert.ToInt32(row["TotalItems"]);

                inventoryDataset.DataPoints.Add(new LPoint(category, quantity));

                inventoryDataset.FillColors.Add(categoryColors.ContainsKey(category) ? categoryColors[category] : Color.Gray);

                inventoryDataset.BorderColors.Add(Color.Black);
            }

            inventoryDataset.BorderWidth = 1;
            gunaInventory.Datasets.Add(inventoryDataset);

            gunaInventory.YAxes.GridLines.Display = true;
            gunaInventory.XAxes.GridLines.Display = false;

            gunaInventory.Update();
        }
        private void LoadTransactions()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
                SELECT 
                    t.TransactionID,
                    e.FirstName AS EmployeeName,
                    t.DateTime,
                    t.PaymentMethod,
                    t.Total
                FROM Transactions t
                INNER JOIN Employees e ON t.EmployeeID = e.EmployeeID
                ORDER BY t.DateTime DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gunaHistory.DataSource = dt;
                gunaHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
