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
    public partial class StudentAnalysis : MaterialSkin.Controls.MaterialForm
    {
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring2);
        public static string filename;
        MultipleSlidingPAnel o1;

        string currentuser;
        string currentpass;
        public StudentAnalysis(string txt1, string user, string pass)
        {
            Console.WriteLine("pumasa"+txt1);
            InitializeComponent();
            Text = txt1;
            currentuser = user;
        
            currentpass = pass;
            Console.WriteLine("dur" + currentuser + currentpass);
            generate();

            
        }

        private void StudentAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }
        public void generate()
        {
            Console.WriteLine("tagg neto" + this.Tag);
            con.Close();
            con.Open();
            string gex = "SELECT col_exam_name FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gexcmd = new MySqlCommand(gex, con);
            gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string exn = Convert.ToString(gexcmd.ExecuteScalar());
            Console.WriteLine(exn + "exam name");
            label3.Text = exn;


            con.Close();
            con.Open();
            string gex1 = "SELECT subject FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gexcmd1 = new MySqlCommand(gex1, con);
            gexcmd1.Parameters.AddWithValue("@exam_id", this.Text);
            string exn1 = Convert.ToString(gexcmd1.ExecuteScalar());
            Console.WriteLine(exn + "exam name");
            sub.Text = exn1;
            con.Close();


            try
            {
                con.Close();

                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_analysis where col_exam_id = @exam", con);

                cmd.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));

                MySqlDataReader dr = cmd.ExecuteReader();






                MemoryStream ms = new MemoryStream();

                if (dr.HasRows == true)
                {

                    con.Close();
                    con.Open();
                    string analcount = "select col_exam_parts from tbl_exam where  col_exam_id = @exam_id";
                    MySqlCommand anal = new MySqlCommand(analcount, con);
                    anal.Parameters.AddWithValue("@exam_id", this.Text);
                    int parts = Convert.ToInt32(anal.ExecuteScalar());
                    anal.Dispose();

                    string sqlstatement = "SELECT col_exam_date FROM tbl_exam where col_exam_id = @exam_id";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    string date = Convert.ToString(cmd1.ExecuteScalar());
                    dte.Text = date;
                    cmd1.Dispose();
                    

                    analcount = "SELECT count( distinct(col_part_no)) FROM exam_system1.tbl_analysis where  col_exam_id = @exam_id";
                    anal = new MySqlCommand(analcount, con);
                    anal.Parameters.AddWithValue("@exam_id", this.Text);
                    int part = Convert.ToInt32(anal.ExecuteScalar());
                    anal.Dispose();


                    //parts loop
                    for (int i = 1; i <= part; i++)
                    {
                        con.Close();
                        con.Open();
                        analcount = "SELECT  distinct(col_part_no) FROM exam_system1.tbl_analysis where  col_exam_id = @exam_id limit " + (i - 1) + ",1";
                        anal = new MySqlCommand(analcount, con);
                        anal.Parameters.AddWithValue("@exam_id", this.Text);
                        int part_no = Convert.ToInt32(anal.ExecuteScalar());
                        anal.Dispose();

                        analcount = "select count(*) from tbl_question where  col_exam_id = @exam_id and col_part_no = "+ part_no + "";
                        anal = new MySqlCommand(analcount, con);
                        anal.Parameters.AddWithValue("@exam_id", this.Text);
                        int qparts = Convert.ToInt32(anal.ExecuteScalar()); 
                        anal.Dispose();

                        string sqlstatement13 = "SELECT count(col_choices) from tbl_choices where col_exam_id = @exam_id and col_part_id = @part";
                        MySqlCommand cmd3 = new MySqlCommand(sqlstatement13, con);
                        cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                        cmd3.Parameters.AddWithValue("@part", part_no);
                        cmd3.Dispose();
                       int total_old = Convert.ToInt32(cmd3.ExecuteScalar());

                        string level = "SELECT col_part_level FROM tbl_parts   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + "";

                        MySqlCommand levl = new MySqlCommand(level, con);

                        string levels = Convert.ToString(levl.ExecuteScalar());
                        Console.WriteLine(levels+"LVLS");

                        string ins = "SELECT col_instructions FROM tbl_parts   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + "";

                        MySqlCommand instruc = new MySqlCommand(ins, con);

                        string instructions = Convert.ToString(instruc.ExecuteScalar());
                        Console.WriteLine(instructions + "instructions");

                        string total_got_answer = "SELECT count(*) FROM student_records where part_no=" + part_no + "  and  col_exam_id = " + this.Text + " and stud_id ="+currentuser+" and score > 0";

                        MySqlCommand totalcmd = new MySqlCommand(total_got_answer, con);

                        int total = Convert.ToInt32(totalcmd.ExecuteScalar());

                        Console.WriteLine(total+"/"+i+"/");
                        totalcmd.Dispose();
                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(600, 90), BackColor = Color.DarkSlateGray };
                        panel1.Controls.Add(new Label { Text = "PART " + part_no + " ( "+levels+" ): "+ instructions + " ", Location = new Point(10, 15), Size = new Size(400, 25), ForeColor = Color.White, Font = new Font("Calibri", 15, FontStyle.Bold) });
                        panel1.Controls.Add(new Label { Text = "     scored: "+total+" out of "+ total_old + "", Location = new Point(10, 60), Size = new Size(400, 25), ForeColor = Color.White, Font = new Font("Calibri", 15, FontStyle.Bold) });
                        
                        flowLayoutPanel1.Controls.Add(panel1);








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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm f2 = new StudentForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Console.WriteLine("dur" + currentuser + currentpass);
            this.Hide();
            StudentForm f2 = new StudentForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }
    }
}
