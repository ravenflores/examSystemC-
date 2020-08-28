using MaterialSkin.Controls;
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
    using Word = Microsoft.Office.Interop.Word;

    public partial class InstructorForm : MaterialForm
    {

       
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con2 = new MySqlConnection(constring2);
        public static string constring1 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring1);
        public string exname;
        string lehpass;
        string currentuser;
        string currentpass;
        public InstructorForm(string user,string pass)
        {
            InitializeComponent();
         
            MaterialSkinManager mat = MaterialSkinManager.Instance;
            mat.AddFormToManage(this);
            mat.Theme = MaterialSkinManager.Themes.LIGHT;
            currentuser = user;
            currentpass = pass;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, teacherpicture.Width - 3, teacherpicture.Height - 3);
            Region rg = new Region(gp);
            teacherpicture.Region = rg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(1);
        }

        private void btnMyAcc_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(2);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }

        private void InstructorForm_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            con2.Open();
            string sql101 = "select picture from accounts where userid = '" + currentuser + "'";
            MySqlCommand cmd101 = new MySqlCommand(sql101, con2);
            string pc = Convert.ToString(cmd101.ExecuteScalar());
            con2.Close();
       
            teacherpicture.ImageLocation = pc;

            con2.Open();
            string sql1 = "select firstname from accounts where userid = @userid";
            MySqlCommand cmd = new MySqlCommand(sql1, con2);
            cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string tehfname = Convert.ToString(cmd.ExecuteScalar());
           // txtFname.Text = tehfname;
            con2.Close();

            con2.Open();
            string sql2 = "select middlename from accounts where userid = @userid";
            MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
            cmd2.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string mehfname = Convert.ToString(cmd2.ExecuteScalar());
          //  txtMname.Text = mehfname;
            con2.Close();

            con2.Open();
            string sql3 = "select lastname from accounts where userid = @userid";
            MySqlCommand cmd3 = new MySqlCommand(sql3, con2);
            cmd3.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string lehfname = Convert.ToString(cmd3.ExecuteScalar());
//txtLname.Text = lehfname;
            con2.Close();

            teachername.Text = tehfname + " " + mehfname + " " + lehfname;

           // txtid.Text = this.Tag.ToString();

            con2.Open();
            string sql4 = "select userpass from accounts where userid = @userid";
            MySqlCommand cmd4 = new MySqlCommand(sql4, con2);
            cmd4.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            lehpass = Convert.ToString(cmd4.ExecuteScalar());
