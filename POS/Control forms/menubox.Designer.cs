namespace sizzlingeropos
{
    partial class menubox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenubox = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblprice = new System.Windows.Forms.Label();
            this.picboxMenu = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).BeginInit();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnMenubox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 178);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnMenubox
            // 
            this.btnMenubox.BorderRadius = 10;
            this.btnMenubox.CustomizableEdges.TopLeft = false;
            this.btnMenubox.CustomizableEdges.TopRight = false;
            this.btnMenubox.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenubox.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenubox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenubox.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenubox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenubox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenubox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(169)))), ((int)(((byte)(68)))));
            this.btnMenubox.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnMenubox.FocusedColor = System.Drawing.Color.Transparent;
            this.btnMenubox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenubox.ForeColor = System.Drawing.Color.White;
            this.btnMenubox.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnMenubox.Location = new System.Drawing.Point(5, 122);
            this.btnMenubox.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenubox.Name = "btnMenubox";
            this.btnMenubox.Size = new System.Drawing.Size(149, 51);
            this.btnMenubox.TabIndex = 1;
            this.btnMenubox.Text = "php";
            this.btnMenubox.Click += new System.EventHandler(this.btnMenubox_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblprice);
            this.guna2Panel1.Controls.Add(this.picboxMenu);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(5, 5);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(149, 117);
            this.guna2Panel1.TabIndex = 2;
            // 
            // lblprice
            // 
            this.lblprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblprice.Location = new System.Drawing.Point(102, 96);
            this.lblprice.Margin = new System.Windows.Forms.Padding(3);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(35, 18);
            this.lblprice.TabIndex = 0;
            this.lblprice.Text = "100";
            this.lblprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picboxMenu
            // 
            this.picboxMenu.BorderRadius = 15;
            this.picboxMenu.CustomizableEdges.BottomLeft = false;
            this.picboxMenu.CustomizableEdges.BottomRight = false;
            this.picboxMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxMenu.FillColor = System.Drawing.Color.Transparent;
            this.picboxMenu.Image = global::sizzlingeropos.Properties.Resources.sisg;
            this.picboxMenu.ImageRotate = 0F;
            this.picboxMenu.Location = new System.Drawing.Point(0, 0);
            this.picboxMenu.Margin = new System.Windows.Forms.Padding(7, 7, 7, 0);
            this.picboxMenu.Name = "picboxMenu";
            this.picboxMenu.Size = new System.Drawing.Size(149, 117);
            this.picboxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxMenu.TabIndex = 0;
            this.picboxMenu.TabStop = false;
            this.picboxMenu.Click += new System.EventHandler(this.picboxMenu_Click);
            // 
            // pnlBorder
            // 
            this.pnlBorder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.pnlBorder.BorderRadius = 7;
            this.pnlBorder.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.pnlBorder.Controls.Add(this.tableLayoutPanel1);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new System.Drawing.Size(159, 178);
            this.pnlBorder.TabIndex = 1;
            // 
            // menubox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "menubox";
            this.Size = new System.Drawing.Size(159, 178);
            this.Click += new System.EventHandler(this.menubox_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).EndInit();
            this.pnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox picboxMenu;
        private Guna.UI2.WinForms.Guna2GradientButton btnMenubox;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblprice;
        private Guna.UI2.WinForms.Guna2Panel pnlBorder;
    }
}
