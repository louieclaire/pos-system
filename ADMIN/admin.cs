using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace sizzlingeropos
{
    public partial class admin : Form
    {
        public AdminNavigation _nav;
        public admin()
        {
            InitializeComponent();
            overviewbtn.Checked = true;
            _nav = new AdminNavigation(panel_70);
            _nav.LoadOverview();
        }

        private void Overviewbtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("a");
            _nav.LoadOverview();
        }
        private void inventorybtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("b");
            _nav.LoadInventory();
        }
        private void historybtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("c");
            _nav.LoadHistory();
        }

        private void changebtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("d");
            _nav.LoadChange();
        }

        private void manage_usersbtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("e");
            _nav.LoadManageUsers();
        }

        private void sales_reportbtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("f");
            _nav.LoadSalesReportUC();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            sidebtncontrols("g");
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "LOGOUT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }

        }
        private void sidebtncontrols(string btn)
        {
            if (btn == "a")
            {
                overviewbtn.Checked = true;
                inventorybtn.Checked = false;
                historybtn.Checked = false;
                changebtn.Checked = false;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = false;
            }
            else if (btn == "b")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = true;
                historybtn.Checked = false;
                changebtn.Checked = false;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = false;
            }
            else if (btn == "c")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = false;
                historybtn.Checked = true;
                changebtn.Checked = false;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = false;
            }
            else if (btn == "d")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = false;
                historybtn.Checked = false;
                changebtn.Checked = true;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = false;
            }
            else if (btn == "e")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = false;
                historybtn.Checked = false;
                changebtn.Checked = false;
                manage_usersbtn.Checked = true;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = false;
            }
            else if (btn == "f")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = false;
                historybtn.Checked = false;
                changebtn.Checked = false;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = true;
                logoutbtn.Checked = false;
            }
            else if (btn == "g")
            {
                overviewbtn.Checked = false;
                inventorybtn.Checked = false;
                historybtn.Checked = false;
                changebtn.Checked = false;
                manage_usersbtn.Checked = false;
                sales_reportbtn.Checked = false;
                logoutbtn.Checked = true;
            }
        } //for menu panel on left side of the form
    }
}
