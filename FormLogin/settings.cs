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
    public partial class settings : Form
    {
        public static string constr = "datasource =  localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        MySqlConnection con = new MySqlConnection(constr);
        string username;
        string userpass;
        string picturelocation;
        public settings(string user , string pass)
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            username = user;
            userpass = pass;
        }

        private void settings_Load(object sender, EventArgs e)
        {
            updateapicture.ImageLocation = picturelocation;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, updateapicture.Width - 3, updateapicture.Height - 3);
            Region rg = new Region(gp);
            updateapicture.Region = rg;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if ((updateauser.Text == "") || (updateapass.Text == ""))
            {
                if (updateauser.Text == "")
                {
                    MessageBox.Show("Input New Username!");
                    return;
                }
                if (updateapass.Text == "")
                {
                    MessageBox.Show("Input New Password!");
                }
            }
            else
            {
                try
                {
                    con.Open();
                    string sqlstatement4 = "update accounts  set userid = @userid, userpass = @userpass,picture = @adminpicture where userid = @currentuserid AND userpass = @currentuserpass";

                    MySqlCommand cmd = new MySqlCommand(sqlstatement4, con);
                    cmd.Parameters.AddWithValue("@currentuserid", username);
                    cmd.Parameters.AddWithValue("@currentuserpass", userpass);
                    cmd.Parameters.AddWithValue("@userid", updateauser.Text);
                    cmd.Parameters.AddWithValue("@userpass", Class1.encrypt(updateapass.Text));
                    cmd.Parameters.AddWithValue("@adminpicture", picturelocation);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfullu updated!!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
                this.Hide();

            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            if (op1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picturelocation = op1.FileName;
                updateapicture.ImageLocation = picturelocation;
                

            }
        }

        private void updateapicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            if (op1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picturelocation = op1.FileName;
                updateapicture.ImageLocation = picturelocation;


            }
        }
    }
}
 