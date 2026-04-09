using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos
{
    public partial class HistoryPanel : UserControl
    {
        public HistoryPanel()
        {
            InitializeComponent();
            
        }
        private void LoadTransactions()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
            SELECT TransactionID, EmployeeID, DateTime, PaymentMethod, Total
            FROM Transactions
            ORDER BY DateTime DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dvgTransactions.DataSource = dt;
                dvgTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadTransactionsByDate(DateTime selectedDate)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
            SELECT TransactionID, EmployeeID, DateTime, PaymentMethod, Total
            FROM Transactions
            WHERE CAST(DateTime AS DATE) = @SelectedDate
            ORDER BY DateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dvgTransactions.DataSource = dt;
                dvgTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void HistoryPanel_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void dvgTransactions_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dvgTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int transactionId = Convert.ToInt32(
                    dvgTransactions.Rows[e.RowIndex].Cells[0].Value
                );
                LoadSubtransactions(transactionId);
            }
        }

        private void LoadSubtransactions(int transactionId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
            SELECT 'Meal' AS Type, M.MealName AS ItemName, MO.Quantity, MO.UnitPrice, MO.Subtotal
            FROM MenuOrders MO
            JOIN MenuInformation M ON MO.MealID = M.MealID
            WHERE MO.TransactionID = @TID

            UNION ALL

            SELECT 'Grocery' AS Type, G.GroceryName AS ItemName, GO.Quantity, GO.UnitPrice, GO.Subtotal
            FROM GroceryOrders GO
            JOIN GroceriesInformation G ON GO.GroceryID = G.GroceryID
            WHERE GO.TransactionID = @TID

            UNION ALL
            SELECT 'Reserved Meal', M.MealName, MR.Quantity, 0 AS UnitPrice, MR.Subtotal
            FROM MenuReservations MR
            JOIN MenuInformation M ON MR.MealID = M.MealID
            WHERE MR.TransactionID = @TID

            UNION ALL
            SELECT 'Reserved Grocery', G.GroceryName, GR.Quantity, 0 AS UnitPrice, GR.Subtotal
            FROM GroceryReservations GR
            JOIN GroceriesInformation G ON GR.GroceryID = G.GroceryID
            WHERE GR.TransactionID = @TID

            ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TID", transactionId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dvgSubtransactions.DataSource = dt;

                dvgSubtransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnDSearch_Click(object sender, EventArgs e)
        {
            LoadTransactionsByDate(dtpDatepicker.Value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void dtpDatepicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
