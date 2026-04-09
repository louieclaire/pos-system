using System;
using System.Windows.Forms;
using sizzlingeropos.ADMIN.Change;
using sizzlingeropos.ADMIN.History;
using sizzlingeropos.ADMIN.Sales_Report;
using sizzlingeropos.Admin_Inventory.Ulam;

namespace sizzlingeropos
{
    public class AdminNavigation
    {
        private Panel _panel70;
        private Panel _panel_Inventory_65;

        public AdminNavigation(Panel panel70)
        {
            _panel70 = panel70;
        }

        public void LoadOverview()
        {
            LoadControl(new overviewUC());
        }

        public void LoadInventory()
        {
            LoadControl(new inventoryUC());
        }
        public void LoadHistory()
        {
            LoadControl(new historyUC());
        }
        public void LoadChange()
        {
            LoadControl(new changeUC());
        }
        public void LoadManageUsers()
        {
            LoadControl(new manageUserUC());
        }
        public void LoadSalesReportUC()
        {
            LoadControl(new SalesReportUC());
        }
        private void LoadControl(UserControl uc)
        {
            _panel70.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            _panel70.Controls.Add(uc);
        }
    }
}
