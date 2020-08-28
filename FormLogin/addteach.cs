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
    public partial class addteach : Form
    {
        public static string constr = "datasource =  localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        public static string constring = "server= localhostuser=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        MySqlConnection con = new MySqlConnection(constr);
        private readonly AdminForm adminfrm;
        public addteach(AdminForm addteach)
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            adminfrm = addteach;

        }

        private void addteach_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            if (((txtFname.Text == "") || (txtMname.Text == "") || (txtLname.Text == "") || (txtUsername.Text == "") || (txtPass.Text == "")))
            {
                if (txtFname.Text == "")
                {
                    MessageBox.Show("Input First name!");
                    return;
                }
                if (txtMname.Text == "")
                {
                    MessageBox.Show("Input Middle name!");
                    return;
                }
                if (txtLname.Text == "")
                {
                    MessageBox.Show("Input Last name!");
                    return;
                }
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Input Username!");
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Input Password!");
                }
            }
            else
            {
                if (txtPass.Text.Count() <= 7)
                {
                    MessageBox.Show("Password must be atleast 8 characters long!");

                }
                else
                {
                    try
                    {
                        string c = "teacher";
                        con.Open();
                        string sqlstatement = "insert into exam_system1.accounts(userid,userpass,firstname,middlename,lastname,position,grade,section)values(@userid,@userpass,@firstname,@middlename,@lastname,@position,@grade,@section)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                        cmd.Parameters.AddWithValue("@userid", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@userpass", Class1.encrypt(txtPass.Text));
                        cmd.Parameters.AddWithValue("@firstname", txtFname.Text);
                        cmd.Parameters.AddWithValue("@middlename", txtMname.Text);
                        cmd.Parameters.AddWithValue("@lastname", txtLname.Text);
                        cmd.Parameters.AddWithValue("@grade", null);
                        cmd.Parameters.AddWithValue("@section", null);
                        cmd.Parameters.AddWithValue("@position", c);

                        cmd.ExecuteNonQuery();




                        MessageBox.Show("Successfully added" + txtFname.Text + " " + txtMname.Text + " " + txtLname.Text);
                        adminfrm.reloadteach();
                        this.Hide();





                    }
                    catch
                    {
                        MessageBox.Show("Input a valid ID!");
                        txtUsername.Clear();
                    }
                    finally
                    {
                        con.Close();
                      

                    }


                }

                /*  AdminForm obj = (AdminForm)Application.OpenForms["AdminForm"];
                  obj.steach();
                  teacherlist.Update();
                  dtgSearchInst.Refresh();*/

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtMname_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtFname_Click(object sender, EventArgs e)
        {

        }

        private void txtLname_Click(object sender, EventArgs e)
        {

        }
    }
}

