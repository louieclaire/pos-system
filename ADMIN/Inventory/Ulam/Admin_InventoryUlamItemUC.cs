using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos.Admin_Inventory.Ulam
{
    public partial class Admin_InventoryUlamItemUC : UserControl
    {
        private int mealID;
        private string mealName;
        private decimal mealPrice;
        private string mealCategory;

        public inventoryUC ParentInventoryUC { get; set; }

        public int MealID
        {
            get => mealID;
            set => mealID = value;
        }

        public string MealName
        {
            get => mealName;
            set
            {
                mealName = value;
                lbl_itemName.Text = mealName; // ✅ update the label on the UC
            }
        }

        public decimal MealPrice
        {
            get => mealPrice;
            set
            {
                mealPrice = value;
                lbl_itemPriceValue.Text = "₱" + mealPrice.ToString("0.00"); // ✅ update price label
            }
        }

        public string MealCategory
        {
            get => mealCategory;
            set => mealCategory = value;
        }
        public Admin_InventoryUlamItemUC()
        {
            InitializeComponent();
        }

        private void btn_itemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteUlam(MealID);
                this.Parent.Controls.Remove(this);
            }
        }
        private void btn_itemEdit_Click(object sender, EventArgs e)
        {
            if (ParentInventoryUC != null)
            {
                ParentInventoryUC.FillEditFields(MealID, MealName, MealPrice, MealCategory);
            }
            else
            {
                MessageBox.Show("Parent inventory control not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
