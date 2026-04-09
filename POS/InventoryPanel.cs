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
using System.Xml.Linq;

namespace sizzlingeropos
{

    public partial class InventoryPanel : UserControl
    {
        private string currentInventoryType = "Grocery";
        public InventoryPanel()
        {
            InitializeComponent();
            this.dgvDisabledMenus.CellContentClick += dgvDisabledMenus_CellContentClick;


            btnGroceryInv.Click += (s, e) =>
            {
                currentInventoryType = "Grocery";
                LoadInventory("Grocery", cmbFilterCategory.SelectedItem?.ToString());
            };

            btnMealInv.Click += (s, e) =>
            {
                currentInventoryType = "Meal";
                LoadInventory("Meal", cmbFilterCategory.SelectedItem?.ToString());
            };



            dgvInventory.CellClick += dgvInventory_CellClick;

            btnEDone.Click += btnEDone_Click;

            cmbFilterCategory.SelectedIndexChanged += cmbFilterCategory_SelectedIndexChanged;

            LoadCategories();

            LoadInventory("Grocery");
            LoadAddItemCategories();

        }
        SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void LoadDisabledMenus()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT MealID, MealName FROM MenuInformation WHERE IsDisabled = 1", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                dgvDisabledMenus.DataSource = dt;

              
                dgvDisabledMenus.Columns["MealID"].HeaderText = "ID";
                dgvDisabledMenus.Columns["MealName"].HeaderText = "Name";
              

                dgvDisabledMenus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (!dgvDisabledMenus.Columns.Contains("EnableButton"))
                {
                    DataGridViewButtonColumn enableCol = new DataGridViewButtonColumn();
                    enableCol.Name = "EnableButton";
                    enableCol.HeaderText = "Action";
                    enableCol.Text = "Enable";
                    enableCol.UseColumnTextForButtonValue = true;
                    dgvDisabledMenus.Columns.Add(enableCol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading disabled menus: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void dgvDisabledMenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDisabledMenus.Columns["EnableButton"].Index)
            {
                int mealId = Convert.ToInt32(dgvDisabledMenus.Rows[e.RowIndex].Cells["MealID"].Value);
                EnableMenuItem(mealId);
            }
        }

        private void EnableMenuItem(int mealId)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE MenuInformation SET IsDisabled = 0 WHERE MealID = @id", conn);
                cmd.Parameters.AddWithValue("@id", mealId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Menu item re-enabled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDisabledMenus(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling menu item: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDisabledMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            LoadDisabledMenus();
        }

        private void LoadInventory(string type, string category = null)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (type == "Grocery")
                {
                    query = "SELECT GroceryID, GroceryName, GroceryPrice, Category, GroceryQuantity FROM GroceriesInformation";
                    if (!string.IsNullOrEmpty(category) && category != "All")
                    {
                        query += " WHERE Category = @Category";
                        cmd.Parameters.AddWithValue("@Category", category);
                    }
                }
                else if (type == "Meal")
                {
                    query = "SELECT MealID, MealName, MealPrice, MealCategory FROM MenuInformation";
                    if (!string.IsNullOrEmpty(category) && category != "All")
                    {
                        query += " WHERE MealCategory = @Category";
                        cmd.Parameters.AddWithValue("@Category", category);
                    }
                }

                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInventory.DataSource = dt;

                // Add Edit button column if not exists
                if (!dgvInventory.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Edit";
                    btn.Text = "Edit";
                    btn.Name = "Edit";
                    btn.UseColumnTextForButtonValue = true;
                    dgvInventory.Columns.Add(btn);
                }
            }
        }


        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvInventory.Columns[e.ColumnIndex].Name == "Edit")
            {
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];

                if (dgvInventory.Columns.Contains("GroceryID"))
                {
                    lblCurrentType.Text = "Grocery";
                    lblCurrentID.Text = row.Cells["GroceryID"].Value.ToString();
                    txtEName.Text = row.Cells["GroceryName"].Value.ToString();
                    txtEPrice.Text = row.Cells["GroceryPrice"].Value.ToString();
                    cmbECategory.SelectedItem = row.Cells["Category"].Value.ToString();
                }
                else if (dgvInventory.Columns.Contains("MealID"))
                {
                    lblCurrentType.Text = "Meal";
                    lblCurrentID.Text = row.Cells["MealID"].Value.ToString();
                    txtEName.Text = row.Cells["MealName"].Value.ToString();
                    txtEPrice.Text = row.Cells["MealPrice"].Value.ToString();
                    cmbECategory.SelectedItem = row.Cells["MealCategory"].Value.ToString();
                }
            }
        }

        private void btnEDone_Click(object sender, EventArgs e)
        {
            string name = txtEName.Text;
            string priceText = txtEPrice.Text;
            string category = cmbECategory.SelectedItem?.ToString();

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            int id = int.Parse(lblCurrentID.Text);
            string type = lblCurrentType.Text;

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = "";
                if (type == "Grocery")
                    query = "UPDATE GroceriesInformation SET GroceryName=@Name, GroceryPrice=@Price, Category=@Category WHERE GroceryID=@ID";
                else
                    query = "UPDATE MenuInformation SET MealName=@Name, MealPrice=@Price, MealCategory=@Category WHERE MealID=@ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadInventory(type, cmbFilterCategory.SelectedItem?.ToString());
        }

        private void LoadCategories()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All"); 

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT Category FROM GroceriesInformation " +
                    "UNION " +
                    "SELECT DISTINCT MealCategory FROM MenuInformation", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbFilterCategory.Items.Add(reader[0].ToString());
                }
            }

            cmbFilterCategory.SelectedIndex = 0; 
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cmbFilterCategory.SelectedItem?.ToString() ?? "All";

            if (btnGroceryInv.Focused)      
                LoadInventory("Grocery", category);
            else if (btnMealInv.Focused)     
                LoadInventory("Meal", category);
            else
                LoadInventory("Grocery", category); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtAName.Text.Trim();
            string priceText = txtAPrice.Text.Trim();
            string category = cmbACategory.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }

            string type = currentInventoryType;

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();
                string query = "";

                if (type == "Grocery")
                    query = "INSERT INTO GroceriesInformation (GroceryName, GroceryPrice, Category, GroceryQuantity) VALUES (@Name, @Price, @Category, 0)";
                else
                    query = "INSERT INTO MenuInformation (MealName, MealPrice, MealCategory) VALUES (@Name, @Price, @Category)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Category", category);

                cmd.ExecuteNonQuery();
            }

            LoadInventory(type, cmbFilterCategory.SelectedItem?.ToString());

            txtAName.Clear();
            txtAPrice.Clear();
            cmbACategory.SelectedIndex = -1;

            MessageBox.Show("Item added successfully!");
        }

        private void LoadAddItemCategories()
        {
            cmbACategory.Items.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT Category FROM GroceriesInformation " +
                    "UNION " +
                    "SELECT DISTINCT MealCategory FROM MenuInformation", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbACategory.Items.Add(reader[0].ToString());
                    cmbECategory.Items.Add(reader[0].ToString());
                }
            }
        }

    }
}
