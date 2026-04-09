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
    public partial class POSform : Form
    {
        public POSform()
        {
            InitializeComponent();
            btnPOS.Checked = true;
            ShowUserControl(posp);
        }

     

        POSPanel posp = new POSPanel();
        ReservePanel resp = new ReservePanel();
        ChangePanel changep = new ChangePanel();
        HistoryPanel historyp = new HistoryPanel();
        InventoryPanel invp = new InventoryPanel();

        public class MenuItemData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Image Picture { get; set; }
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("pos");
            ShowUserControl(posp);
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("reserve");
            ShowUserControl(resp);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("history");
            ShowUserControl(historyp);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("change");
            ShowUserControl(changep);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("inventory");
            ShowUserControl(invp);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            sidemenubtncontrols("logout");

            msgLogout.Parent = this.FindForm();
            msgLogout.Text = "Are you sure you want to logout?";
            DialogResult result = msgLogout.Show();

            if (result == DialogResult.Yes)
            {
                Data.Clear();
                this.Hide();
                Form1 loginform = new Form1();
                loginform.Show();
            }

        }


        private void sidemenubtncontrols(string sidebtn)
        {
            if (sidebtn == "pos")
            {
                btnPOS.Checked = true;
                btnReserve.Checked = false;
                btnHistory.Checked = false;
                btnChange.Checked = false;
                btnInventory.Checked = false;
                btnLogout.Checked = false;
                
            }
            else if (sidebtn == "reserve")
            {
                btnPOS.Checked = false;
                btnReserve.Checked = true;
                btnHistory.Checked = false;
                btnChange.Checked = false;
                btnInventory.Checked = false;
                btnLogout.Checked = false;
            }
            else if (sidebtn == "history")
            {
                btnPOS.Checked = false;
                btnReserve.Checked = false;
                btnHistory.Checked = true;
                btnChange.Checked = false;
                btnInventory.Checked = false;
                btnLogout.Checked = false;
            }
            else if (sidebtn == "change")
            {
                btnPOS.Checked = false;
                btnReserve.Checked = false;
                btnHistory.Checked = false;
                btnChange.Checked = true;
                btnInventory.Checked = false;
                btnLogout.Checked = false;
            }
            else if (sidebtn == "inventory")
            {
                btnPOS.Checked = false;
                btnReserve.Checked = false;
                btnHistory.Checked = false;
                btnChange.Checked = false;
                btnInventory.Checked = true;
                btnLogout.Checked = false;
            }
            else if (sidebtn == "logout")
            {
                btnPOS.Checked = false;
                btnReserve.Checked = false;
                btnHistory.Checked = false;
                btnChange.Checked = false;
                btnInventory.Checked = false;
                btnLogout.Checked = true;
            }

        }

        public void ShowUserControl(UserControl uc)
        {
            pnlParent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void POSform_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
