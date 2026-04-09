using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Management;
using System.Web.ModelBinding;
using System.Windows.Forms;
using sizzlingeropos.Admin_Inventory.Ulam;

namespace sizzlingeropos
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //---------------------- for grocery lang -------------------------------------
        // ✅ SELECT
        public static List<Grocery> GetGroceries(string category = null, string keyword = null) 
        {
            List<Grocery> groceries = new List<Grocery>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM GroceriesInformation WHERE 1=1";

                if (!string.IsNullOrEmpty(category) && category != "All")
                    query += " AND Category = @Category";

                if (!string.IsNullOrEmpty(keyword))
                    query += " AND GroceryName LIKE @Keyword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(category) && category != "All")
                        cmd.Parameters.AddWithValue("@Category", category);

                    if (!string.IsNullOrEmpty(keyword))
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groceries.Add(new Grocery
                            {
                                GroceryID = reader.GetInt32(0),
                                GroceryName = reader.GetString(1),
                                GroceryPrice = reader.GetDecimal(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                GroceryQuantity = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }

            return groceries;
        }

        // ✅ INSERT
        public static void AddGrocery(Grocery grocery)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO GroceriesInformation (GroceryName, GroceryPrice, Category, GroceryQuantity) " +
                               "VALUES (@Name, @Price, @Category, @Quantity)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", grocery.GroceryName);
                    cmd.Parameters.AddWithValue("@Price", grocery.GroceryPrice);
                    cmd.Parameters.AddWithValue("@Category", grocery.Category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Quantity", grocery.GroceryQuantity);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ UPDATE
        public static void UpdateGrocery(Grocery grocery)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            UPDATE GroceriesInformation
            SET GroceryName = @Name,
                GroceryPrice = @Price,
                Category = @Category
            WHERE GroceryID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", grocery.GroceryName);
                    cmd.Parameters.AddWithValue("@Price", grocery.GroceryPrice);
                    cmd.Parameters.AddWithValue("@Category", grocery.Category);
                    cmd.Parameters.AddWithValue("@ID", grocery.GroceryID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ DELETE
        public static void DeleteGrocery(int groceryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM GroceriesInformation WHERE GroceryID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", groceryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // ✅ UPDATE QUANTITY    
        public static void UpdateQuantity(int groceryId, int changeInQuantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE GroceriesInformation " +
                               "SET GroceryQuantity = GroceryQuantity + @Change " +
                               "WHERE GroceryID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Change", changeInQuantity);
                    cmd.Parameters.AddWithValue("@ID", groceryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //---------------------- end ----------------------------------------------//

        //---------------------- for ulam naman -----------------------------------//
        public static void DeleteUlam(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MenuInformation WHERE MealID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                cmd.ExecuteNonQuery ();
            }
        } // ✅ DELETE

        public static DataTable GetUlamItems(string category = null, string search = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuInformation WHERE 1=1";
                if (!string.IsNullOrEmpty(category))
                    query += " AND MealCategory = @MealCategory";
                if (!string.IsNullOrEmpty(search))
                    query += " AND MealName LIKE @Search";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(category))
                    cmd.Parameters.AddWithValue("@MealCategory", category);
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@Search", $"%{search}%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static void AddMeal(Meal meal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO MenuInformation (MealName, MealPrice, MealCategory) VALUES (@name, @price, @category)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", meal.MealName);
                cmd.Parameters.AddWithValue("@price", meal.MealPrice);
                cmd.Parameters.AddWithValue("@category", meal.Category);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateMeal(Meal meal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE MenuInformation SET MealName=@name, MealPrice=@price, MealCategory=@category WHERE MealID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", meal.MealID);
                cmd.Parameters.AddWithValue("@name", meal.MealName);
                cmd.Parameters.AddWithValue("@price", meal.MealPrice);
                cmd.Parameters.AddWithValue("@category", meal.Category);
                cmd.ExecuteNonQuery();
            }
        }

    }
}