using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos.ADMIN.History
{
    public partial class historyUC : UserControl
    {
        public historyUC()
        {
            InitializeComponent();

            HistoryPanel historyPanelUC = new HistoryPanel();
            ShowUserControl(historyPanelUC);
        }

        private void ShowUserControl(UserControl controlToShow)
        {
            pnl_history.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            pnl_history.Controls.Add(controlToShow);
            controlToShow.BringToFront();
        }
    }
}
