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
    public partial class ControlSearchResult : UserControl
    {
        public ControlSearchResult()
        {
            InitializeComponent();
        }

        public void details(Data.MenuItemData d)
        {
            lblSName.Text = d.Name;
            lblSPrice.Text = d.Price.ToString();
            picboxMenu.Image = d.Picture;

        }

        public void searchresult(string key)
        {
            Data get = new Data();
            Data.MenuItemData d = new Data.MenuItemData();
            get.search(key);
            lblSName.Text = d.Name;
            lblSPrice.Text = d.Price.ToString();
            picboxMenu.Image = d.Picture;
            

        }
        private void lblSName_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
