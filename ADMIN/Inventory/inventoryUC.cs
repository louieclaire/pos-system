using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using sizzlingeropos.Admin_Inventory.Ulam;

namespace sizzlingeropos
{
    public partial class inventoryUC : UserControl
    {
        private Admin_InventoryGroceriesUC groceriesUC;
        private Admin_InventoryUlamUC ulamUC;
        private manageUserUC manageUserUC;
        public inventoryUC()
        {
            InitializeComponent();
            btn_inventory_groceries.Checked = true;

            groceriesUC = new Admin_InventoryGroceriesUC();
            LoadControl(groceriesUC);

            cmb_inventoryCategory.Items.AddRange(new string[] { "ALL", "PASTRIES", "CHIPS", "BISCUITS", "DRINKS" });
            cmb_inventoryCategory.SelectedIndex = 0;

            additem_categorycmb.Items.AddRange(new string[] {"PASTRIES", "CHIPS", "BISCUITS", "DRINKS", "ULAM", "ADD ONS"});
            edititem_categorycmb.Items.AddRange(new string[] {"PASTRIES", "CHIPS", "BISCUITS", "DRINKS", "ULAM", "ADD ONS"});
        }

        private void topbtncontrols(string btn)
        {
            if (btn == "a")
            {
                btn_inventory_groceries.Checked = true;
                btn_inventory_ulam.Checked = false;
            }
            else if (btn == "b")
            {
                btn_inventory_groceries.Checked = false;
                btn_inventory_ulam.Checked = true;
            }
        }

        private void btn_inventory_groceries_Click(object sender, EventArgs e)
        {
            topbtncontrols("a");
            cmb_inventoryCategory.Enabled = true;
            cmb_inventoryCategory.SelectedIndex = 0;
            groceriesUC = new Admin_InventoryGroceriesUC();
            LoadControl(groceriesUC);
            groceriesUC.LoadItems(null, this);
        }

        private void btn_inventory_ulam_Click(object sender, EventArgs e)
        {
            topbtncontrols("b");
            cmb_inventoryCategory.Text = "ULAM/ADD ONS";
            cmb_inventoryCategory.Enabled = false;
            ulamUC = new Admin_InventoryUlamUC();
            LoadControl(ulamUC);
            ulamUC.LoadUlamItems(this);
        }

        private void LoadControl(UserControl uc)
        {
            pnl_Inventory65.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnl_Inventory65.Controls.Add(uc);
        }

        private void cmb_inventoryCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groceriesUC = pnl_Inventory65.Controls.OfType<Admin_InventoryGroceriesUC>().FirstOrDefault();
            if (groceriesUC != null)
            {
                if (cmb_inventoryCategory.SelectedItem.ToString() == "All")
                    groceriesUC.LoadAllItems(this);
                else
                    groceriesUC.LoadItems(cmb_inventoryCategory.SelectedItem.ToString(),this);
            }
        }

        private void btn_searchInventory_Click(object sender, EventArgs e)
        {
            string keyword = txt_inventorysearch.Text.Trim();

            if (btn_inventory_groceries.Checked)
            {
                if (groceriesUC != null)
                {
                    groceriesUC.LoadItems(null, this, keyword);
                }
            }
            else if (btn_inventory_ulam.Checked)
            {
                if (ulamUC != null)
                {
                    ulamUC.LoadUlamItems(this, search: keyword);
                }
            }
        }



        private void additem_btn_Click(object sender, EventArgs e)
        {
            string name = additem_nametxtbx.Text.Trim();
            decimal price = decimal.Parse(additem_pricetxtbx.Text.Trim());
            string category = additem_categorycmb.SelectedItem.ToString();

            if (category.Equals("Ulam", StringComparison.OrdinalIgnoreCase) ||
                category.Equals("Add-ons", StringComparison.OrdinalIgnoreCase))
            {
                // Save to MenuInformation
                DatabaseHelper.AddMeal(new Meal
                {
                    MealName = name,
                    MealPrice = price,
                    Category = category
                });
                manageUserUC.ClearFields();
            }
            else
            {
                // Save to Grocery
                DatabaseHelper.AddGrocery(new Grocery
                {
                    GroceryName = name,
                    GroceryPrice = price,
                    GroceryQuantity = 0,
                    Category = category
                });
                manageUserUC.ClearFields();
            }

            MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void edititem_btn_Click(object sender, EventArgs e)
        {
            if (selectedItemID == -1)
            {
                MessageBox.Show("Select an item to edit first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newName = edititem_nametxtbx.Text.Trim();
            decimal newPrice = decimal.Parse(edititem_pricetxtbx.Text.Trim());
            string newCategory = edititem_categorycmb.SelectedItem.ToString();

            if (selectedItemType == "Ulam")
            {
                DatabaseHelper.UpdateMeal(new Meal
                {
                    MealID = selectedItemID,
                    MealName = newName,
                    MealPrice = newPrice,
                    Category = newCategory
                });
                manageUserUC.ClearFields();
            }
            else
            {
                DatabaseHelper.UpdateGrocery(new Grocery
                {
                    GroceryID = selectedItemID,
                    GroceryName = newName,
                    GroceryPrice = newPrice,
                    GroceryQuantity = 0,
                    Category = newCategory
                });
                manageUserUC.ClearFields();
            }

            MessageBox.Show("Item updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadControl(ulamUC);
        }
        private int selectedItemID = -1;
        private string selectedItemType = ""; // "Grocery" or "Ulam"

        public void FillEditFields(int itemID, string name, decimal price, string category)
        {
            selectedItemID = itemID;
            selectedItemType = category.Equals("Ulam", StringComparison.OrdinalIgnoreCase) ||
                               category.Equals("Add-ons", StringComparison.OrdinalIgnoreCase)
                               ? "Ulam"
                               : "Grocery";

            edititem_nametxtbx.Text = name;
            edititem_pricetxtbx.Text = price.ToString();
            edititem_categorycmb.SelectedItem = category;
        } //mag fill yung edit fields

    }
}
