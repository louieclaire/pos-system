using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos.Admin_Inventory.Ulam
{
    public partial class Admin_InventoryUlamUC : UserControl
    {
        public Admin_InventoryUlamUC()
        {
            InitializeComponent();
            LoadUlamItems(null);
        }

        public void LoadUlamItems(inventoryUC parentInventoryUC, string search = null, string category = null)
        {
            flw_base.Controls.Clear(); 
            DataTable dt = DatabaseHelper.GetUlamItems(category, search);

            foreach (DataRow row in dt.Rows)
            {
                var itemUC = new Admin_InventoryUlamItemUC
                {
                    MealID = Convert.ToInt32(row["MealID"]),
                    MealName = row["MealName"].ToString(),
                    MealPrice = Convert.ToDecimal(row["MealPrice"]),
                    MealCategory = row["MealCategory"].ToString(),
                    ParentInventoryUC = parentInventoryUC 
                };

                flw_base.Controls.Add(itemUC);
            }
        }
    }
}
