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

using System.Web;
using System.Net.Mail;

namespace FormLogin
{
    public partial class studentexam : Form
    {
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring);
        static int id;
        static int stud_id;
        int hours, minutes, seconds;
        public static dynamic api;
        public static dynamic api2;
        static string answer = "";
        static string q = "";
        List<int> cnt = new List<int>();
        List<string> choice = new List<string>();
        static string exmid;
        static string stid;
        int right;
        int wrong;
        List<string> list2 = new List<string>();
        List<Label> list3 = new List<Label>();
        enum enumlist1 { };
        enum enumlist2 { };

        private List<int> listint(List<int> liste)
        {
            //          To shuffle an array a of n elements (indices 0..n-1):
            //for i from n − 1 downto 1 do
            // j ← random integer with 0 ≤ j ≤ i
            // exchange a[j] and a[i]
            int[] temp = new int[liste.Count];
            int z = 0;
            foreach (int eintrag in liste)
            {
                temp[z] = eintrag;
                z++;
            }
            int j = 0;
            Random RANDOM = new Random();
            for (int i = temp.Length - 1; i >= 1; i--)
            {
                j = RANDOM.Next(0, i);
                int a = temp[j];
                int b = temp[i];
                temp[i] = a;
                temp[j] = b;
            }
            liste.Clear();
            liste.AddRange(temp);
            return liste;
        }


 
        public void email(int grade,string exam) {
            string username = "MaterDeiAcademy2020@gmail.com";
            string password = "mda20192020";
            string to = "Giepau21@gmail.com";
            string subject = "Mater Dei Academy Examination System ";
           
            string body = "Good Day! this is mater dei academy notifier, "+ Environment.NewLine+" your son got "+grade+" % grade on "+exam;
            string clients = "smtp.gmail.com";
            MailMessage mail = new MailMessage(username, to, subject, body);
            SmtpClient client = new SmtpClient(clients);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Mail sent!", "Success", MessageBoxButtons.OK);
        }

        private List<string> list(List<string> liste)
        {
            //          To shuffle an array a of n elements (indices 0..n-1):
            //for i from n − 1 downto 1 do
            // j ← random integer with 0 ≤ j ≤ i
            // exchange a[j] and a[i]
            string[] temp = new string[liste.Count];
            int z = 0;
            foreach (string eintrag in liste)
            {
                temp[z] = eintrag;
                z++;
            }
            int j = 0;
            Random RANDOM = new Random();
            for (int i = temp.Length - 1; i >= 1; i--)
            {
                j = RANDOM.Next(0, i);
                string a = temp[j];
                string b = temp[i];
                temp[i] = a;
                temp[j] = b;
            }
            liste.Clear();
            liste.AddRange(temp);
            return liste;
        }


        public void dataAnalysis()
        {


        }
        public void save1(dynamic p, int a)
        {

            try
            {

                con.Close();
                con.Open();



                MySqlCommand update2 = new MySqlCommand("select * from student_records where col_exam_id= @exam_id and part_no = @part and col_teacher_id = " + id + " and stud_id = " + stud_id + "", con);

                update2.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update2.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update2.ExecuteReader();

                if (dr.HasRows)
                {
                    MessageBox.Show("already taken exam");
                }

                else {

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {
                            list1.Clear();
                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {




                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();


                                    int ques = Convert.ToInt32(tf.Tag);

                                    if (ques > 100)
                                    {
                                        q = str;


                                    }


                                    else if (rb.Checked == true)
                                    {
                                        answer = str;
                                        
                                    }
                                    


                                }

                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {

                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;





                                    if (Convert.ToInt32(tf.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);

                                    }


                                    //// dito>>>>>                              







                                }















                            }


                            try
                            {

                                con.Close();
                                con.Open();


                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1 limit 0,1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3+"answersaloob");
                                Console.WriteLine(answer + "answernya");
                                int score = 0;
                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    con.Open();
                                    string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                                    MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                                    score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                                    anscheckcmd3.Dispose();


                                }


                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam  where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
        "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@score", score);
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                                cmd.Parameters.AddWithValue("@student_id", stud_id);
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@answer", answer);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }


                    //

                }







            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }
//for data analysation
            try {

                con.Close();
                con.Open();
                


                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();

                if (dr.HasRows)
                {

                    //makeupdate

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {




                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();


                                    int ques = Convert.ToInt32(tf.Tag);

                                    if (ques > 100)
                                    {
                                        q = str;


                                    }


                                    else if (rb.Checked == true)
                                    {
                                        answer = str;

                                    }



                                }

                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {

                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;





                                    if (Convert.ToInt32(tf.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);

                                    }


                                    //// dito>>>>>                              







                                }















                            }


                            try
                            {

                                con.Close();
                                con.Open();





                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1 limit 0,1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {
                                    ///



                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_right_answers =(col_right_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);

                                    

                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }
                                else
                                {
                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_wrong_answers =(col_wrong_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }



     



                          

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }

                }

                else
                {
                    //make insert

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {




                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();


                                    int ques = Convert.ToInt32(tf.Tag);

                                    if (ques > 100)
                                    {
                                        q = str;


                                    }


                                    else if (rb.Checked == true)
                                    {
                                        answer = str;

                                    }



                                }
                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {

                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;





                                    if (Convert.ToInt32(tf.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);

                                    }


                                    //// dito>>>>>                              







                                }















                            }


                            try
                            {

                                con.Close();
                                con.Open();


                                string ques = "SELECT col_question from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                                MySqlCommand quest = new MySqlCommand(ques, con);

                                string question = Convert.ToString(quest.ExecuteScalar());
                                quest.Dispose();

                                con.Close();
                                con.Open();

                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1 limit 0,1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    right = 1;
                                    wrong = 0;


                                }
                                else
                                {
                                    right = 0;
                                    wrong = 1;


                                }



                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam  where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into tbl_analysis(col_teacher_id,col_exam_id,col_exam_name,col_part_no,col_item_no,col_question,col_right_answers,col_wrong_answers) " +
        "values(@teacher_id,@exam_id,@exam_name,@part,@item,@question,@right,@wrong)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                           
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                               
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", question);
                                cmd.Parameters.AddWithValue("@right", right);
                                cmd.Parameters.AddWithValue("@wrong", wrong);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }


                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }


        }
        public void save2(dynamic p, int a)
        {
            try
            {

                con.Close();
                con.Open();

                MySqlCommand update3 = new MySqlCommand("select * from student_records where col_exam_id= @exam_id and part_no =@part and col_teacher_id = " + id + " and stud_id = " + stud_id + "", con);
                update3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update3.Parameters.AddWithValue("@part", a);
                MySqlDataReader dr = update3.ExecuteReader();

                if (dr.HasRows)
                {



                    MessageBox.Show("already taken exam");
                }

                else {

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;




                             
                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {


                                     

                                     MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();




                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);


                                    }







                                }
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text;
                                    if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        answer = str;
                                        answer.ToLower();

                                    }
                                }














                            }



                            try
                    {

                        con.Close();
                        con.Open();


                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");

                                int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();


                        }


                        con.Close();
                        con.Open();
                        string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                        MySqlCommand enamecmd = new MySqlCommand(ename, con);
                        string examname = Convert.ToString(enamecmd.ExecuteScalar());
                        enamecmd.Dispose();



                        con.Close();
                        con.Open();

                        string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
