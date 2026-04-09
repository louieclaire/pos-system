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
    public partial class ReservePanel : UserControl
    {
        public ReservePanel()
        {
            InitializeComponent();
            btnAll.Checked = true;
        }


        private void LoadReservations(string filter, DateTime? selectedDate = null)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
    SELECT *
    FROM (
        SELECT 
            MR.TransactionID,
            MR.CustomerName,
            M.MealName AS ItemName,
            MR.Quantity,
            MR.Subtotal,
            MR.ReservationTime,
            'Meal' AS ItemType,
            MR.IsClaimed
        FROM MenuReservations MR
        JOIN MenuInformation M ON MR.MealID = M.MealID

        UNION ALL

        SELECT 
            GR.TransactionID,
            GR.CustomerName,
            G.GroceryName AS ItemName,
            GR.Quantity,
            GR.Subtotal,
            GR.ReservationTime,
            'Grocery' AS ItemType,
            GR.IsClaimed
        FROM GroceryReservations GR
        JOIN GroceriesInformation G ON GR.GroceryID = G.GroceryID
    ) AS Combined
";

                string whereClause = "";

                // Filter by claim status
                if (filter == "Pending")
                    whereClause = " WHERE IsClaimed = 0";
                else if (filter == "Done")
                    whereClause = " WHERE IsClaimed = 1";

                // Filter by selected date (if provided)
                if (selectedDate != null)
                {
                    string dateCondition = $"CONVERT(date, ReservationTime) = @SelectedDate";
                    if (string.IsNullOrEmpty(whereClause))
                        whereClause = " WHERE " + dateCondition;
                    else
                        whereClause += " AND " + dateCondition;
                }

                query += whereClause + " ORDER BY ReservationTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (selectedDate != null)
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReservations.DataSource = dt;
                dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ReservePanel_Load(object sender, EventArgs e)
        {
            LoadReservations("All");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadReservations("All");
            btnAll.Checked = true;
            btnDone.Checked = false;
            btnPending.Checked = false;
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            LoadReservations("Pending");
            btnAll.Checked = false;
            btnDone.Checked = false;
            btnPending.Checked = true;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            LoadReservations("Done");
            btnAll.Checked = false;
            btnDone.Checked = true;
            btnPending.Checked = false;
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                msgReserve.Text = "Please select a reservation to claim";
                msgReserve.Caption = "No Selection";
                msgReserve.Parent = this.FindForm();
                msgReserve.Show();
                return;
            }

            int transactionId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["TransactionID"].Value);
            string itemType = dgvReservations.SelectedRows[0].Cells["ItemType"].Value.ToString();

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();
                string updateQuery = "";

                if (itemType == "Meal")
                {
                    updateQuery = "UPDATE MenuReservations SET IsClaimed = 1 WHERE TransactionID = @ID";
                }
                else
                {
                    updateQuery = "UPDATE GroceryReservations SET IsClaimed = 1 WHERE TransactionID = @ID";
                }

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", transactionId);
                    cmd.ExecuteNonQuery();
                }
            }

            msgReserve.Text = "Reservation claimed";
            msgReserve.Caption = "Success";
            msgReserve.Parent = this.FindForm();
            msgReserve.Show();

            if (btnDone.Checked == true)
                LoadReservations("Done");
            else if (btnPending.Checked == true)
                LoadReservations("Pending");
            else
                LoadReservations("All");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDateFilter.Value.Date;

            if (btnPending.Checked)
                LoadReservations("Pending", selectedDate);
            else if (btnDone.Checked)
                LoadReservations("Done", selectedDate);
            else
                LoadReservations("All", selectedDate);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpDateFilter.Value = DateTime.Now;
            LoadReservations("All");

            btnAll.Checked = true;
            btnPending.Checked = false;
            btnDone.Checked = false;
        }
    }
}
