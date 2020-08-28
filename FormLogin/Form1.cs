using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace FormLogin
{
    public partial class Form1 : Form
    {
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
             con1.Open();

             string sqlstatement1 = "select userid,firstname,middlename,lastname,grade,section from accounts where position = 'student'";
             MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con1);
             DataSet dt1 = new DataSet();
             adpt1.Fill(dt1, "accounts");
             grid.DataSource = dt1;
             grid.DataMember = "accounts";
             con1.Close();

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            tabControl1.SelectTab(0);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Height = button2.Height;
            panel2.Top = button2.Top;
            tabControl1.SelectTab(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Height = button3.Height;
            panel2.Top = button3.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Height = button4.Height;
            panel2.Top = button4.Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Height = button5.Height;
            panel2.Top = button5.Top;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
