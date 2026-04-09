namespace sizzlingeropos
{
    partial class ControlSearchResult
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
            this.picboxMenu = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSName = new System.Windows.Forms.Label();
            this.lblSPrice = new System.Windows.Forms.Label();
            this.pnlSOne = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlSOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // picboxMenu
            // 
            this.picboxMenu.BackColor = System.Drawing.Color.Transparent;
            this.picboxMenu.BorderRadius = 5;
            this.picboxMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxMenu.FillColor = System.Drawing.Color.Black;
            this.picboxMenu.Image = global::sizzlingeropos.Properties.Resources.sisg;
            this.picboxMenu.ImageRotate = 0F;
            this.picboxMenu.Location = new System.Drawing.Point(5, 3);
            this.picboxMenu.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.picboxMenu.Name = "picboxMenu";
            this.picboxMenu.Size = new System.Drawing.Size(70, 65);
            this.picboxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxMenu.TabIndex = 0;
            this.picboxMenu.TabStop = false;
            this.picboxMenu.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.picboxMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 71);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblSName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSPrice, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(80, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(236, 71);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblSName
            // 
            this.lblSName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSName.AutoSize = true;
            this.lblSName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSName.Location = new System.Drawing.Point(3, 14);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(109, 21);
            this.lblSName.TabIndex = 0;
            this.lblSName.Text = "Sizzling Item";
            this.lblSName.Click += new System.EventHandler(this.lblSName_Click);
            // 
            // lblSPrice
            // 
            this.lblSPrice.AutoSize = true;
            this.lblSPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPrice.Location = new System.Drawing.Point(3, 37);
            this.lblSPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.lblSPrice.Name = "lblSPrice";
            this.lblSPrice.Size = new System.Drawing.Size(45, 16);
            this.lblSPrice.TabIndex = 1;
            this.lblSPrice.Text = "100.00";
            // 
            // pnlSOne
            // 
            this.pnlSOne.BorderRadius = 10;
            this.pnlSOne.Controls.Add(this.tableLayoutPanel1);
            this.pnlSOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSOne.FillColor = System.Drawing.Color.Transparent;
            this.pnlSOne.Location = new System.Drawing.Point(0, 0);
            this.pnlSOne.Name = "pnlSOne";
            this.pnlSOne.Size = new System.Drawing.Size(316, 71);
            this.pnlSOne.TabIndex = 2;
            // 
            // ControlSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlSOne);
            this.Name = "ControlSearchResult";
            this.Size = new System.Drawing.Size(316, 71);
            ((System.ComponentModel.ISupportInitialize)(this.picboxMenu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlSOne.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picboxMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.Label lblSPrice;
        private Guna.UI2.WinForms.Guna2Panel pnlSOne;
    }
}
