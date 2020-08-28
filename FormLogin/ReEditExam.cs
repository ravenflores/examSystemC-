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
    public partial class ReEditExam : Form
    {
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring2);
        public static string filename;
        MultipleSlidingPAnel o1;
      
        string currentuser;
        string currentpass;
        int examparts = 0;
        public ReEditExam(string txt1,string user,string pass)
        {
            InitializeComponent();
            Text = txt1;
            currentuser = pass;
            currentpass = user;


         
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
                    }

        public void ex()
        {



        }
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
                        comboBox1.Text = levels[0];



                        materialSingleLineTextField1.Text = ins[0];


                        break;

                    case 2:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];


                        break;

                    case 3:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];


                        break;
                    case 4:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];


                        break;

                    case 5:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];


                        break;

                    case 6:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];
                        comboBox6.Text = levels[5];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];
                        materialSingleLineTextField6.Text = ins[5];


                        break;

                    case 7:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];
                        comboBox6.Text = levels[5];
                        comboBox7.Text = levels[6];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];
                        materialSingleLineTextField6.Text = ins[5];
                        materialSingleLineTextField7.Text = ins[6];


                        break;

                    case 8:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];
                        comboBox6.Text = levels[5];
                        comboBox7.Text = levels[6];
                        comboBox8.Text = levels[7];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];
                        materialSingleLineTextField6.Text = ins[5];
                        materialSingleLineTextField7.Text = ins[6];
                        materialSingleLineTextField8.Text = ins[7];


                        break;
                    case 9:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];
                        comboBox6.Text = levels[5];
                        comboBox7.Text = levels[6];
                        comboBox8.Text = levels[7];
                        comboBox9.Text = levels[8];



                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];
                        materialSingleLineTextField6.Text = ins[5];
                        materialSingleLineTextField7.Text = ins[6];
                        materialSingleLineTextField8.Text = ins[7];
                        materialSingleLineTextField9.Text = ins[8];


                        break;

                    case 10:
                        comboBox1.Text = levels[0];
                        comboBox2.Text = levels[1];
                        comboBox3.Text = levels[2];
                        comboBox4.Text = levels[3];
                        comboBox5.Text = levels[4];
                        comboBox6.Text = levels[5];
                        comboBox7.Text = levels[6];
                        comboBox8.Text = levels[7];
                        comboBox9.Text = levels[8];
                        comboBox10.Text = levels[9];


                        materialSingleLineTextField1.Text = ins[0];
                        materialSingleLineTextField2.Text = ins[1];
                        materialSingleLineTextField3.Text = ins[2];
                        materialSingleLineTextField4.Text = ins[3];
                        materialSingleLineTextField5.Text = ins[4];
                        materialSingleLineTextField6.Text = ins[5];
                        materialSingleLineTextField7.Text = ins[6];
                        materialSingleLineTextField8.Text = ins[7];
                        materialSingleLineTextField9.Text = ins[8];
                        materialSingleLineTextField10.Text = ins[9];

                        break;
                }




            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }


           
           





           

        }


        public void details()
        {
            con.Close();
            con.Open();

            string name = "SELECT col_exam_name FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand namecmd = new MySqlCommand(name, con);
            namecmd.Parameters.AddWithValue("@exam_id", this.Text);
            string exn = Convert.ToString(namecmd.ExecuteScalar());
            txtExamName.Text = exn;
            Console.WriteLine("NAME"+exn);
            string grade = "SELECT col_exam_grade FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gradecmd = new MySqlCommand(grade, con);
            gradecmd.Parameters.AddWithValue("@exam_id", this.Text);
            string grd = Convert.ToString(gradecmd.ExecuteScalar());
            sgrade.Text = grd;
            Console.WriteLine("GRADE"+grd);

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
            scncmd.Parameters.AddWithValue("@exam_id", this.Text);
            string scn = Convert.ToString(scncmd.ExecuteScalar());
            ssection.Text = scn;

         



            Console.WriteLine("SECTION"+scn);
            string subjectt = "SELECT subject FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand sjtcmd = new MySqlCommand(subjectt, con);
            sjtcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string sjt = Convert.ToString(sjtcmd.ExecuteScalar());
            subject.Text = sjt;
            Console.WriteLine("SUBJECT"+sjt);

            string date= "SELECT col_exam_date FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand dtcmd = new MySqlCommand(date, con);
            dtcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string dt = Convert.ToString(dtcmd.ExecuteScalar());
            dtpExamDate.Text = dt;
            Console.WriteLine("DATE"+dt);
            

            string hour = "SELECT col_exam_duration_hrs FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand hrcmd = new MySqlCommand(hour, con);
            hrcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string hr = Convert.ToString(hrcmd.ExecuteScalar());
            nudHr.Text = hr;
            Console.WriteLine("hr"+hr);


            string mins = "SELECT col_exam_duration_mins FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand mincmd = new MySqlCommand(mins, con);
            mincmd.Parameters.AddWithValue("@exam_id", this.Text);
            string min = Convert.ToString(mincmd.ExecuteScalar());
            nudMin.Text = min;
            con.Close();

            Console.WriteLine("min" + hr);

            con.Close();
        }
        private void ReEditExam_Load(object sender, EventArgs e)
        {  
          //  details();
            inslevel();
            Console.WriteLine("text"+this.Text);
            con.Close();
            con.Open();
            //getting how many parts
            string getExamParts = "SELECT col_exam_parts FROM tbl_exam where  col_exam_id = " + this.Text + " and col_teacher_id = " + this.Tag + "";

            MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

            int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
            getpartscmd.Dispose();
            Console.WriteLine(examPartsCount+"examcount");

            examparts = examPartsCount;
            con.Close();

            generate();
            details();
            switch (examPartsCount)
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
            // ex();
        }
     
        public void generate()
        {
            Console.WriteLine("examssss id"+this.Text);
            con.Close();
            con.Open();
            string gex = "SELECT col_exam_name FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gexcmd = new MySqlCommand(gex, con);
            gexcmd.Parameters.AddWithValue("@exam_id", this.Text);
            string exn = Convert.ToString(gexcmd.ExecuteScalar());
            Console.WriteLine(exn + "exam name");
            label3.Text = exn;
            con.Close();

            con.Close();
            con.Open();
            string gex1 = "SELECT subject FROM tbl_exam where  col_exam_id = @exam_id";
            MySqlCommand gexcmd1 = new MySqlCommand(gex1, con);
            gexcmd1.Parameters.AddWithValue("@exam_id", this.Text);
            string exn1 = Convert.ToString(gexcmd1.ExecuteScalar());
            Console.WriteLine(exn + "exam name");
            label1.Text = exn1;
            con.Close();

            con.Open();
                MySqlCommand cmd = new MySqlCommand("select q.col_question from tbl_parts p, tbl_question q where q.col_part_id = p.col_part_id and q.col_part_no = p.col_part_no and p.col_exam_id =@exam", con);

                cmd.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));

                MySqlDataReader dr = cmd.ExecuteReader();
       
          
    



            MemoryStream ms = new MemoryStream();

            if (dr.HasRows == true)
            {
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = false;
                flowLayoutPanel3.Enabled = false;
                flowLayoutPanel4.Enabled = false;
                flowLayoutPanel5.Enabled = false;
                flowLayoutPanel6.Enabled = false;
                flowLayoutPanel7.Enabled = false;
                flowLayoutPanel8.Enabled = false;
                flowLayoutPanel9.Enabled = false;
                flowLayoutPanel10.Enabled = false;

                con.Close();
                con.Open();
                //prototype
                try
                {
                    
                    //getting how many parts
                    string getExamParts = "SELECT col_exam_parts FROM tbl_exam where col_exam_id = " + this.Text + " ";

                    MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

                    int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
                    getpartscmd.Dispose();


                    //dividing the partssave
                    

                    for (int i = 1; i <= examPartsCount; i++)
                    {
                        //getting how many items in part
                        if (i == 1) 
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation
                          
                           
                            for (int item = 1; item <= itemsCount; item++)
                            {
                                
                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";
                                
                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                             

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                             
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
   
                                a1cmd.Dispose();

                                
                                 string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();
                                Console.WriteLine(no_choices+"ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                              
                      

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test"+chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }




                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 1;

                                    ch.Clear();
                                    
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel1.Controls.Add(panel1);

                                    flowLayoutPanel1.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {
                                    
                                    flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel1.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage,ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item,Text = answer });
                            

                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel1.Controls.Add(panel1);

                                    flowLayoutPanel1.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 5;
                                    ch.Clear();
                                }

                                else if (type == "Essay")
                                {
                                   

                                    //enurows
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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 6;
                                }




                            }
                        }



                        if (i == 2)

                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();



                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel2.Controls.Add(panel1);

                                    flowLayoutPanel2.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel2.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel2.Controls.Add(panel1);

                                    flowLayoutPanel2.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 5;
                                    ch.Clear();
                                }


                                else if (type == "Essay")
                                {


                               

                                    q2cmd.Dispose();
                                    //enurows
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
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 6;
                                }







                            }
                        }

                        if (i == 3)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();

                                Console.WriteLine("/" + item);
                                Console.WriteLine("/" + i);
                                Console.WriteLine("/" + this.Text);
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {


                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }

                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel3.Controls.Add(panel1);

                                    flowLayoutPanel3.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel3.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel3.Controls.Add(panel1);

                                    flowLayoutPanel3.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {


                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 5;
                                }


                                else if (type == "Essay")
                                {
                                   

                                    q2cmd.Dispose();


                                    //enurows
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
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 6;
                                }




                            }
                        }

                        if (i == 4)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel4.Controls.Add(panel1);

                                    flowLayoutPanel4.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel4.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel4.Controls.Add(panel1);

                                    flowLayoutPanel4.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 5;
                                }


                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 6;
                                }




                            }
                        }

                        if (i == 5)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();
                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel5.Controls.Add(panel1);

                                    flowLayoutPanel5.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel5.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel5.Controls.Add(panel1);

                                    flowLayoutPanel5.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 5;
                                }

                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 6;
                                }




                            }
                        }

                        if (i == 6)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel6.Controls.Add(panel1);

                                    flowLayoutPanel6.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel6.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel6.Controls.Add(panel1);

                                    flowLayoutPanel6.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 5;
                                }

                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 6;
                                }




                            }
                        }

                        if (i == 7)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {


                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }

                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel7.Controls.Add(panel1);

                                    flowLayoutPanel7.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel7.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel7.Controls.Add(panel1);

                                    flowLayoutPanel7.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 5;
                                }


                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 6;
                                }




                            }
                        }

                        if (i == 8)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel8.Controls.Add(panel1);

                                    flowLayoutPanel8.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel8.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel8.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel8.Controls.Add(panel1);

                                    flowLayoutPanel8.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 5;
                                }


                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 6;
                                }

                            }
                        }

                        if (i == 9)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {


                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }

                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel9.Controls.Add(panel1);

                                    flowLayoutPanel9.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel9.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel9.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel9.Controls.Add(panel1);

                                    flowLayoutPanel9.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 5;
                                }

                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 6;
                                }




                            }
                        }

                        if (i == 10)
                        {

                            string items = "SELECT col_part_items FROM tbl_parts   where col_part_no=" + i + "  and  col_exam_id = " + this.Text + "";

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



                            //counting exams panel creation


                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //question  


                                string q2 = "select col_question from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string question = Convert.ToString(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                q2 = "select col_points from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                q2cmd = new MySqlCommand(q2, con);
                                q2cmd.Parameters.AddWithValue("@item", item);
                                q2cmd.Parameters.AddWithValue("@partno", i);
                                q2cmd.Parameters.AddWithValue("@exam", this.Text);
                                int points = Convert.ToInt32(q2cmd.ExecuteScalar());


                                q2cmd.Dispose();

                                string q3 = "select col_question_id from tbl_question where col_question_no = @item and col_exam_id = @exam and col_part_no = @partno";

                                MySqlCommand q3cmd = new MySqlCommand(q3, con);
                                q3cmd.Parameters.AddWithValue("@item", item);
                                q3cmd.Parameters.AddWithValue("@partno", i);
                                q3cmd.Parameters.AddWithValue("@exam", this.Text);
                                string questionid = Convert.ToString(q3cmd.ExecuteScalar());


                                q3cmd.Dispose();




                                //answer
                                con.Close();
                                con.Open();
                                string a1 = "SELECT col_choices from tbl_choices where col_item_id = @item and col_exam_id = @exam and col_part_id = @partno and col_answer_flag = 1";
                                MySqlCommand a1cmd = new MySqlCommand(a1, con);
                                a1cmd.Parameters.AddWithValue("@item", item);
                                a1cmd.Parameters.AddWithValue("@partno", i);
                                a1cmd.Parameters.AddWithValue("@exam", this.Text);
                                string answer = Convert.ToString(a1cmd.ExecuteScalar());
                                Console.WriteLine();

                                a1cmd.Dispose();

                                con.Close();
                                con.Open();
                                string a2 = "SELECT col_no_choices from tbl_question where col_exam_id = @exam and col_part_no= @partno and col_question_no = @item";
                                MySqlCommand a2cmd = new MySqlCommand(a2, con);
                                a2cmd.Parameters.AddWithValue("@item", item);
                                a2cmd.Parameters.AddWithValue("@partno", i);
                                a2cmd.Parameters.AddWithValue("@exam", this.Text);
                                string no_choices = Convert.ToString(a2cmd.ExecuteScalar());
                                int choicesCount = Convert.ToInt32(no_choices);
                                Console.WriteLine(no_choices + "ch");
                                Console.WriteLine(item + "item");
                                Console.WriteLine(i + "part");
                                Console.WriteLine(this.Text + "exam");
                                a2cmd.Dispose();
                                List<string> ch = new List<string>();

                                ////////////////////////////////////////////////////////////////////////////////////

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {

                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_item_id = @item and col_answer_flag = 0  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
                                        string chs = Convert.ToString(a3cmd.ExecuteScalar());

                                        Console.WriteLine("test" + chs);
                                        a3cmd.Dispose();
                                        ch.Add(chs);


                                    }


                                    ////

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(890, 90), Location = new Point(10, item * 100), BackColor = Color.White, Tag = item };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ":", Location = new Point(10, 20), Size = new Size(30, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "enter question", Location = new Point(50, 20), Size = new Size(630, 23), Tag = 200, Text = question });

                                    //choices
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Location = new Point(50, 60), Size = new Size(22, 19) });
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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 1;


                                    ch.Clear();
                                }

                                else if (type == "Identification")
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


                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 2;
                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
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

                                    flowLayoutPanel10.Controls.Add(panel1);

                                    flowLayoutPanel10.Tag = 3;

                                }
                                else if (type == "Photo Guest")
                                {

                                    flowLayoutPanel10.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel10.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(385, 250), Location = new Point(10, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new PictureBox { Location = new Point(5, 5), Size = new Size(380, 180), BackColor = Color.Black, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = question });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Answer", Location = new Point(5, 215), Size = new Size(380, 20), Tag = item, Text = answer });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = i.ToString();
                                    button.Location = new Point(5, 188);
                                    button.Size = new Size(380, 25);
                                    button.Tag = i;
                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel10.Controls.Add(panel1);

                                    flowLayoutPanel10.Tag = 4;
                                }

                                else if (type == "Enumeration")
                                {
                                    for (int choices = 0; choices < Convert.ToInt32(no_choices); choices++)
                                    {

                                        string a3 = "SELECT col_choices from tbl_choices where col_exam_id = @exam and col_part_id= @partno and col_answer_flag = 1 and  col_item_id = @item  limit " + choices + ",1";
                                        MySqlCommand a3cmd = new MySqlCommand(a3, con);
                                        a3cmd.Parameters.AddWithValue("@item", item);
                                        a3cmd.Parameters.AddWithValue("@partno", i);
                                        a3cmd.Parameters.AddWithValue("@exam", this.Text);
                                        a3cmd.Parameters.AddWithValue("@qid", questionid);
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
                                    panel1.Controls.Add(num);

                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });
                                    MaterialSkin.Controls.MaterialFlatButton button = new MaterialSkin.Controls.MaterialFlatButton();
                                    button.Text = "add";
                                    button.Tag = item.ToString();
                                    button.Location = new Point(645, 90);
                                    button.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 5;
                                }

                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 6;
                                }




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

                //end proto


            }
            //>>>> no rows      
            else
            {

                comboBox1.Text = "EASY";
                comboBox2.Text = "EASY";
                comboBox3.Text = "EASY";
                comboBox4.Text = "EASY";
                comboBox5.Text = "EASY";
                comboBox6.Text = "EASY";
                comboBox7.Text = "EASY";
                comboBox8.Text = "EASY";
                comboBox9.Text = "EASY";
                comboBox10.Text = "EASY";
                con.Close();

                try
                {
                    con.Open();
                    //getting how many parts
                    string getExamParts = "SELECT col_exam_parts FROM tbl_exam where  col_exam_id = " + this.Text + " ";

                    MySqlCommand getpartscmd = new MySqlCommand(getExamParts, con);

                    int examPartsCount = Convert.ToInt32(getpartscmd.ExecuteScalar());
                    getpartscmd.Dispose();

                    //dividing the parts

                    for (int i = 1; i <= examPartsCount; i++)
                    {
                        //getting how many items in part
                        if (i == 1)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel1.Controls.Add(panel1);

                                    flowLayoutPanel1.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel1.Controls.Add(panel1);

                                    flowLayoutPanel1.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel1.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 4;

                                }


                                else if (type == "Enumeration")
                                {



                                    //enurows
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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel1.Controls.Add(panel1);
                                    flowLayoutPanel1.Tag = 6;
                                }



                            }
                        }


                        if (i == 2)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel2.Controls.Add(panel1);

                                    flowLayoutPanel2.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel2.Controls.Add(panel1);

                                    flowLayoutPanel2.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel2.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel2.Controls.Add(panel1);

                                }


                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel2);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel2.Controls.Add(panel1);
                                    flowLayoutPanel2.Tag = 6;
                                }




                            }
                        }


                        if (i == 3)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel3.Controls.Add(panel1);

                                    flowLayoutPanel3.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel3.Controls.Add(panel1);

                                    flowLayoutPanel3.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel3.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel3.Controls.Add(panel1);

                                }
                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel3);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel3.Controls.Add(panel1);
                                    flowLayoutPanel3.Tag = 6;
                                }



                            }
                        }

                        if (i == 4)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel4.Controls.Add(panel1);

                                    flowLayoutPanel4.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel4.Controls.Add(panel1);

                                    flowLayoutPanel4.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel4.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel4.Controls.Add(panel1);

                                }

                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel4);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel4.Controls.Add(panel1);
                                    flowLayoutPanel4.Tag = 6;
                                }


                            }
                        }


                        if (i == 5)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel5.Controls.Add(panel1);

                                    flowLayoutPanel5.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel5.Controls.Add(panel1);

                                    flowLayoutPanel5.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel5.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel5.Controls.Add(panel1);

                                }
                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel5);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel5.Controls.Add(panel1);
                                    flowLayoutPanel5.Tag = 6;
                                }


                            }
                        }

                        if (i == 6)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel6.Controls.Add(panel1);

                                    flowLayoutPanel6.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel6.Controls.Add(panel1);

                                    flowLayoutPanel6.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel6.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel6.Controls.Add(panel1);

                                }

                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel6);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel6.Controls.Add(panel1);
                                    flowLayoutPanel6.Tag = 6;
                                }



                            }
                        }


                        if (i == 7)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel7.Controls.Add(panel1);

                                    flowLayoutPanel7.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel7.Controls.Add(panel1);

                                    flowLayoutPanel7.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel7.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel7.Controls.Add(panel1);

                                }
                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel7);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel7.Controls.Add(panel1);
                                    flowLayoutPanel7.Tag = 6;
                                }



                            }
                        }

                        if (i == 8)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel8.Controls.Add(panel1);

                                    flowLayoutPanel8.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel8.Controls.Add(panel1);

                                    flowLayoutPanel8.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel8.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel8.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel8.Controls.Add(panel1);

                                }


                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel8);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel8.Controls.Add(panel1);
                                    flowLayoutPanel8.Tag = 6;
                                }



                            }
                        }

                        if (i == 9)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel9.Controls.Add(panel1);

                                    flowLayoutPanel9.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel9.Controls.Add(panel1);

                                    flowLayoutPanel9.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel9.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel9.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel9.Controls.Add(panel1);

                                }

                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel9);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel9.Controls.Add(panel1);
                                    flowLayoutPanel9.Tag = 6;
                                }

                            }
                        }

                        if (i == 10)
                        {

                            string items = "select col_part_items from tbl_parts where col_exam_id = " + this.Text + " and col_part_no = @partno";

                            MySqlCommand itemscmd = new MySqlCommand(items, con);
                            itemscmd.Parameters.AddWithValue("@partno", i);
                            int itemsCount = Convert.ToInt32(itemscmd.ExecuteScalar());

                            itemscmd.Dispose();
                            string examtype = "SELECT col_part_type FROM tbl_parts where col_part_no = @partno AND col_exam_id = @exam_id ";
                            MySqlCommand examtypecmd = new MySqlCommand(examtype, con);
                            examtypecmd.Parameters.AddWithValue("@partno", i);
                            examtypecmd.Parameters.AddWithValue("@exam_id", this.Text);
                            string type = Convert.ToString(examtypecmd.ExecuteScalar());

                            examtypecmd.Dispose();






                            //counting exams panel creation

                            for (int item = 1; item <= itemsCount; item++)
                            {

                                //creating  panel 1

                                if (type == "Multiple Choice")
                                {



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

                                    button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "+";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(845, 30);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 1;



                                }


                                else if (type == "Identification")
                                {

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


                                    flowLayoutPanel10.Controls.Add(panel1);

                                    flowLayoutPanel10.Tag = 2;

                                }

                                else if (type == "true or false")
                                {

                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(757, 150), Location = new Point(0, i * 100), BackColor = Color.White };
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = item.ToString() + ".", Location = new Point(10, 10), Size = new Size(15, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Hint = "Enter Question", Location = new Point(30, 10), Size = new Size(700, 19), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "True", Location = new Point(30, 60), Size = new Size(100, 19) });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialRadioButton { Text = "False", Location = new Point(30, 95), Size = new Size(100, 19) });


                                    flowLayoutPanel10.Controls.Add(panel1);

                                    flowLayoutPanel10.Tag = 3;

                                }

                                else if (type == "Photo Guest")
                                {
                                    flowLayoutPanel10.FlowDirection = FlowDirection.TopDown;
                                    flowLayoutPanel10.Tag = 4;
                                    var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(240, 250), Location = new Point(i * 260, 0), BackColor = System.Drawing.ColorTranslator.FromHtml("#A6A6A6") };
                                    panel1.Controls.Add(new PictureBox() { Height = 120, Width = 190, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.White, Location = new Point(25, 15), Tag = item });
                                    panel1.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField() { Size = new Size(165, 50), Hint = "Enter Answer", BackColor = Color.Aqua, Location = new Point(30, 200), Tag = item });


                                    MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                                    button.Text = "Add Photo";
                                    button.Tag = item;
                                    button.Location = new Point(60, 150);
                                    button.Size = new Size(120, 35);

                                    button.Click += (sender2, e2) => btn_click(sender2, e2, panel1);
                                    panel1.Controls.Add(button);

                                    flowLayoutPanel10.Controls.Add(panel1);

                                }


                                else if (type == "Enumeration")
                                {



                                    //enurows
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

                                    //  button.Click += (sender2, e2) => btn_choice(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button);

                                    //ADD

                                    MaterialSkin.Controls.MaterialFlatButton button1 = new MaterialSkin.Controls.MaterialFlatButton();
                                    button1.Text = "minus";
                                    button1.Tag = item.ToString();
                                    button1.Location = new Point(680, 90);
                                    button1.Size = new Size(39, 36);
                                    //button.Click += new EventHandler(btn_choice,);

                                    // button1.Click += (sender2, e2) => btn_choice1(sender2, e2, flowLayoutPanel10);

                                    panel1.Controls.Add(button1);
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 5;
                                }



                                else if (type == "Essay")
                                {



                                    //enurows
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
                                    flowLayoutPanel10.Controls.Add(panel1);
                                    flowLayoutPanel10.Tag = 6;
                                }



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


            // una



            //2nd



        }
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
        public void btn_fck(object sender, EventArgs e, dynamic p, int i)
        {

            con.Open();
            MySqlCommand search = new MySqlCommand("select * from questions where exam_id= @exam_id and teacher_id = " + this.Tag + " and part_no = @part_no", con);
            search.Parameters.AddWithValue("@part_no", i);
            search.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));

            MySqlDataReader dr = search.ExecuteReader();


            if (dr.HasRows == true)
            {
                rb2 = (MaterialSkin.Controls.MaterialRaisedButton)sender;

                if (rb2.Tag != null)
                {


                    if (p is MaterialSkin.Controls.MaterialDivider)
                    {

                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)p;
                        foreach (Control d in td.Controls)

                        {

                            if (d is PictureBox)

                            {

                                pb2 = (PictureBox)d;




                                if (Convert.ToInt32(pb2.Tag) == Convert.ToInt32(rb2.Tag))
                                {

                                    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })

                                    {
                                        if (ofd.ShowDialog() == DialogResult.OK)
                                        {
                                            filename = ofd.FileName;
                                            pb2.ImageLocation = filename;



                                          

                                            try
                                            {
                                                con.Close();
                                                con.Open();

                                                string up = "update questions set images = @image where teacher_id = @teacher_id and exam_id =@exam and part_no =@part_no and item_no = @item";
                                                MySqlCommand cmd = new MySqlCommand(up, con);
                                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                                cmd.Parameters.AddWithValue("@item", rb2.Tag);
                                                cmd.Parameters.AddWithValue("@part_no", i);
                                                cmd.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                                                cmd.Parameters.AddWithValue("@image", imgs);


                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                            }
                                            finally
                                            {
                                                con.Close();
                                            }



                                        }

                                    }


                                }



                            }
                        }

                    }


                }

            }
            else
            {
                rb2 = (MaterialSkin.Controls.MaterialRaisedButton)sender;

                if (rb2.Tag != null)
                {


                    if (p is MaterialSkin.Controls.MaterialDivider)
                    {

                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)p;
                        foreach (Control d in td.Controls)

                        {

                            if (d is PictureBox)

                            {

                                pb2 = (PictureBox)d;




                                if (Convert.ToInt32(pb2.Tag) == Convert.ToInt32(rb2.Tag))
                                {

                                    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })

                                    {
                                        if (ofd.ShowDialog() == DialogResult.OK)
                                        {
                                            filename = ofd.FileName;
                                            pb2.Image = Image.FromFile(filename);



                                            FileStream fstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                                            BinaryReader br = new BinaryReader(fstream);
                                            imgs = br.ReadBytes((int)fstream.Length);

                                            try
                                            {
                                                con.Close();
                                                con.Open();
                                                string insert = "insert into questions(teacher_id,exam_id,part_no,images,item_no)values(@teacher_id,@exam,@part_no,@image,@item)";
                                                MySqlCommand cmd = new MySqlCommand(insert, con);
                                                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                                                cmd.Parameters.AddWithValue("@item", rb2.Tag);
                                                cmd.Parameters.AddWithValue("@part_no", i);
                                                cmd.Parameters.AddWithValue("@exam", Convert.ToInt32(this.Text));
                                                cmd.Parameters.AddWithValue("@image", imgs);


                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                            }
                                            finally
                                            {
                                                con.Close();
                                            }



                                        }

                                    }


                                }



                            }
                        }

                    }


                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = true;
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

                            string updating = "update tbl_question set col_question = @question where col_exam_id = @exam_id and col_part_no =@part and col_question_no = @item and col_part_id = "+partid+"";

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
                                "values(" + (id2 + 1) + ",@choice,@flag,@exam_id,@part,@item,@choice_flag,"+ (id + 1) + ") ";

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
        // multiple choice
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
                                Console.WriteLine(partid+"partid");
                                q4cmd.Dispose();



                            q4 = "SELECT tbl_choices.col_question_id  FROM tbl_exam  inner join tbl_parts on tbl_exam.col_exam_id = tbl_parts.col_exam_id inner join tbl_question on tbl_parts.col_part_id = tbl_question.col_part_id inner join tbl_choices on tbl_question.col_question_id = tbl_choices.col_question_id where tbl_question.col_question_no = @item and tbl_exam.col_exam_id = @exam and tbl_parts.col_part_no = @partno limit 1";

                            q4cmd = new MySqlCommand(q4, con);
                            q4cmd.Parameters.AddWithValue("@item", item_no);
                            q4cmd.Parameters.AddWithValue("@partno", a);
                            q4cmd.Parameters.AddWithValue("@exam", this.Text);
                            string quesid = Convert.ToString(q4cmd.ExecuteScalar());


                            Console.WriteLine(quesid + "questionid");
                            q4cmd.Dispose();

                            Console.WriteLine("listcnt"+ list.Count);
                                          
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
                                Console.WriteLine(list[j]+ "list");
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
                                    
                                    ques =Convert.ToInt32(tf.Tag);

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
                              "values("+(id+1)+",(SELECT col_part_id FROM tbl_parts where col_part_no = @part and col_exam_id = @exam_id),@part,@item,@question,@exam_id,@no_ch)";
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
                                Console.WriteLine("id"+id2);
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
        //true or false
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
        //photo

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


        //

        // enumeration

        public void instruc(int part_no,string instruction,string level)
        {
            Console.WriteLine("gumana");
            con.Close();
            con.Open();
           
                    Console.WriteLine("has data");
                   string sqlstatement = "update tbl_parts set col_part_level = @level, col_instructions = @ins where col_exam_id= @exam_id and col_part_no = @part ";
                    MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                    cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                    cmd.Parameters.AddWithValue("@ins", instruction);
                    cmd.Parameters.AddWithValue("@level", level);
                    cmd.Parameters.AddWithValue("@part", part_no);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

              


           
            
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

                            Console.WriteLine("dami"+ list.Count);
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
                    cmd1.Parameters.AddWithValue("@no_exams",Convert.ToInt32(alltotal));
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
        private void button1_Click(object sender, EventArgs e)
        {
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


            flowLayoutPanel1.Enabled = false;
            //insss
            instruc(1, materialSingleLineTextField1.Text,comboBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Enabled = true;
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            instruc(2, materialSingleLineTextField2.Text, comboBox2.Text);
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





            flowLayoutPanel2.Enabled = false;
           
        }
        MaterialSkin.Controls.MaterialDivider md = new MaterialSkin.Controls.MaterialDivider();
        MaterialSkin.Controls.MaterialSingleLineTextField sl = new MaterialSkin.Controls.MaterialSingleLineTextField();
        int a = 0;
        NumericUpDown number = new NumericUpDown();
        FlowLayoutPanel fp = new FlowLayoutPanel();



        private void btn_add(object sender, EventArgs e, dynamic p, dynamic q)
        {
            Console.WriteLine("gumana");

            if (p is NumericUpDown)
            {

                number = (NumericUpDown)p;



            }

            int a =Convert.ToInt32( number.Value);
            a = a - 1;

            if (q is FlowLayoutPanel)
            {

                fp = (FlowLayoutPanel)q;

                fp.Controls.Clear();

                for (int i = 0; i < a; i++)
                {
                    fp.Controls.Add(new MaterialSkin.Controls.MaterialSingleLineTextField { Size = new Size(500, 30), Hint = "enter item" });
                }
            }







        }
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
        private void btn_choice(object sender, EventArgs e,dynamic p)
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


        private void button6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            instruc(3, materialSingleLineTextField3.Text, comboBox3.Text);
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


            flowLayoutPanel3.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            instruc(4, materialSingleLineTextField4.Text, comboBox4.Text);
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




            flowLayoutPanel4.Enabled = false;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel4.Enabled = true;
        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
    
      
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser,currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            instruc(5, materialSingleLineTextField5.Text, comboBox5.Text);
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




            flowLayoutPanel5.Enabled = false;
         

        }

        private void button11_Click(object sender, EventArgs e)
        {
            instruc(6, materialSingleLineTextField6.Text, comboBox6.Text);
            if (Convert.ToInt32(flowLayoutPanel6.Tag) == 1)
            {

                api = flowLayoutPanel6 ;
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



            flowLayoutPanel6.Enabled = false;
           

        }

        private void button13_Click(object sender, EventArgs e)
        {
            instruc(7, materialSingleLineTextField7.Text, comboBox7.Text);
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




            flowLayoutPanel7.Enabled = false;
           

        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            instruc(9, materialSingleLineTextField9.Text, comboBox9.Text);
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




            flowLayoutPanel9.Enabled = false;
          
        }

        private void button19_Click(object sender, EventArgs e)
        {
            instruc(10, materialSingleLineTextField10.Text, comboBox10.Text);
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



            flowLayoutPanel10.Enabled = false;
       
        }

        private void slide_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            instruc(8, materialSingleLineTextField8.Text, comboBox8.Text);
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




            flowLayoutPanel8.Enabled = false;
          

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            switch (examparts)
            {
                case 1:

                    if (flowLayoutPanel1.Enabled == true)
                    {


                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();
                    }

           

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;


                case 2:

                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                 

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 3:

                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 4:
                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

        

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 5:
                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show(); ;
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                   

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }

                    break;


                case 6:
                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel6.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 6 is not yet Saved");
                        f3.Show();
                    }

               
                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;
                case 7:
                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel6.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 6 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel7.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 7 is not yet Saved");
                        f3.Show();
                    }

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 8:

                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel6.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 6 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel7.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 7 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel8.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 8 is not yet Saved");
                        f3.Show();
                    }

                   

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 9:

                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel6.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 6 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel7.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 7 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel8.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 8 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel9.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 9 is not yet Saved");
                        f3.Show();
                    }

              

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;

                case 10:
                    if (flowLayoutPanel1.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 1 is not yet Saved");
                        f3.Show();

                    }

                    else if (flowLayoutPanel2.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 2 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel3.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 3 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel4.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 4 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel5.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 5 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel6.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 6 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel7.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 7 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel8.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 8 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel9.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 9 is not yet Saved");
                        f3.Show();
                    }

                    else if (flowLayoutPanel10.Enabled == true)
                    {
                        Form3 f3 = new Form3("Part 10 is not yet Saved");
                        f3.Show();
                    }

                    else
                    {
                        this.Hide();
                        InstructorForm f2 = new InstructorForm(currentuser, currentpass);
                        f2.Tag = this.Tag;
                        f2.Show();
                    }
                    break;
            }
            
       



        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            flowLayoutPanel8.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            flowLayoutPanel5.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            flowLayoutPanel6.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            flowLayoutPanel7.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            flowLayoutPanel9.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            flowLayoutPanel10.Enabled = true;
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

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            if (txtExamName.Text == "")
            {
                Form3 f3 = new Form3("Please input exam name");
                f3.Show();
            }
            else if (sgrade.Text == "")
            {
                Form3 f3 = new Form3("Please input grade");
                f3.Show();

            }
            else if (ssection.Text == "")
            {

                Form3 f3 = new Form3("Please input section");
                f3.Show();
            }

            else if (subject.Text == "")
            {

                Form3 f3 = new Form3("Please input subject");
                f3.Show();
            }
            else if ((nudHr.Value == 0) && (nudMin.Value < 15))
            {

                Form3 f3 = new Form3("Please input at least 15 minutes duration for examination");
                f3.Show();

            }


            else

            {

                string updating = "update tbl_exam set col_exam_name = @ename where col_exam_id = @exam_id";


                MySqlCommand upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@ename", txtExamName.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set col_exam_grade = @cgrade where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@cgrade", sgrade.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set col_exam_section = @csec where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@csec", ssection.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set subject = @csbj where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@csbj", subject.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set col_exam_date = @cdate where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@cdate", dtpExamDate.Value);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set col_exam_duration_hrs = @chr where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@chr", nudHr.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();

                updating = "update tbl_exam set col_exam_duration_mins = @cmins where col_exam_id = @exam_id";


                upcmd = new MySqlCommand(updating, con);
                upcmd.Parameters.AddWithValue("@cmins", nudMin.Text);
                upcmd.Parameters.AddWithValue("@exam_id", Convert.ToInt32(this.Text));
                upcmd.ExecuteNonQuery();
                upcmd.Dispose();


                MessageBox.Show("Details Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);





            }





            con.Close();
        }
    }
}
