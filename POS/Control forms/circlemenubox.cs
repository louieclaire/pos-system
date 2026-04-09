using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sizzlingeropos.POSform;

namespace sizzlingeropos
{
    public partial class circlemenubox : UserControl
    {
        public circlemenubox()
        {
            InitializeComponent();
        }
        public event EventHandler<Data.MenuItemData> ItemClicked;
        public string ItemName
        {
            get => btnName.Text;
            set => btnName.Text = value;
        }

        public decimal ItemPrice
        {
            get => decimal.Parse(lblPrice.Text.Replace("₱", ""));
            set => lblPrice.Text = "₱" + value.ToString("N2");
        }

        public Image ItemPicture
        {
            get => picboxCircle.Image;
            set => picboxCircle.Image = value;
        }
        public string ItemID { get; set; }
        public bool IsMeal { get; set; }

        private void btnName_Click(object sender, EventArgs e)
        {
       
            ItemClicked?.Invoke(this, new Data.MenuItemData
            {
                Id = ItemID,
                Name = ItemName,
                Price = ItemPrice,
                Picture = ItemPicture,
                IsMeal = IsMeal
            });
        }


        private void picboxCircle_Click(object sender, EventArgs e)
        {

        }
    }
}
