namespace FormLogin
{
    partial class Create
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create));
            this.grp = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.ComboBox();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.label24 = new System.Windows.Forms.Label();
            this.add = new MaterialSkin.Controls.MaterialFlatButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtExamName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.nudHr = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.ssection = new System.Windows.Forms.ComboBox();
            this.sgrade = new System.Windows.Forms.ComboBox();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dte = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHr)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.subject);
            this.grp.Controls.Add(this.materialFlatButton2);
            this.grp.Controls.Add(this.label24);
            this.grp.Controls.Add(this.add);
            this.grp.Controls.Add(this.label17);
            this.grp.Controls.Add(this.label23);
            this.grp.Controls.Add(this.txtExamName);
            this.grp.Controls.Add(this.label22);
            this.grp.Controls.Add(this.label21);
            this.grp.Controls.Add(this.label20);
            this.grp.Controls.Add(this.nudMin);
            this.grp.Controls.Add(this.label19);
            this.grp.Controls.Add(this.nudHr);
            this.grp.Controls.Add(this.label18);
            this.grp.Controls.Add(this.ssection);
            this.grp.Controls.Add(this.sgrade);
            this.grp.Controls.Add(this.dtpExamDate);
            this.grp.Location = new System.Drawing.Point(1, 63);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(460, 235);
            this.grp.TabIndex = 77;
            this.grp.TabStop = false;
            this.grp.Enter += new System.EventHandler(this.grp_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(43, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Subject:";
            // 
            // subject
            // 
            this.subject.FormattingEnabled = true;
            this.subject.Items.AddRange(new object[] {
            "AP",
            "COMPUTER",
            "SCIENCE ",
            "MATH",
            "ENGLISH",
            "MAPEH",
            "FILIPINO",
            "ESP"});
            this.subject.Location = new System.Drawing.Point(110, 125);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(127, 21);
            this.subject.TabIndex = 89;
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(131, 196);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(60, 36);
            this.materialFlatButton2.TabIndex = 79;
            this.materialFlatButton2.Text = "DELETE";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(302, 154);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 20);
            this.label24.TabIndex = 84;
            this.label24.Text = "min(s)";
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.add.Depth = 0;
            this.add.Location = new System.Drawing.Point(84, 196);
            this.add.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.add.MouseState = MaterialSkin.MouseState.HOVER;
            this.add.Name = "add";
            this.add.Primary = false;
            this.add.Size = new System.Drawing.Size(39, 36);
            this.add.TabIndex = 78;
            this.add.Text = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(5, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 77;
            this.label17.Text = "Exam Name:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(172, 154);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 20);
            this.label23.TabIndex = 83;
            this.label23.Text = "hr(s)";
            // 
            // txtExamName
            // 
            this.txtExamName.Depth = 0;
            this.txtExamName.Hint = "";
            this.txtExamName.Location = new System.Drawing.Point(110, 28);
            this.txtExamName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.PasswordChar = '\0';
            this.txtExamName.SelectedText = "";
            this.txtExamName.SelectionLength = 0;
            this.txtExamName.SelectionStart = 0;
            this.txtExamName.Size = new System.Drawing.Size(256, 23);
            this.txtExamName.TabIndex = 87;
            this.txtExamName.UseSystemPasswordChar = false;
            this.txtExamName.Click += new System.EventHandler(this.txtExamName_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(29, 153);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 20);
            this.label22.TabIndex = 82;
            this.label22.Text = "Duration:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(29, 203);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 20);
            this.label21.TabIndex = 81;
            this.label21.Text = "Parts:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(172, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 20);
            this.label20.TabIndex = 80;
            this.label20.Text = "Section:";
            // 
            // nudMin
            // 
            this.nudMin.Location = new System.Drawing.Point(239, 153);
            this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(60, 20);
            this.nudMin.TabIndex = 84;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(43, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 20);
            this.label19.TabIndex = 79;
            this.label19.Text = "Grade:";
            // 
            // nudHr
            // 
            this.nudHr.Location = new System.Drawing.Point(110, 153);
            this.nudHr.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudHr.Name = "nudHr";
            this.nudHr.Size = new System.Drawing.Size(60, 20);
            this.nudHr.TabIndex = 83;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(55, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 78;
            this.label18.Text = "Date:";
            // 
            // ssection
            // 
            this.ssection.FormattingEnabled = true;
            this.ssection.Items.AddRange(new object[] {
            "AP",
            "Computer",
            "science ",
            "math ",
            "english",
            "mapeh",
            "filipino",
            "esp"});
            this.ssection.Location = new System.Drawing.Point(239, 99);
            this.ssection.Name = "ssection";
            this.ssection.Size = new System.Drawing.Size(127, 21);
            this.ssection.TabIndex = 81;
            // 
            // sgrade
            // 
            this.sgrade.FormattingEnabled = true;
            this.sgrade.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.sgrade.Location = new System.Drawing.Point(110, 98);
            this.sgrade.Name = "sgrade";
            this.sgrade.Size = new System.Drawing.Size(60, 21);
            this.sgrade.TabIndex = 77;
            this.sgrade.SelectedIndexChanged += new System.EventHandler(this.sgrade_SelectedIndexChanged);
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.dtpExamDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExamDate.Location = new System.Drawing.Point(110, 64);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(256, 22);
            this.dtpExamDate.TabIndex = 75;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 298);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 387);
            this.flowLayoutPanel1.TabIndex = 78;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Location = new System.Drawing.Point(206, 694);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(62, 36);
            this.materialFlatButton3.TabIndex = 79;
            this.materialFlatButton3.Text = "Create";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.materialFlatButton3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dte);
            this.panel1.Controls.Add(this.button21);
            this.panel1.Location = new System.Drawing.Point(1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 61);
            this.panel1.TabIndex = 80;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(147, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 80;
            this.label2.Text = "CREATE EXAM";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(412, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 54);
            this.button1.TabIndex = 79;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dte
            // 
            this.dte.AutoSize = true;
            this.dte.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte.ForeColor = System.Drawing.Color.White;
            this.dte.Location = new System.Drawing.Point(493, 69);
            this.dte.Name = "dte";
            this.dte.Size = new System.Drawing.Size(44, 20);
            this.dte.TabIndex = 78;
            this.dte.Text = "Date";
            // 
            // button21
            // 
            this.button21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Image = ((System.Drawing.Image)(resources.GetObject("button21.Image")));
            this.button21.Location = new System.Drawing.Point(635, 3);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(47, 54);
            this.button21.TabIndex = 77;
            this.button21.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button21.UseVisualStyleBackColor = true;
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(460, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialFlatButton3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.grp);
            this.DoubleBuffered = true;
            this.Name = "Create";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "100";
            this.Text = "Create Exam";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHr)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtExamName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nudHr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox ssection;
        private System.Windows.Forms.ComboBox sgrade;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialFlatButton add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox subject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dte;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Label label2;
    }
}