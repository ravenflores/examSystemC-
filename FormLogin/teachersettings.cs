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
  
    public partial class teachersettings : Form
    {
        public static string constr = "datasource =  localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        MySqlConnection con = new MySqlConnection(constr);
        string currentuser;
        string currentpass;
        string picturelocation;
        Form fr;
        public teachersettings(string user,string pass,Form a)
        {
            InitializeComponent();
            currentuser = user;
            currentpass = pass;
            this.TransparencyKey = (BackColor);
            fr = a;
          
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void teachersettings_Load(object sender, EventArgs e)
        {

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, updatetpicture.Width - 3, updatetpicture.Height - 3);
            Region rg = new Region(gp);
            updatetpicture.Region = rg;

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if ((tea.Text == "") || (updatetpass.Text == ""))
            {
                if (tea.Text == "")
                {
                    MessageBox.Show("Input Username!");
                    return;
                }
                if (updatetpass.Text == "")
                {
                    MessageBox.Show("Input Password!");
                }
            }
            else
            {


                try
                {
                    con.Open();
                    string sqlstatement4 = "update accounts  set userid = @userid, userpass = @userpass, picture = @teacherpicture where userid = @currentuserid AND userpass = @currentuserpass";

                    MySqlCommand cmd = new MySqlCommand(sqlstatement4, con);
                    cmd.Parameters.AddWithValue("@currentuserid", currentuser);
                    cmd.Parameters.AddWithValue("@currentuserpass", currentpass);
                    cmd.Parameters.AddWithValue("@userid", tea.Text);
                    cmd.Parameters.AddWithValue("@userpass", Class1.encrypt(updatetpass.Text));
                    cmd.Parameters.AddWithValue("@teacherpicture", picturelocation);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated!!");
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

        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            if (op1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picturelocation = op1.FileName;
                updatetpicture.ImageLocation = picturelocation;


            }
        }
    }
}
