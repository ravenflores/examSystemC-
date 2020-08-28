namespace FormLogin
{
    partial class teachersettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(teachersettings));
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button18 = new System.Windows.Forms.Button();
            this.updatetpicture = new System.Windows.Forms.PictureBox();
            this.updatetpass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tea = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatetpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(79, 295);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(145, 23);
            this.materialRaisedButton2.TabIndex = 26;
            this.materialRaisedButton2.Text = "CANCEL";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(299, 295);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(156, 23);
            this.materialRaisedButton1.TabIndex = 25;
            this.materialRaisedButton1.Text = "SAVE";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Controls.Add(this.updatetpicture);
            this.groupBox1.Controls.Add(this.updatetpass);
            this.groupBox1.Controls.Add(this.tea);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(79, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 124);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // button18
            // 
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.Image = ((System.Drawing.Image)(resources.GetObject("button18.Image")));
            this.button18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button18.Location = new System.Drawing.Point(97, 45);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(30, 25);
            this.button18.TabIndex = 13;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // updatetpicture
            // 
            this.updatetpicture.Image = ((System.Drawing.Image)(resources.GetObject("updatetpicture.Image")));
            this.updatetpicture.Location = new System.Drawing.Point(18, 35);
            this.updatetpicture.Name = "updatetpicture";
            this.updatetpicture.Size = new System.Drawing.Size(73, 75);
            this.updatetpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.updatetpicture.TabIndex = 12;
            this.updatetpicture.TabStop = false;
            // 
            // updatetpass
            // 
            this.updatetpass.BackColor = System.Drawing.Color.White;
            this.updatetpass.Depth = 0;
            this.updatetpass.ForeColor = System.Drawing.Color.White;
            this.updatetpass.Hint = "Password";
            this.updatetpass.Location = new System.Drawing.Point(240, 78);
            this.updatetpass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updatetpass.MouseState = MaterialSkin.MouseState.HOVER;
            this.updatetpass.Name = "updatetpass";
            this.updatetpass.PasswordChar = '\0';
            this.updatetpass.SelectedText = "";
            this.updatetpass.SelectionLength = 0;
            this.updatetpass.SelectionStart = 0;
            this.updatetpass.Size = new System.Drawing.Size(102, 23);
            this.updatetpass.TabIndex = 10;
            this.updatetpass.UseSystemPasswordChar = false;
            // 
            // tea
            // 
            this.tea.BackColor = System.Drawing.Color.White;
            this.tea.Depth = 0;
            this.tea.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tea.ForeColor = System.Drawing.Color.White;
            this.tea.Hint = "Username";
            this.tea.Location = new System.Drawing.Point(240, 45);
            this.tea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tea.MouseState = MaterialSkin.MouseState.HOVER;
            this.tea.Name = "tea";
            this.tea.PasswordChar = '\0';
            this.tea.SelectedText = "";
            this.tea.SelectionLength = 0;
            this.tea.SelectionStart = 0;
            this.tea.Size = new System.Drawing.Size(102, 23);
            this.tea.TabIndex = 6;
            this.tea.UseSystemPasswordChar = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(6, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 16);
            this.label17.TabIndex = 11;
            this.label17.Text = "Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(161, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(159, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Username:";
            // 
            // teachersettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(531, 363);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "teachersettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.teachersettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatetpicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.PictureBox updatetpicture;
        private MaterialSkin.Controls.MaterialSingleLineTextField updatetpass;
        private MaterialSkin.Controls.MaterialSingleLineTextField tea;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
    }
}