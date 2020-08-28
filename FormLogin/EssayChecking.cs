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
using System.Data.OleDb;
using System.Security.Cryptography;
using MaterialSkin;

namespace FormLogin
{
    public partial class EssayChecking : MaterialSkin.Controls.MaterialForm

    {


        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con2 = new MySqlConnection(constring2);
        public static string constring1 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring1);
        public string exname;
        int examId = 0;
        int StudId = 0;
        NumericUpDown num = new NumericUpDown();
        MaterialSkin.Controls.MaterialLabel lb = new MaterialSkin.Controls.MaterialLabel();
        int item_no = 0;
        public EssayChecking(int studentid,int examid)
        {
            InitializeComponent();

            Console.WriteLine(studentid + "test/" + examid);
            btn_exam(studentid, examid);
            examId = examid;
            StudId = studentid;
        }
        public void save(dynamic p, int partid) 
        {

            foreach (Control c in p.Controls)
            {


                if (c is MaterialSkin.Controls.MaterialDivider)
                {

                    MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;


                    item_no = Convert.ToInt32(td.Tag);


                    foreach (Control d in td.Controls)
                    {

                        if (d is NumericUpDown)
                        {

                            num = (NumericUpDown)d;


                        }

                


                    }


               




                    string updating = "update student_records set score = @cp where col_exam_id = @exam_id and part_no =@part and item_no = @item and stud_id = "+StudId+"";

                    MySqlCommand upcmd = new MySqlCommand(updating, con1);
                  
                    upcmd.Parameters.AddWithValue("@part", partid);
                    upcmd.Parameters.AddWithValue("@item", item_no);
                    upcmd.Parameters.AddWithValue("@exam_id", examId);
                    upcmd.Parameters.AddWithValue("@cp", num.Value);

                    upcmd.ExecuteNonQuery();
                    upcmd.Dispose();






                }



            }
        }

        private void EssayChecking_Load(object sender, EventArgs e)
        {
         
        }

