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
    public partial class Admin_InventoryGroceriesUC : UserControl
    {
        public Admin_InventoryGroceriesUC()
        {
            InitializeComponent();
        }

        // Load by category
        public void LoadItems(string category, inventoryUC parent, string keyword = null)
        {
            flw_base.Controls.Clear();

            List<Grocery> groceries = DatabaseHelper.GetGroceries(category, keyword);

            foreach (var grocery in groceries)
            {
                var itemUC = new Admin_InventoryGroceriesItemUC
                {
                    GroceryID = grocery.GroceryID,
                    ProductName = grocery.GroceryName,
                    Price = grocery.GroceryPrice,
                    Quantity = grocery.GroceryQuantity,
                    Category = grocery.Category,
                    ParentInventoryUC = parent
                };

                flw_base.Controls.Add(itemUC);
            }
        }
        public void LoadAllItems(inventoryUC parent)
        {
            LoadItems(null, parent, null);
        }
    }
}