using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos.ADMIN.Change
{
    public partial class changeUC : UserControl
    {
        public changeUC()
        {
            InitializeComponent();
            ChangePanel changeUC = new ChangePanel();
            ShowUserControl(changeUC);
        }
        private void ShowUserControl(UserControl controlToShow)
        {
            pnl_change.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            pnl_change.Controls.Add(controlToShow);
            controlToShow.BringToFront();
        }
    }
}
