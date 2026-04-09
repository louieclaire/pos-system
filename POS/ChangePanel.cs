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
    public partial class ChangePanel : UserControl
    {
        public ChangePanel()
        {
            InitializeComponent();
            LoadSukli("All");
            btnAllChange.Checked = true;
        }


        private void LoadSukli(string filter, DateTime? selectedDate = null)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"SELECT SukliID, EmployeeID, CustomerName, Amount, DateRecorded, IsClaimed FROM Sukli";
                string whereClause = "";

                // Filter by status
                if (filter == "Pending")
                    whereClause = " WHERE IsClaimed = 0";
                else if (filter == "Done")
                    whereClause = " WHERE IsClaimed = 1";

                // Filter by date if provided
                if (selectedDate != null)
                {
                    string dateCondition = $"CONVERT(date, DateRecorded) = @SelectedDate";
                    if (string.IsNullOrEmpty(whereClause))
                        whereClause = " WHERE " + dateCondition;
                    else
                        whereClause += " AND " + dateCondition;
                }

                query += whereClause + " ORDER BY DateRecorded DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (selectedDate != null)
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSukli.DataSource = dt;
                dgvSukli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnAllChange_Click(object sender, EventArgs e)
        {
            LoadSukli("All");
            btnAllChange.Checked = true;
            btnDoneChange.Checked = false;
            btnPendingChange.Checked = false;
        }

        private void btnPendingChange_Click(object sender, EventArgs e)
        {
            LoadSukli("Pending");
            btnAllChange.Checked = false;
            btnDoneChange.Checked = false;
            btnPendingChange.Checked = true;
        }

        private void btnDoneChange_Click(object sender, EventArgs e)
        {
            LoadSukli("Done");
            btnAllChange.Checked = false;
            btnDoneChange.Checked = true;
            btnPendingChange.Checked = false;
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
           
            if (dgvSukli.SelectedRows.Count == 0)
            {
                msgChange.Text = "Please select a record to update,";
                msgChange.Caption = " No Selection";
                msgChange.Parent = this.FindForm();
                msgChange.Show();
           
                return;
            }

            int sukliId = Convert.ToInt32(dgvSukli.SelectedRows[0].Cells["SukliID"].Value);

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();
                string updateQuery = @"UPDATE Sukli SET IsClaimed = 1 WHERE SukliID = @ID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", sukliId);
                    cmd.ExecuteNonQuery();
                }
            }


            msgChange.Text = "Sukli is Claimed!";
            msgChange.Caption = "Success";
            msgChange.Parent = this.FindForm();
            msgChange.Show();

        
            if (btnPendingChange.Checked)
                LoadSukli("Pending");
            else if (btnDoneChange.Checked)
                LoadSukli("Done");
            else
                LoadSukli("All");
        

        }

        private void dgvSukli_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDateFilter.Value.Date;

            if (btnPendingChange.Checked)
                LoadSukli("Pending", selectedDate);
            else if (btnDoneChange.Checked)
                LoadSukli("Done", selectedDate);
            else
                LoadSukli("All", selectedDate);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpDateFilter.Value = DateTime.Now;  
            LoadSukli("All");

            btnAllChange.Checked = true;
            btnPendingChange.Checked = false;
            btnDoneChange.Checked = false;
        }
    }
}
