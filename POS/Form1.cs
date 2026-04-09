using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sizzlingeropos
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
          
            txtPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Image = Properties.Resources.pwEyeIcon;
        }

        private readonly string connectionString =
         "Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                msgBox.Text = "Please enter both username and password.";
                msgBox.Caption = "Missing Info";
                msgBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgBox.Parent = this;
                msgBox.Show();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ✅ Hash the password before checking
                    string hashedPassword = manageUserUC.HashPassword(password);

                    // Step 1: Validate credentials
                    string query = "SELECT UserID, Username, Role FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword); // ✔ use hashed password

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        msgBox.Text = "Invalid username or password.";
                        msgBox.Caption = "Login Failed";
                        msgBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        msgBox.Parent = this;
                        msgBox.Show();
                        return;
                    }

                    // ✅ Store session info
                    int userId = Convert.ToInt32(reader["UserID"]);
                    string uname = reader["Username"].ToString();
                    string role = reader["Role"].ToString();
                    reader.Close();

                    Data.UserID = userId;
                    Data.Username = uname;
                    Data.Role = role;

                    if (role == "admin")
                    {
                        this.Hide();
                        admin adminForm = new admin();
                        adminForm.Show();
                    }
                    else if (role == "staff")
                    {
                        this.Hide();
                        POSform posForm = new POSform();
                        posForm.Show();
                    }
                    else
                    {
                        msgBox.Text = "User role not found. Please contact administrator.";
                        msgBox.Caption = "Access Denied";
                        msgBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        msgBox.Parent = this;
                        msgBox.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                msgBox.Text = "An error occurred while logging in:\n" + ex.Message;
                msgBox.Caption = "Error";
                msgBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                msgBox.Parent = this;
                msgBox.Show();
            }
        }

        private bool isPasswordVisible = false;
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Hide password
                txtPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Image = Properties.Resources.pwEyeIcon;
                isPasswordVisible = false;
            }
            else
            {
                // Show password
                txtPassword.UseSystemPasswordChar= false;
                btnTogglePassword.Image = Properties.Resources.pwCloseEyeIcon;
                isPasswordVisible = true;
            }
        }
    }
}
