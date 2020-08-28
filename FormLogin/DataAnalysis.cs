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
    public partial class DataAnalysis : MaterialSkin.Controls.MaterialForm
    {
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring2);
        public static string filename;
        MultipleSlidingPAnel o1;

        string currentuser;
        string currentpass;

        public DataAnalysis(string txt1, string user, string pass)
        {
            InitializeComponent();
            Text = txt1;
            currentuser = pass;
            currentpass = user;
            generate();
        }

       

        private void DataAnalysis_Load(object sender, EventArgs e)
        {

        }
        public void generate()
        {

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
            label1.Text = exn1;
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
                    string analcount = "SELECT count( distinct(col_part_no)) FROM exam_system1.tbl_analysis where  col_exam_id = @exam_id";
                    MySqlCommand anal = new MySqlCommand(analcount, con);
                    anal.Parameters.AddWithValue("@exam_id", this.Text);
                    int parts = Convert.ToInt32(anal.ExecuteScalar());
                   
                   
                    con.Close();

                    //parts loop
                    for (int i = 1; i <= parts; i++)
                    {
                        con.Close();
                        con.Open();

                         analcount = "SELECT  distinct(col_part_no) FROM exam_system1.tbl_analysis where  col_exam_id = @exam_id limit "+(i-1)+",1";
                         anal = new MySqlCommand(analcount, con);
                        anal.Parameters.AddWithValue("@exam_id", this.Text);
                        int part_no = Convert.ToInt32(anal.ExecuteScalar());
                        //getting how many items per part
                        string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(636, 90), BackColor = Color.SlateBlue };
                        panel1.Controls.Add(new Label { Text = "PART "+i, Location = new Point(270, 20), Size = new Size(100, 19),ForeColor = Color.White, Font = new Font("Calibri", 15, FontStyle.Bold) });
                        flowLayoutPanel1.Controls.Add(panel1);

                        for (int x = 1; x <= itemsCount; x++)
                        {

                            //getting question per part


                            string quest = "SELECT col_question FROM tbl_analysis   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + " and col_item_no ="+x+"";

                            MySqlCommand questions = new MySqlCommand(quest, con);

                            string question = Convert.ToString(questions.ExecuteScalar());

                            questions.Dispose();

                            string quest1 = "SELECT col_right_answers FROM tbl_analysis   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + " and col_item_no =" + x + "";

                            MySqlCommand questions1 = new MySqlCommand(quest1, con);

                            string right = Convert.ToString(questions1.ExecuteScalar());

                            questions1.Dispose();

                            string quest2 = "SELECT col_wrong_answers FROM tbl_analysis   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + " and col_item_no =" + x + "";

                            MySqlCommand questions2 = new MySqlCommand(quest2, con);

                            string wrong = Convert.ToString(questions2.ExecuteScalar());

                            questions2.Dispose();

                            string type = "SELECT col_part_type FROM tbl_parts   where col_part_no=" + part_no + "  and  col_exam_id = " + this.Text + "";

                            MySqlCommand types = new MySqlCommand(type, con);

                            string typ = Convert.ToString(types.ExecuteScalar());

                            types.Dispose();

                            var panel2 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(636, 90), BackColor = Color.SkyBlue };
                            panel2.Controls.Add(new Label { Text = "question " + x+":", Location = new Point(10, 20), Size = new Size(100, 19), Font = new Font("Calibri", 13, FontStyle.Bold) });

                            if (typ == "Photo Guest")
                            {
                                panel2.Controls.Add(new PictureBox { Location = new Point(160, 5), Size = new Size(80, 80), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                            }
                            else
                            {
                                panel2.Controls.Add(new Label { Text = "" + question, Location = new Point(20, 50), Size = new Size(550, 19), Font = new Font("Calibri", 11, FontStyle.Regular) });
                            }

                           
                            panel2.Controls.Add(new Label { Text = "Student Passed: "+right, Location = new Point(350, 10), Size = new Size(400, 19), ForeColor = Color.Green , Font = new Font("Calibri", 12, FontStyle.Regular) });
                            panel2.Controls.Add(new Label { Text = "Student Failed" + wrong, Location = new Point(350, 30), Size = new Size(400, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12, FontStyle.Regular) });

                            flowLayoutPanel1.Controls.Add(panel2);
                            Console.WriteLine(question);
                            Console.WriteLine(right);
                            Console.WriteLine(wrong);








                        }





                    }






                }

                else
                {
                    Console.WriteLine("exam is not yet taken by students");

                }



                }
            catch (MySqlException ex) { Console.WriteLine("error" + ex); }
            finally {

                con.Close();

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
