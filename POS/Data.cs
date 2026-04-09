using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos
{
    public class Data
    {
        SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public class MenuItemData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Image Picture { get; set; }
            public string Id { get; set; }
            public bool IsMeal { get; set; }   

        }


        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static int EmployeeID { get; set; } // optional, if employee table linked
        public static int AdminID { get; set; } // optional, if admin table linked

        public static void Clear()
        {
            UserID = 0;
            Username = null;
            Role = null;
            EmployeeID = 0;
            AdminID = 0;
        }

        public static List<MenuItemData> list = new List<MenuItemData>();

        public void search(string key)
        {
           
            try
            {
                conn.Open();
                list.Clear();

                // ==============================
                // 1️⃣ Search MenuInformation
                // ==============================
                string query1 = "SELECT MealID, MealName, MealPrice, MealPicPath FROM MenuInformation WHERE MealName LIKE @key";
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        byte[] imgBytes = reader["MealPicPath"] as byte[];
                        Image img = null;

                        if (imgBytes != null && imgBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                img = Image.FromStream(ms);
                            }
                        }

                        MenuItemData data = new MenuItemData
                        {
                            Id = (string)reader["MealID"],
                            Name = reader["MealName"].ToString(),
                            Price = Convert.ToDecimal(reader["MealPrice"]),
                            Picture = img
                        };

                        list.Add(data);
                    }
                }

                // Dispose MenuInformation command and reader
                reader.Close();
                reader.Dispose();
                cmd.Dispose();

                // ==============================
                // 2️⃣ Search GroceriesInformation
                // ==============================
                string query2 = "SELECT GroceryID, GroceryName, GroceryPrice, Category FROM GroceriesInformation WHERE GroceryName LIKE @key";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@key", "%" + key + "%");
                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        Image img = null;
                        string category = reader2["Category"].ToString();

                        if (category == "BISCUITS" || category == "CHIPS" || category == "PASTRIES")
                        {
                            img = Properties.Resources.whitegroceryicon;
                        }
                        else if (category == "DRINKS")
                        {
                            img = Properties.Resources.whitebottleicon;
                        }

                        MenuItemData data = new MenuItemData
                        {
                            Id = reader2["GroceryID"].ToString(),
                            Name = reader2["GroceryName"].ToString(),
                            Price = Convert.ToDecimal(reader2["GroceryPrice"]),
                            Picture = img
                        };

                        list.Add(data);
                    }
                }

                // Dispose GroceriesInformation command and reader
                reader2.Close();
                reader2.Dispose();
                cmd2.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message);
            }
            finally
            {
                // Always close connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Dispose();
            }
        }






    }

}
