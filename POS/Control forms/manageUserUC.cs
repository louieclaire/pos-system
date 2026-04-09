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
    public partial class manageUserUC : UserControl
    {
        private string connectionString = "Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public manageUserUC()
        {
            InitializeComponent();
            grid.CellClick += grid_CellClick;

            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT e.EmployeeID, e.FirstName, e.LastName, e.ContactNumber, e.DateCreated,
                   e.Role AS EmployeeRole, u.Username, u.Role AS UserRole
            FROM Employees e
            INNER JOIN Users u ON e.UserID = u.UserID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

                grid.Columns["EmployeeID"].HeaderText = "ID";
                grid.Columns["FirstName"].HeaderText = "First Name";
                grid.Columns["LastName"].HeaderText = "Last Name";
                grid.Columns["ContactNumber"].HeaderText = "Contact";
                grid.Columns["DateCreated"].HeaderText = "Date Created";
                grid.Columns["EmployeeRole"].HeaderText = "Role";
                grid.Columns["Username"].HeaderText = "Username";
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = grid.Rows[e.RowIndex];

                txtbx_FirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtbx_LastName.Text = row.Cells["LastName"].Value.ToString();
                txtbx_contactNumber.Text = row.Cells["ContactNumber"].Value.ToString();
                cmb_role.SelectedItem = row.Cells["EmployeeRole"].Value.ToString();
                txtbx_Username.Text = row.Cells["Username"].Value.ToString();
                txtbx_password.Text = ""; 
            }
        }

        public void ClearFields()
        {
            txtbx_FirstName.Text = "";
            txtbx_LastName.Text = "";
            txtbx_contactNumber.Text = "";
            txtbx_Username.Text = "";
            txtbx_password.Text = "";
            cmb_role.SelectedIndex = -1; // Reset combo box selection
        } //pang clear
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        private int GetUserID(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID FROM Employees WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }//pang reflect sa fields

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_Username.Text) || string.IsNullOrWhiteSpace(txtbx_password.Text))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertUser = "INSERT INTO Users (Username, PasswordHash, Role) OUTPUT INSERTED.UserID VALUES (@Username, @PasswordHash, @Role)";
                    SqlCommand cmdUser = new SqlCommand(insertUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@Username", txtbx_Username.Text);
                    cmdUser.Parameters.AddWithValue("@PasswordHash", HashPassword(txtbx_password.Text));
                    cmdUser.Parameters.AddWithValue("@Role", cmb_role.SelectedItem.ToString());

                    int newUserID = (int)cmdUser.ExecuteScalar();

                    string insertEmployee = "INSERT INTO Employees (UserID, FirstName, LastName, ContactNumber, DateCreated, Role) " +
                                            "VALUES (@UserID, @FirstName, @LastName, @ContactNumber, @DateCreated, @Role)";
                    SqlCommand cmdEmp = new SqlCommand(insertEmployee, conn, transaction);
                    cmdEmp.Parameters.AddWithValue("@UserID", newUserID);
                    cmdEmp.Parameters.AddWithValue("@FirstName", txtbx_FirstName.Text);
                    cmdEmp.Parameters.AddWithValue("@LastName", txtbx_LastName.Text);
                    cmdEmp.Parameters.AddWithValue("@ContactNumber", txtbx_contactNumber.Text);
                    cmdEmp.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                    cmdEmp.Parameters.AddWithValue("@Role", cmb_role.SelectedItem.ToString());
                    cmdEmp.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Employee added successfully.");
                    LoadEmployeeData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            int employeeID = (int)grid.CurrentRow.Cells["EmployeeID"].Value;
            int userID = GetUserID(employeeID);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateEmp = "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, ContactNumber=@ContactNumber, Role=@Role WHERE EmployeeID=@EmployeeID";
                    SqlCommand cmdEmp = new SqlCommand(updateEmp, conn, transaction);
                    cmdEmp.Parameters.AddWithValue("@FirstName", txtbx_FirstName.Text);
                    cmdEmp.Parameters.AddWithValue("@LastName", txtbx_LastName.Text);
                    cmdEmp.Parameters.AddWithValue("@ContactNumber", txtbx_contactNumber.Text);
                    cmdEmp.Parameters.AddWithValue("@Role", cmb_role.SelectedItem.ToString());
                    cmdEmp.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmdEmp.ExecuteNonQuery();

                    string updateUser = "UPDATE Users SET Username=@Username, Role=@Role" +
                                        (string.IsNullOrEmpty(txtbx_password.Text) ? "" : ", PasswordHash=@PasswordHash") +
                                        " WHERE UserID=@UserID";

                    SqlCommand cmdUser = new SqlCommand(updateUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@Username", txtbx_Username.Text);
                    cmdUser.Parameters.AddWithValue("@Role", cmb_role.SelectedItem.ToString());
                    cmdUser.Parameters.AddWithValue("@UserID", userID);
                    if (!string.IsNullOrEmpty(txtbx_password.Text))
                        cmdUser.Parameters.AddWithValue("@PasswordHash", HashPassword(txtbx_password.Text));

                    cmdUser.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Employee updated successfully.");
                    LoadEmployeeData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            int employeeID = (int)grid.CurrentRow.Cells["EmployeeID"].Value;
            int userID = GetUserID(employeeID);

            var confirm = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteEmp = "DELETE FROM Employees WHERE EmployeeID=@EmployeeID";
                    SqlCommand cmdEmp = new SqlCommand(deleteEmp, conn, transaction);
                    cmdEmp.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmdEmp.ExecuteNonQuery();

                    string deleteUser = "DELETE FROM Users WHERE UserID=@UserID";
                    SqlCommand cmdUser = new SqlCommand(deleteUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@UserID", userID);
                    cmdUser.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Employee deleted successfully.");
                    LoadEmployeeData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
