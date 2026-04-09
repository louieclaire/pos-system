namespace sizzlingeropos
{
    partial class Admin_InventoryGroceriesItemUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_InventoryGroceriesItemUC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_itemDelete = new Guna.UI2.WinForms.Guna2Button();
            this.tbl_itemName = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_itemEdit = new Guna.UI2.WinForms.Guna2Button();
            this.tbl_itemPrice = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itemPriceText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_itemPriceValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbl_itemQty = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itemQtyValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_itemQtyText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_itemQtyMinus = new Guna.UI2.WinForms.Guna2Button();
            this.btn_itemQtyPlus = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbl_itemName.SuspendLayout();
            this.tbl_itemPrice.SuspendLayout();
            this.tbl_itemQty.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_itemDelete, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbl_itemName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbl_itemPrice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbl_itemQty, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(125, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_itemDelete
            // 
            this.btn_itemDelete.BorderRadius = 5;
            this.btn_itemDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_itemDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_itemDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_itemDelete.FillColor = System.Drawing.Color.Red;
            this.btn_itemDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_itemDelete.ForeColor = System.Drawing.Color.White;
            this.btn_itemDelete.Location = new System.Drawing.Point(10, 103);
            this.btn_itemDelete.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btn_itemDelete.Name = "btn_itemDelete";
            this.btn_itemDelete.Size = new System.Drawing.Size(105, 19);
            this.btn_itemDelete.TabIndex = 4;
            this.btn_itemDelete.Text = "Delete";
            this.btn_itemDelete.Click += new System.EventHandler(this.btn_itemDelete_Click);
            // 
            // tbl_itemName
            // 
            this.tbl_itemName.ColumnCount = 2;
            this.tbl_itemName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.6F));
            this.tbl_itemName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.4F));
            this.tbl_itemName.Controls.Add(this.lbl_itemName, 0, 0);
            this.tbl_itemName.Controls.Add(this.btn_itemEdit, 1, 0);
            this.tbl_itemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_itemName.Location = new System.Drawing.Point(0, 0);
            this.tbl_itemName.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_itemName.Name = "tbl_itemName";
            this.tbl_itemName.RowCount = 1;
            this.tbl_itemName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_itemName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_itemName.Size = new System.Drawing.Size(125, 38);
            this.tbl_itemName.TabIndex = 0;
            // 
            // lbl_itemName
            // 
            this.lbl_itemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.lbl_itemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_itemName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbl_itemName.Location = new System.Drawing.Point(3, 3);
            this.lbl_itemName.MaximumSize = new System.Drawing.Size(85, 0);
            this.lbl_itemName.Name = "lbl_itemName";
            this.lbl_itemName.Size = new System.Drawing.Size(85, 32);
            this.lbl_itemName.TabIndex = 0;
            this.lbl_itemName.Text = "Item Name";
            this.lbl_itemName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_itemEdit
            // 
            this.btn_itemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_itemEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_itemEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_itemEdit.FillColor = System.Drawing.Color.Transparent;
            this.btn_itemEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_itemEdit.ForeColor = System.Drawing.Color.White;
            this.btn_itemEdit.Image = ((System.Drawing.Image)(resources.GetObject("btn_itemEdit.Image")));
            this.btn_itemEdit.ImageSize = new System.Drawing.Size(30, 20);
            this.btn_itemEdit.Location = new System.Drawing.Point(100, 3);
            this.btn_itemEdit.Name = "btn_itemEdit";
            this.btn_itemEdit.Size = new System.Drawing.Size(22, 32);
            this.btn_itemEdit.TabIndex = 1;
            this.btn_itemEdit.Click += new System.EventHandler(this.btn_itemEdit_Click);
            // 
            // tbl_itemPrice
            // 
            this.tbl_itemPrice.ColumnCount = 2;
            this.tbl_itemPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.4F));
            this.tbl_itemPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.6F));
            this.tbl_itemPrice.Controls.Add(this.lbl_itemPriceText, 0, 0);
            this.tbl_itemPrice.Controls.Add(this.lbl_itemPriceValue, 1, 0);
            this.tbl_itemPrice.Location = new System.Drawing.Point(0, 38);
            this.tbl_itemPrice.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_itemPrice.Name = "tbl_itemPrice";
            this.tbl_itemPrice.RowCount = 1;
            this.tbl_itemPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_itemPrice.Size = new System.Drawing.Size(125, 18);
            this.tbl_itemPrice.TabIndex = 1;
            // 
            // lbl_itemPriceText
            // 
            this.lbl_itemPriceText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemPriceText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemPriceText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemPriceText.Location = new System.Drawing.Point(3, 3);
            this.lbl_itemPriceText.Name = "lbl_itemPriceText";
            this.lbl_itemPriceText.Size = new System.Drawing.Size(30, 12);
            this.lbl_itemPriceText.TabIndex = 0;
            this.lbl_itemPriceText.Text = "Price:";
            // 
            // lbl_itemPriceValue
            // 
            this.lbl_itemPriceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemPriceValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemPriceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemPriceValue.Location = new System.Drawing.Point(41, 3);
            this.lbl_itemPriceValue.Name = "lbl_itemPriceValue";
            this.lbl_itemPriceValue.Size = new System.Drawing.Size(34, 12);
            this.lbl_itemPriceValue.TabIndex = 1;
            this.lbl_itemPriceValue.Text = "[price]";
            // 
            // tbl_itemQty
            // 
            this.tbl_itemQty.ColumnCount = 2;
            this.tbl_itemQty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.6F));
            this.tbl_itemQty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.4F));
            this.tbl_itemQty.Controls.Add(this.lbl_itemQtyValue, 1, 0);
            this.tbl_itemQty.Controls.Add(this.lbl_itemQtyText, 0, 0);
            this.tbl_itemQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_itemQty.Location = new System.Drawing.Point(0, 56);
            this.tbl_itemQty.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_itemQty.Name = "tbl_itemQty";
            this.tbl_itemQty.RowCount = 1;
            this.tbl_itemQty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_itemQty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_itemQty.Size = new System.Drawing.Size(125, 20);
            this.tbl_itemQty.TabIndex = 2;
            // 
            // lbl_itemQtyValue
            // 
            this.lbl_itemQtyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemQtyValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemQtyValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemQtyValue.Location = new System.Drawing.Point(60, 3);
            this.lbl_itemQtyValue.Name = "lbl_itemQtyValue";
            this.lbl_itemQtyValue.Size = new System.Drawing.Size(50, 14);
            this.lbl_itemQtyValue.TabIndex = 2;
            this.lbl_itemQtyValue.Text = "Quantity:";
            // 
            // lbl_itemQtyText
            // 
            this.lbl_itemQtyText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemQtyText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemQtyText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemQtyText.Location = new System.Drawing.Point(3, 3);
            this.lbl_itemQtyText.Name = "lbl_itemQtyText";
            this.lbl_itemQtyText.Size = new System.Drawing.Size(50, 14);
            this.lbl_itemQtyText.TabIndex = 1;
            this.lbl_itemQtyText.Text = "Quantity:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_itemQtyMinus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_itemQtyPlus, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(125, 24);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btn_itemQtyMinus
            // 
            this.btn_itemQtyMinus.BorderRadius = 5;
            this.btn_itemQtyMinus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemQtyMinus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemQtyMinus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_itemQtyMinus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_itemQtyMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_itemQtyMinus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(217)))), ((int)(((byte)(87)))));
            this.btn_itemQtyMinus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_itemQtyMinus.ForeColor = System.Drawing.Color.White;
            this.btn_itemQtyMinus.Location = new System.Drawing.Point(10, 3);
            this.btn_itemQtyMinus.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btn_itemQtyMinus.Name = "btn_itemQtyMinus";
            this.btn_itemQtyMinus.Size = new System.Drawing.Size(42, 18);
            this.btn_itemQtyMinus.TabIndex = 0;
            this.btn_itemQtyMinus.Text = "-";
            this.btn_itemQtyMinus.Click += new System.EventHandler(this.btn_itemQtyMinus_Click);
            // 
            // btn_itemQtyPlus
            // 
            this.btn_itemQtyPlus.BorderRadius = 5;
            this.btn_itemQtyPlus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemQtyPlus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_itemQtyPlus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_itemQtyPlus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_itemQtyPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_itemQtyPlus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(217)))), ((int)(((byte)(87)))));
            this.btn_itemQtyPlus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_itemQtyPlus.ForeColor = System.Drawing.Color.White;
            this.btn_itemQtyPlus.Location = new System.Drawing.Point(72, 3);
            this.btn_itemQtyPlus.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btn_itemQtyPlus.Name = "btn_itemQtyPlus";
            this.btn_itemQtyPlus.Size = new System.Drawing.Size(43, 18);
            this.btn_itemQtyPlus.TabIndex = 1;
            this.btn_itemQtyPlus.Text = "+";
            this.btn_itemQtyPlus.Click += new System.EventHandler(this.btn_itemQtyPlus_Click);
            // 
            // Admin_InventoryGroceriesItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Admin_InventoryGroceriesItemUC";
            this.Size = new System.Drawing.Size(125, 125);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbl_itemName.ResumeLayout(false);
            this.tbl_itemName.PerformLayout();
            this.tbl_itemPrice.ResumeLayout(false);
            this.tbl_itemPrice.PerformLayout();
            this.tbl_itemQty.ResumeLayout(false);
            this.tbl_itemQty.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tbl_itemName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemName;
        private Guna.UI2.WinForms.Guna2Button btn_itemEdit;
        private System.Windows.Forms.TableLayoutPanel tbl_itemPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemPriceText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemPriceValue;
        private System.Windows.Forms.TableLayoutPanel tbl_itemQty;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemQtyText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btn_itemDelete;
        private Guna.UI2.WinForms.Guna2Button btn_itemQtyMinus;
        private Guna.UI2.WinForms.Guna2Button btn_itemQtyPlus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemQtyValue;
    }
}
