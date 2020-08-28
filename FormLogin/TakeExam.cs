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
    public partial class TakeExam : MaterialSkin.Controls.MaterialForm
    {
        public static string constring = "server= 192.168.0.13;user=monty;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring);
        static int id;
        static int stud_id;
        int hours, minutes, seconds;
        public static dynamic api;
        public static dynamic api2;
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



                MySqlCommand update2 = new MySqlCommand("select * from student_records where exam_id= @exam_id and part_no = @part and teacher_id = " + id + " and stud_id = " + stud_id + "", con);

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



                            con.Close();
                            con.Open();
                            string check = "SELECT answer from questions where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + " and item_no = " + item_no + "";
                            MySqlCommand checkcmd = new MySqlCommand(check, con);

                            string anscheck = Convert.ToString(checkcmd.ExecuteScalar());
                            checkcmd.Dispose();

                            int score = 0;
                            if (anscheck == answer)
                            {
                                con.Close();
                                con.Open();
                                string ans = " SELECT points_per_item from exam_parts where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + "";
                                MySqlCommand anscheckcmd = new MySqlCommand(ans, con);

                                score = Convert.ToInt32(anscheckcmd.ExecuteScalar());
                                anscheckcmd.Dispose();


                            }


                            con.Close();
                            con.Open();
                            string ename = " SELECT exam_name from exams where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " ";
                            MySqlCommand enamecmd = new MySqlCommand(ename, con);
                            string examname = Convert.ToString(enamecmd.ExecuteScalar());
                            enamecmd.Dispose();




                            con.Close();
                            con.Open();
                            string save2 = "insert into student_records(teacher_id,exam_id,exam_name,stud_id,part_no,item_no,answer,score) " +
    "values(@teacher_id,@exam_id,@exam_name,@student_id,@part,@item,@answer,@score)";
                            MySqlCommand save2cmd = new MySqlCommand(save2, con);
                            save2cmd.Parameters.AddWithValue("@score", score);
                            save2cmd.Parameters.AddWithValue("@exam_name", examname);
                            save2cmd.Parameters.AddWithValue("@student_id", stud_id);
                            save2cmd.Parameters.AddWithValue("@teacher_id", id);
                            save2cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            save2cmd.Parameters.AddWithValue("@part", a);
                            save2cmd.Parameters.AddWithValue("@item", item_no);
                            save2cmd.Parameters.AddWithValue("@answer", answer);

                            save2cmd.ExecuteNonQuery();
                            save2cmd.Dispose();





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

                MySqlCommand update3 = new MySqlCommand("select * from student_records where exam_id= @exam_id and part_no =@part and teacher_id = " + id + " and stud_id = " + stud_id + "", con);
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


                                string check3 = "SELECT answer from questions where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + " and item_no = " + item_no + "";
                                MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                                string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                                checkcmd3.Dispose();

                                int score = 0;
                                con.Close();
                                if (anscheck3 == answer)
                                {

                                    con.Open();
                                    string ans3 = "SELECT points_per_item from exam_parts where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + "";
                                    MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                                    score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                                    anscheckcmd3.Dispose();


                                }


                                con.Close();
                                con.Open();
                                string ename = " SELECT exam_name from exams where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " ";
                                MySqlCommand enamecmd = new MySqlCommand(ename, con);
                                string examname = Convert.ToString(enamecmd.ExecuteScalar());
                                enamecmd.Dispose();



                                con.Close();
                                con.Open();

                                string sqlstatement = "insert into student_records(teacher_id,exam_id,exam_name,stud_id,part_no,item_no,answer,score) " +
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

                                MessageBox.Show("its working");
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


                        string check3 = "SELECT answer from questions where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + " and item_no = " + item_no + "";
                        MySqlCommand checkcmd3 = new MySqlCommand(check3, con);

                        string anscheck3 = Convert.ToString(checkcmd3.ExecuteScalar());
                        checkcmd3.Dispose();

                        int score = 0;
                        con.Close();
                        if (anscheck3 == answer)
                        {

                            con.Open();
                            string ans3 = "SELECT points_per_item from exam_parts where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " and part_no = " + a + "";
                            MySqlCommand anscheckcmd3 = new MySqlCommand(ans3, con);

                            score = Convert.ToInt32(anscheckcmd3.ExecuteScalar());
                            anscheckcmd3.Dispose();


                        }


                        con.Close();
                        con.Open();
                        string ename = " SELECT exam_name from exams where teacher_id = " + id + " and exam_id = " + Convert.ToInt32(this.Text) + " ";
                        MySqlCommand enamecmd = new MySqlCommand(ename, con);
                        string examname = Convert.ToString(enamecmd.ExecuteScalar());
                        enamecmd.Dispose();



                        con.Close();
                        con.Open();

                        string sqlstatement = "insert into student_records(teacher_id,exam_id,exam_name,stud_id,part_no,item_no,answer,score) " +
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

                        MessageBox.Show("its working" + q + answer);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("eerror" + ex);
                    }








                }


            }

        }
        public void ins1()
        {
            con.Open();
            MySqlCommand update = new MySqlCommand("select Instructions from exam_parts where exam_id= @exam_id and part_no =@part and teacher_id = " + id + "", con);
            update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
            update.Parameters.AddWithValue("@part", 1);

            MySqlDataReader dr = update.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Instructions"] != DBNull.Value)
                {


                    var myString = dr.GetString(0);

                    materialLabel1.Text = myString;
                }
                else
                {

                }
            }
            con.Close();
        }

        public void ins2()
        {
            con.Open();
            MySqlCommand update = new MySqlCommand("select Instructions from exam_parts where exam_id= @exam_id and part_no =@part and teacher_id = " + id + "", con);
            update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
            update.Parameters.AddWithValue("@part", 2);

            MySqlDataReader dr = update.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Instructions"] != DBNull.Value)
                {


                    var myString = dr.GetString(0);

                    materialLabel2.Text = myString;
                }
                else
                {

                }
            }
            con.Close();
        }

        public void ins3()
        {
            con.Open();
            MySqlCommand update = new MySqlCommand("select Instructions from exam_parts where exam_id= @exam_id and part_no =@part and teacher_id = " + id + "", con);
            update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
            update.Parameters.AddWithValue("@part", 3);

            MySqlDataReader dr = update.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Instructions"] != DBNull.Value)
                {


                    var myString = dr.GetString(0);

                    materialLabel3.Text = myString;
                }
                else
                {

                }
            }
            con.Close();
        }

        public void ins4()
        {
            con.Open();
            MySqlCommand update = new MySqlCommand("select Instructions from exam_parts where exam_id= @exam_id and part_no =@part and teacher_id = " + id + "", con);
            update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
            update.Parameters.AddWithValue("@part", 4);

            MySqlDataReader dr = update.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Instructions"] != DBNull.Value)
                {


                    var myString = dr.GetString(0);

                    materialLabel4.Text = myString;
                }
                else
                {

                }
            }

            con.Close();
        }

        public void getime()
        {
            con.Close();
            con.Open();
            MySqlCommand hr = new MySqlCommand("select duration_hrs from exams where exam_id= @exam_id and teacher_id = " + id + "", con);
            hr.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));


            MySqlDataReader hrs = hr.ExecuteReader();

            while (hrs.Read())
            {
                if (hrs["duration_hrs"] != DBNull.Value)
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
            MySqlCommand min = new MySqlCommand("select duration_mins from exams where exam_id= @exam_id and teacher_id = " + id + "", con);
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

        public TakeExam(string exam_id, int teacher_id, int student_id)
        {
            InitializeComponent();
            this.Text = exam_id;
            stud_id = student_id;
            id = teacher_id;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TakeExam_Load(object sender, EventArgs e)
        {
            generate();
            ins1();
            ins2();
            ins3();
            ins4();
            getime();
            timer1.Start();

        }

        public void generate()
        {
            try
            {
                con.Open();
                //getting how many parts
                string getExamParts = "SELECT parts FROM exams where  exam_id = " + this.Text + " and teacher_id = " + id + "";

                MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

                int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
                getpartscmd.Dispose();


                //dividing the parts

                switch (examPartsCount)
                {
                    case 1:
                        tabControl1.Controls.Remove(tabPage2);
                        tabControl1.Controls.Remove(tabPage3);
                        tabControl1.Controls.Remove(tabPage4);
                        break;

                    case 2:

                        tabControl1.Controls.Remove(tabPage3);
                        tabControl1.Controls.Remove(tabPage4);
                        break;

                    case 3:

                        tabControl1.Controls.Remove(tabPage4);
                        break;


                }

                for (int i = 1; i <= examPartsCount; i++)
                {
                    //getting how many items in part
                    if (i == 1)
                    {


                        string items = "SELECT items FROM exam_parts where part_no=" + i + "  and  exam_id = " + this.Text + " and teacher_id = " + id + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT exam_type FROM exam_parts where part_no = @partno AND exam_id = @exam_id and teacher_id = " + id + "";
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

                            string q1 = "SELECT question FROM questions where part_no = @partno AND exam_id = @exam_id and item_no = @item and  teacher_id = " + id + " order by rand() ";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string question = Convert.ToString(q1cmd.ExecuteScalar());
                            //

                            string itm = "SELECT item_no FROM questions where part_no = @partno AND exam_id = @exam_id and  teacher_id = " + id + " and question = '" + question + "' ";
                            MySqlCommand itmcmd = new MySqlCommand(itm, con);
                            itmcmd.Parameters.AddWithValue("@item", item);
                            itmcmd.Parameters.AddWithValue("@partno", i);
                            itmcmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string itms = Convert.ToString(itmcmd.ExecuteScalar());
                            //answer

                            string a1 = "SELECT answer FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "' and teacher_id = " + id + "";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());


                            choice.Add(answer);
                            //choice 1

                            string c1 = "SELECT choice_1 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2

                            string c2 = "SELECT choice_2 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            string c3 = "SELECT choice_3 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
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



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3] });


                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
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

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:" });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19) });
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

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                flowLayoutPanel1.Controls.Add(panel1);

                                flowLayoutPanel1.Tag = 3;

                            }



                            //ctr
                            a++;
                        }

                    }

                    else if (i == 2)
                    {
                        choice.Clear();


                        string items = "SELECT items FROM exam_parts where part_no=" + i + "  and  exam_id = " + this.Text + " and teacher_id = " + id + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT exam_type FROM exam_parts where part_no = @partno AND exam_id = @exam_id and teacher_id = " + id + "";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();
                        //counting exams panel creation

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
                            choice.Clear();
                            string q1 = "SELECT question FROM questions where part_no = @partno AND exam_id = @exam_id and item_no = @item and teacher_id = " + id + " order by rand()";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string question = Convert.ToString(q1cmd.ExecuteScalar());

                            //answer

                            string a1 = "SELECT answer FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());
                            choice.Add(answer);
                            //choice 1

                            string c1 = "SELECT choice_1 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2

                            string c2 = "SELECT choice_2 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            string c3 = "SELECT choice_3 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
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



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel2.Controls.Add(panel1);
                                flowLayoutPanel2.Tag = 1;


                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:" });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19) });
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

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                flowLayoutPanel2.Controls.Add(panel1);

                                flowLayoutPanel2.Tag = 3;

                            }




                            a++;
                        }

                    }

                    else if (i == 3)
                    {
                        choice.Clear();


                        string items = "SELECT items FROM exam_parts where part_no=" + i + "  and  exam_id = " + this.Text + " and teacher_id = " + id + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT exam_type FROM exam_parts where part_no = @partno AND exam_id = @exam_id and teacher_id = " + id + "";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();
                        //counting exams panel creation

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
                            string q1 = "SELECT question FROM questions where part_no = @partno AND exam_id = @exam_id and item_no = @item and teacher_id = " + id + " order by rand()";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string question = Convert.ToString(q1cmd.ExecuteScalar());

                            //answer

                            string a1 = "SELECT answer FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());
                            choice.Add(answer);
                            //choice 1

                            string c1 = "SELECT choice_1 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2

                            string c2 = "SELECT choice_2 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            string c3 = "SELECT choice_3 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1

                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel3.Controls.Add(panel1);
                                flowLayoutPanel3.Tag = 1;


                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:" });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19) });
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

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                flowLayoutPanel3.Controls.Add(panel1);

                                flowLayoutPanel3.Tag = 3;

                            }




                            a++;
                        }

                    }

                    else if (i == 4)
                    {
                        choice.Clear();


                        string items = "SELECT items FROM exam_parts where part_no=" + i + "  and  exam_id = " + this.Text + " and teacher_id = " + id + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                        itemscmd.Dispose();

                        //getting exam type


                        string examtype = "SELECT exam_type FROM exam_parts where part_no = @partno AND exam_id = @exam_id and teacher_id = " + id + "";
                        MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                        examtypecmd.Parameters.AddWithValue("@partno", i);
                        examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                        string type = Convert.ToString(examtypecmd.ExecuteScalar());

                        examtypecmd.Dispose();
                        //counting exams panel creation
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
                            string q1 = "SELECT question FROM questions where part_no = @partno AND exam_id = @exam_id and item_no = @item and teacher_id = " + id + " order by rand()";
                            MySqlCommand q1cmd = new MySqlCommand(q1, con);
                            q1cmd.Parameters.AddWithValue("@item", item);
                            q1cmd.Parameters.AddWithValue("@partno", i);
                            q1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string question = Convert.ToString(q1cmd.ExecuteScalar());

                            //answer

                            string a1 = "SELECT answer FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());
                            choice.Add(answer);
                            //choice 1

                            string c1 = "SELECT choice_1 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c1cmd = new MySqlCommand(c1, con);
                            c1cmd.Parameters.AddWithValue("@item", item);
                            c1cmd.Parameters.AddWithValue("@partno", i);
                            c1cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice1 = Convert.ToString(c1cmd.ExecuteScalar());
                            choice.Add(choice1);
                            //choice 2

                            string c2 = "SELECT choice_2 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c2cmd = new MySqlCommand(c2, con);
                            c2cmd.Parameters.AddWithValue("@item", item);
                            c2cmd.Parameters.AddWithValue("@partno", i);
                            c2cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice2 = Convert.ToString(c2cmd.ExecuteScalar());
                            choice.Add(choice2);
                            //choice 3
                            string c3 = "SELECT choice_3 FROM questions where part_no = @partno AND exam_id = @exam_id and question = '" + question + "'  and teacher_id = " + id + "";
                            MySqlCommand c3cmd = new MySqlCommand(c3, con);
                            c3cmd.Parameters.AddWithValue("@item", item);
                            c3cmd.Parameters.AddWithValue("@partno", i);
                            c3cmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string choice3 = Convert.ToString(c3cmd.ExecuteScalar());
                            choice.Add(choice3);
                            //creating  panel 1

                            if (type == "Multiple Choice")
                            {



                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });

                                //choices
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(100, 60), Size = new Size(132, 19), Text = choice[0] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(255, 60), Size = new Size(132, 19), Text = choice[1] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(390, 60), Size = new Size(132, 19), Text = choice[2] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(525, 60), Size = new Size(132, 19), Text = choice[3] });

                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                button.Text = "Edit";
                                button.Tag = item.ToString();
                                button.Location = new Point(650, 40);
                                button.Size = new Size(98, 23);


                                flowLayoutPanel4.Controls.Add(panel1);
                                flowLayoutPanel4.Tag = 1;


                            }

                            else if (type == "Identification")
                            {

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = (a + 1) + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(50, 20), Size = new Size(800, 23), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:" });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101 });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19) });
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

                                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                flowLayoutPanel4.Controls.Add(panel1);

                                flowLayoutPanel4.Tag = 3;

                            }




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
        public static MaterialSkin.Controls.MaterialRadioButton rb = new MaterialSkin.Controls.MaterialRadioButton();
        public static MaterialSkin.Controls.MaterialLabel lb = new MaterialSkin.Controls.MaterialLabel();
        static int item_no;
        public void saving()
        {
            con.Close();
            con.Open();
            //getting how many parts
            string getExamParts = "SELECT parts FROM exams where  exam_id = " + this.Text + " and teacher_id = " + id + "";

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

                    break;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hours == 0 && minutes == 0 && seconds == 0)// on here we chack if the time is up and we add some stuff on times up
            {
                timer1.Stop();
                MessageBox.Show(new Form() { TopMost = true }, "Times up!!! :P", "Will you press OK? :P", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblHr.Text = "00";
                lblMin.Text = "00";
                lblSec.Text = "00";

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
                    lblHr.Text = hours.ToString();
                else lblHr.Text = "0" + hours.ToString();
                if (minutes > 9)
                    lblMin.Text = minutes.ToString();
                else lblMin.Text = "0" + minutes.ToString();
                if (seconds > 9)
                    lblSec.Text = seconds.ToString();
                else lblSec.Text = "0" + seconds.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            saving();
            this.Hide();
            return;
        }

        static string answer = "";
        static string q = "";


    }
}
