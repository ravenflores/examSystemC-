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
using System.IO;
namespace FormLogin
{
    public partial class Form4 : MaterialSkin.Controls.MaterialForm
    {
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring2);
        public static string filename;
        MultipleSlidingPAnel o1;
        string currentuser;
        string currentpass;
        public Form4(string txt1, string user, string pass)
        {
          
            InitializeComponent();
            Text = txt1;
            currentuser = user;
            Console.WriteLine("dur" + currentuser);
            currentpass = pass;
            generate();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public void generate()
        {
            Console.WriteLine("dur" + this.Text);
            con.Close();
            con.Open();
            string gex = "SELECT col_exam_name FROM tbl_exam where col_exam_id = @exam_id";
            MySqlCommand gexcmd = new MySqlCommand(gex, con);
            gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string exn = Convert.ToString(gexcmd.ExecuteScalar());
            Console.WriteLine(exn + "exam name");
            label3.Text = exn;


       


            try
            {
                con.Close();
                con.Open();
                string cntsqlstatement = "select stud_id from student_records";
                MySqlCommand cmd = new MySqlCommand(cntsqlstatement, con);
                MySqlDataReader dr = cmd.ExecuteReader();






                MemoryStream ms = new MemoryStream();

                if (dr.HasRows == true)
                {
               
                    con.Close();
                    con.Open();

                    string examsqlstatement = "select COUNT(distinct stud_id ) from student_records";
                    MySqlCommand examcmd = new MySqlCommand(examsqlstatement, con);
                    int parts = Convert.ToInt32(examcmd.ExecuteScalar());
                    examcmd.Dispose();


                    Console.WriteLine(exn + "gumana name");
                    //parts loop
                    for (int i = 1; i <= parts; i++)
                    {
                        string sqlstatement1 = "SELECT stud_id FROM(select COUNT(distinct stud_id ),stud_id from student_records) ename limit "+i+",1";

                        MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);


                        string studid = Convert.ToString(cmd1.ExecuteScalar());


                        cmd1.Dispose();

                        string sqlstatement2 = "SELECT firstname FROM accounts where userid = " + studid + "";

                        MySqlCommand cmd2 = new MySqlCommand(sqlstatement2, con);
                        string fname = Convert.ToString(cmd2.ExecuteScalar());
                        cmd2.Dispose();


                       





                    }






                }

                else
                {
                    Console.WriteLine("exam is not yet taken by students");

                }



            }
            catch (MySqlException ex) { Console.WriteLine("error" + ex); }
            finally
            {

                con.Close();

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
