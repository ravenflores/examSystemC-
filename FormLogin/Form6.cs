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
    public partial class  Form6 : MaterialSkin.Controls.MaterialForm
    {
       static int examid = 0;
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring2);

        string currentuser;
        string currentpass;
        public Form6(int a,string user,string pass)
        {
            InitializeComponent();

            examid = a;
            Text = "100";
            this.Tag = user;

            currentuser = user;
            currentpass = pass;

        }
        //controls
        public static int b1;
        public static int b2;
        public static dynamic api;
        public static dynamic api2;




        //controls
        public static MaterialSkin.Controls.MaterialRadioButton rb = new MaterialSkin.Controls.MaterialRadioButton();
        public static MaterialSkin.Controls.MaterialLabel lb = new MaterialSkin.Controls.MaterialLabel();
        public static PictureBox pb = new PictureBox();
        public static int item_no;
        public static int no_ch;
        public static string answer = "";
        public static string q = "";
        static byte[] imgs;
        PictureBox pb2 = new PictureBox();
        List<string> list = new List<string>();
        MaterialSkin.Controls.MaterialRaisedButton rb2 = new MaterialSkin.Controls.MaterialRaisedButton();
        MaterialSkin.Controls.MaterialSingleLineTextField st3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
        MaterialSkin.Controls.MaterialDivider td3 = new MaterialSkin.Controls.MaterialDivider();
        MaterialSkin.Controls.MaterialRaisedButton rb4 = new MaterialSkin.Controls.MaterialRaisedButton();
        MaterialSkin.Controls.MaterialSingleLineTextField mtf = new MaterialSkin.Controls.MaterialSingleLineTextField();
        string mf;
        int tempnud = 1;
        public void save(dynamic p, Button b)
        {
            Button btn = (Button)b;
            FlowLayoutPanel flp = (FlowLayoutPanel)p;
            if (Convert.ToInt32(flp.Tag) == 1)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);//part no
                save1(api, tag);
                //flp.Enabled = false;
            }
            else if (Convert.ToInt32(flp.Tag) == 2)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);
                save2(api, tag);
                //flp.Enabled = false;
            }

            else if (Convert.ToInt32(flp.Tag) == 3)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);
                save3(api, tag);
                //flp.Enabled = false;
            }

            else if (Convert.ToInt32(flp.Tag) == 4)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);
                save4(api, tag);
                //flp.Enabled = false;
            }

            else if (Convert.ToInt32(flp.Tag) == 5)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);
                save5(api, tag);
                //flp.Enabled = false;
            }


            else if (Convert.ToInt32(flp.Tag) == 6)
            {
                api = flp;
                int tag = Convert.ToInt32(btn.Tag);
                save6(api, tag);
                //flp.Enabled = false;
            }
            


        }
        public void save1(dynamic p, int a)
        {

            try
            {
                //a is ung part id nya
                con.Close();
                con.Open();




                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
                {
                    list.Clear();
                    con.Close();
                    con.Open();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {
                            list.Clear();
                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {

                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }


                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
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


                                    else if (rb.Checked == true)
                                    {
                                        answer = str;
                                        Console.WriteLine("sagot" + answer);
                                        list.Add(answer);

                                    }
                                    else
                                    {
                                        list.Add(str);
                                    }



                                }















                            }
                            // 


                            
                            string q4 = "SELECT tbl_question.col_part_id FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            MySqlCommand q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string partid = Convert.ToString(q4cmd.ExecuteScalar());
                            Console.WriteLine(partid + "partid");
                            q4cmd.Dispose();



                            q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                            Console.WriteLine(quesid + "questionid");
                            q4cmd.Dispose();

                            Console.WriteLine("listcnt" + list.Count);

                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);



                                string sqlstatement = "delete from tbl_choices  where col_exam_id = @exam_id and col_part_id =@part and col_item_id = @item and col_item_id = @item";

                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);//part ng id
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", quesid);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 0;
                                if (list[j] == answer)
                                {
                                    right = 1;

                                }

                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.Parameters.AddWithValue("@qid", quesid);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();



                            }

                            list.Clear();
                            no_ch = 0;

                        }


                    }


                    con.Close();
                    con.Dispose();
                    con.Open();
                    list.Clear();
                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }

                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
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

                                    else if (rb.Checked == true)
                                    {
                                        answer = str;
                                        Console.WriteLine("sagot" + answer);
                                        list.Add(answer);
                                    }
                                    else
                                    {
                                        list.Add(str);
                                    }




                                }










                            }


                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            ////////////////////////////////////////////////////////////////////////////////done
                            string updating = "update tbl_question set col_question = @question where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item ";

                            MySqlCommand upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();

                            ////

                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);


                                sqlstatement = "SELECT count(*) FROM tbl_choices";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("id" + id2);
                                cmd.Dispose();

                                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                 "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                                cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 0;
                                Console.WriteLine(list[j] + "list");
                                Console.WriteLine(answer + "ANS");
                                if (list[j] == answer)
                                {
                                    right = 1;

                                }

                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();



                            }



                            ////

                            list.Clear();
                            no_ch = 0;


                        }


                    }



                }

                else
                {

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
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }

                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                }
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

                                    else if (rb.Checked == true)
                                    {
                                        answer = str;
                                        Console.WriteLine("sagot" + answer);
                                        list.Add(answer);

                                    }
                                    else
                                    {
                                        list.Add(str);
                                    }




                                }










                            }

                            //ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();




                            ////////////////////////////////////////////////////////////////////////////////done

                            sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices) " +
                              "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            ////

                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);

                                sqlstatement = "SELECT count(*) FROM tbl_choices";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("id" + id2);
                                cmd.Dispose();

                                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                 "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                                cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 0;
                                if (list[j] == answer)
                                {
                                    right = 1;

                                }

                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();



                            }



                            ////

                            list.Clear();
                            no_ch = 0;


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

        public void addTab()
        {
            TabPage tb = new TabPage();

            tb.Tag = tabControl1.Controls.Count + 1;
            Console.WriteLine("addtag"+tb.Tag);

            Label lb = new Label();

            lb.Text = "Select Exam Type:";
            lb.Size = new Size(101, 13);
            lb.Location = new Point(29, 24);

            Label lb2 = new Label();
            lb2.Text = "No Of Items:";
            lb2.Size = new Size(66, 13);
            lb2.Location = new Point(346, 24);

            NumericUpDown nud = new NumericUpDown();
            nud.Minimum = 1;
            nud.Maximum = 20;
            nud.Size = new Size(62, 20);
            nud.Location = new Point(427, 21);
            nud.Tag = "b";

            Label lb3 = new Label();
            lb3.Text = "Points Per Item:";
            lb3.Size = new Size(84, 13);
            lb3.Location = new Point(572, 26);

            Label lb4 = new Label();
            lb4.Text = "Set Instructions";
            lb4.Size = new Size(84, 13);
            lb4.Location = new Point(752, 21);

            TextBox tb1 = new TextBox();
            tb1.Multiline = true;
            tb1.Size = new Size(186, 39);
            tb1.Location = new Point(844, 17);
            tb1.Tag = "d";

            Label lb5 = new Label();
            lb5.Text = "Set Difficulty";
            lb5.Size = new Size(112, 13);
            lb5.Location = new Point(1053, 28);

            ComboBox cbx1 = new ComboBox();
            cbx1.Size = new Size(121, 21);
            cbx1.Location = new Point(1171, 25);
            cbx1.Tag = "";
            cbx1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx1.Tag = "e";
            cbx1.Items.Add("EASY");
            cbx1.Items.Add("NORMAL");
            cbx1.Items.Add("HARD");
            cbx1.Items.Add("VERY HARD");


            NumericUpDown nud1 = new NumericUpDown();
            nud1.Minimum = 1;
            nud1.Maximum = 20;

            nud1.Size = new Size(62, 20);
            nud1.Location = new Point(662, 22);
            nud1.Tag = "c";

            ComboBox cbx = new ComboBox();
            cbx.Size = new Size(147, 21);
            cbx.Location = new Point(136, 21);
            cbx.Items.Add("Multiple Choice");
            cbx.Items.Add("Identification");
            cbx.Items.Add("true or false");
            cbx.Items.Add("Photo Guest");
            cbx.Items.Add("Enumeration");
            cbx.Items.Add("Essay");
            cbx.Tag = "a";
            cbx.DropDownStyle = ComboBoxStyle.DropDownList;






            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Size = new Size(1305, 400);
            flp.Location = new Point(12, 62);
            flp.BackColor = Color.LightGray;
            flp.AutoScroll = true;

            cbx.SelectedValueChanged += (sender2, e2) => types(sender2, e2, flp, Convert.ToInt32(nud.Value), cbx,nud1,lb3);
            nud.ValueChanged += (sender2, e2) => Items(sender2, e2, flp, Convert.ToInt32(nud.Value), cbx);
            Button edit = new Button();
            edit.Size = new Size(75, 23);
            edit.Location = new Point(1113, 492);
            edit.Text = "Edit";

            Button save = new Button();
            save.Size = new Size(75, 23);
            save.Location = new Point(1232, 492);
            save.Tag = tabControl1.Controls.Count + 1;
            Console.WriteLine("line" + save.Tag);
            save.Text = "save";
            tb.Controls.Add(lb);
            tb.Controls.Add(lb2);
            tb.Controls.Add(nud1);
            tb.Controls.Add(nud);
            tb.Controls.Add(lb3);
            tb.Controls.Add(cbx);
            tb.Controls.Add(flp);
            tb.Controls.Add(edit);
            tb.Controls.Add(save);
            tb.Controls.Add(lb4);
            tb.Controls.Add(lb5);
            tb.Controls.Add(tb1);
            tb.Controls.Add(cbx1);



            tb.Text = "PART " + (tabControl1.Controls.Count + 1);
            tb.Size = new Size(1336, 536);
            tb.BackColor = Color.Transparent;
            tb.UseVisualStyleBackColor = true;
            tabControl1.Controls.Add(tb);



        }

        public void save2(dynamic p, int a)
        {
            no_ch += 1;
            try
            {

                con.Close();
                con.Open();


                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
                {

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


                                }
                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;
                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {



                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();



                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {
                                        q = str;
                                        item_no = Convert.ToInt32(tf.Tag);


                                    }


                                    else if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        answer = str;
                                        answer.ToLower();


                                    }




                                }















                            }

                            string q4 = "SELECT tbl_question.col_part_id FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            MySqlCommand q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string partid = Convert.ToString(q4cmd.ExecuteScalar());
                            Console.WriteLine(partid + "partid");
                            q4cmd.Dispose();



                            q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                            Console.WriteLine(answer + "answer");
                            q4cmd.Dispose();

                            string updating = "update tbl_question set col_question = @question where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item and col_part_id = " + partid + "";

                            MySqlCommand upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();

                            updating = "update tbl_choices set col_choices = @answer where col_exam_id = @exam_id  and col_item_id = @item and col_part_id = " + a + "";

                            upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@qid", quesid);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();


                            list.Clear();

                        }


                    }
                }

                else
                {
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


                                }
                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;
                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();



                                    if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                    {
                                        q = str;
                                        item_no = Convert.ToInt32(tf.Tag);
                                    }


                                    else if (Convert.ToInt32(tf.Tag) == 101)
                                    {
                                        no_ch += 1;
                                        answer = str;
                                        answer.ToLower();

                                    }




                                }















                            }


                            //GEETING QUESTION ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            ////////////////////////////////////////////////////////////////////////////////done

                            sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices) " +
                         "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            sqlstatement = "SELECT count(*) FROM tbl_choices";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("id" + id2);
                            cmd.Dispose();

                            sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                            cmd = new MySqlCommand(sqlstatement, con);
                            //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);
                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@choice", answer);
                            cmd.Parameters.AddWithValue("@choice_flag", 1);
                            int right = 1;
                            cmd.Parameters.AddWithValue("@flag", right);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();


                            list.Clear();
                            no_ch = 0;
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

            try
            {
                con.Close();
                con.Open();




                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
                {

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

                                    string str = st.Text;

                                    q = str;
                                    item_no = Convert.ToInt32(st.Tag);

                                }
                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                    if (rb.Checked == true)
                                    {
                                        answer = rb.Text.ToLower(); ;
                                    }


                                }
                            }
                            string q4 = "SELECT tbl_question.col_part_id FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            MySqlCommand q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string partid = Convert.ToString(q4cmd.ExecuteScalar());
                            Console.WriteLine(partid + "partid");
                            q4cmd.Dispose();



                            q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                            Console.WriteLine(answer + "answer");
                            q4cmd.Dispose();

                            string updating = "update tbl_question set col_question = @question where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item ";

                            MySqlCommand upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();

                            updating = "update tbl_choices set col_choices = @answer where col_exam_id = @exam_id  and col_item_id = @item and col_part_id = " + a + "";

                            upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@qid", quesid);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();


                            list.Clear();
                        }
                    }




                }
                else
                {

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

                                    string str = st.Text;

                                    q = str;
                                    item_no = Convert.ToInt32(st.Tag);

                                }
                                if (d is MaterialSkin.Controls.MaterialRadioButton)
                                {
                                    no_ch += 1;
                                    rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                    if (rb.Checked == true)
                                    {
                                        answer = rb.Text.ToLower();
                                    }


                                }
                            }
                            //GEETING QUESTION ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            ////////////////////////////////////////////////////////////////////////////////done

                            sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices) " +
                         "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            sqlstatement = "SELECT count(*) FROM tbl_choices";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("id" + id2);
                            cmd.Dispose();

                            sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                            cmd = new MySqlCommand(sqlstatement, con);
                            //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);
                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@choice", answer);
                            cmd.Parameters.AddWithValue("@choice_flag", 1);
                            int right = 1;
                            cmd.Parameters.AddWithValue("@flag", right);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();


                            list.Clear();
                            no_ch = 0;
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

        public void save4(dynamic p, int a)
        {
            no_ch += 1;



            try
            {
                con.Close();
                con.Open();




                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
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

                                string q4 = "SELECT tbl_question.col_part_id FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                                MySqlCommand q4cmd = new MySqlCommand(q4, con);
                                q4cmd.Parameters.AddWithValue("@item", item_no);
                                q4cmd.Parameters.AddWithValue("@partno", a);
                                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                                string partid = Convert.ToString(q4cmd.ExecuteScalar());
                                Console.WriteLine(partid + "partid");
                                q4cmd.Dispose();



                                q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                                q4cmd = new MySqlCommand(q4, con);
                                q4cmd.Parameters.AddWithValue("@item", item_no);
                                q4cmd.Parameters.AddWithValue("@partno", a);
                                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                                string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                                Console.WriteLine(answer + "answer");
                                q4cmd.Dispose();

                                string updating = "update tbl_question set col_question = @question where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item ";

                                MySqlCommand upcmd = new MySqlCommand(updating, con);
                                upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                upcmd.Parameters.AddWithValue("@part", a);
                                upcmd.Parameters.AddWithValue("@item", item_no);
                                upcmd.Parameters.AddWithValue("@question", filename);
                                upcmd.Parameters.AddWithValue("@answer", answer);

                                upcmd.ExecuteNonQuery();
                                upcmd.Dispose();

                                updating = "update tbl_choices set col_choices = @answer where col_exam_id = @exam_id  and col_item_id = @item and col_part_id = " + a + "";

                                upcmd = new MySqlCommand(updating, con);
                                upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                upcmd.Parameters.AddWithValue("@part", a);
                                upcmd.Parameters.AddWithValue("@item", item_no);
                                upcmd.Parameters.AddWithValue("@qid", quesid);
                                upcmd.Parameters.AddWithValue("@question", q);
                                upcmd.Parameters.AddWithValue("@answer", answer);

                                upcmd.ExecuteNonQuery();
                                upcmd.Dispose();


                                list.Clear();


                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("" + ex);

                            }

                        }
                    }

                }


                else

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
                                    answer.ToLower();
                                    item_no = Convert.ToInt32(st3.Tag);
                                }



                            }

                            try
                            {
                                con.Close();
                                con.Open();
                                //GEETING QUESTION ID
                                string sqlstatement = "SELECT count(*) FROM tbl_question";
                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id = Convert.ToInt32(cmd.ExecuteScalar());
                                cmd.Dispose();

                                ////////////////////////////////////////////////////////////////////////////////done

                                sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices) " +
                             "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", filename);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                sqlstatement = "SELECT count(*) FROM tbl_choices";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("id" + id2);
                                cmd.Dispose();

                                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                    "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                                cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", answer);
                                cmd.Parameters.AddWithValue("@choice_flag", 1);
                                int right = 1;
                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();


                                list.Clear();
                                no_ch = 0;

                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("" + ex);

                            }

                        }
                    }
                }


            }

            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);

            }




        }


        public void generate()
        {
            FlowLayoutPanel fl = new FlowLayoutPanel();
            ComboBox cb1 = new ComboBox();
            NumericUpDown nud1 = new NumericUpDown();
            NumericUpDown nud2 = new NumericUpDown();
            TextBox txt1 = new TextBox();
            ComboBox cb2 = new ComboBox();
            Console.WriteLine("ex");
            if (examid > 0)

            {
                details();
                Console.WriteLine("gumana");
                con.Close();
                con.Open();
                //getting how many parts
                string getExamParts = "SELECT col_exam_parts FROM tbl_exam where col_exam_id = " + examid + " ";

                MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

                int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
                getpartscmd.Dispose();


                //dividing the partssave

                for (int x = 2; x <= examPartsCount; x++)
                {
                    addTab();
                }


                for (int i = 1; i <= examPartsCount; i++)
                {
                    

                    foreach (Control a in tabControl1.Controls)
                    {

                        //whole tab
                        if (a is TabPage)
                        {

                            TabPage tb = (TabPage)a;
                            if(Convert.ToInt32(tb.Tag) == i)
                            {
                                Console.WriteLine("tabpage tag"+ i);

                                foreach (Control tbc in tb.Controls)

                                {

                                    if (Convert.ToString(tbc.Tag) == "a")
                                    {
                                        cb1 = (ComboBox)tbc;
                                    }
                                        if (Convert.ToString(tbc.Tag) == "b")
                                    {
                                        nud1 = (NumericUpDown)tbc;
                                        
                                    }

                                    else if (Convert.ToString(tbc.Tag) == "c")
                                    {
                                        nud2 = (NumericUpDown)tbc;
                                       
                                    }

                                    else if (Convert.ToString(tbc.Tag) == "d")
                                    {
                                         txt1 = (TextBox)tbc;
                                       
                                    }


                                    else if (Convert.ToString(tbc.Tag) == "e")
                                    {
                                        cb2 = (ComboBox)tbc;
                                       
                                    }


                                    if (tbc is FlowLayoutPanel)
                                    {
                                        fl = (FlowLayoutPanel)tbc;
                                        Console.WriteLine("gumana2"+i);
                                       
                                    }
                                }

                            }

                            
                        }
                    }

                    //getting how many items in part
                   
                    Console.WriteLine("gumana3");
                    string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + examid + "";

                        MySqlCommand itemscmd = new MySqlCommand(items, con);

                        int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());
                        nud1.Value = itemsCount;
                        itemscmd.Dispose();


                    string ins = "SELECT col_instructions FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + examid + "";

                    MySqlCommand inscmd = new MySqlCommand(ins, con);

                    string instruc = Convert.ToString(inscmd.ExecuteScalar());
                    txt1.Text = instruc;
                    inscmd.Dispose();

                    

                    string lvl = "SELECT col_part_level FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + examid + "";

                    MySqlCommand lvlcmd = new MySqlCommand(lvl, con);

                    string level = Convert.ToString(lvlcmd.ExecuteScalar());
                    cb2.Text = level;
                    lvlcmd.Dispose();

                    string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", examid);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());
                            cb1.Text = type;
                            examtypecmd.Dispose();
                            fl.Controls.Clear();

                    Console.WriteLine("gumanaaaaaa"+type+itemsCount);




                    string pnt = "SELECT col_points FROM tbl_parts where col_part_no=" + i + "  and  col_exam_id = " + examid + "";

                    MySqlCommand pntcmd = new MySqlCommand(pnt, con);

                    int pnts = Convert.ToInt32(pntcmd.ExecuteScalar());
                    Console.WriteLine("nuuuuuuuuuud" + pnts);
                    nud2.Value = pnts;
                    pntcmd.Dispose();

                    //counting exams panel creation


                    for (int item = 1; item <= itemsCount; item++)
                        {

                        //question  
                        Console.WriteLine("gumanaaaaaa" + item + examid + i);

                        string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", examid);
                            string question = Convert.ToString(q2cmd.ExecuteScalar());

                        Console.WriteLine("gumana5"+question);
                        q2cmd.Dispose();



                            string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            MySqlCommand q3cmd = new MySqlCommand(q3, con);
                            q3cmd.Parameters.AddWithValue("@item", item);
                            q3cmd.Parameters.AddWithValue("@partno", i);
                            q3cmd.Parameters.AddWithValue("@exam", examid);
                            string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                            q3cmd.Dispose();




                            //answer

                            string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                            MySqlCommand a1cmd = new MySqlCommand(a1, con);
                            a1cmd.Parameters.AddWithValue("@item", item);
                            a1cmd.Parameters.AddWithValue("@partno", i);
                            a1cmd.Parameters.AddWithValue("@exam", examid);
                            string answer = Convert.ToString(a1cmd.ExecuteScalar());

                            a1cmd.Dispose();


                            string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                            MySqlCommand a2cmd = new MySqlCommand(a2, con);
                            a2cmd.Parameters.AddWithValue("@item", item);
                            a2cmd.Parameters.AddWithValue("@partno", i);
                            a2cmd.Parameters.AddWithValue("@exam", examid);
                            string no_choices = Convert.ToString(a2cmd.ExecuteScalar());

                            q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                            q2cmd = new MySqlCommand(q2, con);
                            q2cmd.Parameters.AddWithValue("@item", item);
                            q2cmd.Parameters.AddWithValue("@partno", i);
                            q2cmd.Parameters.AddWithValue("@exam", examid);
                            int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                            q2cmd.Dispose();
                            Console.WriteLine(no_choices + "ch");
                            Console.WriteLine(item + "item");
                            Console.WriteLine(i + "part");
                            Console.WriteLine(this.Text + "exam");
                            a2cmd.Dispose();
                            List<string> ch = new List<string>();

                            if (type == "Multiple Choice")
                            {

                                for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                {

                                    string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                    MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                    a3cmd.Parameters.AddWithValue("@item", item);
                                    a3cmd.Parameters.AddWithValue("@partno", i);
                                    a3cmd.Parameters.AddWithValue("@exam", examid);
                                    a3cmd.Parameters.AddWithValue("@qid", questionid);
                                    string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                    Console.WriteLine("test" + chs);
                                    a3cmd.Dispose();
                                    ch.Add(chs);


                                }

                                 multipleChoice1(fl, item, ch, question,no_choices,answer);
                            }
                            else if (type == "Identification")
                             {
                                identification1(fl, item, ch, question, no_choices, answer);
                             }

                             else if (type == "true or false")
                            {
                                trueorfalse1(fl, item, ch, question, no_choices, answer);
                            }


                            else if (type == "Photo Guest")
                            {
                                photoguest1(fl, item, ch, question, no_choices, answer);
                            }

                            else if (type == "Enumeration")
                            {
                                enumeration1(fl, item, ch, question, no_choices, answer,i);
                            }
                            else if (type == "Essay")
                            {
                                essay1(fl, item, ch, question, no_choices, answer,points);
                            }



                    }



                    


                    } 





                }
            else
            {
               



            } 



        }
        string no_choices;
        NumericUpDown num = new NumericUpDown();
        int part_point = 0;
        int total_no_of_exam;
        int old_enum_points;
        int total = 0;
        int total_no_ch;

        public void save5(dynamic p, int a)
        {

            try
            {
                //a is ung part id nya
                con.Close();
                con.Open();




                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
                {
                    Console.WriteLine("may row");

                    list.Clear();
                    con.Close();
                    con.Open();
                    int total_old = 0;
                    total_no_of_exam = 0;
                    string sqlstatement13 = "SELECT count(col_choices) from tbl_choices where col_exam_id = @exam_id and col_part_id = @part";
                    MySqlCommand cmd3 = new MySqlCommand(sqlstatement13, con);
                    cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd3.Parameters.AddWithValue("@part", a);
                    total_old = Convert.ToInt32(cmd3.ExecuteScalar());
                    Console.WriteLine("tt" + total_old);
                    cmd3.Dispose();
                    sqlstatement13 = "SELECT col_part_points from tbl_parts where  col_part_no = @part and col_exam_id = @exam_id";
                    cmd3 = new MySqlCommand(sqlstatement13, con);
                    cmd3.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd3.Parameters.AddWithValue("@part", a);

                    int new_part = Convert.ToInt32(cmd3.ExecuteScalar());
                    cmd3.Dispose();

                    total_old = total_old * new_part;

                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {
                            list.Clear();
                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {

                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }



                                int ques = 0;
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();


                                    ques = Convert.ToInt32(tf.Tag);

                                    if (ques > 100)
                                    {
                                        q = str;

                                        Console.WriteLine("ques" + q);
                                    }






                                }


                                if (d is NumericUpDown)
                                {




                                }

                                if (d is FlowLayoutPanel)
                                {

                                    Console.WriteLine("gumana flow");
                                    //fppp
                                    fp = (FlowLayoutPanel)d;
                                    no_ch = fp.Controls.Count;
                                    foreach (Control f in d.Controls)
                                    {

                                        if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                        {

                                            mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                            mf = mtf.Text.ToLower();
                                            Console.WriteLine(mf);

                                            list.Add(mf);

                                        }


                                    }



                                }















                            }




                            string q4 = "SELECT tbl_question.col_part_id FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            MySqlCommand q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string partid = Convert.ToString(q4cmd.ExecuteScalar());
                            Console.WriteLine(partid + "partid");
                            q4cmd.Dispose();



                            q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                            Console.WriteLine("nadelete");
                            q4cmd.Dispose();







                            Console.WriteLine("listcnt" + list.Count);

                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);



                                string sqlstatement = "delete from tbl_choices  where col_exam_id = @exam_id and col_part_id =@part and col_item_id = @item and col_item_id = @item";

                                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);//part ng id
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", quesid);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 1;


                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.Parameters.AddWithValue("@qid", quesid);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();


                            }




                            list.Clear();
                            no_ch = 0;

                        }


                    }
                    ///ADD
                    list.Clear();
                    con.Close();
                    con.Open();
                    Console.WriteLine("else gumana");
                    ///enurows




                    foreach (Control c in p.Controls)
                    {


                        if (c is MaterialSkin.Controls.MaterialDivider)
                        {

                            MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)c;





                            foreach (Control d in td.Controls)
                            {


                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }



                                int ques = 0;
                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();

                                    ques = Convert.ToInt32(tf.Tag);

                                    if (ques > 100)
                                    {
                                        q = str;
                                        Console.WriteLine("ques" + q);

                                    }


                                    //// dito>>>>>                              






                                }
                                Console.WriteLine("bago gumana flow");
                                if (d is FlowLayoutPanel)
                                {

                                    Console.WriteLine("gumana flow");
                                    //fppp
                                    fp = (FlowLayoutPanel)d;
                                    no_ch = fp.Controls.Count;
                                    total_no_ch += fp.Controls.Count;
                                    Console.WriteLine("fp nch" + total_no_ch);
                                    foreach (Control f in d.Controls)
                                    {

                                        if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                        {

                                            mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                            mf = mtf.Text.ToLower();
                                            Console.WriteLine(mf);

                                            list.Add(mf);

                                        }

                                    }



                                }








                            }

                            //ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);
                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            string updating = "update  tbl_question set col_question = @question,col_no_choices = @no_ch where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item";

                            MySqlCommand upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@answer", answer);
                            upcmd.Parameters.AddWithValue("@no_ch", list.Count);
                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();

                            Console.WriteLine("dami" + list.Count);
                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);

                                sqlstatement = "SELECT count(*) FROM tbl_choices";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("id" + id2);
                                cmd.Dispose();

                                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                    "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                                cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 1;

                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();



                            }



                            ////

                            list.Clear();
                            no_ch = 0;


                        }





                    }


                    //TOTALEXAM


                    string sqlstatement1 = "SELECT col_no_of_exams FROM tbl_exam where col_exam_id = @exam_id ";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));

                    int no_exams = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();
                    total_no_of_exam = no_exams;
                    Console.WriteLine("total_no_of_exam" + total_no_of_exam);
                    //old_enum_points

                    sqlstatement1 = "SELECT col_part_points from tbl_parts where  col_part_no = @part and col_exam_id = @exam_id";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int new_part_points = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();
                    Console.WriteLine("totalnch" + total_no_ch);
                    Console.WriteLine("new part points" + new_part_points);
                    part_point = (new_part_points * total_no_ch);
                    Console.WriteLine("total part point" + part_point);


                    sqlstatement1 = "SELECT col_part_points FROM tbl_parts where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int part_points = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    sqlstatement1 = "SELECT col_part_items FROM tbl_parts where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int part_items = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    Console.WriteLine("part_points" + part_points);


                    //old_enum_points = (part_points * total_old_question);
                    //    total_no_of_exam = (total_no_of_exam - old_enum_points);
                    // total_no_of_exam = total_no_of_exam - (part_items * part_points);

                    total_no_of_exam = total_no_of_exam - total_old;
                    //  Console.WriteLine("old_enum_points" + old_enum_points);
                    Console.WriteLine("total_no_of_exam" + total_no_of_exam);
                    Console.WriteLine("total old" + total_old);
                    Console.WriteLine("part" + part_point);


                    total = (total_no_of_exam + part_point);
                    Console.WriteLine("total" + total);
                    string up = "update tbl_exam set col_no_of_exams = @no_exams where col_exam_id =@exam";
                    cmd1 = new MySqlCommand(up, con);
                    cmd1.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@no_exams", total);
                    cmd1.Parameters.AddWithValue("@item", item_no);
                    cmd1.Parameters.AddWithValue("@part_no", a);

                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();


                    Console.WriteLine("gumana partsss");


                    total_no_ch = 0;

                }

                else
                {
                    list.Clear();
                    Console.WriteLine("walang row");
                    ///enurows
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
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;

                                    if (Convert.ToInt32(lb.Tag) >= 1)
                                    {

                                        item_no = Convert.ToInt32(lb.Tag);
                                    }
                                }



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
                                Console.WriteLine("bago gumana flow");
                                if (d is FlowLayoutPanel)
                                {

                                    Console.WriteLine("gumana flow");
                                    //fppp
                                    fp = (FlowLayoutPanel)d;
                                    no_ch = fp.Controls.Count;
                                    foreach (Control f in d.Controls)
                                    {

                                        if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                        {

                                            mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                            mf = mtf.Text.ToLower();
                                            Console.WriteLine(mf);

                                            list.Add(mf);

                                        }

                                    }



                                }








                            }

                            //ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            ///

                            sqlstatement = "SELECT col_part_points from tbl_parts where  col_part_no = @part and col_exam_id = @exam_id";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            int new_part_points = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            part_point += new_part_points * no_ch;


                            ////////////////////////////////////////////////////////////////////////////////done

                            sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices) " +
                              "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);

                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            ////

                            for (int j = 0; j < list.Count; j++)
                            {
                                Console.WriteLine(list[j]);

                                sqlstatement = "SELECT count(*) FROM tbl_choices";
                                cmd = new MySqlCommand(sqlstatement, con);
                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);

                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("id" + id2);
                                cmd.Dispose();

                                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                    "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                                cmd = new MySqlCommand(sqlstatement, con);
                                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                                cmd.Parameters.AddWithValue("@part", a);
                                cmd.Parameters.AddWithValue("@item", item_no);
                                cmd.Parameters.AddWithValue("@question", q);
                                cmd.Parameters.AddWithValue("@col_question_no", q);
                                cmd.Parameters.AddWithValue("@choice", list[j]);
                                cmd.Parameters.AddWithValue("@choice_flag", (j + 1));
                                int right = 1;

                                cmd.Parameters.AddWithValue("@flag", right);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();



                            }






                            ////

                            list.Clear();
                            no_ch = 0;


                        }




                    }

                    //TOTALEXAM


                    string sqlstatement1 = "SELECT col_no_of_exams FROM tbl_exam where col_exam_id = @exam_id ";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));

                    int no_exams = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();
                    total_no_of_exam = no_exams;
                    Console.WriteLine("total_no_of_exam" + total_no_of_exam);
                    //old_enum_points



                    sqlstatement1 = "SELECT col_part_points FROM tbl_parts where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int part_points = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    sqlstatement1 = "SELECT col_part_items FROM tbl_parts where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int part_items = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    Console.WriteLine("part_points" + part_points);

                    Console.WriteLine("part_point" + part_point);
                    sqlstatement1 = "SELECT sum(col_no_choices) FROM tbl_question where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int total_old_question = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();
                    //old_enum_points = (part_points * total_old_question);
                    //    total_no_of_exam = (total_no_of_exam - old_enum_points);
                    total_no_of_exam = total_no_of_exam - (part_items * part_points);
                    //  Console.WriteLine("old_enum_points" + old_enum_points);
                    Console.WriteLine("total_no_of_exam" + total_no_of_exam);




                    total = (total_no_of_exam + part_point);
                    Console.WriteLine("total" + total);
                    string up = "update tbl_exam set col_no_of_exams = @no_exams where col_exam_id =@exam";
                    cmd1 = new MySqlCommand(up, con);
                    cmd1.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@no_exams", total);
                    cmd1.Parameters.AddWithValue("@item", item_no);
                    cmd1.Parameters.AddWithValue("@part_no", a);

                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();


                    Console.WriteLine("gumana partsss");





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

        decimal all = 0;
        decimal alltotal = 0;

        public void save6(dynamic p, int a)
        {





            try
            {

                con.Close();
                con.Open();



                MySqlCommand update = new MySqlCommand("select col_question  from tbl_question where col_exam_id= @exam_id and col_part_no = @part ", con);

                update.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                update.Parameters.AddWithValue("@part", a);

                MySqlDataReader dr = update.ExecuteReader();

                if (dr.HasRows)
                {

                    con.Close();
                    con.Open();

                    string sqlstatement1 = "SELECT col_no_of_exams FROM tbl_exam where col_exam_id = @exam_id ";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));

                    int no_exams = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    Console.WriteLine("dami ng exam" + no_exams);

                    sqlstatement1 = "SELECT sum(col_points) FROM tbl_question where col_exam_id = @exam_id and col_part_no = @part";
                    cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@part", a);
                    int total_old_points = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();
                    no_exams -= total_old_points;



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


                                }
                                if (d is NumericUpDown)
                                {

                                    num = (NumericUpDown)d;


                                }

                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;
                                    if ((Convert.ToInt32(lb.Tag) >= 1) && (Convert.ToInt32(lb.Tag) <= 100))
                                    {
                                        // q = str;
                                        item_no = Convert.ToInt32(lb.Tag);
                                        Console.WriteLine("gumana sya");
                                    }

                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();






                                    if (Convert.ToInt32(tf.Tag) == 200)
                                    {
                                        q = str;
                                        // item_no = Convert.ToInt32(tf.Tag);
                                        Console.WriteLine("gumana sya");
                                    }




                                }















                            }


                            all += num.Value;




                            string updating = "update tbl_question set col_points = @cp where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item ";

                            MySqlCommand upcmd = new MySqlCommand(updating, con);
                            upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                            upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            upcmd.Parameters.AddWithValue("@part", a);
                            upcmd.Parameters.AddWithValue("@item", item_no);
                            upcmd.Parameters.AddWithValue("@question", q);
                            upcmd.Parameters.AddWithValue("@cp", num.Value);

                            upcmd.ExecuteNonQuery();
                            upcmd.Dispose();






                        }




                    }

                    Console.WriteLine(all + "all");
                    Console.WriteLine(no_exams + "allnumb");
                    alltotal = all + no_exams;
                    string up = "update tbl_exam set col_no_of_exams = @no_exams where col_exam_id =@exam";
                    cmd1 = new MySqlCommand(up, con);
                    cmd1.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@no_exams", Convert.ToInt32(alltotal));
                    cmd1.Parameters.AddWithValue("@item", item_no);
                    cmd1.Parameters.AddWithValue("@part_no", a);

                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    alltotal = 0;
                    all = 0;



                }

                else
                {

                    Console.WriteLine("nag else ");
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


                                }
                                if (d is NumericUpDown)
                                {

                                    num = (NumericUpDown)d;


                                }

                                if (d is MaterialSkin.Controls.MaterialLabel)

                                {
                                    lb = (MaterialSkin.Controls.MaterialLabel)d;
                                    if ((Convert.ToInt32(lb.Tag) >= 1) && (Convert.ToInt32(lb.Tag) <= 100))
                                    {
                                        // q = str;
                                        item_no = Convert.ToInt32(lb.Tag);
                                        Console.WriteLine("gumana sya");
                                    }

                                }

                                if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                {

                                    MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                    string str = tf.Text.ToLower();






                                    if (Convert.ToInt32(tf.Tag) == 200)
                                    {
                                        q = str;
                                        // item_no = Convert.ToInt32(tf.Tag);
                                        Console.WriteLine("gumana sya");
                                    }




                                }















                            }


                            all += num.Value;
                            //GEETING QUESTION ID
                            string sqlstatement = "SELECT count(*) FROM tbl_question";
                            MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", no_ch);
                            int id = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.Dispose();

                            ////////////////////////////////////////////////////////////////////////////////done

                            sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices,col_points) " +
                         "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch,@cp)";
                            cmd = new MySqlCommand(sqlstatement, con);
                            cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                            cmd.Parameters.AddWithValue("@part", a);
                            cmd.Parameters.AddWithValue("@item", item_no);

                            cmd.Parameters.AddWithValue("@question", q);
                            cmd.Parameters.AddWithValue("@col_question_no", q);
                            cmd.Parameters.AddWithValue("@no_ch", 0);
                            cmd.Parameters.AddWithValue("@cp", num.Value);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();




                        }


                    }


                    //all

                    string sqlstatement1 = "SELECT col_no_of_exams FROM tbl_exam where col_exam_id = @exam_id ";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));

                    int no_exams = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.Dispose();

                    Console.WriteLine("total_no_of_exam" + total_no_of_exam);



                    alltotal = (all + no_exams);
                    Console.WriteLine("total" + total);
                    string up = "update tbl_exam set col_no_of_exams = @no_exams where col_exam_id =@exam";
                    cmd1 = new MySqlCommand(up, con);
                    cmd1.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                    cmd1.Parameters.AddWithValue("@no_exams", Convert.ToInt32(alltotal));
                    cmd1.Parameters.AddWithValue("@item", item_no);
                    cmd1.Parameters.AddWithValue("@part_no", a);

                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();

                    alltotal = 0;
                    all = 0;

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

        public void details()
        {
            con.Close();
            con.Open();

            string name = "SELECT col_exam_name FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand namecmd = new MySqlCommand(name, con);
            namecmd.Parameters.AddWithValue("@exam_id", examid);
            string exn = Convert.ToString(namecmd.ExecuteScalar());
            txtExamName.Text = exn;
            Console.WriteLine("NAME" + exn);
            string grade = "SELECT col_exam_grade FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gradecmd = new MySqlCommand(grade, con);
            gradecmd.Parameters.AddWithValue("@exam_id", examid);
            string grd = Convert.ToString(gradecmd.ExecuteScalar());
            sgrade.Text = grd;
            Console.WriteLine("GRADE" + grd);

            con.Close();
            con.Open();
            ssection.Items.Clear();
            string sql = string.Format(@"SELECT section FROM class WHERE grade='{0}'", sgrade.Text);
            MySqlCommand sqlcmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                ssection.Items.Add(dr.GetString("section"));
            }

            con.Close();
            con.Open();



            string section = "SELECT col_exam_section FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand scncmd = new MySqlCommand(section, con);
            scncmd.Parameters.AddWithValue("@exam_id", examid);
            string scn = Convert.ToString(scncmd.ExecuteScalar());
            ssection.Text = scn;





            Console.WriteLine("SECTION" + scn);
            string subjectt = "SELECT subject FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand sjtcmd = new MySqlCommand(subjectt, con);
            sjtcmd.Parameters.AddWithValue("@exam_id", examid);
            string sjt = Convert.ToString(sjtcmd.ExecuteScalar());
            subject.Text = sjt;
            Console.WriteLine("SUBJECT" + sjt);

            string date = "SELECT col_exam_date FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand dtcmd = new MySqlCommand(date, con);
            dtcmd.Parameters.AddWithValue("@exam_id", examid);
            string dt = Convert.ToString(dtcmd.ExecuteScalar());
            dtpExamDate.Text = dt;
            Console.WriteLine("DATE" + dt);


            string hour = "SELECT col_exam_duration_hrs FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand hrcmd = new MySqlCommand(hour, con);
            hrcmd.Parameters.AddWithValue("@exam_id", examid);
            string hr = Convert.ToString(hrcmd.ExecuteScalar());
            nudHr.Text = hr;
            Console.WriteLine("hr" + hr);


            string mins = "SELECT col_exam_duration_mins FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand mincmd = new MySqlCommand(mins, con);
            mincmd.Parameters.AddWithValue("@exam_id", examid);
            string min = Convert.ToString(mincmd.ExecuteScalar());
            nudMin.Text = min;
            con.Close();

            Console.WriteLine("min" + hr);

            con.Close();
        }

        public void types(object sender, EventArgs e, dynamic p,int items,ComboBox a,NumericUpDown num,Label lbtext)
        {
            ComboBox cb =  (ComboBox)a;
            FlowLayoutPanel flp = (FlowLayoutPanel)p;
            
            flp.Controls.Clear();
            Console.WriteLine("item"+cb.Text);
            if (cb.SelectedIndex == 0)
            {
                flp.Tag = 1;
                num.Show();
                lbtext.Show();
                multipleChoice(flp, items, 0);

            }
            else if (cb.SelectedIndex == 1)
            {
                flp.Tag = 2;
                num.Show();
                lbtext.Show();
                identification(flp, items, 0);
            }
            else if (cb.SelectedIndex == 4)
            {
                flp.Tag = 5;
                num.Show();
                lbtext.Show();
                enumeration(flp, items, 0);
            }
            else if (cb.SelectedIndex == 2)
            {
                flp.Tag = 3;
                num.Show();
                lbtext.Show();
                trueOrFalse(flp, items, 0);
            }

            else if (cb.SelectedIndex == 3)
            {
                flp.Tag = 4;
                num.Show();
                lbtext.Show();
                photoGuest(flp, items, 0);
            }

            else if (cb.SelectedIndex == 5)
            {
                flp.Tag = 6;
                num.Hide();
                lbtext.Hide();
                Essay(flp, items, 0);
            }


        }
         
        public void Items(object sender, EventArgs e, dynamic p, int items, ComboBox a)
        {

            ComboBox cb = (ComboBox)a;
            FlowLayoutPanel flp = (FlowLayoutPanel)p;
            int ExistingItems = flp.Controls.Count;
            Console.WriteLine("exisiting"+ExistingItems);
            Console.WriteLine("exisiting" + items);

            if (ExistingItems > items)
            {
                int temp = ExistingItems - items;
                Console.WriteLine("temp minus" + temp);
                for (int x = 0; x < temp; x++)
                {
                    Console.WriteLine(x + "EX");
                    flp.Controls.RemoveAt((ExistingItems -= 1));
                }





            }

            else if (ExistingItems < items)
                {

               

                int temp = items - ExistingItems;
                Console.WriteLine("temp add" + temp);


                Console.WriteLine("item" + cb.Text);
                if (cb.SelectedIndex == 0)
                {
                    multipleChoice(flp, items, ExistingItems);
                }
                else if (cb.SelectedIndex == 1)
                {
                    identification(flp, items, ExistingItems);
                }
                else if (cb.SelectedIndex == 4)
                {
                    enumeration(flp, items, ExistingItems);
                }

                else if (cb.SelectedIndex == 2)
                {
                    trueOrFalse(flp, items, ExistingItems);
                }

                else if (cb.SelectedIndex == 3)
                {
                    photoGuest(flp, items, ExistingItems);
                }

                else if (cb.SelectedIndex == 5)
                {
                    Essay(flp, items, ExistingItems);
                }





            }


        }
         
        public void examSave(TabControl p,int totalPoints)
        {
            con.Close();
            con.Open();
            Console.WriteLine(totalPoints+"toooootal");
            MySqlCommand update = new MySqlCommand("select * from tbl_exam where col_exam_id= @exam_id", con);

            update.Parameters.AddWithValue("@exam_id", examid);
           
            MySqlDataReader dr = update.ExecuteReader();

            if (dr.HasRows)
            {


                con.Close();
                con.Open();
                string updating = "update tbl_exam set col_exam_name = @ename,col_exam_grade = @cgrade,col_exam_section = @csec,subject = @csbj,col_exam_date = @cdate,col_exam_duration_hrs = @chr, col_exam_duration_mins = @cmins,col_no_of_exams =@total,col_exam_parts = @parts where col_exam_id = @exam_id";


                MySqlCommand upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@ename", txtExamName.Text);
                upcmd.Parameters.AddWithValue("@cmins", nudMin.Text);
                upcmd.Parameters.AddWithValue("@chr", nudHr.Text);
                upcmd.Parameters.AddWithValue("@cdate", dtpExamDate.Value);
                upcmd.Parameters.AddWithValue("@csbj", subject.Text);
                upcmd.Parameters.AddWithValue("@csec", ssection.Text);
                upcmd.Parameters.AddWithValue("@cgrade", sgrade.Text);
                upcmd.Parameters.AddWithValue("@total", totalPoints);
                upcmd.Parameters.AddWithValue("@exam_id", examid);
                upcmd.Parameters.AddWithValue("@parts", p.Controls.Count);
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                con.Close();

            }
            else
            {
               
                con.Close();
                con.Open();

                string sqlstatement = "Insert into tbl_exam(col_exam_name,col_exam_parts,col_exam_grade,col_exam_section,col_exam_date,col_exam_duration_hrs,col_exam_duration_mins,col_exam_status,col_teacher_id,col_no_of_exams,subject) " +
                    "values(@exam_name, @parts, @grade, @sec, @date, @hrs, @mins,@stats,@teacher_id,@total,@subject)";


                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                cmd.Parameters.AddWithValue("@hrs", nudHr.Value);
                cmd.Parameters.AddWithValue("@mins", nudMin.Value);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                cmd.Parameters.AddWithValue("@date", dtpExamDate.Value);
                //  cmd.Parameters.AddWithValue("@classname", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@parts", p.Controls.Count);

                cmd.Parameters.AddWithValue("@stats", 0);
                cmd.Parameters.AddWithValue("@grade", sgrade.Text);
                cmd.Parameters.AddWithValue("@sec", ssection.Text);
                cmd.Parameters.AddWithValue("@total", totalPoints);
                cmd.Parameters.AddWithValue("@subject", subject.Text);

                cmd.ExecuteNonQuery();
                

                


                string examidssss = "select count(*) from tbl_exam";

                MySqlCommand examcmd = new MySqlCommand(examidssss, con);
                examcmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                int examcmdcount = Convert.ToInt32(examcmd.ExecuteScalar());
                examcmd.Dispose();
                examid = examcmdcount;

                con.Close();

            }

        }

        public void partSave(int partNo,int items, string type, decimal points,string ins, string dif,int pon)
        {
            con.Close();
            con.Open();
            MySqlCommand update = new MySqlCommand("select col_part_id from tbl_parts where col_exam_id= @exam_id and col_part_no = @part ", con);

            update.Parameters.AddWithValue("@exam_id", examid);
            update.Parameters.AddWithValue("@part", partNo);
            Console.WriteLine("this"+examid);
            Console.WriteLine("this1" + partNo);
            MySqlDataReader dr = update.ExecuteReader();

            if (dr.HasRows)
            {

                try {

                    Console.WriteLine("hasrows" + partNo);

                    con.Close();
                    con.Open();

                    string sqlstatement1 = "update tbl_parts set col_part_type = @type, col_part_items = @item,col_instructions = @ins, col_part_level = @dif,col_points = @points  where col_exam_id = @exam_id and col_part_no = @part_no";
                    MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                    cmd1.Parameters.AddWithValue("@teacher_id", 100);
                    cmd1.Parameters.AddWithValue("@exam_id", examid);
                    cmd1.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                    cmd1.Parameters.AddWithValue("@part_no", partNo);
                    cmd1.Parameters.AddWithValue("@item", items);//no_ch of items
                    cmd1.Parameters.AddWithValue("@type", type);
                    cmd1.Parameters.AddWithValue("@ins", ins);
                    cmd1.Parameters.AddWithValue("@dif", dif);
                    cmd1.Parameters.AddWithValue("@points", pon);

                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    con.Close();



                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);

                }
                
                
            }

            else
            {
                Console.WriteLine("norows" + partNo);

                con.Close();
                con.Open();
                string sqlstatement = "insert into tbl_parts(col_part_type,col_points,col_exam_id,col_part_no,col_part_items,col_instructions,col_part_level)values(@type,@points,(select count(*) from tbl_exam),@part_no,@item,@ins,@dif)";
                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                cmd.Parameters.AddWithValue("@part_no", partNo);
                cmd.Parameters.AddWithValue("@item", items);//no_ch of items
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@ins", ins);
                cmd.Parameters.AddWithValue("@dif", dif);
                cmd.Parameters.AddWithValue("@points", pon);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

            }

          


        }
        public void choiceSave(int partNo, int itemNo,int right,int flag,string choice) {
            con.Close();
            con.Open();



            MySqlCommand update = new MySqlCommand("select *  from tbl_choices where col_exam_id= @exam_id and col_part_id = @part and col_item_id = @item and col_choice_flag = @cf ", con);

            update.Parameters.AddWithValue("@exam_id", examid);
            update.Parameters.AddWithValue("@part", partNo);
            update.Parameters.AddWithValue("@item", itemNo);
            update.Parameters.AddWithValue("@cf", flag);

            MySqlDataReader dr = update.ExecuteReader();

            if (dr.HasRows)
            {



                con.Close();
                con.Open();
                string sqlstatement = "update tbl_choices set col_choices = @cc, col_answer_flag = @caf where col_exam_id = @exam_id and col_part_id =@part and col_item_id = @item and col_choice_flag = @cf ";

                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_id", examid);
                cmd.Parameters.AddWithValue("@part", partNo);//part ng id
                cmd.Parameters.AddWithValue("@item", itemNo);
                cmd.Parameters.AddWithValue("@cc", choice);
                cmd.Parameters.AddWithValue("@caf", right);
                cmd.Parameters.AddWithValue("@cf", flag);

                cmd.ExecuteNonQuery();
                cmd.Dispose();






            }

            else {
                con.Close();
                con.Open();
                string sqlstatement = "SELECT count(*) FROM tbl_question";
                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_id",examid);
                cmd.Parameters.AddWithValue("@part", partNo);
                cmd.Parameters.AddWithValue("@item", itemNo);

                cmd.Parameters.AddWithValue("@question", q);
                cmd.Parameters.AddWithValue("@col_question_no", q);
                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();


                sqlstatement = "SELECT count(*) FROM tbl_choices";
                cmd = new MySqlCommand(sqlstatement, con);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_id", examid);
                cmd.Parameters.AddWithValue("@part", partNo);
                cmd.Parameters.AddWithValue("@item", itemNo);

                cmd.Parameters.AddWithValue("@question", q);
                cmd.Parameters.AddWithValue("@col_question_no", q);
                cmd.Parameters.AddWithValue("@no_ch", no_ch);
                int id2 = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("id" + id2);
                cmd.Dispose();


                sqlstatement = "insert into tbl_choices(col_choice_id,col_choices,col_answer_flag,col_exam_id,col_part_id,col_item_id,col_choice_flag,col_question_id)" +
                                     "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag," + (id + 1) + ") ";

                cmd = new MySqlCommand(sqlstatement, con);
                //cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_id", examid);
                cmd.Parameters.AddWithValue("@part", partNo);
                cmd.Parameters.AddWithValue("@item", itemNo);

                cmd.Parameters.AddWithValue("@choice", choice);
                cmd.Parameters.AddWithValue("@choice_flag", flag);
                cmd.Parameters.AddWithValue("@flag", right);
                cmd.ExecuteNonQuery();
                cmd.Dispose();



            }



               

            con.Close();

        }
        public void TEST()
        {
            Console.WriteLine("ITEM TEST");
        }
        public void itemSave(int partNo,int quesNo, string q1,int no_ch1,int essay)
        {
            Console.WriteLine("ITEM"+essay  );

            con.Close();
            con.Open();
            MySqlCommand update1 = new MySqlCommand("select col_part_id from tbl_question where col_exam_id= @exam_id and col_part_no = @part and col_question_no = @ques ", con);

            update1.Parameters.AddWithValue("@exam_id", examid);
            update1.Parameters.AddWithValue("@part", partNo);
            update1.Parameters.AddWithValue("@ques", quesNo);

            MySqlDataReader dr1 = update1.ExecuteReader();

            if (dr1.HasRows)
            {
                try {


                    Console.WriteLine("has row" + partNo + "/" + quesNo + "/" + q1+ "/" + no_ch1);

                    con.Close();
                    con.Open();
                    string updating = "update tbl_question set col_question = @question, col_points = @cp, col_no_choices = @cnc where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item ";
                    Console.WriteLine("essay" + essay);
                    MySqlCommand upcmd = new MySqlCommand(updating, con);
                    upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                    upcmd.Parameters.AddWithValue("@exam_id", examid);
                    upcmd.Parameters.AddWithValue("@part", partNo);
                    upcmd.Parameters.AddWithValue("@item", quesNo);
                    upcmd.Parameters.AddWithValue("@question", q1);
                    upcmd.Parameters.AddWithValue("@answer", no_ch1);
                    upcmd.Parameters.AddWithValue("@cp", essay);
                    upcmd.Parameters.AddWithValue("@cnc", no_ch1);


                    upcmd.ExecuteNonQuery();
                    upcmd.Dispose();


                    con.Close();





                }
                catch (MySqlException ex)
                {

                    Console.WriteLine("ex");
                }
                
            }
            else
            {
                con.Close();
                con.Open();

                string sqlstatement = "SELECT count(*) FROM tbl_question";
                MySqlCommand cmd = new MySqlCommand(sqlstatement, con);             
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

                

                    sqlstatement = "insert into tbl_question(col_question_id,col_part_id,col_part_no,col_question_no,col_question,col_exam_id,col_no_choices,col_points) " +
                              "values(" + (id + 1) + ",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch,@cp)";

           


                cmd = new MySqlCommand(sqlstatement, con);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_id", examid);
                cmd.Parameters.AddWithValue("@part", partNo);
                cmd.Parameters.AddWithValue("@item", quesNo);
                cmd.Parameters.AddWithValue("@cp", essay);
                cmd.Parameters.AddWithValue("@question", q1);               
                cmd.Parameters.AddWithValue("@no_ch", no_ch1);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("no rows");

                con.Close();
            }

        }
        public void multipleChoice(FlowLayoutPanel p,int items,int EI) 
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            { 
                int item = (x + 1);
                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200 });

                //choices
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Name = "4" });


                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                button.Text = "-";
                button.Tag = item.ToString();
                button.Location = new Point(830, 30);
                button.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                button.Click += (sender2, e2) => btn_choice(sender2, e2, p);

                panel1.Controls.Add(button);

                //ADD

                MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                button1.Text = "+";
                button1.Tag = item.ToString();
                button1.Location = new Point(845, 30);
                button1.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                button1.Click += (sender2, e2) => btn_choice1(sender2, e2, p);

                panel1.Controls.Add(button1);
                p.Controls.Add(panel1);
                p.Tag = 1;
            }
           


        }

        public void multipleChoice1(FlowLayoutPanel p, int item,List<string> ch,string question, string no_choices,string answer)
        {
            
                
                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                //choices
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19), Checked = true });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(75, 55), Size = new Size(120, 23), Text = answer });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(205, 60), Size = new Size(22, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(230, 55), Size = new Size(120, 23), Text = ch[0] });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(360, 60), Size = new Size(22, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(385, 55), Size = new Size(120, 23), Text = ch[1] });
                if (no_choices == "4")
                {

                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = ch[2] });

                }
                else if (no_choices == "5")
                {
                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4", Text = ch[2] });

                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5", Text = ch[3] });



                }




                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                button.Text = "-";
                button.Tag = item.ToString();
                button.Location = new Point(830, 30);
                button.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel1);

                panel1.Controls.Add(button);

                //ADD

                MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                button1.Text = "+";
                button1.Tag = item.ToString();
                button1.Location = new Point(845, 30);
                button1.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel1);

                panel1.Controls.Add(button1);
                p.Controls.Add(panel1);
                p.Tag = 1;

                ch.Clear();

             
            



        }

        public void identification1(FlowLayoutPanel p, int item, List<string> ch, string question, string no_choices, string answer)
        {


            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question...", Location = new Point(50, 20), Size = new Size(600, 23), Tag = item, Text = question });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(80, 55), Size = new Size(70, 23), Text = "answer:" });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter answer....", Location = new Point(150, 55), Size = new Size(400, 23), Tag = 101, Text = answer });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "answer:", Location = new Point(10, 20), Size = new Size(30, 19) });
            //choices


            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
            MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
            button.Text = "Edit";
            button.Tag = item.ToString();
            button.Location = new Point(650, 40);
            button.Size = new Size(98, 23);

            //panel1.Controls.Add(button1);
            p.Controls.Add(panel1);
            p.Tag = 2;

            




        }

        public void trueorfalse1(FlowLayoutPanel p, int item, List<string> ch, string question, string no_choices, string answer)
        {

            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, item * 100), BackColor = Color.White };
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item, Text = question });



            if (answer == "True")
            {
                //new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) }
                MaterialSkin.Controls.MaterialRadioButton a = new MaterialSkin.Controls.MaterialRadioButton();
                a.Text = "True";
                a.Location = new Point(30, 60);
                a.Size = new Size(100, 19);
                a.Checked = true;

                MaterialSkin.Controls.MaterialRadioButton b = new MaterialSkin.Controls.MaterialRadioButton();
                b.Text = "False";
                b.Location = new Point(30, 95);
                b.Size = new Size(100, 19);
                panel1.Controls.Add(a);
                panel1.Controls.Add(b);

            }
            else
            {
                //new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) }
                MaterialSkin.Controls.MaterialRadioButton a = new MaterialSkin.Controls.MaterialRadioButton();
                a.Text = "True";
                a.Location = new Point(30, 60);
                a.Size = new Size(100, 19);


                MaterialSkin.Controls.MaterialRadioButton b = new MaterialSkin.Controls.MaterialRadioButton();
                b.Text = "False";
                b.Location = new Point(30, 95);
                b.Size = new Size(100, 19);
                b.Checked = true;
                panel1.Controls.Add(a);
                panel1.Controls.Add(b);

            }


            p.Controls.Add(panel1);
            p.Tag = 3;






        }


        public void photoguest1(FlowLayoutPanel p, int item, List<string> ch, string question, string no_choices, string answer)
        {

          
            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, item * 100), BackColor = Color.White };
            panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


            MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
            button.Text = "Add Photo";
            button.Tag = item.ToString();
            button.Location = new Point(5, 188);
            button.Size = new Size(380, 25);
            button.Tag = item;
            button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
            panel1.Controls.Add(button);


            p.Controls.Add(panel1);
            p.Tag = 4;






        }

        public void enumeration1(FlowLayoutPanel p, int item, List<string> ch, string question, string no_choices, string answer,int part)
        {

            for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
            {

                string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                MySqlCommand a3cmd = new MySqlCommand(a3, con);
                a3cmd.Parameters.AddWithValue("@item", item);
                a3cmd.Parameters.AddWithValue("@partno", part);
                a3cmd.Parameters.AddWithValue("@exam", examid);
              
                string chs = Convert.ToString(a3cmd.ExecuteScalar());

                // Console.WriteLine(chs + "choice");
                a3cmd.Dispose();
                ch.Add(chs);


            }
            //enurows
            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

            //choices
            FlowLayoutPanel enumerate = new FlowLayoutPanel();
            enumerate.Size = new Size(565, 80);
            enumerate.Location = new Point(65, 50);
            enumerate.BackColor = Color.GhostWhite;
            enumerate.FlowDirection = FlowDirection.LeftToRight;
            enumerate.AutoScroll = true;
            for (int x = 0; x < Convert.ToInt32(no_choices); x++)
            {

                enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item", Text = ch[x] });

            }



            panel1.Controls.Add(enumerate);
            NumericUpDown num = new NumericUpDown();
            num.Size = new Size(39, 36);
            num.Value = Convert.ToInt32(no_choices);
            num.Location = new Point(670, 60);
            num.ValueChanged += (sender2, e2) => btn_enumerate(sender2, e2, num, enumerate);
            num.Minimum = 1;
            num.Maximum = 50;
            panel1.Controls.Add(num);

            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
            MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
            button.Text = "add";
            button.Tag = item.ToString();
            button.Location = new Point(645, 90);
            button.Size = new Size(39, 36);
            //button.Click += new EventHandler(btn_choice,);

            //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel1);

            panel1.Controls.Add(button);

            //ADD

            MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
            button1.Text = "minus";
            button1.Tag = item.ToString();
            button1.Location = new Point(680, 90);
            button1.Size = new Size(39, 36);
            //button.Click += new EventHandler(btn_choice,);

            // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel1);

            panel1.Controls.Add(button1);

            p.Controls.Add(panel1);
            p.Tag = 5;
            ch.Clear();






        }

        public void essay1(FlowLayoutPanel p, int item, List<string> ch, string question, string no_choices, string answer, int points)
        {

            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 100), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Text = question, Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200 });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
            // panel1.Controls.Add(new )


            NumericUpDown num = new NumericUpDown();
            num.Size = new Size(39, 36);
            num.Value = points;
            num.Location = new Point(670, 60);
            num.Minimum = 1;
            num.Maximum = 20;
            panel1.Controls.Add(num);

            p.Controls.Add(panel1);
            p.Tag = 6;
            ch.Clear();






        }

        public void identification(FlowLayoutPanel p, int items, int EI)
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            {
                int item = (x + 1);

                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(898, 90), Location = new Point(10, item * 100), BackColor = Color.White };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question...", Location = new Point(50, 20), Size = new Size(600, 23), Tag = item });
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
                p.Controls.Add(panel1);
                p.Tag = 1;
            }



        }
        public void enumeration(FlowLayoutPanel p, int items, int EI)
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            {
                int item = (x + 1);

                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200 });

                //choices
                FlowLayoutPanel enumerate = new FlowLayoutPanel();
                enumerate.Size = new Size(565, 80);
                enumerate.Location = new Point(65, 50);
                enumerate.BackColor = Color.GhostWhite;
                enumerate.FlowDirection = FlowDirection.LeftToRight;
                enumerate.AutoScroll = true;


                enumerate.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });


                panel1.Controls.Add(enumerate);
                NumericUpDown num = new NumericUpDown();
                num.Size = new Size(39, 36);
                num.Value = 1;
                num.Location = new Point(670, 60);
                num.Minimum = 1;
                num.Maximum = 50;
                num.ValueChanged += (sender2, e2) => btn_enumerate(sender2, e2, num, enumerate);
                panel1.Controls.Add(num);

                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                button.Text = "add";
                button.Tag = item.ToString();
                button.Location = new Point(645, 90);
                button.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel1);

                panel1.Controls.Add(button);

                //ADD

                MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                button1.Text = "minus";
                button1.Tag = item.ToString();
                button1.Location = new Point(680, 90);
                button1.Size = new Size(39, 36);
                //button.Click += new EventHandler(btn_choice,);

                // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel1);

                panel1.Controls.Add(button1);
                p.Controls.Add(panel1);
                p.Tag = 1;
            }



        }

        public void trueOrFalse(FlowLayoutPanel p, int items, int EI)
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            {
                int item = (x + 1);
                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, item * 100), BackColor = Color.White };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });



                p.Controls.Add(panel1);
                p.Tag = 1;
            }



        }

        public void photoGuest(FlowLayoutPanel p, int items, int EI)
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            {
                int item = (x + 1);
                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(item * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                button.Text = "Add Photo";
                button.Tag = item;
                button.Location = new Point(60, 150);
                button.Size = new Size(120, 35);

                button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                panel1.Controls.Add(button);


                p.Controls.Add(panel1);
                p.Tag = 1;
            }



        }

        public void Essay(FlowLayoutPanel p, int items, int EI)
        {

            Console.WriteLine("temp ei" + EI);
            Console.WriteLine("temp item" + items);
            for (int x = EI; x < items; x++)
            {
                int item = (x + 1);

                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 100), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(700, 23), Tag = 200 });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Location = new Point(540, 60), Size = new Size(95, 23), Text = "set points:" });
                // panel1.Controls.Add(new )


                NumericUpDown num = new NumericUpDown();
                num.Size = new Size(39, 36);
                num.Value = 1;
                num.Location = new Point(670, 60);
                num.Minimum = 1;
                num.Maximum = 20;
                panel1.Controls.Add(num);
                p.Controls.Add(panel1);
                p.Tag = 1;
            }



        }     
        public static string filename;
    
        protected void btn_click(object sender, EventArgs e, dynamic p)
        {

            rb2 = (MaterialSkin.Controls.MaterialRaisedButton)sender;


            if (p is MaterialSkin.Controls.MaterialDivider)
            {

                MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)p;
                foreach (Control d in td.Controls)

                {

                    if (d is PictureBox)
                    {
                        pb2 = (PictureBox)d;


                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            string picloc = dlg.FileName.ToString();
                            pb2.ImageLocation = picloc;
                            filename = picloc;


                        }
                    }


                }

            }


            api = flowLayoutPanel1;

        }

         
        MaterialSkin.Controls.MaterialDivider md = new MaterialSkin.Controls.MaterialDivider();
        NumericUpDown number = new NumericUpDown();
        FlowLayoutPanel fp = new FlowLayoutPanel();
        private void btn_enumerate(object sender, EventArgs e, dynamic p, dynamic q)
        {
            Console.WriteLine("gumana");

            if (p is NumericUpDown)
            {

                number = (NumericUpDown)p;



            }


            if (q is FlowLayoutPanel)
            {

                fp = (FlowLayoutPanel)q;

                fp.Controls.Clear();

                for (int i = 0; i < number.Value; i++)
                {
                    fp.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });
                }
            }







        }

        private void btn_choice(object sender, EventArgs e, dynamic p)
        {

            MaterialSkin.Controls.MaterialFlatButton add = (MaterialSkin.Controls.MaterialFlatButton)sender;
            foreach (Control fl in p.Controls)
            {
                if (fl is MaterialSkin.Controls.MaterialDivider)
                {
                    md = (MaterialSkin.Controls.MaterialDivider)fl;

                    if (md.Tag.ToString() == add.Tag.ToString())
                    {
                        Console.WriteLine("count" + md.Tag);
                        Console.WriteLine("count" + add.Tag);
                        int b = 0;
                        foreach (Control count in md.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>())
                        {
                            b += 1;
                            Console.WriteLine("count" + b);
                        }
                        if (b == 5)
                        {

                            foreach (Control item in md.Controls.OfType<Control>())
                            {
                                if (item.Name == "5")
                                {
                                    md.Controls.Remove(item);

                                    foreach (Control item2 in md.Controls.OfType<Control>())
                                    {
                                        if (item2.Name == "51")
                                        {
                                            md.Controls.Remove(item2);

                                        }
                                    }
                                }
                            }
                            b--;

                        }

                        else
                        {
                            foreach (Control item in md.Controls.OfType<Control>())
                            {
                                if (item.Name == "4")
                                {
                                    md.Controls.Remove(item);

                                    foreach (Control item2 in md.Controls.OfType<Control>())
                                    {
                                        if (item2.Name == "41")
                                        {
                                            md.Controls.Remove(item2);

                                        }
                                    }

                                    b--;
                                }
                            }
                        }
                        Console.WriteLine(b);
                    }
                }
            }



        }
        private void btn_choice1(object sender, EventArgs e, dynamic p)
        {

            MaterialSkin.Controls.MaterialFlatButton add = (MaterialSkin.Controls.MaterialFlatButton)sender;

            foreach (Control fl in p.Controls)
            {
                if (fl is MaterialSkin.Controls.MaterialDivider)
                {
                    md = (MaterialSkin.Controls.MaterialDivider)fl;

                    if (md.Tag.ToString() == add.Tag.ToString())
                    {
                        Console.WriteLine("count" + md.Tag);
                        Console.WriteLine("count" + add.Tag);
                        int b = 0;
                        foreach (Control count in md.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>())
                        {
                            b += 1;
                            Console.WriteLine("count" + b);
                        }
                        if (b == 3)
                        {

                            md.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(515, 60), Size = new Size(22, 19), Name = "41" });
                            md.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(540, 55), Size = new Size(120, 23), Tag = 4, Name = "4" });
                            b++;

                        }

                        else if (b == 4)
                        {


                            md.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(670, 60), Size = new Size(22, 19), Name = "51" });
                            md.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter choices", Location = new Point(695, 55), Size = new Size(120, 23), Tag = 5, Name = "5" });
                            b++;
                        }
                        Console.WriteLine(b);

                    }


                }

            }


        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count < 10)
            {
                TabPage tb = new TabPage();

                tb.Tag = tabControl1.Controls.Count + 1;

                Label lb = new Label();

                lb.Text = "Select Exam Type:";
                lb.Size = new Size(101, 13);
                lb.Location = new Point(29, 24);

                Label lb2 = new Label();
                lb2.Text = "No Of Items:";
                lb2.Size = new Size(66, 13);
                lb2.Location = new Point(346, 24);

                NumericUpDown nud = new NumericUpDown();
                nud.Minimum = 1;
                nud.Maximum = 20;
                nud.Size = new Size(62, 20);
                nud.Location = new Point(427, 21);
                nud.Tag = "b";

                Label lb3 = new Label();
                lb3.Text = "Points Per Item:";
                lb3.Size = new Size(84,13);
                lb3.Location = new Point(572, 26);

                Label lb4 = new Label();
                lb4.Text = "Set Instructions";
                lb4.Size = new Size(84, 13);
                lb4.Location = new Point(752, 21);

                TextBox tb1 = new TextBox();
                tb1.Multiline = true;
                tb1.Size = new Size(186, 39);
                tb1.Location = new Point(844, 17);
                tb1.Tag = "d";

                Label lb5 = new Label();
                lb5.Text = "Set Difficulty";
                lb5.Size = new Size(112, 13);
                lb5.Location = new Point(1053, 28);

                ComboBox cbx1 = new ComboBox();
                cbx1.Size = new Size(121, 21);
                cbx1.Location = new Point(1171, 25);
                cbx1.Tag = "";
                cbx1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbx1.Tag = "e";
                cbx1.Items.Add("EASY");
                cbx1.Items.Add("NORMAL");
                cbx1.Items.Add("HARD");
                cbx1.Items.Add("VERY HARD");


                NumericUpDown nud1 = new NumericUpDown();
                nud1.Minimum = 1;
                nud1.Maximum = 20;

                nud1.Size = new Size(62, 20);
                nud1.Location = new Point(662,22);
                nud1.Tag = "c";

                ComboBox cbx = new ComboBox();
                cbx.Size = new Size(147, 21);
                cbx.Location = new Point(136, 21);
                cbx.Items.Add("Multiple Choice");
                cbx.Items.Add("Identification");
                cbx.Items.Add("true or false");
                cbx.Items.Add("Photo Guest");
                cbx.Items.Add("Enumeration");
                cbx.Items.Add("Essay");
                cbx.Tag = "a";
                cbx.DropDownStyle = ComboBoxStyle.DropDownList;






                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Size = new Size(1305, 400);
                flp.Location = new Point(12, 62);
                flp.BackColor = Color.LightGray;
                flp.AutoScroll = true;

                cbx.SelectedValueChanged += (sender2, e2) => types(sender2, e2, flp, Convert.ToInt32(nud.Value), cbx,nud1,lb3);
                nud.ValueChanged += (sender2, e2) => Items(sender2, e2, flp, Convert.ToInt32(nud.Value), cbx);
                Button edit = new Button();
                edit.Size = new Size(75, 23);
                edit.Location = new Point(1113, 492);
                edit.Text = "Edit";

                Button save = new Button();
                save.Size = new Size(75, 23);
                save.Location = new Point(1232, 492);
                save.Tag = tabControl1.Controls.Count + 1;
                Console.WriteLine("line" + save.Tag);
                save.Text = "save";
                tb.Controls.Add(lb);
                tb.Controls.Add(lb2);
                tb.Controls.Add(nud1);
                tb.Controls.Add(nud);
                tb.Controls.Add(lb3);
                tb.Controls.Add(cbx);
                tb.Controls.Add(flp);
                tb.Controls.Add(edit);
                tb.Controls.Add(save);
                tb.Controls.Add(lb4);
                tb.Controls.Add(lb5);
                tb.Controls.Add(tb1);
                tb.Controls.Add(cbx1);



                tb.Text = "PART " + (tabControl1.Controls.Count + 1);
                tb.Size = new Size(1336, 536);
                tb.BackColor = Color.Transparent;
                tb.UseVisualStyleBackColor = true;
                tabControl1.Controls.Add(tb);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 1)
                { }
            else
            {
                tabControl1.Controls.RemoveAt(tabControl1.Controls.Count - 1);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            generate();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        types(sender, e, flowLayoutPanel1, Convert.ToInt32(numericUpDown1.Value), comboBox1,numericUpDown2,label3);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Items(sender, e, flowLayoutPanel1, Convert.ToInt32(numericUpDown1.Value), comboBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Console.WriteLine( flowLayoutPanel1.Controls.Count);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

       
        private void button5_Click_1(object sender, EventArgs e)
        {
          
           
            int points = 0;
            examSave(tabControl1, points);
            foreach (Control a in tabControl1.Controls)
            {
                
                //whole tab
                if (a is TabPage)
                {
                    int temp1 = 0;
                    int temp3 = 0;
                    string type = "";
                    int noOfItems = 0;
                    string ins = "";
                    string dif = "";
                    ComboBox cb = new ComboBox();
                    TabPage tb = (TabPage)a;
                    foreach (Control tbc in tb.Controls)
                    {
                       
                        
                        //per part
                        if (Convert.ToString(tbc.Tag) == "a")
                        {
                            cb = (ComboBox)tbc;
                            Console.WriteLine(cb.Text+"taggg"+cb.SelectedIndex);
                            type = cb.Text;
                            temp3 = cb.SelectedIndex;


                        }


                        

                      

                    }

                    foreach (Control tbc in tb.Controls)

                    {
                         if (Convert.ToString(tbc.Tag) == "b")
                        {
                            NumericUpDown nud = (NumericUpDown)tbc;
                            Console.WriteLine(nud.Value + "taggg");
                            noOfItems = Convert.ToInt32(nud.Value);
                        }

                        else if (Convert.ToString(tbc.Tag) == "c")
                        {
                            NumericUpDown nud1 = (NumericUpDown)tbc;
                            Console.WriteLine(nud1.Value + "taggg");
                            temp1 = Convert.ToInt32(nud1.Value);
                        }

                        else if (Convert.ToString(tbc.Tag) == "d")
                        {
                            TextBox nud2 = (TextBox)tbc;
                            Console.WriteLine(nud2.Text + "taggg");
                            ins = nud2.Text;
                        }


                        else if (Convert.ToString(tbc.Tag) == "e")
                        {
                            ComboBox nud3 = (ComboBox)tbc;
                            Console.WriteLine(nud3.Text + "taggg");
                            dif = nud3.Text;
                        } 

                        else if (tbc is FlowLayoutPanel)
                        {
                            Console.WriteLine("flow" + cb.SelectedIndex);

                            Console.WriteLine(temp3 + "ttt");

                            //essay 
                            if (temp3 == 5)
                            {
                                Console.WriteLine("essay");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;
                                int value = 0;


                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                        Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                       




                                        foreach (Control d in td.Controls)
                                        {
                                            if (d is NumericUpDown)
                                            {
                                                Console.WriteLine("number");
                                                num = (NumericUpDown)d;
                                                
                                                temp2 += Convert.ToInt32(num.Value);
                                                Console.WriteLine("nummmmmmm"+num.Value);
                                                value =Convert.ToInt32( num.Value);
                                            }

                                            if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                            {

                                                MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                                string str = tf.Text.ToLower();






                                                if (Convert.ToInt32(tf.Tag) == 200)
                                                {
                                                    q = str;
                                                    // item_no = Convert.ToInt32(tf.Tag);
                                                    Console.WriteLine("gumana sya");
                                                }




                                            }
                                            Console.WriteLine("tep" + temp2);

                                            
                                        }

                                        itemSave(Convert.ToInt32(a.Tag), temp4, q, no_ch, value);

                                        temp4 += 1;
                                      
                                    }



                                 

                                }

                                points += temp2;

                                Console.WriteLine("esssssay"+points);
                            }




                            //multiple chice
                            else if (temp3 == 0)
                            {

                                points += (noOfItems * temp1);
                                Console.WriteLine("esssssay" + points);
                                Console.WriteLine("else" + points);
                                Console.WriteLine("else" + noOfItems);
                                Console.WriteLine("else" + temp1);

                                Console.WriteLine("others");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;

                                 
                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                         Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                        no_ch = 0;
                                        int ch_flag = 0;



                                        foreach (Control d in td.Controls)
                                        {
                                            if (d is NumericUpDown)
                                            {
                                                Console.WriteLine("number");
                                                num = (NumericUpDown)d;
                                                temp2 += Convert.ToInt32(num.Value);

                                            }

                                            if (d is MaterialSkin.Controls.MaterialLabel)

                                            {
                                                lb = (MaterialSkin.Controls.MaterialLabel)d;

                                                if (Convert.ToInt32(lb.Tag) >= 1)
                                                {

                                                    item_no = Convert.ToInt32(lb.Tag);
                                                }
                                            }


                                            if (d is MaterialSkin.Controls.MaterialRadioButton)
                                            {
                                                no_ch += 1;
                                                rb = (MaterialSkin.Controls.MaterialRadioButton)d;
                                            }
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


                                                else if (rb.Checked == true)
                                                {
                                                    answer = str;
                                                    Console.WriteLine("sagot" + answer);
                                                    
                                                    ch_flag += 1;
                                                    choiceSave(Convert.ToInt32(a.Tag), temp4,1,ch_flag,answer);

                                                }
                                                else
                                                {
                                                    ch_flag += 1;
                                                  
                                                    choiceSave(Convert.ToInt32(a.Tag), temp4,0,ch_flag,str);

                                                }



                                            }
                                        }


                                        

                                        itemSave(Convert.ToInt32(a.Tag),temp4, q, no_ch,temp1);
                                        temp4 += 1;

                                    }



                                }

                            }


                            else if (temp3 == 1)
                            {

                                points += (noOfItems * temp1);
                                Console.WriteLine("esssssay" + points);
                                Console.WriteLine("else" + points);
                                Console.WriteLine("else" + noOfItems);
                                Console.WriteLine("else" + temp1);

                                Console.WriteLine("others");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;


                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                        Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                        no_ch = 0;
                                        int ch_flag = 0;



                                        foreach (Control d in td.Controls)
                                        {

                                            if (d is MaterialSkin.Controls.MaterialRadioButton)
                                            {

                                                rb = (MaterialSkin.Controls.MaterialRadioButton)d;


                                            }
                                            if (d is MaterialSkin.Controls.MaterialLabel)

                                            {
                                                lb = (MaterialSkin.Controls.MaterialLabel)d;
                                            }

                                            if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                            {



                                                MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                                string str = tf.Text.ToLower();



                                                if ((Convert.ToInt32(tf.Tag) >= 1) && (Convert.ToInt32(tf.Tag) <= 50))
                                                {
                                                    q = str;
                                                    item_no = Convert.ToInt32(tf.Tag);


                                                }


                                                else if (Convert.ToInt32(tf.Tag) == 101)
                                                {
                                                    answer = str;
                                                    answer.ToLower();

                                                    ch_flag += 1;
                                                    no_ch += 1;

                                                    choiceSave(Convert.ToInt32(a.Tag), temp4, 1, ch_flag, answer);


                                                }




                                            }



                                        }




                                        itemSave(Convert.ToInt32(a.Tag), temp4, q, no_ch, temp1);
                                        temp4 += 1;

                                    }



                                }

                            }


                            else if (temp3 == 2)
                            {

                                points += (noOfItems * temp1);
                                Console.WriteLine("esssssay" + points);
                                Console.WriteLine("else" + points);
                                Console.WriteLine("else" + noOfItems);
                                Console.WriteLine("else" + temp1);

                                Console.WriteLine("others");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;


                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                        Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                        no_ch = 0;
                                        int ch_flag = 0;



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
                                                    answer = rb.Text.ToLower(); ;

                                                    ch_flag += 1;
                                                    no_ch += 1;

                                                    choiceSave(Convert.ToInt32(a.Tag), temp4, 1, ch_flag, answer);
                                                }


                                            }





                                        }




                                        itemSave(Convert.ToInt32(a.Tag), temp4, q, no_ch, temp1);
                                        temp4 += 1;

                                    }



                                }

                            }


                            else if (temp3 == 3)
                            {

                                points += (noOfItems * temp1);
                                Console.WriteLine("esssssay" + points);
                                Console.WriteLine("else" + points);
                                Console.WriteLine("else" + noOfItems);
                                Console.WriteLine("else" + temp1);

                                Console.WriteLine("others");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;


                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                        Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                        no_ch = 0;
                                        int ch_flag = 0;
                                        
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

                                                ch_flag += 1;
                                                no_ch += 1;

                                                choiceSave(Convert.ToInt32(a.Tag), temp4, 1, ch_flag, answer);
                                            }





                                        }




                                        itemSave(Convert.ToInt32(a.Tag), temp4, filename, no_ch, temp1);
                                        temp4 += 1;

                                    }



                                }

                            }


                            else if (temp3 == 4)
                            {

                               // points += (noOfItems * temp1);
                                Console.WriteLine("esssssay" + points);
                                Console.WriteLine("else" + points);
                                Console.WriteLine("else" + noOfItems);
                                Console.WriteLine("else" + temp1);

                                Console.WriteLine("others");
                                int temp2 = 0;

                                FlowLayoutPanel fl = (FlowLayoutPanel)tbc;
                                int temp4 = 1;


                                foreach (Control fltemp in fl.Controls)

                                {

                                    if (fltemp is MaterialSkin.Controls.MaterialDivider)
                                    {

                                        Console.WriteLine("divider");
                                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)fltemp;
                                        no_ch = 0; 
                                        int ch_flag = 0;

                                        foreach (Control d in td.Controls)
                                        {
                                            if (d is MaterialSkin.Controls.MaterialLabel)

                                            {
                                                lb = (MaterialSkin.Controls.MaterialLabel)d;

                                                if (Convert.ToInt32(lb.Tag) >= 1)
                                                {

                                                    item_no = Convert.ToInt32(lb.Tag);
                                                }
                                            }



                                            int ques = 0;
                                            if (d is MaterialSkin.Controls.MaterialSingleLineTextField)
                                            {

                                                MaterialSkin.Controls.MaterialSingleLineTextField tf = (MaterialSkin.Controls.MaterialSingleLineTextField)d;
                                                string str = tf.Text.ToLower();


                                                ques = Convert.ToInt32(tf.Tag);

                                                if (ques > 100)
                                                {
                                                    q = str;

                                                    Console.WriteLine("ques" + q);
                                                }






                                            }


                                            if (d is NumericUpDown)
                                            {




                                            }

                                            if (d is FlowLayoutPanel)
                                            {

                                                Console.WriteLine("gumana flow");
                                                //fppp
                                                fp = (FlowLayoutPanel)d;
                                                no_ch = fp.Controls.Count;

                                                points += (no_ch * temp1);
                                                foreach (Control f in d.Controls)
                                                {

                                                    if (f is MaterialSkin.Controls.MaterialSingleLineTextField)
                                                    {

                                                        mtf = (MaterialSkin.Controls.MaterialSingleLineTextField)f;

                                                        mf = mtf.Text.ToLower();
                                                        Console.WriteLine(mf);

                                                        list.Add(mf);


                                                        ch_flag += 1;

                                                        
                                                        choiceSave(Convert.ToInt32(a.Tag), temp4, 1, ch_flag, mf);

                                                    }


                                                }



                                            }






                                        }




                                        itemSave(Convert.ToInt32(a.Tag), temp4, q, no_ch, temp1);
                                        temp4 += 1;

                                    }



                                }

                            }


                        }



                    }


                    Console.WriteLine(type +"/" +ins+ "/" + dif);
                    partSave(Convert.ToInt32(a.Tag), noOfItems, type, 0,ins,dif,temp1);
                    //per parts insert


                }

                

            }

            //perexam
            Console.WriteLine(points + "total points");
            examSave(tabControl1, points);

            //
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ssection.Items.Clear();
            con.Close();
            con.Open();
            string sql1 = string.Format(@"SELECT section FROM class WHERE grade='{0}'", sgrade.Text);
            MySqlCommand sqlcmd1 = new MySqlCommand(sql1, con);
            MySqlDataReader dr1 = sqlcmd1.ExecuteReader();
            while (dr1.Read())
            {
                ssection.Items.Add(dr1.GetString("section"));
            }

            con.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();


        }
    }
}