        public void btn_exam(int studid, int examid)
        {
            con1.Close();
            con1.Open();
            //bilang ng parts per exam
            string examcnt = "SELECT count(distinct(part_no)) FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + "";

            MySqlCommand fexam = new MySqlCommand(examcnt, con1);
            int partcnt = Convert.ToInt32(fexam.ExecuteScalar());
            fexam.Dispose();
            int a = 0;

            examcnt = "SELECT count(distinct(part_no)) FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and score = 0 and essay_flag = 1";

            fexam = new MySqlCommand(examcnt, con1);
            int partcnnt = Convert.ToInt32(fexam.ExecuteScalar());
            fexam.Dispose();

            //eto ung parts ng exam
            for (int i = 0; i < partcnnt; i++)
            {
                //pag kuha ng id ng part na may essay
                examcnt = "SELECT distinct(part_no) FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and score = 0 and essay_flag = 1 limit " + i + ",1";

                fexam = new MySqlCommand(examcnt, con1);
                int partid = Convert.ToInt32(fexam.ExecuteScalar());
                fexam.Dispose();

                //bilang ng sagot ng studyante
                examcnt = "SELECT count(*) FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and part_no =" + partid + "  ";

                fexam = new MySqlCommand(examcnt, con1);
                int partcount = Convert.ToInt32(fexam.ExecuteScalar());
                fexam.Dispose();

                Console.WriteLine(partcount+"partcntttt");
                



                if (i == 0)
                {
                    a+=1;

                    for (int x = 0; x < partcount; x++)
                    {
                        //question number ng exam
                        examcnt = "SELECT item_no FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and part_no =" + partid + " limit " + x + ",1";

                        fexam = new MySqlCommand(examcnt, con1);
                        int quesno = Convert.ToInt32(fexam.ExecuteScalar());
                        fexam.Dispose();

                        //pagkuha ng question
                        examcnt = "SELECT col_question FROM exam_system1.tbl_question where col_exam_id = " + examid + " and col_part_no =" + partid + " and col_question_no = " + quesno + "";

                        fexam = new MySqlCommand(examcnt, con1);
                        string question = Convert.ToString(fexam.ExecuteScalar());
                        fexam.Dispose();

                        examcnt = "SELECT col_points FROM exam_system1.tbl_question where col_exam_id = " + examid + " and col_part_no =" + partid + " and col_question_no = " + quesno + "";

                        fexam = new MySqlCommand(examcnt, con1);
                        int points = Convert.ToInt32(fexam.ExecuteScalar());
                        Console.WriteLine("pnt" + points);
                        fexam.Dispose();
                        //pagkuha ng answer ng student
                        examcnt = "SELECT answer FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and part_no =" + partid + " limit " + x + ",1";

                        fexam = new MySqlCommand(examcnt, con1);
                        string answer = Convert.ToString(fexam.ExecuteScalar());
                        fexam.Dispose();



                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(570, 200), BackColor = Color.AntiqueWhite, Tag = quesno };
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (x+1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = quesno });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = question, Location = new Point(50, 20), Size = new Size(560, 23), Tag = 200 });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(90, 170), Size = new Size(95, 23), Text = "set points:" });
                        // panel1.Controls.Add(new )

                        TextBox tb = new TextBox();
                        tb.Location = new Point(25, 45);
                        tb.Size = new Size(510, 120);
                        tb.Text = answer;
                        tb.Font = new Font("Calibri", 12.0f);
                        tb.BackColor = Color.White;
                        tb.Multiline = true;
                        tb.Tag = 101;
                        panel1.Controls.Add(tb);
                        //NumericUpDown num = new NumericUpDown();
                        //num.Maximum = points;
                        //num.Minimum = 0;
                        //num.Value = 0;
                        //num.Size = new Size(39, 36);
                        //num.Location = new Point(130, 170);
                        //panel1.Controls.Add(tb);
                        //panel1.Controls.Add(num);

                        NumericUpDown num = new NumericUpDown();
                        num.Size = new Size(39, 36);
                        num.Value = 1;
                        num.Location = new Point(200, 170);
                        num.Minimum = 0;
                        num.Maximum = points;
                        panel1.Controls.Add(num);
                        flowLayoutPanel1.Controls.Add(panel1);
                        flowLayoutPanel1.Tag = partid;

                    }



                }

                if (i == 1)
                {
                    a += 1;

                    for (int x = 0; x < partcount; x++)
                    {
                        //question number ng exam
                        examcnt = "SELECT item_no FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and part_no =" + partid + " limit " + x + ",1";

                        fexam = new MySqlCommand(examcnt, con1);
                        int quesno = Convert.ToInt32(fexam.ExecuteScalar());
                        fexam.Dispose();

                        //pagkuha ng question
                        examcnt = "SELECT col_question FROM exam_system1.tbl_question where col_exam_id = " + examid + " and col_part_no =" + partid + " and col_question_no = " + quesno + "";

                        fexam = new MySqlCommand(examcnt, con1);
                        string question = Convert.ToString(fexam.ExecuteScalar());
                        fexam.Dispose();

                        examcnt = "SELECT col_points FROM exam_system1.tbl_question where col_exam_id = " + examid + " and col_part_no =" + partid + " and col_question_no = " + quesno + "";

                        fexam = new MySqlCommand(examcnt, con1);
                        int points = Convert.ToInt32(fexam.ExecuteScalar());
                        Console.WriteLine("pnt" + points);
                        fexam.Dispose();
                        //pagkuha ng answer ng student
                        examcnt = "SELECT answer FROM exam_system1.student_records where col_exam_id = " + examid + " and stud_id = " + studid + " and part_no =" + partid + " limit " + x + ",1";

                        fexam = new MySqlCommand(examcnt, con1);
                        string answer = Convert.ToString(fexam.ExecuteScalar());
                        fexam.Dispose();



                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(570, 200), BackColor = Color.Gray, Tag = quesno };
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (x + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = quesno });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = question, Location = new Point(50, 20), Size = new Size(560, 23), Tag = 200 });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(90, 170), Size = new Size(95, 23), Text = "set points:" });
                        // panel1.Controls.Add(new )

                        TextBox tb = new TextBox();
                        tb.Location = new Point(25, 45);
                        tb.Size = new Size(510, 120);
                        tb.Text = answer;
                        tb.Font = new Font("Calibri", 12.0f);
                        tb.BackColor = Color.LightCyan;
                        tb.Multiline = true;
                        tb.Tag = 101;
                        panel1.Controls.Add(tb);
                        //NumericUpDown num = new NumericUpDown();
                        //num.Maximum = points;
                        //num.Minimum = 0;
                        //num.Value = 0;
                        //num.Size = new Size(39, 36);
                        //num.Location = new Point(130, 170);
                        //panel1.Controls.Add(tb);
                        //panel1.Controls.Add(num);

                        NumericUpDown num = new NumericUpDown();
                        num.Size = new Size(39, 36);
                        num.Value = 1;
                        num.Location = new Point(200, 170);
                        num.Minimum = 0;
                        num.Maximum = points;
                        panel1.Controls.Add(num);
                        flowLayoutPanel2.Controls.Add(panel1);
                        flowLayoutPanel2.Tag = partid;

                    }



                }






            }

            switch (partcnnt)
            {
                case 1:

                    tabControl1.Controls.Remove(tabPage2);
                    tabControl1.Controls.Remove(tabPage3);
                    tabControl1.Controls.Remove(tabPage4);
                    tabControl1.Controls.Remove(tabPage5);
                    tabControl1.Controls.Remove(tabPage6);
                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;

                case 2:


                    tabControl1.Controls.Remove(tabPage3);
                    tabControl1.Controls.Remove(tabPage4);
                    tabControl1.Controls.Remove(tabPage5);
                    tabControl1.Controls.Remove(tabPage6);
                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 3:


                    tabControl1.Controls.Remove(tabPage4);
                    tabControl1.Controls.Remove(tabPage5);
                    tabControl1.Controls.Remove(tabPage6);
                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 4:



                    tabControl1.Controls.Remove(tabPage5);
                    tabControl1.Controls.Remove(tabPage6);
                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 5:




                    tabControl1.Controls.Remove(tabPage6);
                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 6:



                    tabControl1.Controls.Remove(tabPage7);
                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 7:



                    tabControl1.Controls.Remove(tabPage8);
                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;

                case 8:



                    tabControl1.Controls.Remove(tabPage9);
                    tabControl1.Controls.Remove(tabPage10);


                    break;
                case 9:



                    tabControl1.Controls.Remove(tabPage10);


                    break;

            }




        }
        dynamic api;
        int fl = 0;
        private void button10_Click(object sender, EventArgs e)
        {
                api = flowLayoutPanel1;
                fl = Convert.ToInt32(flowLayoutPanel1.Tag);
                int tag = 1;
                save(api,fl);
                flowLayoutPanel1.Enabled = false;          
        }

    }
}
