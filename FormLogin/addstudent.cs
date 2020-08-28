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
    public partial class addstudent : Form
    {
        public static string a = "student";
        public static string constr = "datasource =  localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        MySqlConnection con = new MySqlConnection(constr);
        private readonly AdminForm adminfrmm;
        public addstudent(AdminForm addstud)
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            adminfrmm = addstud;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (((sfname.Text == "") || (smname.Text == "") || (slname.Text == "") || (suser.Text == "") || (spass.Text == "") || (grade.Text == "") || (section.Text == "")))
            {
                if (sfname.Text == "")
                {
                    MessageBox.Show("Input First name!");
                    return;
                }
                if (smname.Text == "")
                {
                    MessageBox.Show("Input Middle name!");
                    return;
                }
                if (slname.Text == "")
                {
                    MessageBox.Show("Input Last name!");
                    return;
                }
                if (grade.Text == "")
                {
                    MessageBox.Show("Input Student grade !");
                    return;
                }
                if (section.Text == "")
                {
                    MessageBox.Show("Input Student Section !");
                    return;
                }
                if (suser.Text == "")
                {
                    MessageBox.Show("Input Username name!");
                    return;
                }
                if (spass.Text == "")
                {
                    MessageBox.Show("Input Password name!");

                }

            }
            else
            {
                if (spass.Text.Count() <= 7)
                {
                    MessageBox.Show("Password must be atleast 8 characters long!");
                }
                else
                {
                    try
                    {
                        string d = "student";

                        con.Open();
                        string sqlstatement = "insert into exam_system1.accounts(userid,userpass,firstname,middlename,lastname,position,grade,section)values(@userid,@userpass,@firstname,@middlename,@lastname,@position,@grade,@section)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                        cmd.Parameters.AddWithValue("@userid", suser.Text);
                        cmd.Parameters.AddWithValue("@userpass", Class1.encrypt(spass.Text));

                        cmd.Parameters.AddWithValue("@firstname", sfname.Text);
                        cmd.Parameters.AddWithValue("@middlename", smname.Text);
                        cmd.Parameters.AddWithValue("@lastname", slname.Text);
                        cmd.Parameters.AddWithValue("@grade", grade.Text);
                        cmd.Parameters.AddWithValue("@section", section.Text);
                        cmd.Parameters.AddWithValue("@position", d);



                        cmd.ExecuteNonQuery();
                        MessageBox.Show(sfname.Text + " " + smname.Text + " " + slname.Text + "Successfully added");
                        adminfrmm.reloadstud();
                        this.Hide();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Input a valid ID!");
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
        }

        private void addstudent_Load(object sender, EventArgs e)
        {

        }

        private void grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            section.Items.Clear();
            con.Close();
            con.Open();
            string sql = string.Format(@"SELECT section FROM class WHERE grade='{0}'", grade.Text);
            MySqlCommand sqlcmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                section.Items.Add(dr.GetString("section"));
            }

            con.Close();
        }
    }
}
