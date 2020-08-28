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
    public partial class studentrecord : Form
    {
        public static string constring = "server= localhost;user=rooot;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
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
                    MessageBox.Show("already take exam");
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




                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                    if (rb.Checked == true)
                                    {
                                        answer = rb.Text;

                                    }
                                    else

                                    {



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


                                string check3 = "SELECT col_question_answer from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                                checkcmd3.Dispose();

                                int score = 0;
                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    con.Open();
                                    string ans3 = "SELECT col_part_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
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



                    MessageBox.Show("already take exam");
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
                                    string str = tf.Text;




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


                                    }
                                }














                            }



                            try
                    {

                        con.Close();
                        con.Open();


                        string check3 = "SELECT col_question_answer from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                        checkcmd3.Dispose();

                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_part_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
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

                            string str = st.Text;

                            q = str;
                            item_no = Convert.ToInt32(st.Tag);

                        }
                        if (d is MaterialSkin.Controls.MaterialRadioButton)
                        {

                            rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                            if (rb.Checked == true)
                            {
                                answer = rb.Text;
                            }


                        }














                    }


                    try
                    {

                        con.Close();
                        con.Open();


                        string check3 = "SELECT col_question_answer from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                        checkcmd3.Dispose();

                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_part_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
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
        PictureBox pb2 = new PictureBox();
        public static string filename;
        MaterialSkin.Controls.MaterialSingleLineTextField st3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
        public void save4(dynamic p, int a)
        {

            MessageBox.Show("save4");
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
                            string q = st3.Text;
                            answer = q;
                            item_no = Convert.ToInt32(st3.Tag);
                        }



                    }

                    try
                    {

                        con.Close();
                        con.Open();


                        string check3 = "SELECT col_question_answer from tbl_question where  col_exam_id = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + " and col_question_no = " + item_no + "";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                        checkcmd3.Dispose();

                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT col_part_points from tbl_parts where col_exam_id   = " + Convert.ToInt32(this.Text) + " and col_part_no = " + a + "";
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


        public studentrecord(string exam_id, int teacher_id, int student_id)
        {


            InitializeComponent();
           
        
            this.Text = exam_id;
            stud_id = student_id;
            id = teacher_id;
            con.Open();
            string gex = "SELECT exam_name FROM exams where teacher_id = @t_id  AND exam_id = @exam_id";
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

            a.Hide();
            label5.Hide();
            b.Hide();
            label1.Hide();
            label6.Hide();
            d.Hide();

            generate();   
          //  getime();
            //timer1.Start();


        }
        //

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
                if (mins["duration_mins"] != DBNull.Value)
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


            switch (examPartsCount)
            {
                case 1:

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
                    break;

                case 3:
                    if (Convert.ToInt32(flowLayoutPanel1.Tag) == 1)
                    {

                        api = flowLayoutPanel1;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 2)
                    {

                        api = flowLayoutPanel1;
                        int tag = 3;
                        save2(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }
                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 3)
                    {

                        api = flowLayoutPanel1;
                        int tag = 3;
                        save3(api, tag);
                        flowLayoutPanel1.Enabled = false;
                    }

                    else if (Convert.ToInt32(flowLayoutPanel1.Tag) == 4)
                    {

                        api = flowLayoutPanel1;
                        int tag = 3;
                        save4(api, tag);
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

                    break;

                default:
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
                    if (Convert.ToInt32(flowLayoutPanel3.Tag) == 1)
                    {

                        api = flowLayoutPanel3;
                        int tag = 3;
                        save1(api, tag);
                        flowLayoutPanel2.Enabled = false;
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

                    break;
            }

        }

        //
        Color col = ColorTranslator.FromHtml("#0F6C4F");
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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  
                            
                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());
                     

                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White,Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White});

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.Black, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel1.Controls.Add(panel1);
                                flowLayoutPanel1.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White,Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a+1) +":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White,Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White,Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel1.Controls.Add(panel1);

                                flowLayoutPanel1.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {
                          
                                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel1.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer , Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel1.Controls.Add(panel1);



                                flowLayoutPanel1.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 2)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel2.Controls.Add(panel1);

                                flowLayoutPanel2.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                              
                                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel2.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel2.Controls.Add(panel1);



                                flowLayoutPanel2.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 3)
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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel3.Controls.Add(panel1);

                                flowLayoutPanel3.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                               
                                flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel3.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel3.Controls.Add(panel1);



                                flowLayoutPanel3.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 4)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel4.Controls.Add(panel1);
                                flowLayoutPanel4.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel4.Controls.Add(panel1);

                                flowLayoutPanel4.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                               
                                flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel4.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel4.Controls.Add(panel1);



                                flowLayoutPanel4.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }



                    else if (i == 5)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel5.Controls.Add(panel1);
                                flowLayoutPanel5.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel5.Controls.Add(panel1);

                                flowLayoutPanel5.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                              
                                flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel5.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel5.Controls.Add(panel1);



                                flowLayoutPanel5.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 6)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel6.Controls.Add(panel1);
                                flowLayoutPanel6.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel6.Controls.Add(panel1);

                                flowLayoutPanel6.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                             
                                flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel6.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel6.Controls.Add(panel1);



                                flowLayoutPanel6.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 7)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel7.Controls.Add(panel1);
                                flowLayoutPanel7.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel7.Controls.Add(panel1);

                                flowLayoutPanel7.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                              
                                flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel7.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel7.Controls.Add(panel1);



                                flowLayoutPanel7.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 8)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel8.Controls.Add(panel1);
                                flowLayoutPanel8.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel8.Controls.Add(panel1);

                                flowLayoutPanel8.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                               
                                flowLayoutPanel8.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel8.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel8.Controls.Add(panel1);



                                flowLayoutPanel8.Tag = 4;
                            }

                            //ctr
                            a++;
                        }

                    }

                    else if (i == 9)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel9.Controls.Add(panel1);
                                flowLayoutPanel9.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel9.Controls.Add(panel1);

                                flowLayoutPanel9.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                              
                                flowLayoutPanel9.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel9.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel9.Controls.Add(panel1);



                                flowLayoutPanel9.Tag = 4;
                            }



                            //ctr
                            a++;
                        }

                    }


                    else if (i == 10)

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
                        //listint(cnt);
                        int a = 0;
                        while ((a + 1) <= itemsCount)
                        {

                            int item = cnt[a];

                            choice.Clear();
                            //question  

                            string q1 = "SELECT col_question FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question_no = @item  order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);

                            string question = Convert.ToString(q1cmd.ExecuteScalar());


                            string itm = "SELECT col_question_no FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id  and col_question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            con.Close();
                            con.Open();
                            string a1 = "SELECT col_question_answer from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();

                            con.Close();
                            con.Open();
                            string a2 = "SELECT answer FROM student_records where part_no = @partno AND col_exam_id = @exam_id and item_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer2 = Convert.ToString(a2cmd.ExecuteScalar());
                            a2cmd.Dispose();
                            choice.Add(answer);
                            //choice 1
                            con.Close();
                            con.Open();
                            string c1 = "SELECT col_choice1 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "'  ";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2
                            con.Close();
                            con.Open();
                            string c2 = "SELECT col_choice2 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            con.Close();
                            con.Open();
                            string c3 = "SELECT col_choice3 FROM tbl_question where col_part_no = @partno AND col_exam_id = @exam_id and col_question = '" + question + "' ";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1
                            list(choice);


                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                if (answer == choice[0])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[1])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[2])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White, Checked = true });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White });


                                }

                                if (answer == choice[3])
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2], ForeColor = Color.White });

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3], ForeColor = Color.White, Checked = true });


                                }


                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = Color.WhiteSmoke, Size = new Size(10, 120), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel10.Controls.Add(panel1);
                                flowLayoutPanel10.Tag = 1;

                                choice.Clear();

                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 120), Location = new Point(10, item * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question, ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:", ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, ForeColor = Color.White, Text = answer2 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19), ForeColor = Color.White });
                                //choices

                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(250, 90), Size = new Size(380, 20), ForeColor = Color.Black });
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
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 10), Size = new Size(15, 19), ForeColor = Color.White });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question, ForeColor = Color.White });

                                if (answer2 == "True")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White });

                                }

                                else if (answer2 == "False")
                                {
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19), ForeColor = Color.White });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19), ForeColor = Color.White, Checked = true });

                                }



                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(200, 100), Size = new Size(380, 20), ForeColor = Color.Black });

                                flowLayoutPanel10.Controls.Add(panel1);

                                flowLayoutPanel10.Tag = 3;

                            }

                            else if (type == "Photo Guest")
                            {

                            
                                flowLayoutPanel10.FlowDirection = FlowDirection.TopDown;
                                flowLayoutPanel10.Tag = 4;
                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.FromArgb(228, 228, 230) };
                                panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(370, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Location = new Point(5, 190), Size = new Size(380, 20), Tag = item, Text = answer2 });
                                panel1.Controls.Add(new Label { Text = "CORRECT ANSWER: " + answer, Location = new Point(5, 215), Size = new Size(380, 20), ForeColor = Color.Black });


                                flowLayoutPanel10.Controls.Add(panel1);



                                flowLayoutPanel10.Tag = 4;
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
                MessageBox.Show(new Form() { TopMost = true }, "Times up!!! :P", "Will you press OK? :P", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                else {
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
            
            this.Hide();
            return;
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

        private void metroButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exnamee_Click(object sender, EventArgs e)
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