//txtpass.Text = lehpass;
            con2.Close();
            // txtFname.Enabled = false;
            // txtMname.Enabled = false;
            // txtLname.Enabled = false;
            // txtid.Enabled = false;
            // txtpass.Enabled = false;

            con2.Open();
            string sql5 = "select position from accounts where userid = @userid";
            MySqlCommand cmd5 = new MySqlCommand(sql5, con2);
            cmd5.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string position = Convert.ToString(cmd5.ExecuteScalar());
            //txtpass.Text = lehpass;
            con2.Close();

            //pppp.Text = position;
            generate();
            generate2();
            pending(flowLayoutPanel3);
        }
        private void btn_click(object sender, EventArgs e)
        {


            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;



            try
            {
                con1.Close();
                con1.Open();
                int tabb = Convert.ToInt32(btn.Tag.ToString());
                string id = "SELECT col_exam_id FROM(select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (tabb + 1) + "";
                
                MySqlCommand fexam = new MySqlCommand(id, con1);
                exname = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();
            
                Form6 frm4 = new Form6(Convert.ToInt32(exname),currentuser,currentpass);
                this.Close();
                frm4.Tag = this.Tag;
                frm4.Show();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }
        }


        private void btn_click2(object sender, EventArgs e)
        {


            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;

          

            try
            {
                int tabb = Convert.ToInt32(btn.Tag.ToString());
                con1.Close();
                con1.Open();
                string cntsqlstatement = "SELECT * FROM tbl_analysis where col_teacher_id =" + this.Tag + " and col_exam_id = "+(tabb+1)+"";
                MySqlCommand cmd = new MySqlCommand(cntsqlstatement, con1);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)

                {
                    con1.Close();
                    con1.Open();

                    string id = "SELECT col_exam_id FROM(select *, row_number() over(order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (tabb + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                    MySqlCommand fexam = new MySqlCommand(id, con1);
                    exname = Convert.ToString(fexam.ExecuteScalar());
                    fexam.Dispose();

                    DataAnalysis frm4 = new DataAnalysis(exname, currentuser, currentpass);
                    this.Close();
                    frm4.Tag = this.Tag;
                    frm4.Show();
                }

                else
                {
                    Form3 f3 = new Form3("No record available");
                    f3.Show();

                }
                



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }
        }

        private void btn_click3(object sender, EventArgs e)
        {


            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;



            try
            {
                con1.Close();
                con1.Open();
                int tabb = Convert.ToInt32(btn.Tag.ToString());
                string id = "SELECT col_exam_id FROM(select *, row_number() over(order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (tabb + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                MySqlCommand fexam = new MySqlCommand(id, con1);
                exname = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();

                Form4 frm4 = new Form4(exname, currentuser, currentpass);
                this.Close();
                frm4.Tag = this.Tag;
                frm4.Show();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }
        }
        public void record()
        {


            con2.Open();
            string sqlstatement1 = "SELECT stud_id,col_exam_name, col_exam_date, (sum(score)/col_no_of_exams * 50+ 50) as 'grade'  FROM student_records inner join tbl_exam USING (col_teacher_id,col_exam_id,col_exam_name)  where col_teacher_id = " + this.Tag + " GROUP BY col_teacher_id , col_exam_id , stud_id";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con2);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            stud_rec.DataSource = dt1;
            stud_rec.DataMember = "users";
            con2.Close();





        }
        List<int> partlist = new List<int>();
        public void btn_redirect(object sender, EventArgs e, int examid)
        {
            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;
            int studid = Convert.ToInt32(btn.Tag.ToString());

            EssayChecking ec = new EssayChecking(studid,examid);
            ec.Show(); 

          


        }

        public void btn_students(object sender, EventArgs e, string name)
        {
            label3.Text = "Select Students From: " + name;
            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;

            //bilang ng estudyante

            con1.Close();
            con1.Open();
            int examid = Convert.ToInt32(btn.Tag.ToString());
            string examcnt = "SELECT count(distinct(stud_id)) FROM exam_system1.student_records where col_exam_id = " + examid + " and essay_flag = 1 and score = 0";

            MySqlCommand fexam = new MySqlCommand(examcnt, con1);
            int studentidcount = Convert.ToInt32(fexam.ExecuteScalar());
            fexam.Dispose();
            flowLayoutPanel5.Controls.Clear();
            for (int x = 0; x < studentidcount; x++)
            {
                //lalabas ng students na walang score pa sa essay
                examcnt = "SELECT distinct(stud_id) FROM exam_system1.student_records where col_exam_id = " + examid + " and essay_flag = 1 and score = 0 limit " + x+",1";

                 fexam = new MySqlCommand(examcnt, con1);
                 int students = Convert.ToInt32(fexam.ExecuteScalar());
                 fexam.Dispose();

                examcnt = "SELECT firstname FROM accounts where userid = "+students+"";

                fexam = new MySqlCommand(examcnt, con1);
                string fn = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();

                examcnt = "SELECT lastname FROM accounts where userid = " + students + "";

                fexam = new MySqlCommand(examcnt, con1);
                string ln = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();

                examcnt = "SELECT section FROM accounts where userid = " + students + "";

                fexam = new MySqlCommand(examcnt, con1);
                string sec = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();

                examcnt = "SELECT section FROM accounts where userid = " + students + "";

                fexam = new MySqlCommand(examcnt, con1);
                string grd = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();




                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(700, 70), BackColor = Color.White };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Student: " + fn +"  "+ln, Location = new Point(10, 40), Size = new Size(200, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text =grd+"-" + sec, Location = new Point(10, 16), Size = new Size(150, 19) });

                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                button.Text = "Check Essay";
                button.Tag = students.ToString();
                button.Location = new Point(550, 15);
                button.Size = new Size(76, 43);
                button.Click += (sender2, e2) => btn_redirect(sender2, e2, examid);

                panel1.Controls.Add(button);


                flowLayoutPanel5.Controls.Add(panel1);      

            }
        }
     public void pending(dynamic p)
        {
            con1.Close();
            con1.Open();
           FlowLayoutPanel ap = (FlowLayoutPanel)p;
            //bilang ng exam ni teacher na may essay
            string q4 = "SELECT count(distinct (col_exam_id)) FROM tbl_exam inner join tbl_parts using (col_exam_id) where col_part_type = 'Essay' and col_teacher_id = @tch";

            MySqlCommand q4cmd = new MySqlCommand(q4, con1);
            q4cmd.Parameters.AddWithValue("@exam", this.Text);
            q4cmd.Parameters.AddWithValue("@tch", currentuser);
            int allexams = Convert.ToInt32(q4cmd.ExecuteScalar());
            Console.WriteLine(allexams + "allexams");
            q4cmd.Dispose();

            for(int i = 0;i<allexams;i++)
            {
              //ng kada isang exam ni teacher n may essay
                q4 = "SELECT distinct (col_exam_id) FROM tbl_exam inner join tbl_parts using (col_exam_id) where col_part_type = 'Essay' and col_teacher_id = @tch LIMIT "+i+",1";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamsID = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamsID + "allexamsid");
                q4cmd.Dispose();

                q4 = "SELECT col_exam_name FROM exam_system1.tbl_exam where col_exam_id ="+allexamsID+"";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamsname = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamsname + "allexamsname");
                q4cmd.Dispose();

                q4 = "SELECT col_exam_date FROM exam_system1.tbl_exam where col_exam_id =" + allexamsID + "";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamsdate = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamsdate + "allexamsdate");
                q4cmd.Dispose();

                q4 = "SELECT col_exam_grade FROM exam_system1.tbl_exam where col_exam_id =" + allexamsID + "";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamsgrade = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamsgrade + "allexamsgrade");
                q4cmd.Dispose();

                q4 = "SELECT col_exam_section FROM exam_system1.tbl_exam where col_exam_id =" + allexamsID + "";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamssec = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamssec + "allexamssec");
                q4cmd.Dispose();

                q4 = "SELECT subject FROM exam_system1.tbl_exam where col_exam_id =" + allexamsID + "";

                q4cmd = new MySqlCommand(q4, con1);
                q4cmd.Parameters.AddWithValue("@exam", this.Text);
                q4cmd.Parameters.AddWithValue("@tch", currentuser);
                string allexamssubj = Convert.ToString(q4cmd.ExecuteScalar());
                Console.WriteLine(allexamssubj + "allexamssubj");
                q4cmd.Dispose();




                var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(647, 70), Location = new Point(10, i * 100), BackColor = Color.White };
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Exam: " + allexamsname, Location = new Point(10, 40), Size = new Size(200, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Subject:  " + allexamssubj, Location = new Point(10, 16), Size = new Size(150, 19) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = allexamsdate, Location = new Point(300, 40) });
                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                button.Text = "SELECT";
                button.Tag = allexamsID.ToString();
                button.Location = new Point(540, 15);
                button.Size = new Size(76, 43);
                button.Click += (sender2, e2) =>btn_students(sender2, e2, allexamsname);

                panel1.Controls.Add(button);





                panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Enable/Disable Exam:", Location = new Point(267, 15), Size = new Size(180, 23) });

                ap.Controls.Add(panel1);








            }
  



        }
        public void itemAnalysis()
        {


            con2.Open();
            string sqlstatement1 = "SELECT stud_id,exam_name, exam_date, sum(score)/no_of_exams * 50+ 50  FROM `student_records`  inner join exams USING (teacher_id,exam_id,exam_name) where teacher_id = " + this.Tag + " GROUP BY teacher_id , exam_id , stud_id";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con2);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            stud_rec.DataSource = dt1;
            stud_rec.DataMember = "users";
            con2.Close();
        }
        public void generate()
        {
            try
            {
                con1.Close();
                con1.Open();
                string cntsqlstatement = "SELECT col_exam_id FROM tbl_exam where col_teacher_id =" + this.Tag + "";
                MySqlCommand cmd = new MySqlCommand(cntsqlstatement, con1);
                MySqlDataReader dr = cmd.ExecuteReader();
              

                if (dr.HasRows)

                {

                    con1.Close();
                    con1.Open();

                    string examsqlstatement = "SELECT count(col_exam_id) FROM tbl_exam where col_teacher_id = " + this.Tag.ToString() + "";
                    MySqlCommand examcmd = new MySqlCommand(examsqlstatement, con1);
                    int rowscount = Convert.ToInt32(examcmd.ExecuteScalar());
                    examcmd.Dispose();
                 


                    for (int i = 0; i < rowscount; i++)
                    {

                        

                        string sqlstatement1 = "SELECT col_exam_name FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (i+1)+"";

                        MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con1);


                        string name = Convert.ToString(cmd1.ExecuteScalar());
                    
                        cmd1.Dispose();
                        string sqlstatement2 = "SELECT subject FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (i + 1) + "";

                        MySqlCommand cmd2 = new MySqlCommand(sqlstatement2, con1);


                        string name1 = Convert.ToString(cmd2.ExecuteScalar());
                        cmd2.Dispose();

                        string sqlstatement3 = "SELECT col_exam_date FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (i + 1) + "";

                        MySqlCommand cmd3 = new MySqlCommand(sqlstatement3, con1);


                        string date = Convert.ToString(cmd3.ExecuteScalar());
                        cmd3.Dispose();

                        MetroFramework.Controls.MetroToggle toggle = new MetroFramework.Controls.MetroToggle();
                        string stats = "SELECT col_exam_status FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (i + 1) + "";

                        MySqlCommand statscmd = new MySqlCommand(stats, con1);

                        int statvalue = Convert.ToInt32(statscmd.ExecuteScalar());
                        statscmd.Dispose();


                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(647, 70), Location = new Point(10, i * 100), BackColor = Color.White };
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Exam: " + name, Location = new Point(10, 40), Size = new Size(200, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Subject:  " + name1, Location = new Point(10, 16), Size = new Size(150, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = date, Location = new Point(300, 40) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                        MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                        button.Text = "Edit";
                        button.Tag = i.ToString();
                        button.Location = new Point(540, 40);
                        button.Size = new Size(76, 23);
                        button.Click += new EventHandler(btn_click);

                        panel1.Controls.Add(button);



                        if (statvalue == 1)
                        { toggle.Checked = true; }
                        else
                        { toggle.Checked = false; }
                        toggle.Theme = MetroFramework.MetroThemeStyle.Light;
                        toggle.Tag = i.ToString();
                        toggle.Location = new Point(510, 15);
                        toggle.Size = new Size(106, 23);
                        toggle.Click += new EventHandler(btn_stats);


                        panel1.Controls.Add(toggle);

                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Enable/Disable Exam:", Location = new Point(267, 15), Size = new Size(180, 23) });

                        flowLayoutPanel1.Controls.Add(panel1);

                    }

                }

                else
                {

                   




                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }


        }

        public void generate2()
        {
            try
            {
                con1.Close();
                con1.Open();
                string cntsqlstatement = "SELECT col_exam_id FROM tbl_exam where col_teacher_id =" + this.Tag + "";
                MySqlCommand cmd = new MySqlCommand(cntsqlstatement, con1);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)

                {

                    con1.Close();
                    con1.Open();

                    string examsqlstatement = "SELECT count(col_exam_id) FROM tbl_exam where col_teacher_id = " + this.Tag.ToString() + "";
                    MySqlCommand examcmd = new MySqlCommand(examsqlstatement, con1);
                    int rowscount = Convert.ToInt32(examcmd.ExecuteScalar());
                    examcmd.Dispose();



                    for (int i = 0; i < rowscount; i++)
                    {



                        string sqlstatement1 = "SELECT col_exam_name FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (i + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                        MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con1);


                        string name = Convert.ToString(cmd1.ExecuteScalar());
                        cmd1.Dispose();

                       sqlstatement1 = "SELECT col_exam_id FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (i + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                        cmd1 = new MySqlCommand(sqlstatement1, con1);


                        string id = Convert.ToString(cmd1.ExecuteScalar());

                        cmd1.Dispose();
                        string sqlstatement2 = "SELECT subject FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (i + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                        MySqlCommand cmd2 = new MySqlCommand(sqlstatement2, con1);


                        string name1 = Convert.ToString(cmd2.ExecuteScalar());
                        cmd2.Dispose();

                        string sqlstatement3 = "SELECT col_exam_date FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (i + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                        MySqlCommand cmd3 = new MySqlCommand(sqlstatement3, con1);


                        string date = Convert.ToString(cmd3.ExecuteScalar());
                        cmd3.Dispose();

                        MetroFramework.Controls.MetroToggle toggle = new MetroFramework.Controls.MetroToggle();
                        string stats = "SELECT col_exam_status FROM (select *, row_number() over (order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (i + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                        MySqlCommand statscmd = new MySqlCommand(stats, con1);

                        int statvalue = Convert.ToInt32(statscmd.ExecuteScalar());
                        statscmd.Dispose();


                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(647, 70), Location = new Point(10, i * 100), BackColor = Color.White };
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Exam: " + name, Location = new Point(10, 40), Size = new Size(200, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Subject:  " + name1, Location = new Point(10, 16), Size = new Size(150, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = date, Location = new Point(300, 40) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                        MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                        button.Text = "OVERALL";
                        button.Tag = i.ToString();
                        button.Location = new Point(540, 15);
                        button.Size = new Size(76, 43);
                        button.Click += new EventHandler(btn_click2);

                        panel1.Controls.Add(button);
                        /*
                        MaterialSkin.Controls.MaterialRaisedButton button1 = new MaterialSkin.Controls.MaterialRaisedButton();
                        button1.Text = "SPECIFIC";
                        button1.Tag = i.ToString();
                        button1.Location = new Point(420, 15);
                        button1.Size = new Size(76, 43);
                        button1.Click += new EventHandler(btn_click3);
                      
                        panel1.Controls.Add(button1);*/
                       // button1.Click += (sender2, e2) => btn_click3(sender2, e2, flowLayoutPanel1);






                        flowLayoutPanel2.Controls.Add(panel1);

                    }

                }

                else
                {

                 




                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }


        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }

            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }

            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
        private void btn_stats(object sender, EventArgs e)
        {


            MetroFramework.Controls.MetroToggle toggle = (MetroFramework.Controls.MetroToggle)sender;



            try
            {

                if (toggle.Checked == true)
                {
                    con1.Close();
                    con1.Open();
                    int tabb = Convert.ToInt32(toggle.Tag.ToString());

                    string up = "update tbl_exam set col_exam_status = 1 where col_exam_id = (SELECT col_exam_id FROM(select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (tabb + 1) + ")";

                    MySqlCommand upcmd = new MySqlCommand(up, con1);
                    upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);

                    upcmd.Parameters.AddWithValue("@id", (tabb + 1));
                    upcmd.ExecuteNonQuery(); 
                    upcmd.Dispose();
                    
                }

                else
                {
                    con1.Close();
                    con1.Open();
                    int tabb = Convert.ToInt32(toggle.Tag.ToString());

                    string up = "update tbl_exam set col_exam_status = 0 where col_exam_id = (SELECT col_exam_id FROM(select *, row_number() over (order by col_exam_id) as rownm from tbl_exam  where  col_teacher_id =  " + this.Tag.ToString() + ") t2 where rownm = " + (tabb + 1) + ")";

                    MySqlCommand upcmd = new MySqlCommand(up, con1);
                    upcmd.Parameters.AddWithValue("@teachers_id", tabPage1.Tag);
                    upcmd.Parameters.AddWithValue("@id", (tabb + 1));
                    upcmd.ExecuteNonQuery();
                    upcmd.Dispose();
                }







            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con2.Close();
             

            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            record();
        }

        private void grp_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm f2 = new LoginForm();
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InstructorForm st = new InstructorForm(this.Tag.ToString(), lehpass);
            teachersettings techset = new teachersettings(this.Tag.ToString(), lehpass, st);

            techset.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form6 f2 = new Form6(0,currentuser,currentpass);
            f2.Tag = this.Tag;
            f2.Show();
            this.Hide(); 

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lo = new LoginForm();
            lo.Show();
        }

        private void button2_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            panel1.Height = button8.Height;
            panel1.Top = button8.Top;
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            panel1.Height = button9.Height;
            panel1.Top = button9.Top;
          
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            panel1.Height = button10.Height;
            panel1.Top = button10.Top;
          
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        private void CreateDocument()
        {
            try
            {
                //Create an instance for word app  
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application  
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                winword.Visible = false;

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                //Create a new document  
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document  
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.  
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 30;
                    headerRange.Text = "Header text goes here";
                }

                //Add the footers into the document  
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.  
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                }

                //adding text to document  
                document.Content.SetRange(0, 0);
                document.Content.Text = "This is test document " + Environment.NewLine;

                //Add paragraph with Heading 1 style  
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Heading 1";
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter();

                //Add paragraph with Heading 2 style  
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "Para 2 text";
                para2.Range.InsertParagraphAfter();


                //Create a 5X5 table and insert some dummy record  
                Word.Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

                firstTable.Borders.Enable = 1;
                foreach (Word.Row row in firstTable.Rows)
                {
                    foreach (Word.Cell cell in row.Cells)
                    {
                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here  
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                            //Center alignment for the Header cells  
                            cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row  
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }

                //Save the document  
                object filename = @"e:\temp1.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                MessageBox.Show("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender; 

            try
            {
                con1.Close();
                con1.Open();
                int tabb = Convert.ToInt32(btn.Tag.ToString());
                string id = "SELECT col_exam_id FROM(select *, row_number() over(order by col_exam_id) as rownm from tbl_exam ) t2 where rownm = " + (tabb + 1) + " and col_teacher_id = " + this.Tag.ToString() + "";

                MySqlCommand fexam = new MySqlCommand(id, con1);
                exname = Convert.ToString(fexam.ExecuteScalar());
                fexam.Dispose();
              
                ReEditExam frm4 = new ReEditExam(exname, currentuser, currentpass);
                this.Close();
                frm4.Tag = this.Tag;
                frm4.Show();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con1.Close();
            }
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {

        }

        private void stud_rec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            panel1.Height = button3.Height;
            panel1.Top = button3.Top;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void pppp_Click(object sender, EventArgs e)
        {

        }
    }
   
}
