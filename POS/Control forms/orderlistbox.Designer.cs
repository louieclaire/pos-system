namespace sizzlingeropos
{
    partial class orderlistbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(orderlistbox));
            this.pnlInside = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picboxMenu = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnDeleteItem = new Guna.UI2.WinForms.Guna2ImageButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtboxCount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinus = new Guna.UI2.WinForms.Guna2Button();
            this.tblpanelOne = new System.Windows.Forms.TableLayoutPanel();
            this.tblpnlTwo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tblpanelOne.SuspendLayout();
            this.tblpnlTwo.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInside
            // 
            this.pnlInside.BackColor = System.Drawing.Color.Transparent;
            this.pnlInside.BorderRadius = 15;
            this.pnlInside.Controls.Add(this.tblpnlTwo);
            this.pnlInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInside.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.pnlInside.Location = new System.Drawing.Point(3, 5);
            this.pnlInside.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlInside.Name = "pnlInside";
            this.pnlInside.Size = new System.Drawing.Size(344, 92);
            this.pnlInside.TabIndex = 0;
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPrice.Location = new System.Drawing.Point(3, 3);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 19);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "95 php";
            this.lblPrice.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblName.Location = new System.Drawing.Point(3, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 22);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Sisig";
            this.lblName.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // picboxMenu
            // 
            this.picboxMenu.BackColor = System.Drawing.Color.Transparent;
            this.picboxMenu.BorderRadius = 10;
            this.picboxMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxMenu.Image = global::sizzlingeropos.Properties.Resources.sisg;
            this.picboxMenu.ImageRotate = 0F;
            this.picboxMenu.Location = new System.Drawing.Point(7, 7);
            this.picboxMenu.Margin = new System.Windows.Forms.Padding(7);
            this.picboxMenu.Name = "picboxMenu";
            this.picboxMenu.Size = new System.Drawing.Size(86, 78);
            this.picboxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxMenu.TabIndex = 0;
            this.picboxMenu.TabStop = false;
            this.picboxMenu.UseTransparentBackground = true;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDeleteItem.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDeleteItem.ImageRotate = 0F;
            this.btnDeleteItem.ImageSize = new System.Drawing.Size(10, 10);
            this.btnDeleteItem.Location = new System.Drawing.Point(221, 3);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDeleteItem.Size = new System.Drawing.Size(14, 21);
            this.btnDeleteItem.TabIndex = 0;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.txtboxCount, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnAdd, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMinus, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(121, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(114, 37);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // txtboxCount
            // 
            this.txtboxCount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(96)))), ((int)(((byte)(42)))));
            this.txtboxCount.BorderRadius = 5;
            this.txtboxCount.BorderThickness = 3;
            this.txtboxCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxCount.DefaultText = "";
            this.txtboxCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtboxCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxCount.Location = new System.Drawing.Point(41, 3);
            this.txtboxCount.Name = "txtboxCount";
            this.txtboxCount.PlaceholderText = "";
            this.txtboxCount.ReadOnly = true;
            this.txtboxCount.SelectedText = "";
            this.txtboxCount.Size = new System.Drawing.Size(32, 31);
            this.txtboxCount.TabIndex = 2;
            this.txtboxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(96)))), ((int)(((byte)(42)))));
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.BorderThickness = 3;
            this.btnAdd.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(96)))), ((int)(((byte)(42)))));
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::sizzlingeropos.Properties.Resources.plusicon;
            this.btnAdd.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAdd.ImageSize = new System.Drawing.Size(19, 19);
            this.btnAdd.Location = new System.Drawing.Point(79, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = " ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(96)))), ((int)(((byte)(42)))));
            this.btnMinus.BorderRadius = 5;
            this.btnMinus.BorderThickness = 3;
            this.btnMinus.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(96)))), ((int)(((byte)(42)))));
            this.btnMinus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus.FillColor = System.Drawing.Color.Transparent;
            this.btnMinus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinus.ForeColor = System.Drawing.Color.White;
            this.btnMinus.Image = global::sizzlingeropos.Properties.Resources.minusicon;
            this.btnMinus.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnMinus.Location = new System.Drawing.Point(3, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(32, 31);
            this.btnMinus.TabIndex = 3;
            this.btnMinus.Text = " ";
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // tblpanelOne
            // 
            this.tblpanelOne.BackColor = System.Drawing.Color.Transparent;
            this.tblpanelOne.ColumnCount = 1;
            this.tblpanelOne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpanelOne.Controls.Add(this.pnlInside, 0, 0);
            this.tblpanelOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpanelOne.Location = new System.Drawing.Point(0, 0);
            this.tblpanelOne.Name = "tblpanelOne";
            this.tblpanelOne.RowCount = 1;
            this.tblpanelOne.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpanelOne.Size = new System.Drawing.Size(350, 100);
            this.tblpanelOne.TabIndex = 1;
            // 
            // tblpnlTwo
            // 
            this.tblpnlTwo.ColumnCount = 2;
            this.tblpnlTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblpnlTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpnlTwo.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tblpnlTwo.Controls.Add(this.picboxMenu, 0, 0);
            this.tblpnlTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlTwo.Location = new System.Drawing.Point(0, 0);
            this.tblpnlTwo.Name = "tblpnlTwo";
            this.tblpnlTwo.RowCount = 1;
            this.tblpnlTwo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpnlTwo.Size = new System.Drawing.Size(344, 92);
            this.tblpnlTwo.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(103, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(238, 86);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel7.Controls.Add(this.lblPrice, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(238, 43);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnDeleteItem, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(238, 43);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // orderlistbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tblpanelOne);
            this.Name = "orderlistbox";
            this.Size = new System.Drawing.Size(350, 100);
            this.pnlInside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tblpanelOne.ResumeLayout(false);
            this.tblpnlTwo.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlInside;
        private Guna.UI2.WinForms.Guna2PictureBox picboxMenu;
        private Guna.UI2.WinForms.Guna2ImageButton btnDeleteItem;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2Button btnMinus;
        private Guna.UI2.WinForms.Guna2TextBox txtboxCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPrice;
        private System.Windows.Forms.TableLayoutPanel tblpanelOne;
        private System.Windows.Forms.TableLayoutPanel tblpnlTwo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}
