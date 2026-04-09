using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sizzlingeropos.POSform;

namespace sizzlingeropos
{
    public partial class POSPanel : UserControl
    {
        SqlConnection connectionString = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public POSPanel()
        {
            InitializeComponent();
            btnmenu1.Checked = true;
            lblDate.Text = DateTime.Now.ToLongDateString();
            LoadMenuItemsFromDatabase();
            pnlSearchResult.Visible = false;
            msgChange.Parent = this.FindForm();
            lblEmployeeID.Text = Data.EmployeeID.ToString();
            
        }
        private void btnmenu1_Click(object sender, EventArgs e)
        {
            menubtncontrols("a");
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            menubtncontrols("b");
        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            menubtncontrols("c");
        }

        SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void btnMenu4_Click(object sender, EventArgs e)
        {
            //  menubtncontrols("d");
            if (selectedBox != null && selectedBox.Enabled == true)
            {
                selectedBox.Enabled = false;

                using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE MenuInformation SET IsDisabled = 1 WHERE MealID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedBox.ItemID);
                        cmd.ExecuteNonQuery();
                    }
                }

                selectedBox.SetSelected(false); 
                selectedBox = null; 
            }
            else
            {
                MessageBox.Show("Please select a menu item first.");
            }

        }

        menubox selectedBox = null;

        private void Box_MenuboxClicked(object sender, EventArgs e)
        {
            menubox clickedBox = sender as menubox;

           
            if (selectedBox != null && selectedBox != clickedBox)
            {
                selectedBox.SetSelected(false); 
            }

        
            if (clickedBox != null)
            {
                clickedBox.SetSelected(true);
                selectedBox = clickedBox; 
            }
        }


        private void menubtncontrols(string btn)
        {
            if (btn == "a")
            {
                btnmenu1.Checked = true;
                btnMenu2.Checked = false;
                btnMenu3.Checked = false;
                btnDisable.Checked = false;
            }
            else if (btn == "b")
            {
                btnmenu1.Checked = false;
                btnMenu2.Checked = true;
                btnMenu3.Checked = false;
                btnDisable.Checked = false;
            }
            else if (btn == "c")
            {
                btnmenu1.Checked = false;
                btnMenu2.Checked = false;
                btnMenu3.Checked = true;
                btnDisable.Checked = false;
            }
            else if (btn == "d")
            {
                btnmenu1.Checked = false;
                btnMenu2.Checked = false;
                btnMenu3.Checked = false;
                btnDisable.Checked = true;
            }

            LoadMenuItemsFromDatabase();
        }

        private void LoadMenuItemsFromDatabase()
        {
            flwpnlMenu.Controls.Clear();
            flwpnlAddOns.Controls.Clear();

            if (btnmenu1.Checked == true)
            {
                pnlCategory.Controls.Clear();
                tblpnlUlam.Parent = pnlCategory;
                tblpnlUlam.Dock = DockStyle.Fill;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
              "SELECT MealID, MealName, MealPrice, MealPicPath, IsDisabled FROM MenuInformation WHERE MealCategory = 'Ulam'", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menubox box = new menubox();
                        box.ItemName = reader["MealName"].ToString();
                        box.ItemPrice = Convert.ToDecimal(reader["MealPrice"]);

                        byte[] imgBytes = (byte[])reader["MealPicPath"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            box.ItemPicture = Image.FromStream(ms);
                        }

                        box.ItemID = reader["MealID"].ToString();
                        box.IsMeal = true;
                        box.ItemClicked += Box_ItemClicked;
                        box.MenuboxClicked += Box_MenuboxClicked;

                        bool isDisabled = Convert.ToBoolean(reader["IsDisabled"]);

                        if (isDisabled)
                        {
                            box.Enabled = false;
                            box.ItemPicture = Properties.Resources.disableicon;
                            box.Cursor = Cursors.No;
                        }
                      
                        box.Height = 170;
                        box.Width = 150;
                        box.Margin = new Padding(15);
                        flwpnlMenu.Controls.Add(box);
                    }
                }

                
                using (SqlCommand cmdd = new SqlCommand(
                    "SELECT MealID, MealName, MealPrice, MealPicPath FROM MenuInformation WHERE MealCategory = 'add-ons'", conn))
                using (SqlDataReader reader2 = cmdd.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        circlemenubox serkol = new circlemenubox();
                        serkol.ItemName = reader2["MealName"].ToString();   
                        serkol.ItemPrice = Convert.ToDecimal(reader2["MealPrice"]);

                        byte[] imgBytes = (byte[])reader2["MealPicPath"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            serkol.ItemPicture = Image.FromStream(ms);
                        }

                        serkol.ItemID = reader2["MealID"].ToString();
                        serkol.IsMeal = true;

                        serkol.ItemClicked += Box_ItemClicked;
                        


                        serkol.Height = 100;
                        serkol.Width = 100;
                        serkol.Margin = new Padding(20, 6, 20, 5);
                        flwpnlAddOns.Controls.Add(serkol);
                    }
                }

                conn.Close();
            }


            else if (btnMenu2.Checked == true)
            {
                pnlCategory.Controls.Clear();

                FlowLayoutPanel flwGrocery = new FlowLayoutPanel();
                flwGrocery.Parent = pnlCategory;
                flwGrocery.Dock = DockStyle.Fill; 

                pnlCategory.Controls.Add(flwGrocery);

                conn.Open();


                SqlCommand cmd = new SqlCommand(
                 "SELECT GroceryID, GroceryName, GroceryPrice, GroceryQuantity FROM GroceriesInformation WHERE Category IN ('BISCUITS', 'CHIPS', 'PASTRIES')",
                 conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menubox box = new menubox();
                    box.ItemName = reader["GroceryName"].ToString();
                    box.ItemPrice = Convert.ToDecimal(reader["GroceryPrice"]);
                    box.ItemPicture = Properties.Resources.whitegroceryicon;
                    box.ItemID = reader["GroceryID"].ToString();
                    box.IsMeal = false;

                    int quantity = Convert.ToInt32(reader["GroceryQuantity"]);

                    if (quantity <= 0)
                    {
                        box.ItemPicture = Properties.Resources.disableicon;
                        box.Enabled = false; 
                        box.Cursor = Cursors.No;
                    }

                    box.ItemClicked += Box_ItemClicked;
                    box.MenuboxClicked += Box_MenuboxClicked;


                    box.Height = 130;
                    box.Width = 110;
                    box.Margin = new Padding(12);
                    flwGrocery.Controls.Add(box);
                }

                conn.Close();
            }

            else if (btnMenu3.Checked == true) {

                pnlCategory.Controls.Clear();

                FlowLayoutPanel flwGrocery = new FlowLayoutPanel();
                flwGrocery.Parent = pnlCategory;
                flwGrocery.Dock = DockStyle.Fill;
                flwGrocery.AutoScroll = true;

                pnlCategory.Controls.Add(flwGrocery);

                conn.Open();


                SqlCommand cmd = new SqlCommand("SELECT GroceryID, GroceryName, GroceryPrice, GroceryQuantity FROM GroceriesInformation  WHERE Category = 'DRINKS'", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menubox box = new menubox();
                    box.ItemName = reader["GroceryName"].ToString();
                    box.ItemPrice = Convert.ToDecimal(reader["GroceryPrice"]);
                    box.ItemPicture = Properties.Resources.whitebottleicon;
                    box.ItemID = reader["GroceryID"].ToString();
                    box.IsMeal = false;

                    int quantity = Convert.ToInt32(reader["GroceryQuantity"]);

                    if (quantity <= 0)
                    {
                        box.ItemPicture = Properties.Resources.disableicon;
                        box.Enabled = false; 
                        box.Cursor = Cursors.No;
                    }

                    box.ItemClicked += Box_ItemClicked;
                    box.MenuboxClicked += Box_MenuboxClicked;


                    box.Height = 130;
                    box.Width = 110;
                    box.Margin = new Padding(12);
                    flwGrocery.Controls.Add(box);
                }

                conn.Close();
            }


        }

        private void Box_ItemClicked(object s, Data.MenuItemData itemData)
        {
            foreach (orderlistbox ctrl in pnlList.Controls.OfType<orderlistbox>())
            {
                if (ctrl.OrderItemName == itemData.Name)
                {
                    ctrl.IncrementQuantity();
                    lblPrice.Text = "Total: ₱ " + CalculateTotal().ToString("N2");
                    
                    return;
                }
            }

            orderlistbox neworderbox = new orderlistbox();
            neworderbox.AddItem(itemData);
            pnlList.Controls.Add(neworderbox);
            neworderbox.Dock = DockStyle.Top;
            lblPrice.Text = "Total: ₱ " + CalculateTotal().ToString("N2");

            neworderbox.QuantityChanged += (sender, e) =>
            {
                lblPrice.Text = "Total: ₱ " + CalculateTotal().ToString("N2");
            };

            neworderbox.ItemDeleted += (sender, e) =>
            {
                pnlList.Controls.Remove(neworderbox);
                neworderbox.Dispose(); 
                lblPrice.Text = "Total: ₱ " + CalculateTotal().ToString("N2");
            };
        }

        private void POSPanel_Load(object sender, EventArgs e)
        {
           // LoadMenuItemsFromDatabase();
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (orderlistbox ctrl in pnlList.Controls.OfType<orderlistbox>())
            {
                if (ctrl.OrderItemData != null)
                {
                    total += ctrl.OrderItemData.Price * ctrl.quantity;
                }
            }

            lblPrice.Text = "Total: ₱ " + total.ToString("N2");
            txtBill_TextChanged(null, null);
            return total;
        }

        private void btnCancelOrders_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel all orders?",
                                "Cancel Orders",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clearlist();
            }
        }

        public void clearlist()
        {
            
            foreach (var ctrl in pnlList.Controls.OfType<orderlistbox>().ToList())
            {
                pnlList.Controls.Remove(ctrl);
                ctrl.Dispose(); 
            }

        
            lblPrice.Text = "Total: ₱ 0.00";
            lblChange.Text = "Change: ₱ 0.00";

        
            txtBill.Text = string.Empty;
            txtCustomerName.Text = string.Empty;

            pnlList.Refresh();

        }

        //search bar
        private void LoadSearchDetails()
        {
            foreach (Data.MenuItemData data in Data.list)
            {
                ControlSearchResult search = new ControlSearchResult();
                search.details(data);
                pnlSearchResult.Controls.Add(search);
            }

            pnlSearchResult.Visible = pnlSearchResult.Controls.Count > 0;
        }
        private void ShowFloatingSearchPanel()
        {
           
            Form parentForm = this.FindForm();
            if (parentForm == null) return;

            Point screenPoint = txtbxSearchbar.PointToScreen(Point.Empty);
            Point formPoint = parentForm.PointToClient(screenPoint);

 
            pnlSearchResult.Parent = parentForm;
            pnlSearchResult.Location = new Point(formPoint.X, formPoint.Y + txtbxSearchbar.Height);
            pnlSearchResult.Width = txtbxSearchbar.Width;
            pnlSearchResult.Height = 250;
            pnlSearchResult.BringToFront();
            pnlSearchResult.Visible = true;
        }

        private void txtbxSearchbar_TextChanged(object sender, EventArgs e)
        {
            string key = txtbxSearchbar.Text.Trim();

            if (string.IsNullOrEmpty(key))
            {
                pnlSearchResult.Visible = false;
                pnlSearchResult.Controls.Clear();
                return;
            }

                pnlSearchResult.Controls.Clear();
                ControlSearchResult search = new ControlSearchResult();
                search.searchresult(txtbxSearchbar.Text);
                LoadSearchDetails();
                ShowFloatingSearchPanel();
        
        }

        // for placing order na cash yung payment method
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            bool hasDisabledItems = false;
            bool hasOverQuantity = false;

            foreach (orderlistbox item in pnlList.Controls.OfType<orderlistbox>())
            {
                if (item.quantity > 20)
                {
                    hasOverQuantity = true;
                    break;
                }
            }

            if (hasOverQuantity)
            {
                msgOverQuantity.Parent = this.FindForm(); 
                DialogResult result = msgOverQuantity.Show();

                if (result == DialogResult.No)
                {
                    clearlist();
                    return;
                }
            }

            if (hasDisabledItems)
            {
                msgDisabledItems.Parent = this.FindForm();
                DialogResult result = msgDisabledItems.Show();

                if (result == DialogResult.No)
                {
                    clearlist();
                    return; 
                }
            }

            if (pnlList.Controls.OfType<orderlistbox>().Count() == 0)
            {
                MsgNoOrders.Parent = this.FindForm();
                MsgNoOrders.Show();
                return;
            }

            if (checkReserve.Checked && string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                msgNoName.Parent = this.FindForm();
                msgNoName.Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBill.Text))
            {
                msgInvalidBill.Text = "Please enter the bill amount.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            if (!decimal.TryParse(txtBill.Text, out decimal billAmount))
            {
                msgInvalidBill.Text = "Invalid bill amount. Please enter a valid number.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            decimal total = CalculateTotal();
            string paymentMethod = "Cash";
            int employeeId = int.Parse(lblEmployeeID.Text);
            int transactionId;

            if (billAmount < total)
            {
                msgInvalidBill.Text = "The bill amount is not enough to cover the total.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();

  
                string insertTransaction = @"INSERT INTO Transactions (EmployeeID, DateTime, PaymentMethod, Total)
                                     VALUES (@EmployeeID, GETDATE(), @PaymentMethod, @Total);
                                     SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertTransaction, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@Total", total);
                    transactionId = Convert.ToInt32(cmd.ExecuteScalar());
                }

         
                foreach (orderlistbox ctrl in pnlList.Controls.OfType<orderlistbox>())
                {
                    if (ctrl.OrderItemData == null) continue;

                    decimal subtotal = ctrl.OrderItemData.Price * ctrl.quantity;

                    if (checkReserve.Checked)
                    {
                        if (ctrl.OrderItemData.IsMeal)
                        {
                            string insertMenuRes = @"INSERT INTO MenuReservations 
                        (TransactionID, CustomerName, MealID, Quantity, Subtotal, ReservationTime, ReservedByEmployee, IsClaimed)
                        VALUES (@TID, @CustName, @MealID, @Qty, @Sub, GETDATE(), @EmpID, @claim)";
                            using (SqlCommand cmd = new SqlCommand(insertMenuRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                                cmd.Parameters.AddWithValue("@MealID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.Parameters.AddWithValue("@EmpID", employeeId);
                                cmd.Parameters.AddWithValue("@claim", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertGroceryRes = @"INSERT INTO GroceryReservations 
                        (TransactionID, CustomerName, GroceryID, Quantity, Subtotal, ReservationTime, ReservedByEmployee, IsClaimed)
                        VALUES (@TID, @CustName, @GID, @Qty, @Sub, GETDATE(), @EmpID, @claim)";
                            using (SqlCommand cmd = new SqlCommand(insertGroceryRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                                cmd.Parameters.AddWithValue("@GID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.Parameters.AddWithValue("@EmpID", employeeId);
                                cmd.Parameters.AddWithValue("@claim", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        if (ctrl.OrderItemData.IsMeal)
                        {
                            string insertMenu = @"INSERT INTO MenuOrders (TransactionID, MealID, UnitPrice, Quantity, Subtotal)
                                          VALUES (@TID, @MealID, @Price, @Qty, @Sub)";
                            using (SqlCommand cmd = new SqlCommand(insertMenu, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@MealID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Price", ctrl.OrderItemData.Price);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertGrocery = @"INSERT INTO GroceryOrders (TransactionID, GroceryID, UnitPrice, Quantity, Subtotal)
                                             VALUES (@TID, @GID, @Price, @Qty, @Sub)";
                            using (SqlCommand cmd = new SqlCommand(insertGrocery, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@GID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Price", ctrl.OrderItemData.Price);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

             
                msgChange.Parent = this.FindForm();
                var result = msgChange.Show();
                
                if (result == DialogResult.No) 
                {
                    decimal changeAmount = GetChangeAmount();
                    string insertSukli = @"INSERT INTO Sukli (EmployeeID, CustomerName, Amount, DateRecorded, IsClaimed)
                                   VALUES (@EmpID, @CustName, @Amount, GETDATE(), 0)";
                    using (SqlCommand cmd = new SqlCommand(insertSukli, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpID", employeeId);
                        cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@Amount", changeAmount);
                        cmd.ExecuteNonQuery();
                    }
                }

              
               

                msgOrderSuccesful.Parent = this.FindForm();
                clearlist();
                msgOrderSuccesful.Show();
            }
        }


        private decimal GetChangeAmount()
        {
            string changeText = lblChange.Text.Replace("Change: ₱", "").Trim();
            decimal.TryParse(changeText, out decimal changeAmount);
            return changeAmount;
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flwpnlAddOns_Paint(object sender, PaintEventArgs e)
        {

        }


        private void txtBill_TextChanged(object sender, EventArgs e)
        {
            decimal billAmount = 0;
            decimal totalAmount = 0;

         
            string totalText = lblPrice.Text.Replace("Total: ₱", "").Trim();
            decimal.TryParse(totalText, out totalAmount);

          
            if (!decimal.TryParse(txtBill.Text.Trim(), out billAmount))
            {
                lblChange.Text = "Change: ₱ 0.00";
                return;
            }

        
            decimal change = billAmount - totalAmount;
            if (change < 0) change = 0;

          
            lblChange.Text = "Change: ₱ " + change.ToString("N2");
        }


        // para sa place order ng gcash payment method
        private void btnGCashPlaceOrder_Click(object sender, EventArgs e)
        {

            bool hasDisabledItems = false;
            bool hasOverQuantity = false;

            foreach (orderlistbox item in pnlList.Controls.OfType<orderlistbox>())
            {
                if (item.quantity > 20)
                {
                    hasOverQuantity = true;
                    break;
                }
            }

            if (hasOverQuantity)
            {
                msgOverQuantity.Parent = this.FindForm(); 
                DialogResult result = msgOverQuantity.Show();

                if (result == DialogResult.No)
                {
                    clearlist();
                    return;
                }
                
            }

            if (hasDisabledItems)
            {
                msgDisabledItems.Parent = this.FindForm();
                DialogResult result = msgDisabledItems.Show();

                if (result == DialogResult.No)
                {
                    clearlist();
                    return;
                }
            }


            if (pnlList.Controls.OfType<orderlistbox>().Count() == 0)
            {
                MsgNoOrders.Parent = this.FindForm();
                MsgNoOrders.Show();
                return;
            }

            if (checkReserve.Checked && string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                msgNoName.Parent = this.FindForm();
                msgNoName.Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBill.Text))
            {
                msgInvalidBill.Text = "Please enter the bill amount.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            if (!decimal.TryParse(txtBill.Text, out decimal billAmount))
            {
                msgInvalidBill.Text = "Invalid bill amount. Please enter a valid number.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            decimal total = CalculateTotal();
            string paymentMethod = "GCash";
            int employeeId = int.Parse(lblEmployeeID.Text);
            int transactionId;

            if (billAmount < total)
            {
                msgInvalidBill.Text = "The bill amount is not enough to cover the total.";
                msgInvalidBill.Parent = this.FindForm();
                msgInvalidBill.Show();
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=DARIUSJENO\\SQLEXPRESS;Initial Catalog=sizzlingeroPOS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                conn.Open();

                
                string insertTransaction = @"INSERT INTO Transactions (EmployeeID, DateTime, PaymentMethod, Total)
                                     VALUES (@EmployeeID, GETDATE(), @PaymentMethod, @Total);
                                     SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertTransaction, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@Total", total);
                    transactionId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (orderlistbox ctrl in pnlList.Controls.OfType<orderlistbox>())
                {
                    if (ctrl.OrderItemData == null) continue;

                    decimal subtotal = ctrl.OrderItemData.Price * ctrl.quantity;

                    if (checkReserve.Checked)
                    {
                        if (ctrl.OrderItemData.IsMeal)
                        {
                            string insertMenuRes = @"INSERT INTO MenuReservations 
                        (TransactionID, CustomerName, MealID, Quantity, Subtotal, ReservationTime, ReservedByEmployee, IsClaimed)
                        VALUES (@TID, @CustName, @MealID, @Qty, @Sub, GETDATE(), @EmpID, @claim)";
                            using (SqlCommand cmd = new SqlCommand(insertMenuRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                                cmd.Parameters.AddWithValue("@MealID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.Parameters.AddWithValue("@EmpID", employeeId);
                                cmd.Parameters.AddWithValue("@claim", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertGroceryRes = @"INSERT INTO GroceryReservations 
                        (TransactionID, CustomerName, GroceryID, Quantity, Subtotal, ReservationTime, ReservedByEmployee, IsClaimed)
                        VALUES (@TID, @CustName, @GID, @Qty, @Sub, GETDATE(), @EmpID, @claim)";
                            using (SqlCommand cmd = new SqlCommand(insertGroceryRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                                cmd.Parameters.AddWithValue("@GID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.Parameters.AddWithValue("@EmpID", employeeId);
                                cmd.Parameters.AddWithValue("@claim", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else                    
                    {
                        if (ctrl.OrderItemData.IsMeal)
                        {
                            string insertMenu = @"INSERT INTO MenuOrders (TransactionID, MealID, UnitPrice, Quantity, Subtotal)
                                          VALUES (@TID, @MealID, @Price, @Qty, @Sub)";
                            using (SqlCommand cmd = new SqlCommand(insertMenu, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@MealID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Price", ctrl.OrderItemData.Price);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertGrocery = @"INSERT INTO GroceryOrders (TransactionID, GroceryID, UnitPrice, Quantity, Subtotal)
                                             VALUES (@TID, @GID, @Price, @Qty, @Sub)";
                            using (SqlCommand cmd = new SqlCommand(insertGrocery, conn))
                            {
                                cmd.Parameters.AddWithValue("@TID", transactionId);
                                cmd.Parameters.AddWithValue("@GID", ctrl.OrderItemData.Id);
                                cmd.Parameters.AddWithValue("@Price", ctrl.OrderItemData.Price);
                                cmd.Parameters.AddWithValue("@Qty", ctrl.quantity);
                                cmd.Parameters.AddWithValue("@Sub", subtotal);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                msgChange.Parent = this.FindForm();
                var result = msgChange.Show();
                msgChange.Parent = this.FindForm();
                if (result == DialogResult.No)
                {
                    decimal changeAmount = GetChangeAmount();
                    string insertSukli = @"INSERT INTO Sukli (EmployeeID, CustomerName, Amount, DateRecorded, IsClaimed)
                                   VALUES (@EmpID, @CustName, @Amount, GETDATE(), 0)";
                    using (SqlCommand cmd = new SqlCommand(insertSukli, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpID", employeeId);
                        cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@Amount", changeAmount);
                        cmd.ExecuteNonQuery();
                    }
                }

                msgOrderSuccesful.Parent = this.FindForm();
                clearlist();
                msgOrderSuccesful.Show();
            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEmployeeID_Click(object sender, EventArgs e)
        {

        }

       

    }
}