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
    public partial class addadmin : Form
    {
        public static string constr = "datasource =  localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        MySqlConnection con = new MySqlConnection(constr);
        private readonly AdminForm adminfrmm;
        public addadmin(AdminForm addadmin)
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            adminfrmm = addadmin;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (((afirst.Text == "") || (amiddle.Text == "") || (alast.Text == "") || (auser.Text == "") || (apass.Text == "")))
            {
                if (afirst.Text == "")
                {
                    MessageBox.Show("Input First name!");
                    return;
                }
                if (amiddle.Text == "")
                {
                    MessageBox.Show("Input Middle name!");
                    return;

                }
                if (alast.Text == "")
                {
                    MessageBox.Show("Input Last name!");
                    return;
                }
                if (auser.Text == "")
                {
                    MessageBox.Show("Input User name!");
                    return;
                }
                if (apass.Text == "")
                {
                    MessageBox.Show("Input Password!");
                }
            }
            else
            {
                if (apass.Text.Count() <= 7)
                {
                    MessageBox.Show("Password must be atleast 8 characters long!");
                }
                else
                {
                    try
                    {
                        string a = "admin";
                        con.Open();
                        string sqlstatement = "insert into exam_system1.accounts(userid,userpass,firstname,middlename,lastname,position,grade,section)values(@userid,@userpass,@firstname,@middlename,@lastname,@position,@grade,@section)";

                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                        cmd.Parameters.AddWithValue("@userid", auser.Text);
                        cmd.Parameters.AddWithValue("@userpass", Class1.encrypt(apass.Text));
                        cmd.Parameters.AddWithValue("@firstname", afirst.Text);
                        cmd.Parameters.AddWithValue("@middlename", amiddle.Text);
                        cmd.Parameters.AddWithValue("@lastname", alast.Text);
                        cmd.Parameters.AddWithValue("@position", a);
                        cmd.Parameters.AddWithValue("@grade", null);
                        cmd.Parameters.AddWithValue("@section", null);



                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Successfully added" + afirst.Text + " " + amiddle.Text + " " + alast.Text);
                        adminfrmm.reloadadmin();
                        this.Hide();
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

            }
        }

        private void addadmin_Load(object sender, EventArgs e)
        {

        }

        private void aafirst_Click(object sender, EventArgs e)
        {

        }
    }
}
