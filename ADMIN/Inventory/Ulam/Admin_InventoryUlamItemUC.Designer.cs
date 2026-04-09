namespace sizzlingeropos.Admin_Inventory.Ulam
{
    partial class Admin_InventoryUlamItemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_InventoryUlamItemUC));
            this.tbl_main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_itemDelete = new Guna.UI2.WinForms.Guna2Button();
            this.tbl_Top = new System.Windows.Forms.TableLayoutPanel();
            this.btn_itemEdit = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_itemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbl_price = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itemPriceValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_itemPriceText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbl_main.SuspendLayout();
            this.tbl_Top.SuspendLayout();
            this.tbl_price.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_main
            // 
            this.tbl_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.tbl_main.ColumnCount = 1;
            this.tbl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_main.Controls.Add(this.btn_itemDelete, 0, 2);
            this.tbl_main.Controls.Add(this.tbl_Top, 0, 0);
            this.tbl_main.Controls.Add(this.tbl_price, 0, 1);
            this.tbl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_main.Location = new System.Drawing.Point(0, 0);
            this.tbl_main.Name = "tbl_main";
            this.tbl_main.RowCount = 3;
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.4F));
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.4F));
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.2F));
            this.tbl_main.Size = new System.Drawing.Size(125, 125);
            this.tbl_main.TabIndex = 0;
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
            this.btn_itemDelete.Location = new System.Drawing.Point(10, 88);
            this.btn_itemDelete.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.btn_itemDelete.Name = "btn_itemDelete";
            this.btn_itemDelete.Size = new System.Drawing.Size(105, 25);
            this.btn_itemDelete.TabIndex = 5;
            this.btn_itemDelete.Text = "Delete";
            this.btn_itemDelete.Click += new System.EventHandler(this.btn_itemDelete_Click);
            // 
            // tbl_Top
            // 
            this.tbl_Top.ColumnCount = 2;
            this.tbl_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.58823F));
            this.tbl_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
            this.tbl_Top.Controls.Add(this.btn_itemEdit, 1, 0);
            this.tbl_Top.Controls.Add(this.lbl_itemName, 0, 0);
            this.tbl_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Top.Location = new System.Drawing.Point(0, 0);
            this.tbl_Top.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_Top.Name = "tbl_Top";
            this.tbl_Top.RowCount = 1;
            this.tbl_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_Top.Size = new System.Drawing.Size(125, 38);
            this.tbl_Top.TabIndex = 0;
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
            this.btn_itemEdit.TabIndex = 2;
            this.btn_itemEdit.Click += new System.EventHandler(this.btn_itemEdit_Click);
            // 
            // lbl_itemName
            // 
            this.lbl_itemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.lbl_itemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_itemName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbl_itemName.Location = new System.Drawing.Point(3, 3);
            this.lbl_itemName.MaximumSize = new System.Drawing.Size(80, 0);
            this.lbl_itemName.Name = "lbl_itemName";
            this.lbl_itemName.Size = new System.Drawing.Size(80, 32);
            this.lbl_itemName.TabIndex = 1;
            this.lbl_itemName.Text = "Item Name";
            this.lbl_itemName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbl_price
            // 
            this.tbl_price.ColumnCount = 2;
            this.tbl_price.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.6F));
            this.tbl_price.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.4F));
            this.tbl_price.Controls.Add(this.lbl_itemPriceValue, 1, 0);
            this.tbl_price.Controls.Add(this.lbl_itemPriceText, 0, 0);
            this.tbl_price.Location = new System.Drawing.Point(0, 38);
            this.tbl_price.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_price.Name = "tbl_price";
            this.tbl_price.RowCount = 1;
            this.tbl_price.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_price.Size = new System.Drawing.Size(125, 38);
            this.tbl_price.TabIndex = 1;
            // 
            // lbl_itemPriceValue
            // 
            this.lbl_itemPriceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemPriceValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemPriceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemPriceValue.Location = new System.Drawing.Point(40, 20);
            this.lbl_itemPriceValue.Name = "lbl_itemPriceValue";
            this.lbl_itemPriceValue.Size = new System.Drawing.Size(34, 15);
            this.lbl_itemPriceValue.TabIndex = 2;
            this.lbl_itemPriceValue.Text = "[price]";
            // 
            // lbl_itemPriceText
            // 
            this.lbl_itemPriceText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_itemPriceText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itemPriceText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemPriceText.Location = new System.Drawing.Point(3, 20);
            this.lbl_itemPriceText.Name = "lbl_itemPriceText";
            this.lbl_itemPriceText.Size = new System.Drawing.Size(30, 15);
            this.lbl_itemPriceText.TabIndex = 1;
            this.lbl_itemPriceText.Text = "Price:";
            // 
            // Admin_InventoryUlamItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.tbl_main);
            this.Name = "Admin_InventoryUlamItemUC";
            this.Size = new System.Drawing.Size(125, 125);
            this.tbl_main.ResumeLayout(false);
            this.tbl_Top.ResumeLayout(false);
            this.tbl_Top.PerformLayout();
            this.tbl_price.ResumeLayout(false);
            this.tbl_price.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_main;
        private System.Windows.Forms.TableLayoutPanel tbl_Top;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemName;
        private Guna.UI2.WinForms.Guna2Button btn_itemEdit;
        private System.Windows.Forms.TableLayoutPanel tbl_price;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemPriceText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_itemPriceValue;
        private Guna.UI2.WinForms.Guna2Button btn_itemDelete;
    }
}
