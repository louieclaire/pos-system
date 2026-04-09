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
    public partial class orderlistbox : UserControl
    {
        public orderlistbox()
        {
            InitializeComponent();
        }

        public Data.MenuItemData OrderItemData { get; private set; }
        public string OrderItemName { get; private set; }
        public int quantity { get; private set; } = 1;

        public decimal iprice { get; private set; }

        public event EventHandler QuantityChanged;
        public event EventHandler ItemDeleted;


        public void AddItem(Data.MenuItemData item) {

            OrderItemData = item;
            OrderItemName = item.Name;
            lblName.Text = item.Name;
            lblPrice.Text = item.Price.ToString();
            picboxMenu.Image = item.Picture;
            txtboxCount.Text = quantity.ToString();
            
            iprice = item.Price;
        }

        public void IncrementQuantity()
        {
            quantity++;
            txtboxCount.Text = quantity.ToString();
            decimal itemtotalprice = quantity * iprice;

            lblPrice.Text = itemtotalprice.ToString();
            QuantityChanged?.Invoke(this, EventArgs.Empty);

        }

        public void DecrementQuantity()
        {
            if (quantity > 1) // optional: prevent negative or zero quantities
            {
                quantity--;
                txtboxCount.Text = quantity.ToString();
                decimal itemtotalprice = quantity * iprice;

                lblPrice.Text = itemtotalprice.ToString();
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IncrementQuantity();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            DecrementQuantity();
            
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            ItemDeleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
