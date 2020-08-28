namespace FormLogin
{
    partial class settings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.updateapicture = new System.Windows.Forms.PictureBox();
            this.updateapass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.updateauser = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.updateapicture)).BeginInit();
            this.SuspendLayout();
            // 
            // updateapicture
            // 
            this.updateapicture.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.updateapicture.Image = ((System.Drawing.Image)(resources.GetObject("updateapicture.Image")));
            this.updateapicture.Location = new System.Drawing.Point(118, 159);
            this.updateapicture.Name = "updateapicture";
            this.updateapicture.Size = new System.Drawing.Size(124, 132);
            this.updateapicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.updateapicture.TabIndex = 12;
            this.updateapicture.TabStop = false;
            this.updateapicture.Click += new System.EventHandler(this.updateapicture_Click);
            // 
            // updateapass
            // 
            this.updateapass.BackColor = System.Drawing.SystemColors.Control;
            this.updateapass.Depth = 0;
            this.updateapass.ForeColor = System.Drawing.Color.White;
            this.updateapass.Hint = "New Password";
            this.updateapass.Location = new System.Drawing.Point(339, 250);
            this.updateapass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateapass.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateapass.Name = "updateapass";
            this.updateapass.PasswordChar = '\0';
            this.updateapass.SelectedText = "";
            this.updateapass.SelectionLength = 0;
            this.updateapass.SelectionStart = 0;
            this.updateapass.Size = new System.Drawing.Size(153, 23);
            this.updateapass.TabIndex = 10;
            this.updateapass.UseSystemPasswordChar = false;
            // 
            // updateauser
            // 
            this.updateauser.BackColor = System.Drawing.SystemColors.Control;
            this.updateauser.Depth = 0;
            this.updateauser.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateauser.ForeColor = System.Drawing.Color.White;
            this.updateauser.Hint = "New Username";
            this.updateauser.Location = new System.Drawing.Point(339, 211);
            this.updateauser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateauser.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateauser.Name = "updateauser";
            this.updateauser.PasswordChar = '\0';
            this.updateauser.SelectedText = "";
            this.updateauser.SelectionLength = 0;
            this.updateauser.SelectionStart = 0;
            this.updateauser.Size = new System.Drawing.Size(153, 23);
            this.updateauser.TabIndex = 6;
            this.updateauser.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(260, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(258, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Username:";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(371, 407);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(121, 39);
            this.materialRaisedButton1.TabIndex = 22;
            this.materialRaisedButton1.Text = "SAVE";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(245, 407);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(120, 39);
            this.materialRaisedButton2.TabIndex = 23;
            this.materialRaisedButton2.Text = "CANCEL";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(615, 472);
            this.Controls.Add(this.updateauser);
            this.Controls.Add(this.updateapass);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.updateapicture);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "settings";
            this.Load += new System.EventHandler(this.settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updateapicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox updateapicture;
        private MaterialSkin.Controls.MaterialSingleLineTextField updateapass;
        private MaterialSkin.Controls.MaterialSingleLineTextField updateauser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}