namespace sizzlingeropos
{
    partial class circlemenubox
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnName = new Guna.UI2.WinForms.Guna2GradientButton();
            this.picboxCircle = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblPrice);
            this.guna2Panel1.Controls.Add(this.btnName);
            this.guna2Panel1.Controls.Add(this.picboxCircle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(141, 126);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnName
            // 
            this.btnName.BorderRadius = 15;
            this.btnName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnName.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(110)))), ((int)(((byte)(61)))));
            this.btnName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(169)))), ((int)(((byte)(68)))));
            this.btnName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnName.ForeColor = System.Drawing.Color.White;
            this.btnName.Location = new System.Drawing.Point(0, 100);
            this.btnName.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(141, 26);
            this.btnName.TabIndex = 1;
            this.btnName.Text = "Full cup rice";
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // picboxCircle
            // 
            this.picboxCircle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxCircle.Image = global::sizzlingeropos.Properties.Resources.rice;
            this.picboxCircle.ImageRotate = 0F;
            this.picboxCircle.Location = new System.Drawing.Point(0, 0);
            this.picboxCircle.Name = "picboxCircle";
            this.picboxCircle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picboxCircle.Size = new System.Drawing.Size(141, 126);
            this.picboxCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxCircle.TabIndex = 0;
            this.picboxCircle.TabStop = false;
            this.picboxCircle.Click += new System.EventHandler(this.picboxCircle_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPrice.Location = new System.Drawing.Point(0, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(141, 18);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "100.00";
            // 
            // circlemenubox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "circlemenubox";
            this.Size = new System.Drawing.Size(141, 126);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCircle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picboxCircle;
        private Guna.UI2.WinForms.Guna2GradientButton btnName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPrice;
    }
}
