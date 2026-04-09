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
    public partial class menubox : UserControl
    {
        public menubox()
        {
            InitializeComponent();
          
            this.Margin = new Padding(15);

            picboxMenu.Click += picboxMenu_Click;

        }
        public bool IsSelected { get; set; } = true;

       
        public event EventHandler<Data.MenuItemData> ItemClicked;
        public event EventHandler MenuboxClicked;

        public string ItemName
        {
            get => btnMenubox.Text;
            set => btnMenubox.Text = value;
        }

        public decimal ItemPrice
        {
            get => decimal.Parse(lblprice.Text.Replace("₱", ""));
            set => lblprice.Text = "₱" + value.ToString("N2");
        }

        public Image ItemPicture
        {
            get => picboxMenu.Image;
            set => picboxMenu.Image = value;
        }

        public string ItemID { get; set; }     
        public bool IsMeal { get; set; }

     


        private void picboxMenu_Click(object sender, EventArgs e)
        {
            this.Focus();
            SetSelected(!IsSelected);
            MenuboxClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetSelected(bool selected)
        {
            IsSelected = selected;
            if (IsSelected == true)
            {
                
                pnlBorder.BorderThickness = 3;
               
            }
            else 
            {
                pnlBorder.BorderThickness = 0;
               
            }
        }


        //button to para sa pagtake ng orders
        private void btnMenubox_Click(object sender, EventArgs e)
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

        
        private void menubox_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
