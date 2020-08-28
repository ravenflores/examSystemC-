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
    public partial class addclass : Form
    {
        public static string constr = "datasource = localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        MySqlConnection con = new MySqlConnection(constr);
        private readonly AdminForm adminfrmm;
        public addclass(AdminForm addclas)
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            adminfrmm = addclas;
        }

        private void addclass_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if ((cname.Text == "") || (cgrade.Text == ""))
            {
                if (cname.Text == "")
                {
                    MessageBox.Show("Input class name!");
                    return;
                }
                if (cgrade.Text == "")
                {
                    MessageBox.Show("Input class grade!");

                }
            }
            else
            {
                try
                {
                    con.Open();
                    string sqlstatement = "insert into class(grade,section)values(@grade,@section)";
                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                    cmd.Parameters.AddWithValue("@grade", cgrade.Text);
                    cmd.Parameters.AddWithValue("@section", cname.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }


                adminfrmm.reloadclass();
                this.Hide();


            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
