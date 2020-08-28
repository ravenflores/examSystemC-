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
    public partial class LoginForm : Form
    {
        public static string constr = "server=localhost;username=root;password=1234admin;port=3306;database=exam_system1;";
        MySqlConnection con = new MySqlConnection(constr);
        public LoginForm()
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            this.AcceptButton = this.button1;

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enter();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            enter();
        }

        public  void enter(){
            if (((txtUsername.Text != "") && (txtPass.Text != "")))
            {

                try
                {
                    con.Close();             
                    con.Open();
                    string sqlstatement = "select position from accounts where userid = @user AND userpass = @pass";
                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);


                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                  
                    cmd.Parameters.AddWithValue("@pass", Class1.encrypt(txtPass.Text));
                    string a = Convert.ToString(cmd.ExecuteScalar());
                    
                    cmd.Dispose();


                    if (a == "teacher")
                    {
                        InstructorForm frm1 = new InstructorForm(txtUsername.Text, Class1.encrypt(txtPass.Text));
                        frm1.Tag = txtUsername.Text;

                        frm1.Show();
                        this.Hide();
                    }
                    else if (a == "student")
                    {
                        StudentForm frm8 = new StudentForm(txtUsername.Text, txtPass.Text);
                        frm8.Tag = txtUsername.Text;
                        frm8.Show();
                        this.Hide();
                        Console.WriteLine("login" + txtUsername.Text + txtPass.Text);

                    }

                    else if (a == "admin")
                    {
                        AdminForm frm7 = new AdminForm(txtUsername.Text, Class1.encrypt(txtPass.Text));

                        frm7.Tag = txtUsername.Text;
                        frm7.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form3 f3 = new Form3("user doesn't exist");
                        f3.Show();
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Form3 f3 = new Form3("Empty Fields are not allowed");
                f3.Show();
            }
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, EventArgs e)
        {
           
        }

       

        private void txtPass_KeyDown(object sender, EventArgs e)
        {
        
        }

        private void txtPass_KeyPress(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPass_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            enter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enter();
        }
    }
}
