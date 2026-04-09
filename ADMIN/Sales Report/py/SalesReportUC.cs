using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using sizzlingeropos.ADMIN.Sales_Report.py;

namespace sizzlingeropos.ADMIN.Sales_Report
{
    public partial class SalesReportUC : UserControl
    {
        private ForecastService forecastService;
        private string connectionString = "Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public SalesReportUC()
        {
            InitializeComponent();
            DateTime endDate = date_enddate.Value.Date;
            DateTime startDate = date_startdate.Value.Date;
            LoadSalesReport(startDate, endDate, "Payment");

            string pythonPath = @"C:\Users\DJ akhi\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.11_qbz5n2kfra8p0\python.exe";
            string scriptPath = @"C:\Users\DJ akhi\OneDrive\Desktop\sizzlingero\sizzlingeropos(MERGED)\sizzlingeropos\sizzlingeropos\ADMIN\Sales Report\py\forecast.py";

            forecastService = new ForecastService(pythonPath, scriptPath);

        }
        private void LoadSalesReport(DateTime startdate, DateTime enddate, string reportType)
        {
            DataTable dt = new DataTable();

            string storedProc = reportType == "Payment"
                ? "GetSalesReportPaymentMethod"     
                : "GetSalesReportMealsGroceries";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(storedProc, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startdate);
                cmd.Parameters.AddWithValue("@EndDate", enddate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No sales found in the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gunaSalesReport.Datasets.Clear();
                gunaSalesReport.Update();
                return;
            }

            // detect source column name (either "Category" or "PaymentMethod")
            string sourceCol = dt.Columns.Contains("Category") ? "Category"
                             : dt.Columns.Contains("PaymentMethod") ? "PaymentMethod"
                             : null;

            if (sourceCol == null)
            {
                MessageBox.Show("Stored procedure result missing Category/PaymentMethod column.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gunaSalesReport.Datasets.Clear();
            gunaSalesReport.Title.Text = $"Sales Summary ({startdate:MMM dd} - {enddate:MMM dd, yyyy})";
            gunaSalesReport.YAxes.GridLines.Display = true;
            gunaSalesReport.XAxes.GridLines.Display = false;

            // date labels for every day in range
            var allDates = Enumerable.Range(0, (enddate - startdate).Days + 1)
                .Select(i => startdate.AddDays(i).ToString("MMM dd"))
                .ToList();

            // Decide the two keys we care about depending on reportType
            string key1 = reportType == "Payment" ? "Cash" : "Meals";
            string key2 = reportType == "Payment" ? "GCash" : "Groceries";

            // dictionaries to hold value per date
            var data1 = new Dictionary<string, double>();
            var data2 = new Dictionary<string, double>();

            // fill dictionaries from returned rows
            foreach (DataRow row in dt.Rows)
            {
                string dateLabel = Convert.ToDateTime(row["Date"]).ToString("MMM dd");
                string val = row[sourceCol].ToString();
                double total = row["TotalSales"] == DBNull.Value ? 0 : Convert.ToDouble(row["TotalSales"]);

                if (val.Equals(key1, StringComparison.OrdinalIgnoreCase))
                    data1[dateLabel] = total;
                else if (val.Equals(key2, StringComparison.OrdinalIgnoreCase))
                    data2[dateLabel] = total;
                else
                {
                    if (!data2.ContainsKey(dateLabel)) data2[dateLabel] = 0;
                    data2[dateLabel] += total;
                }
            }

            string label1 = reportType == "Payment" ? "Cash Sales (₱)" : "Meal Sales (₱)";
            string label2 = reportType == "Payment" ? "GCash Sales (₱)" : "Grocery Sales (₱)";

            var ds1 = new GunaBarDataset { Label = label1 };
            ds1.FillColors.Add(Color.FromArgb(255, 142, 76));     // orange
            ds1.BorderColors.Add(Color.FromArgb(255, 120, 60));
            ds1.BorderWidth = 1;

            var ds2 = new GunaBarDataset { Label = label2 };
            ds2.FillColors.Add(Color.FromArgb(0, 113, 179));      // blue
            ds2.BorderColors.Add(Color.FromArgb(0, 90, 140));
            ds2.BorderWidth = 1;

            var totalDs = new GunaLineDataset
            {
                Label = "Total Sales (₱)",
                BorderColor = Color.FromArgb(60, 179, 113),
                FillColor = Color.Transparent,
                BorderWidth = 3,
                ShowLine = true,
                PointStyle = PointStyle.Circle,
                IndexLabelForeColor = Color.Black
            };

            // fill points per date (ensures empty days show 0)
            foreach (var date in allDates)
            {
                double v1 = data1.ContainsKey(date) ? data1[date] : 0;
                double v2 = data2.ContainsKey(date) ? data2[date] : 0;
                double tot = v1 + v2;

                ds1.DataPoints.Add(new LPoint(date, v1));
                ds2.DataPoints.Add(new LPoint(date, v2));
                totalDs.DataPoints.Add(new LPoint(date, tot));
            }

            gunaSalesReport.Datasets.Add(ds1);
            gunaSalesReport.Datasets.Add(ds2);
            gunaSalesReport.Datasets.Add(totalDs);

            // optional: legend and styling
            gunaSalesReport.Legend.Display = true;
            gunaSalesReport.Legend.Position = LegendPosition.Top;

            gunaSalesReport.Update();
        }

        // button handlers
        private void btnCashGcash_Click(object sender, EventArgs e)
        {
            DateTime startDate = date_startdate.Value.Date;
            DateTime endDate = date_enddate.Value.Date;
            LoadSalesReport(startDate, endDate, "Payment");
        }

        private void btnMealsGroceries_Click(object sender, EventArgs e)
        {
            DateTime startDate = date_startdate.Value.Date;
            DateTime endDate = date_enddate.Value.Date;
            LoadSalesReport(startDate, endDate, "Category");
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            DateTime startDate = date_startdate.Value.Date;
            DateTime endDate = date_enddate.Value.Date;
            LoadSalesReport(startDate, endDate, "Payment");
        }

        private void btn_weekly_Click(object sender, EventArgs e)
        {
            string csvPath = @"C:\Users\DJ akhi\OneDrive\Desktop\sizzlingero\sizzlingeropos(MERGED)\sizzlingeropos\sizzlingeropos\ADMIN\Sales Report\py\csv\sales_weekly.csv";
            DataTable dtSales = GetSalesForForecastFromDB(DateTime.Today.AddDays(-30), DateTime.Today);
            WriteDataTableToCSV(dtSales, csvPath);

            DataTable dtForecast = forecastService.RunForecast("weekly", csvPath);
            DisplayForecastInGunaChart(dtForecast);
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            string csvPath = @"C:\Users\DJ akhi\OneDrive\Desktop\sizzlingero\sizzlingeropos(MERGED)\sizzlingeropos\sizzlingeropos\ADMIN\Sales Report\py\csv\sales_monthly.csv";
            DataTable dtSales = GetSalesForForecastFromDB(DateTime.Today.AddMonths(-1), DateTime.Today);
            WriteDataTableToCSV(dtSales, csvPath);

            DataTable dtForecast = forecastService.RunForecast("monthly", csvPath);
            DisplayForecastInGunaChart(dtForecast);
        }

        private void WriteDataTableToCSV(DataTable dt, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                
                writer.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

                foreach (DataRow row in dt.Rows)
                {
                    writer.WriteLine(string.Join(",", row.ItemArray));
                }
            }
        }

        private DataTable GetSalesForForecastFromDB(DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetSalesForForecast", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", start);
                cmd.Parameters.AddWithValue("@EndDate", end);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        } //pull data from database

        private void DisplayForecastInGunaChart(DataTable dtForecast)
        {
            if (dtForecast == null || dtForecast.Rows.Count == 0)
                return;

            gunaForecast.Datasets.Clear();
            gunaForecast.Title.Text = "Sales Forecast";

            var ds = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = "Forecast (₱)"
            };

            ds.FillColors.Add(Color.FromArgb(0, 113, 179));
            ds.BorderColors.Add(Color.FromArgb(0, 90, 140));
            ds.BorderWidth = 2;

            // Add each row from DataTable as a data point
            foreach (DataRow row in dtForecast.Rows)
            {
                string metric = row["Metric"].ToString();
                double value = Convert.ToDouble(row["Value"]);
                ds.DataPoints.Add(new LPoint(metric, value));
            }

            gunaForecast.Datasets.Add(ds);
            gunaForecast.Legend.Display = true;
            gunaForecast.Update();
        }




    }
}
