using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos
{
    public partial class Admin_InventoryGroceriesItemUC : UserControl
    {
        public int GroceryID { get; set; }
        public string ProductName
        {
            get => lbl_itemName.Text;
            set => lbl_itemName.Text = value;
        }
        public decimal Price
        {
            get => decimal.Parse(lbl_itemPriceValue.Text.Replace("₱", ""));
            set => lbl_itemPriceValue.Text = "₱" + value.ToString("0.00");
        }
        public int Quantity
        {
            get => int.Parse(lbl_itemQtyValue.Text);
            set => lbl_itemQtyValue.Text = value.ToString();
        }
        public string Category { get; set; }

        public Admin_InventoryGroceriesItemUC()
        {
            InitializeComponent();
        }

        private void btn_itemQtyMinus_Click(object sender, EventArgs e)
        {
            if (Quantity > 0)
            {
                Quantity--;
                DatabaseHelper.UpdateQuantity(GroceryID, -1);
            }
        }
        private void btn_itemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DatabaseHelper.DeleteGrocery(GroceryID);
                this.Parent.Controls.Remove(this);
            }
        }

        private void btn_itemQtyPlus_Click(object sender, EventArgs e)
        {
            Quantity++;
            DatabaseHelper.UpdateQuantity(GroceryID, +1);
        }

        public inventoryUC ParentInventoryUC { get; set; }
        private void btn_itemEdit_Click(object sender, EventArgs e)
        {
            if (ParentInventoryUC != null)
            {
                ParentInventoryUC.FillEditFields(GroceryID, ProductName, Price, Category);
            }
        }
    }
}