"values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@exam_name", examname);
                        cmd.Parameters.AddWithValue("@student_id", stud_id);
                        cmd.Parameters.AddWithValue("@teacher_id", id);
                        cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                        cmd.Parameters.AddWithValue("@part", a);
                        cmd.Parameters.AddWithValue("@item", item_no);
                        cmd.Parameters.AddWithValue("@answer", answer);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("eerror" + ex);
                    }




                        }


                    }




                }







            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }

            // for data analyzation

            try
            {

                con.Close();
                con.Open();



                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();

                if (dr.HasRows)
                {

                    //makeupdate

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                          
                                foreach (Control d in td.Controls)
                                {


                                    if (d is MaterialSkin.Controls.MaterialLabel)
                                    {




                                        MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                        string str = tf.Text.ToLower();




                                        if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                        {

                                            item_no = Convert.ToInt32(tf.Tag);


                                        }







                                    }
                                    if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                    {

                                        MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                        string str = tf.Text.ToLower();
                                        if (Convert.ToInt32(tf.Tag) == 101)
                                        {
                                            answer = str;
                                            


                                        }
                                    }














                                }


                            try
                            {

                                con.Close();
                                con.Open();





                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {
                                    ///



                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_right_answers =(col_right_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }
                                else
                                {
                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_wrong_answers =(col_wrong_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }









                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }

                }

                else
                {
                    //make insert

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {




                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();




                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);


                                    }







                                }
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();
                                    if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        answer = str;
                                        answer.ToLower();

                                    }
                                }














                            }


                            try
                            {

                                con.Close();
                                con.Open();


                                string ques = "SELECT col_question from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                                MySqlCommand quest = new MySqlCommand(ques, con);

                                string question = Convert.ToString(quest.ExecuteScalar());
                                quest.Dispose();

                                con.Close();
                                con.Open();

                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    right = 1;
                                    wrong = 0;


                                }
                                else
                                {
                                    right = 0;
                                    wrong = 1;


                                }



                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam  where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into tbl_analysis(col_teacher_id,col_exam_id,col_exam_name,col_part_no,col_item_no,col_question,col_right_answers,col_wrong_answers) " +
        "values(@teacher_id,@exam_id,@exam_name,@part,@item,@question,@right,@wrong)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                                cmd.Parameters.AddWithValue("@exam_name", examname);

                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", question);
                                cmd.Parameters.AddWithValue("@right", right);
                                cmd.Parameters.AddWithValue("@wrong", wrong);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }


                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }
        }
        public void save3(dynamic p, int a)

        {
            foreach (Control c in p.Controls)
            {


                if (c is MaterialSkin.Controls.MaterialDivider)
                {

                    MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                    foreach (Control d in td.Controls)
                    {

                        if (d is MaterialSkin.Controls.MaterialSingleLineTextField)

                        {

                            MaterialSkin.Controls.MaterialSingleLineTextField st = (MaterialSkin.Controls.MaterialSingleLineTextField)d;

                            string str = st.Text.ToLower();

                            q = str;
                            item_no = Convert.ToInt32(st.Tag);

                        }
                        if (d is MaterialSkin.Controls.MaterialRadioButton)
                        {

                            rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                            if (rb.Checked == true)
                            {
                                answer = rb.Text.ToLower();
                               
                            }


                        }














                    }


                    try
                    {

                        con.Close();
                        con.Open();


                        string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                        checkcmd3.Dispose();
                        Console.WriteLine(anscheck3 + "answersaloob");
                        Console.WriteLine(answer + "answernya");

                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();


                        }


                        con.Close();
                        con.Open();
                        string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                        MySqlCommand enamecmd = new MySqlCommand(ename, con);
                        string examname = Convert.ToString(enamecmd.ExecuteScalar());
                        enamecmd.Dispose();

                        

                        con.Close();
                        con.Open();

                        string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
"values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@exam_name", examname);
                        cmd.Parameters.AddWithValue("@student_id", stud_id);
                        cmd.Parameters.AddWithValue("@teacher_id", id);
                        cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                        cmd.Parameters.AddWithValue("@part", a);
                        cmd.Parameters.AddWithValue("@item", item_no);
                        cmd.Parameters.AddWithValue("@answer", answer);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("eerror" + ex);
                    }








                }


            }


            // for data analyzation

            try
            {

                con.Close();
                con.Open();



                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();

                if (dr.HasRows)
                {

                    //makeupdate

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;






                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)

                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField st = (MaterialSkin.Controls.MaterialSingleLineTextField)d;

                                    string str = st.Text.ToLower();

                                    q = str;
                                    item_no = Convert.ToInt32(st.Tag);

                                }
                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {

                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                    if (rb.Checked == true)
                                    {
                                        answer = rb.Text.ToLower();
                                       
                                    }


                                }














                            }


                            try
                            {

                                con.Close();
                                con.Open();





                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {
                                    ///



                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_right_answers =(col_right_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }
                                else
                                {
                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_wrong_answers =(col_wrong_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }









                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }

                }

                else
                {
                    //make insert

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)

                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField st = (MaterialSkin.Controls.MaterialSingleLineTextField)d;

                                    string str = st.Text.ToLower();

                                    q = str;
                                    item_no = Convert.ToInt32(st.Tag);

                                }
                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {

                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                    if (rb.Checked == true)
                                    {
                                        answer = rb.Text.ToLower();
                                        answer.ToLower();
                                    }


                                }














                            }


                            try
                            {

                                con.Close();
                                con.Open();


                                string ques = "SELECT col_question from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                                MySqlCommand quest = new MySqlCommand(ques, con);

                                string question = Convert.ToString(quest.ExecuteScalar());
                                quest.Dispose();

                                con.Close();
                                con.Open();

                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    right = 1;
                                    wrong = 0;


                                }
                                else
                                {
                                    right = 0;
                                    wrong = 1;


                                }



                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam  where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into tbl_analysis(col_teacher_id,col_exam_id,col_exam_name,col_part_no,col_item_no,col_question,col_right_answers,col_wrong_answers) " +
        "values(@teacher_id,@exam_id,@exam_name,@part,@item,@question,@right,@wrong)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                                cmd.Parameters.AddWithValue("@exam_name", examname);

                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", question);
                                cmd.Parameters.AddWithValue("@right", right);
                                cmd.Parameters.AddWithValue("@wrong", wrong);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }


                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }

        }
        PictureBox pb2 = new PictureBox();
        //controls
        public static int no_ch;
        MaterialSkin.Controls.MaterialSingleLineTextField mtf = new MaterialSkin.Controls.MaterialSingleLineTextField();
        string mf;
        List<string> list1 = new List<string>();
        public static string filename;
        MaterialSkin.Controls.MaterialSingleLineTextField st3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
        FlowLayoutPanel fp = new FlowLayoutPanel();
        public void save4(dynamic p, int a)
        {

           
            foreach (Control c in p.Controls)
            {
                if (c is MaterialSkin.Controls.MaterialDivider)
                {
                    MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;
                    foreach (Control d in td.Controls)
                    {
                        if (d is PictureBox)
                        {
                            pb2 = (PictureBox)d;



                            filename = pb2.ImageLocation;




                        }

                        if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                        {
                            st3 = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                            string q = st3.Text.ToLower();
                            answer = q;
                           
                            item_no = Convert.ToInt32(st3.Tag);
                        }



                    }

                    try
                    {

                        con.Close();
                        con.Open();


                        string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                        checkcmd3.Dispose();
                        Console.WriteLine(anscheck3 + "answersaloob");
                        string A = answer.ToLower();
                        Console.WriteLine(A + "answernya");


                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();


                        }


                        con.Close();
                        con.Open();
                        string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                        MySqlCommand enamecmd = new MySqlCommand(ename, con);
                        string examname = Convert.ToString(enamecmd.ExecuteScalar());
                        enamecmd.Dispose();



                        con.Close();
                        con.Open();

                        string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
"values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@exam_name", examname);
                        cmd.Parameters.AddWithValue("@student_id", stud_id);
                        cmd.Parameters.AddWithValue("@teacher_id", id);
                        cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                        cmd.Parameters.AddWithValue("@part", a);
                        cmd.Parameters.AddWithValue("@item", item_no);
                        cmd.Parameters.AddWithValue("@answer", answer);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("eerror" + ex);
                    }

                }
            }


            // for data analyzation

            try
            {

                con.Close();
                con.Open();



                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();

                if (dr.HasRows)
                {

                    //makeupdate

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;






                            foreach (Control d in td.Controls)
                            {


                                if (d is PictureBox)
                                {
                                    pb2 = (PictureBox)d;



                                    filename = pb2.ImageLocation;




                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {
                                    st3 = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string q = st3.Text.ToLower();
                                    answer = q;
                                  
                                    item_no = Convert.ToInt32(st3.Tag);
                                }














                            }


                            try
                            {

                                con.Close();
                                con.Open();





                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {
                                    ///



                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_right_answers =(col_right_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }
                                else
                                {
                                    con.Close();
                                    con.Open();

                                    string sqlstatement = "update tbl_analysis set col_wrong_answers =(col_wrong_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                    cmd.Parameters.AddWithValue("@teacher_id", id);
                                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                    cmd.Parameters.AddWithValue("@part", a);
                                    cmd.Parameters.AddWithValue("@item", item_no);



                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();


                                }









                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }

                }

                else
                {
                    //make insert

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is PictureBox)
                                {
                                    pb2 = (PictureBox)d;



                                    filename = pb2.ImageLocation;




                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {
                                    st3 = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string q = st3.Text.ToLower();
                                    answer = q;
                                    answer.ToLower();
                                    item_no = Convert.ToInt32(st3.Tag);
                                }














                            }


                            try
                            {

                                con.Close();
                                con.Open();


                                string ques = "SELECT col_question from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                                MySqlCommand quest = new MySqlCommand(ques, con);

                                string question = Convert.ToString(quest.ExecuteScalar());
                                quest.Dispose();

                                con.Close();
                                con.Open();

                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");


                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    right = 1;
                                    wrong = 0;


                                }
                                else
                                {
                                    right = 0;
                                    wrong = 1;


                                }



                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam  where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into tbl_analysis(col_teacher_id,col_exam_id,col_exam_name,col_part_no,col_item_no,col_question,col_right_answers,col_wrong_answers) " +
        "values(@teacher_id,@exam_id,@exam_name,@part,@item,@question,@right,@wrong)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                                cmd.Parameters.AddWithValue("@exam_name", examname);

                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", question);
                                cmd.Parameters.AddWithValue("@right", right);
                                cmd.Parameters.AddWithValue("@wrong", wrong);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }





                        }


                    }


                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }

        }
       
        public void save5analysis(dynamic p, int a)
        {
            int totalscore = 0;
            int gotscore = 0;
            int result =0;
            try
            {


                con.Close();
                con.Open();



                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();
                if (dr.HasRows)
                {



                    Console.WriteLine("else gumana");
                    ///enurows
                    con.Close();
                    con.Open();


                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;


                            item_no = Convert.ToInt32(td.Tag);


                            foreach (Control d in td.Controls)
                            {






                                int ques = 0;
                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {

                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();

                                    ques = Convert.ToInt32(tf.Tag);

                                    if (ques == 200)
                                    {
                                        q = str;


                                    }


                                    //// dito>>>>>                              






                                }

                                if (d is FlowLayoutPanel)
                                {


                                    //fppp
                                    fp = (FlowLayoutPanel)d;
                                    no_ch = fp.Controls.Count;
                                    foreach (Control f in d.Controls)
                                    {

                                        if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                        {
                                            mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                            mf = mtf.Text.ToLower();


                                            list1.Add(mf);
                                            string[] answerlist = { };
                                            //   answerlist = 

                                        }

                                    }



                                }








                            }

                            con.Close();
                            con.Open();



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item_no);
                            a2cmd.Parameters.AddWithValue("@partno", a);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());




                            for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                            {
                                ///mgasagot list 2
                                con.Close();
                                con.Open();
                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = @exam and col_item_id = @item and col_part_id = @partno limit " + x + ",1 ";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);
                                checkcmd3.Parameters.AddWithValue("@item", item_no);
                                checkcmd3.Parameters.AddWithValue("@partno", a);
                                checkcmd3.Parameters.AddWithValue("@exam", this.Text);


                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                                checkcmd3.Dispose();
                                Console.WriteLine("got score" + anscheck3);

                                list2.Add(anscheck3);
                            }










                            string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            int score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();

                            con.Close();
                            con.Open();

                            string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                            MySqlCommand enamecmd = new MySqlCommand(ename, con);
                            string examname = Convert.ToString(enamecmd.ExecuteScalar());
                            enamecmd.Dispose();







                            List<string> list4 = new List<string>();

                            for (int k = 0; k < list1.Count; k++)//answer nya
                            {


                                if (list2.Contains(list1[k]))//right answetr

                                {



                                    if (list4.Contains(list1[k]))
                                    {
                                        score += 0;
                                    }
                                    else {
                                        gotscore += score;
                                    }

                                    list4.Add(list1[k]);



                                }

                                else
                                {


                                }







                            }




                            //}





                            ////
                            Console.WriteLine("nagclear");
                            list1.Clear();
                            list2.Clear();
                            no_ch = 0;



                            Console.WriteLine("gotscore" + gotscore);

                            int total_old = 0;
                            int total_no_of_exam = 0;
                            string sqlstatement13 = "SELECT count(col_choices) from tbl_choices where col_exam_id = @exam_id and col_part_id = @part";
                            MySqlCommand cmd3 = new MySqlCommand(sqlstatement13, con);
                            cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd3.Parameters.AddWithValue("@part", a);
                            total_old = Convert.ToInt32(cmd3.ExecuteScalar());
                            Console.WriteLine("tt" + total_old);
                            cmd3.Dispose();
                            sqlstatement13 = "SELECT col_points from tbl_parts where  col_part_no = @part and col_exam_id = @exam_id";
                            cmd3 = new MySqlCommand(sqlstatement13, con);
                            cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd3.Parameters.AddWithValue("@part", a);

                            int new_part = Convert.ToInt32(cmd3.ExecuteScalar());
                            cmd3.Dispose();

                            total_old = total_old * new_part;

                            int half = (total_old / 2);

                            if (gotscore > half)
                            {

                                
                                con.Close();
                                con.Open();

                                string sqlstatement = "update tbl_analysis set col_right_answers =(col_right_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);



                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            else
                            {
                                con.Close();
                                con.Open();

                                string sqlstatement = "update tbl_analysis set col_wrong_answers =(col_wrong_answers+1) where col_exam_id = @exam_id and col_part_no = @part and col_item_no = @item";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);



                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);



                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }



                            con.Close();



                        }





                    }







                }
                else

                {
                    string q = "";
                    Console.WriteLine("else gumana");
                    ///enurows
                    con.Close();
                    con.Open();


                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;


                            item_no = Convert.ToInt32(td.Tag);


                            foreach (Control d in td.Controls)
                            {






                                int ques = 0;
                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {

                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();

                                    ques = Convert.ToInt32(tf.Tag);

                                    if (ques == 200)
                                    {
                                        q = str;
                                        Console.WriteLine("question gumana"+q);

                                    }


                                    //// dito>>>>>                              






                                }

                                if (d is FlowLayoutPanel)
                                {


                                    //fppp
                                    fp = (FlowLayoutPanel)d;
                                    no_ch = fp.Controls.Count;
                                    foreach (Control f in d.Controls)
                                    {

                                        if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                        {
                                            mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                            mf = mtf.Text.ToLower();


                                            list1.Add(mf);
                                            string[] answerlist = { };
                                            //   answerlist = 

                                        }

                                    }



                                }








                            }

                            con.Close();
                            con.Open();

                    

                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item_no);
                            a2cmd.Parameters.AddWithValue("@partno", a);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                        



                            for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                            {
                                ///mgasagot list 2
                                con.Close();
                                con.Open();
                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = @exam and col_item_id = @item and col_part_id = @partno limit " + x + ",1 ";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);
                                checkcmd3.Parameters.AddWithValue("@item", item_no);
                                checkcmd3.Parameters.AddWithValue("@partno", a);
                                checkcmd3.Parameters.AddWithValue("@exam", this.Text);


                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                                checkcmd3.Dispose();
                                Console.WriteLine("got score" + anscheck3);

                                list2.Add(anscheck3);
                            }










                            string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            int score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();

                            con.Close();
                            con.Open();

                            string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                            MySqlCommand enamecmd = new MySqlCommand(ename, con);
                            string examname = Convert.ToString(enamecmd.ExecuteScalar());
                            enamecmd.Dispose();







                            List<string> list4 = new List<string>();

                            for (int k = 0; k < list1.Count; k++)//answer nya
                            {


                                if (list2.Contains(list1[k]))//right answetr

                                {


                                 
                                    if (list4.Contains(list1[k]))
                                    {
                                        score += 0;
                                    }
                                    else {
                                        gotscore += score;
                                    }

                                    list4.Add(list1[k]);
                              


                                }

                                else
                                {

                          
                                }







                            }




                            //}



                            

                            ////
                            Console.WriteLine("nagclear");
                            list1.Clear();
                            list2.Clear();
                            no_ch = 0;



                            Console.WriteLine("gotscore" + gotscore);

                            int total_old = 0;
                            int total_no_of_exam = 0;
                            string sqlstatement13 = "SELECT count(col_choices) from tbl_choices where col_exam_id = @exam_id and col_part_id = @part";
                            MySqlCommand cmd3 = new MySqlCommand(sqlstatement13, con);
                            cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd3.Parameters.AddWithValue("@part", a);
                            total_old = Convert.ToInt32(cmd3.ExecuteScalar());
                            Console.WriteLine("tt" + total_old);
                            cmd3.Dispose();
                            sqlstatement13 = "SELECT col_points from tbl_parts where  col_part_no = @part and col_exam_id = @exam_id";
                            cmd3 = new MySqlCommand(sqlstatement13, con);
                            cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd3.Parameters.AddWithValue("@part", a);

                            int new_part = Convert.ToInt32(cmd3.ExecuteScalar());
                            cmd3.Dispose();

                            total_old = total_old * new_part;

                            int half = (total_old / 2);

                            if (gotscore >= half)
                            {

                                right = 1;
                                wrong = 0;

                            }
                            else
                            {
                                wrong = 1;
                                right = 0;
                            }

                            string sqlstatement = "insert into tbl_analysis(col_teacher_id,col_exam_id,col_exam_name,col_part_no,col_item_no,col_question,col_right_answers,col_wrong_answers) " +
              "values(@teacher_id,@exam_id,@exam_name,@part,@item,@question,@right,@wrong)";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);

                            cmd.Parameters.AddWithValue("@exam_name", examname);

                            cmd.Parameters.AddWithValue("@teacher_id", id);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);
                            Console.WriteLine("value ni q"+q);
                            cmd.Parameters.AddWithValue("@question",q);
                            cmd.Parameters.AddWithValue("@right", right);
                            cmd.Parameters.AddWithValue("@wrong", wrong);

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            con.Close();



                        }


                      


                    }




                   

                }


              


            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }



            ///datasave5







        }

        public void save5(dynamic p, int a)
        {

            try
            {




                Console.WriteLine("nagsave 5");
                ///enurows
                con.Close();
                con.Open();


                foreach (Control c in p.Controls)
                {


                    if (c is MaterialSkin.Controls.MaterialDivider)
                    {

                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;


                        item_no = Convert.ToInt32(td.Tag);


                        foreach (Control d in td.Controls)
                        {






                            int ques = 0;
                            if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                            {

                                MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                string str = tf.Text.ToLower();

                                ques = Convert.ToInt32(tf.Tag);

                                if (ques > 100)
                                {
                                    q = str;


                                }


                                //// dito>>>>>                              






                            }

                            if (d is FlowLayoutPanel)
                            {


                                //fppp
                                fp = (FlowLayoutPanel)d;
                                no_ch = fp.Controls.Count;
                                foreach (Control f in d.Controls)
                                {

                                    if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                    {
                                        mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                        mf = mtf.Text.ToLower();


                                        list1.Add(mf);
                                        string[] answerlist = { };
                                        //   answerlist = 

                                    }

                                }



                            }








                        }

                        con.Close();
                        con.Open();

                        Console.WriteLine("exam" + this.Text);
                        Console.WriteLine("partno" + a);
                        Console.WriteLine("ques no" + item_no);

                        string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                        MySqlCommand a2cmd = new MySqlCommand(a2, con);
                        a2cmd.Parameters.AddWithValue("@item", item_no);
                        a2cmd.Parameters.AddWithValue("@partno", a);
                        a2cmd.Parameters.AddWithValue("@exam", this.Text);
                        string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                        Console.WriteLine("no" + no_choices);

                        for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                        {
                            con.Close();
                            con.Open();
                            string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = @exam and col_item_id = @item and col_part_id = @partno limit " + x + ",1 ";
                            MySqlCommand checkcmd3 = new MySqlCommand(check3, con);
                            checkcmd3.Parameters.AddWithValue("@item", item_no);
                            checkcmd3.Parameters.AddWithValue("@partno", a);
                            checkcmd3.Parameters.AddWithValue("@exam", this.Text);


                            string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                            checkcmd3.Dispose();
                            Console.WriteLine("got score" + anscheck3);

                            list2.Add(anscheck3);
                        }










                        string ans3 = "SELECT col_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
                        MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                        int score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                        anscheckcmd3.Dispose();

                        con.Close();
                        con.Open();

                        string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                        MySqlCommand enamecmd = new MySqlCommand(ename, con);
                        string examname = Convert.ToString(enamecmd.ExecuteScalar());
                        enamecmd.Dispose();




                        Console.WriteLine("lop1" + list1.Count);
                        Console.WriteLine("lop1" + list2.Count);




                        List<string> list4 = new List<string>();

                        for (int k = 0; k < list1.Count; k++)//answer nya
                        {


                            if (list2.Contains(list1[k]))//right answetr

                            {


                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
                                 "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                if (list4.Contains(list1[k]))
                                {
                                    cmd.Parameters.AddWithValue("@score", 0);
                                }
                                else {
                                    cmd.Parameters.AddWithValue("@score", score);
                                }
                                list4.Add(list1[k]);
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                                cmd.Parameters.AddWithValue("@student_id", stud_id);
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@answer", list1[k]);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                                Console.WriteLine("listtsssssss" + list1[k]);
                                Console.WriteLine("" + list2);
                            }

                            else
                            {


                                Console.WriteLine("nag if" + list1[k]);
                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score) " +
                                 "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,0)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                                cmd.Parameters.AddWithValue("@student_id", stud_id);
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@answer", list1[k]);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }







                        }




                        //}





                        ////
                        Console.WriteLine("nagclear");
                        list1.Clear();
                        list2.Clear();
                        no_ch = 0;







                    }


                }






                con.Close();


            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }



            ///datasave5



            save5analysis(p, a);



        }

        
       public void save6analysis(dynamic p, int a)
        {
            try
            {

                con.Close();
                con.Open();


                MySqlCommand analysis = new MySqlCommand("select * from tbl_analysis where col_exam_id= @exam_id and col_part_no = @part and col_teacher_id = " + id + " ", con);

                analysis.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                analysis.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = analysis.ExecuteReader();

                if (dr.HasRows)
                {



                    MessageBox.Show("already taken exam");
                }

                else {

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {




                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();




                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);


                                    }







                                }
                                if (d is TextBox)
                                {

                                    TextBox tf = (TextBox)d;
                                    string str = tf.Text;
                                    if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        answer = str;

                                    }
                                }














                            }



                            try
                            {

                                con.Close();
                                con.Open();


                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");

                                int score = 0;
                                con.Close();



                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score,essay_flag) " +
        "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score,1)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@score", score);
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                                cmd.Parameters.AddWithValue("@student_id", stud_id);
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@answer", answer);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }




                        }


                    }




                }







            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }

            // for data analyzation


        }

        public void save6(dynamic p, int a)
        {
            try
            {

                con.Close();
                con.Open();

                MySqlCommand update3 = new MySqlCommand("select * from student_records where col_exam_id= @exam_id and part_no =@part and col_teacher_id = " + id + " and stud_id = " + stud_id + "", con);
                update3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update3.Parameters.AddWithValue("@part", a);
                MySqlDataReader dr = update3.ExecuteReader();

                if (dr.HasRows)
                {



                    MessageBox.Show("already taken exam");
                }

                else {

                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)
                                {




                                    MaterialSkin.Controls.MaterialLabel tf = (MaterialSkin.Controls.MaterialLabel)d;
                                    string str = tf.Text.ToLower();




                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {

                                        item_no = Convert.ToInt32(tf.Tag);


                                    }







                                }
                                if (d is TextBox)
                                {

                                    TextBox tf = (TextBox)d;
                                    string str = tf.Text;
                                    if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        answer = str;
                                    
                                    }
                                }














                            }



                            try
                            {

                                con.Close();
                                con.Open();


                                string check3 = "SELECT col_choices from tbl_choices where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_id = " + a + " and col_item_id = " + item_no + " and col_answer_flag = 1";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());

                                checkcmd3.Dispose();
                                Console.WriteLine(anscheck3 + "answersaloob");
                                Console.WriteLine(answer + "answernya");

                                int score = 0;
                                con.Close();
                              


                                con.Close();
                                con.Open();
                                string ename = " SELECT col_exam_name from tbl_exam where col_exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(col_teacher_id,col_exam_id,col_exam_name,stud_id,part_no,item_no,answer,score,essay_flag) " +
        "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score,1)";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@score", score);
                                cmd.Parameters.AddWithValue("@exam_name", examname);
                                cmd.Parameters.AddWithValue("@student_id", stud_id);
                                cmd.Parameters.AddWithValue("@teacher_id", id);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@answer", answer);

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("eerror" + ex);
                            }




                        }


                    }




                }







            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }

            // for data analyzation

           
        }

        public studentexam(string exam_id, int teacher_id, int student_id)
        {


            Console.WriteLine(exam_id + "1");
            InitializeComponent();
            exmid = exam_id;
            stid = student_id.ToString();
            Console.WriteLine(exam_id + "2");
         

            this.Text = exam_id;


            stud_id = student_id;
            id = teacher_id;
            con.Open();
            string gex = "SELECT col_exam_name FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gexcmd = new MySqlCommand(gex, con);
            gexcmd.Parameters.AddWithValue("@t_id", id);
            gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string exn = Convert.ToString(gexcmd.ExecuteScalar());
          
            con.Close();

            con.Open();
            string gt = "SELECT firstname FROM accounts where userid = @t_id";
            MySqlCommand gtcmd = new MySqlCommand(gt, con);
            gtcmd.Parameters.AddWithValue("@t_id", id);
            string tc = Convert.ToString(gtcmd.ExecuteScalar());
           
            con.Close();
            con.Open();
            string gt1 = "SELECT lastname FROM accounts where userid = @t_id";
            MySqlCommand gt1cmd = new MySqlCommand(gt1, con);
            gt1cmd.Parameters.AddWithValue("@t_id", id);
            string tc1 = Convert.ToString(gt1cmd.ExecuteScalar());
            
            con.Close();

            con.Open();
            string gt2 = "SELECT grade FROM accounts where userid = @t_id";
            MySqlCommand gt2cmd = new MySqlCommand(gt2, con);
            gt2cmd.Parameters.AddWithValue("@t_id", stud_id);
            string tc2 = Convert.ToString(gt2cmd.ExecuteScalar());

            con.Close();

            con.Open();
            string gt4 = "SELECT section FROM accounts where userid = @t_id";
            MySqlCommand gt4cmd = new MySqlCommand(gt4, con);
            gt4cmd.Parameters.AddWithValue("@t_id", stud_id);
            string tc4 = Convert.ToString(gt4cmd.ExecuteScalar());

            con.Close();

            grdsec.Text = "Grade " + tc2 + " " + tc4;
            exnamee.Text = exn;
            tchr.Text = "Prof: " + tc + "  "+tc1;
            dte.Text = Convert.ToString(DateTime.Today.Date);

        }

        private void studentexam_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel4.AutoScroll = true;
           customTabControl1.Appearance = TabAppearance.FlatButtons;
           customTabControl1.ItemSize = new Size(0, 1);
           customTabControl1.SizeMode = TabSizeMode.Fixed;
            d.Hide();
            label6.Hide();

            generate();   
            getime();
            timer1.Start();
            inslevel();


        }
        //


        List<string> levels = new List<string>();
        List<string> ins = new List<string>();
        public void inslevel()
        {

        
            try {
                con.Close();
                con.Open();
              

                string sqlstatement = "SELECT col_exam_parts FROM tbl_exam where col_exam_id = @exam_id";
                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);          
                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));     
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("id"+id);
                cmd.Dispose();

                for (int x = 0; x < id; x++)
                {

                    string gex = "SELECT col_part_level FROM tbl_parts  where  col_exam_id = @exam_id and col_part_no = @part";
                    MySqlCommand gexcmd = new MySqlCommand(gex, con);
                    gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
                    gexcmd.Parameters.AddWithValue("@part", x + 1);
                    string partlvl = Convert.ToString(gexcmd.ExecuteScalar());
                    gexcmd.Dispose();

                    gex = "SELECT col_instructions FROM tbl_parts  where  col_exam_id = @exam_id and col_part_no = @part";
                    gexcmd = new MySqlCommand(gex, con);
                    gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
                    gexcmd.Parameters.AddWithValue("@part", x + 1);
                    string partins = Convert.ToString(gexcmd.ExecuteScalar());
                    gexcmd.Dispose();



                    levels.Add(partlvl);
                    ins.Add(partins);

                    Console.WriteLine("id" +partlvl);
                    Console.WriteLine("id" + partins);






                }
                switch (Convert.ToInt32(id))
                {

                    case 1:
                        label3.Text = levels[0];



                        label14.Text = ins[0];


                        break;

                    case 2:
                        label3.Text = levels[0];
                        label2.Text = levels[1];



                        label14.Text = ins[0];
                        label15.Text = ins[1];


                        break;

                    case 3:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];


                        break;
                    case 4:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];


                        break;

                    case 5:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];


                        break;

                    case 6:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];
                        label9.Text = levels[5];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];
                        label19.Text = ins[5];


                        break;

                    case 7:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];
                        label9.Text = levels[5];
                        label10.Text = levels[6];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];
                        label19.Text = ins[5];
                        label20.Text = ins[6];


                        break;

                    case 8:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];
                        label9.Text = levels[5];
                        label10.Text = levels[6];
                        label11.Text = levels[7];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];
                        label19.Text = ins[5];
                        label20.Text = ins[6];
                        label21.Text = ins[7];


                        break;
                    case 9:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];
                        label9.Text = levels[5];
                        label10.Text = levels[6];
                        label11.Text = levels[7];
                        label12.Text = levels[8];



                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];
                        label19.Text = ins[5];
                        label20.Text = ins[6];
                        label21.Text = ins[7];
                        label22.Text = ins[8];


                        break;

                    case 10:
                        label3.Text = levels[0];
                        label2.Text = levels[1];
                        label4.Text = levels[2];
                        label7.Text = levels[3];
                        label8.Text = levels[4];
                        label9.Text = levels[5];
                        label10.Text = levels[6];
                        label11.Text = levels[7];
                        label12.Text = levels[8];
                        label13.Text = levels[9];


                        label14.Text = ins[0];
                        label15.Text = ins[1];
                        label16.Text = ins[2];
                        label17.Text = ins[3];
                        label18.Text = ins[4];
                        label19.Text = ins[5];
                        label20.Text = ins[6];
                        label21.Text = ins[7];
                        label22.Text = ins[8];
                        label23.Text = ins[9];

                        break;
                }




            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }


           
           





           

        }
       

        public void getime()
        {
            con.Close();
            con.Open();
            MySqlCommand hr = new MySqlCommand("select col_exam_duration_hrs from tbl_exam where col_exam_id= @exam_id ", con);
            hr.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));


            MySqlDataReader hrs = hr.ExecuteReader();

            while (hrs.Read())
            {
                if (hrs["col_exam_duration_hrs"] != DBNull.Value)
                {



                    var section = hrs.GetString(0);
                    hours = Convert.ToInt32(section);

                }
                else
                {

                }
            }

            con.Close();

            con.Open();
            MySqlCommand min = new MySqlCommand("select col_exam_duration_mins from tbl_exam where col_exam_id= @exam_id ", con);
            min.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));


            MySqlDataReader mins = min.ExecuteReader();

            while (mins.Read())
            {
                if (mins["col_exam_duration_mins"] != DBNull.Value)
                {



                    var section = mins.GetString(0);
                    minutes = Convert.ToInt32(section);
                }
                else
                {
                    MessageBox.Show("null");
                }
            }

            con.Close();

            seconds = 0;

        }
        //
        public static MaterialSkin.Controls.MaterialRadioButton rb = new MaterialSkin.Controls.MaterialRadioButton();
        public static MaterialSkin.Controls.MaterialLabel lb = new MaterialSkin.Controls.MaterialLabel();
        static int item_no;
        public void saving()
        {
            con.Close();
            con.Open();
            //getting how many parts
            string getExamParts = "SELECT col_exam_parts FROM tbl_exam where  col_exam_id = " + this.Text + " ";

            MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

            int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
            getpartscmd.Dispose();
            Console.WriteLine(examPartsCount+"rxmprts");

            switch (examPartsCount)
            {
                case 1:
                    Console.WriteLine("gumana5"+ flowLayoutPanel1.Tag);
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;
                        
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    break;

                case 2:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    break;

                case 3:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    break;

                    case 4:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }


                    break;


                case 5:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag =2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    break;
                case 6:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save1(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 2)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save2(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 3)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save3(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 4)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save4(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 5)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save5(api, tag);
                        flowLayoutPanel6.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 6)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save6(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    break;


                   case 7 :
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save1(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 2)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save2(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 3)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save3(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 4)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save4(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 5)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save5(api, tag);
                        flowLayoutPanel6.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 6)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save6(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel7.Tag) == 1)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save1(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 2)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save2(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 3)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save3(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 4)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save4(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 5)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save5(api, tag);
                        flowLayoutPanel7.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 6)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save6(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }



                    break;


                case 8:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save1(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 2)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save2(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 3)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save3(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 4)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save4(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 5)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save5(api, tag);
                        flowLayoutPanel6.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 6)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save6(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel7.Tag) == 1)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save1(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 2)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save2(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 3)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save3(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 4)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save4(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 5)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save5(api, tag);
                        flowLayoutPanel7.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 6)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save6(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel8.Tag) == 1)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save1(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 2)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save2(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 3)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save3(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 4)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save4(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 5)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save5(api, tag);
                        flowLayoutPanel8.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 6)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save6(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }



                    break;


                case 9:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save1(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 2)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save2(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 3)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save3(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 4)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save4(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 5)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save5(api, tag);
                        flowLayoutPanel6.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 6)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save6(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel7.Tag) == 1)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save1(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 2)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save2(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 3)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save3(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 4)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save4(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 5)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save5(api, tag);
                        flowLayoutPanel7.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 6)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save6(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel8.Tag) == 1)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save1(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 2)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save2(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 3)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save3(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 4)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save4(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 5)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save5(api, tag);
                        flowLayoutPanel8.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 6)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save6(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel9.Tag) == 1)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save1(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 2)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save2(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 3)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save3(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 4)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save4(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 5)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save5(api, tag);
                        flowLayoutPanel9.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 6)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save6(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }



                    break;

                case 10:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save4(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 5)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save5(api, tag);
                        flowLayoutPanel1.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 6)
                    {

                        api = flowLayoutPanel1;
                        int tag = 1;
                        save6(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel2.Tag) == 1)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 2)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save2(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 3)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save3(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 4)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save4(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save5(api, tag);
                        flowLayoutPanel2.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel2.Tag) == 6)
                    {

                        api = flowLayoutPanel2;
                        int tag = 2;
                        save6(api, tag);
                        flowLayoutPanel2.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 2)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 3)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 4)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save4(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 5)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save5(api, tag);
                        flowLayoutPanel3.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel3.Tag) == 6)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save6(api, tag);
                        flowLayoutPanel3.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel4.Tag) == 1)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save1(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 2)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save2(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 3)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save3(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 4)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save4(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 5)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save5(api, tag);
                        flowLayoutPanel4.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel4.Tag) == 6)
                    {

                        api = flowLayoutPanel4;
                        int tag = 4;
                        save6(api, tag);
                        flowLayoutPanel4.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel5.Tag) == 1)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save1(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 2)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save2(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 3)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save3(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 4)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save4(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 5)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save5(api, tag);
                        flowLayoutPanel5.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel5.Tag) == 6)
                    {

                        api = flowLayoutPanel5;
                        int tag = 5;
                        save6(api, tag);
                        flowLayoutPanel5.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save1(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 2)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save2(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 3)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save3(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 4)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save4(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 5)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save5(api, tag);
                        flowLayoutPanel6.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel6.Tag) == 6)
                    {

                        api = flowLayoutPanel6;
                        int tag = 6;
                        save6(api, tag);
                        flowLayoutPanel6.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel7.Tag) == 1)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save1(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 2)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save2(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 3)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save3(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 4)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save4(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 5)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save5(api, tag);
                        flowLayoutPanel7.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel7.Tag) == 6)
                    {

                        api = flowLayoutPanel7;
                        int tag = 7;
                        save6(api, tag);
                        flowLayoutPanel7.Enabled = false;
                    }

                    if (Convert.ToInt32(flowLayoutPanel8.Tag) == 1)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save1(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 2)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save2(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 3)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save3(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 4)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save4(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 5)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save5(api, tag);
                        flowLayoutPanel8.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel8.Tag) == 6)
                    {

                        api = flowLayoutPanel8;
                        int tag = 8;
                        save6(api, tag);
                        flowLayoutPanel8.Enabled = false;
                    }


                    if (Convert.ToInt32(flowLayoutPanel9.Tag) == 1)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save1(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 2)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save2(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 3)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save3(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 4)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save4(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 5)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save5(api, tag);
                        flowLayoutPanel9.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel9.Tag) == 6)
                    {

                        api = flowLayoutPanel9;
                        int tag = 9;
                        save6(api, tag);
                        flowLayoutPanel9.Enabled = false;
                    }



                    if (Convert.ToInt32(flowLayoutPanel10.Tag) == 1)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save1(api, tag);
                        flowLayoutPanel10.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel10.Tag) == 2)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save2(api, tag);
                        flowLayoutPanel10.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel10.Tag) == 3)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save3(api, tag);
                        flowLayoutPanel10.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel10.Tag) == 4)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save4(api, tag);
                        flowLayoutPanel10.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel10.Tag) == 5)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save5(api, tag);
                        flowLayoutPanel10.Enabled = false;

                    }

                    else if (Convert.ToInt32(flowLayoutPanel10.Tag) == 6)
                    {

                        api = flowLayoutPanel10;
                        int tag = 10;
                        save6(api, tag);
                        flowLayoutPanel10.Enabled = false;
                    }


                    break;




            }

            timer1.Stop();

        }

        //

        public void generate()
        {
            try
            {
                con.Open();
                //getting how many parts
                string getExamParts = "SELECT col_exam_parts FROM tbl_exam where  col_exam_id = " + this.Text + " and col_teacher_id = " + id + "";

                MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

                int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
                getpartscmd.Dispose();


                //dividing the parts
                Console.WriteLine(examPartsCount+"");
              switch (examPartsCount)
                {
                    case 1:
                        customTabControl1.Controls.Remove(tabPage2);
                        customTabControl1.Controls.Remove(tabPage3);
                        customTabControl1.Controls.Remove(tabPage4);
                        customTabControl1.Controls.Remove(tabPage5);
                        customTabControl1.Controls.Remove(tabPage6);
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton2.Hide();
                        break;

                    case 2:
             
                        customTabControl1.Controls.Remove(tabPage3);
                        customTabControl1.Controls.Remove(tabPage4);
                        customTabControl1.Controls.Remove(tabPage5);
                        customTabControl1.Controls.Remove(tabPage6);
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton4.Hide();
                        break;


                    case 3:                    
                        customTabControl1.Controls.Remove(tabPage4);
                        customTabControl1.Controls.Remove(tabPage5);
                        customTabControl1.Controls.Remove(tabPage6);
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton7.Hide();
                        break;

                    case 4:
                      
                        customTabControl1.Controls.Remove(tabPage5);
                        customTabControl1.Controls.Remove(tabPage6);
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton20.Hide();
                        break;

                    case 5:
                   
                        customTabControl1.Controls.Remove(tabPage6);
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton8.Hide();
                        break;

                    case 6:
                      
                        customTabControl1.Controls.Remove(tabPage7);
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton10.Hide();
                        break;

                    case 7:
                        customTabControl1.Controls.Remove(tabPage8);
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton12.Hide();
                        break;

                    case 8:
                        customTabControl1.Controls.Remove(tabPage9);
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton14.Hide();
                        break;
                    case 9:
                        customTabControl1.Controls.Remove(tabPage10);
                        metroButton16.Hide();
                        break;
                    



                }

                for (int i = 1; i <= examPartsCount; i++)
                {
                    //getting how many items in part
                    if (i == 1)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question"+question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid"+questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber"+itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices"+no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }
                   
                            
                                

                            
                            //choice 1

                         
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel1.Controls.Add(panel1);
                                flowLayoutPanel1.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel1.Controls.Add(panel1);
                                flowLayoutPanel1.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19) ,ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel1.Controls.Add(panel1);

                                flowLayoutPanel1.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {
                                
                               
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item});
                                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel1.Tag = 4;
                                flowLayoutPanel1.Controls.Add(panel1);

                                
                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });
                               
                                
                                flowLayoutPanel1.Controls.Add(panel1);
                                flowLayoutPanel1.Tag = 5;
                            }


                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel1.Controls.Add(panel1);
                                flowLayoutPanel1.Tag = 6;
                            }

                            //ctr
                            a++;
                        }

                    }


                    if (i == 2)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel2.Controls.Add(panel1);

                                flowLayoutPanel2.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel2.Tag = 4;
                                flowLayoutPanel2.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 5;
                            }


                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a+1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();
                              
                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 6;
                            }

                            //ctr
                            a++;
                        }

                    }

                    if (i == 3)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel3.Controls.Add(panel1);

                                flowLayoutPanel3.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel3.Tag = 4;
                                flowLayoutPanel3.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 6;
                            }

                            //ctr
                            a++;
                        }

                    }

                    if (i == 4)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel4.Controls.Add(panel1);
                                flowLayoutPanel4.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel4.Controls.Add(panel1);
                                flowLayoutPanel4.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel4.Controls.Add(panel1);

                                flowLayoutPanel4.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel4.Tag = 4;
                                flowLayoutPanel4.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel4.Controls.Add(panel1);
                                flowLayoutPanel4.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 6;
                            }

                            //ctr
                            a++;
                        }

                    }


                    if (i == 5)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel5.Controls.Add(panel1);
                                flowLayoutPanel5.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel5.Controls.Add(panel1);
                                flowLayoutPanel5.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel5.Controls.Add(panel1);

                                flowLayoutPanel5.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel5.Tag = 4;
                                flowLayoutPanel5.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel5.Controls.Add(panel1);
                                flowLayoutPanel5.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel5.Controls.Add(panel1);
                                flowLayoutPanel5.Tag = 6;
                            }

                            //ctr
                            a++;
                        }

                    }



                    if (i == 6)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel6.Controls.Add(panel1);
                                flowLayoutPanel6.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel6.Controls.Add(panel1);
                                flowLayoutPanel6.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel6.Controls.Add(panel1);

                                flowLayoutPanel6.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel6.Tag = 4;
                                flowLayoutPanel6.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel6.Controls.Add(panel1);
                                flowLayoutPanel6.Tag = 5;
                            }
                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel6.Controls.Add(panel1);
                                flowLayoutPanel6.Tag = 6;
                            }




                            //ctr
                            a++;
                        }

                    }

                    if (i == 7)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel7.Controls.Add(panel1);
                                flowLayoutPanel7.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel7.Controls.Add(panel1);
                                flowLayoutPanel7.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel7.Controls.Add(panel1);

                                flowLayoutPanel7.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel7.Tag = 4;
                                flowLayoutPanel7.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel7.Controls.Add(panel1);
                                flowLayoutPanel7.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel7.Controls.Add(panel1);
                                flowLayoutPanel7.Tag = 6;
                            }


                            //ctr
                            a++;
                        }

                    }


                    if (i == 8)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel8.Controls.Add(panel1);
                                flowLayoutPanel8.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel8.Controls.Add(panel1);
                                flowLayoutPanel8.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel8.Controls.Add(panel1);

                                flowLayoutPanel8.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel8.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel8.Tag = 4;
                                flowLayoutPanel8.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel8.Controls.Add(panel1);
                                flowLayoutPanel8.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel8.Controls.Add(panel1);
                                flowLayoutPanel8.Tag = 6;
                            }


                            //ctr
                            a++;
                        }

                    }

                    if (i == 9)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel9.Controls.Add(panel1);
                                flowLayoutPanel9.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel9.Controls.Add(panel1);
                                flowLayoutPanel9.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel9.Controls.Add(panel1);

                                flowLayoutPanel9.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel9.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel9.Tag = 4;
                                flowLayoutPanel9.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel9.Controls.Add(panel1);
                                flowLayoutPanel9.Tag = 5;
                            }

                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel9.Controls.Add(panel1);
                                flowLayoutPanel9.Tag = 6;
                            }


                            //ctr
                            a++;
                        }

                    }


                    if (i == 10)
                    {


                        string items = "SELECT col_part_items FROM tbl_parts where col_part_no  =" + i + "  and  col_exam_id = " + this.Text + " ";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();

                        cnt.Clear();
                        //counting exams panel creation
                        for (int count = 1; count <= itemsCount; count++)
                        {
                            cnt.Add(count);
                        }
                        listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  


                            string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                            Console.WriteLine("question" + question);

                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", this.Text);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());
                            q3cmd.Dispose();

                            Console.WriteLine("questionid" + questionid);


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question_no = @item ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            Console.WriteLine("itemsnumber" + itms);



                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", this.Text);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                            Console.WriteLine("no_choices" + no_choices);

                            if (type == "Multiple Choice")
                            {
                                for (int j = 0; j < Convert.ToInt32(no_choices); j++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno  and col_item_id = @item  limit " + j + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string answer1 = Convert.ToString(a3cmd.ExecuteScalar());
                                    choice.Add(answer1);
                                }

                            }





                            //choice 1


                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = choice[0] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = choice[1] });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = choice[2] });
                                if (no_choices == "4")
                                {

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                }
                                else if (no_choices == "5")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = choice[3] });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = choice[4] });



                                }

                                flowLayoutPanel10.Controls.Add(panel1);
                                flowLayoutPanel10.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                //choices


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel10.Controls.Add(panel1);
                                flowLayoutPanel10.Tag = 2;
                            }
                            else if (type == "true or false")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.Red, Font = new Font("Calibri", 12.0f) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.Red });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.Red });


                                flowLayoutPanel10.Controls.Add(panel1);

                                flowLayoutPanel10.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {


                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item });
                                flowLayoutPanel10.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel10.Tag = 4;
                                flowLayoutPanel10.Controls.Add(panel1);


                            }
                            else if (type == "Enumeration")
                            {
                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 150), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                //choices
                                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                                enumerate.Size = new Size(585, 80);
                                enumerate.Location = new Point(65, 50);
                                enumerate.BackColor = Color.GhostWhite;
                                enumerate.FlowDirection = FlowDirection.LeftToRight;
                                enumerate.AutoScroll = true;
                                for (int x = 0; x < Convert.ToInt32(no_choices); x++)
                                {

                                    enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });

                                }


                                panel1.Controls.Add(enumerate);

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 150), Location = new Point(0, 0) });


                                flowLayoutPanel10.Controls.Add(panel1);
                                flowLayoutPanel10.Tag = 5;
                            }
                            else if (type == "Essay")
                            {



                                //enurows
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 200), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200, Text = question });
                                // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                                // panel1.Controls.Add(new )
                                TextBox tb = new TextBox();

                                tb.Location = new Point(25, 45);
                                tb.Size = new Size(680, 100);
                                tb.Text = "    ";
                                tb.Font = new Font("Calibri", 12.0f);
                                tb.BackColor = Color.LightCyan;
                                tb.Multiline = true;
                                tb.Tag = 101;
                                panel1.Controls.Add(tb);

                                flowLayoutPanel10.Controls.Add(panel1);
                                flowLayoutPanel10.Tag = 6;
                            }


                            //ctr
                            a++;
                        }

                    }





                }

            }

            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        //
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
























              
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hours == 0 && minutes == 0 && seconds == 0)// on here we chack if the time is up and we add some stuff on times up
            {

                timer1.Stop();
                MessageBox.Show(new Form() { TopMost = true }, "Times up!!! ", "Press OK to Continue :P", MessageBoxButtons.OK, MessageBoxIcon.Information);

                a.Text = "00";
                b.Text = "00";
                d.Text = "00";

                saving();
                this.Hide();
                return;
            }
            else
            {

                if (seconds < 1)// here is the most important code (dont forget to change the timer to 1000 milliseconds)!!! first we check if the secs are smaller than 1
                {
                    seconds = 59;// on here we make the secs to 59 if it is smaller than 1
                    if (minutes < 1)// here we check if the minutes are smaller than 1
                    {
                        minutes = 59;// on here we make the mins to 59 if it is smaller than 1
                        if (hours != 0)// on here we check if the hours are different from 0
                            hours -= 1;// on here we remove from the current hour the number 1. its the same if we write hours = hours - 1;
                    }
                    else minutes -= 1;// on here we remove fro mthe current mins 1

                }
                else seconds -= 1;// and here we do the same with the seconds
                if (hours > 9)// and on this stage we add the numbers on the labels
                {

                    a.Text = hours.ToString();
                }
                else
                {
                    a.Text = "0" + hours.ToString();
                }
                if (minutes > 9)
                {
                    b.Text = minutes.ToString();
                }

                else
                {
                    b.Text = "0" + minutes.ToString();
                }
                if (seconds > 9)
                {
                    d.Text = seconds.ToString();
                }

                else
                {
                    d.Text = "0" + seconds.ToString();
                }



            }
        }

        private void metroScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel2.AutoScrollPosition = new Point(flowLayoutPanel2.AutoScrollPosition.X, e.NewValue);
        }

        private void metroScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel3.AutoScrollPosition = new Point(flowLayoutPanel3.AutoScrollPosition.X, e.NewValue);
        }

        private void metroScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel4.AutoScrollPosition = new Point(flowLayoutPanel4.AutoScrollPosition.X, e.NewValue);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(1);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(0);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(2);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(3);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to submit this?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                saving();
                this.Hide();


                con.Close();
                con.Open();

                string sqlstatement1 = "SELECT ( sum(score)/col_no_of_exams * 50+ 50) as 'Grade'  FROM `student_records`  inner join tbl_exam USING (col_teacher_id,col_exam_id,col_exam_name) where stud_id = " + stid + " and col_exam_id =  " + exmid + " GROUP BY col_teacher_id , col_exam_id , stud_id";
                MySqlCommand cmd51 = new MySqlCommand(sqlstatement1, con);
                int exam = Convert.ToInt32(cmd51.ExecuteScalar());
                con.Close();
                Console.WriteLine(exam + "exam");
                results rs = new results(Convert.ToDouble(exam));
                rs.Show();

                //eto ung email 
                // email(exam,exnamee.Text);

            }

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(2);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(2);
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(1);
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(5);
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(4);
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(3);
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(0);
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(2);
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(1);
        }

        private void metroButton7_Click_1(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(3);
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(4);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(5);
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(6);
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(7);
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(6);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(8);
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(7);
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(9);
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectTab(8);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.NewValue);
        }
    }


   
}
