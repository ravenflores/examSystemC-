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
using System.Security.Cryptography;
using MaterialSkin;

namespace FormLogin
{
    public partial class StudentForm : MaterialSkin.Controls.MaterialForm
    {
        public static string constring2 = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con2 = new MySqlConnection(constring2);
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring);
        static string current;
        static string passwor;
        int exid;
        static string lehpass;
        public StudentForm(string userName, string pass)
        {
            InitializeComponent();
            Console.WriteLine("student" + userName + pass);
            current = userName;
            passwor = pass;
            MaterialSkinManager mat = MaterialSkinManager.Instance;
            mat.AddFormToManage(this);
            mat.Theme = MaterialSkinManager.Themes.LIGHT;
        }
        static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(0);
        }

        private void btnStud_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(1);
        }

        private void btnMyAcc_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_click(object sender, EventArgs e, int id)
        {
            con.Close();
            con.Open();
            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;
            MySqlCommand update2 = new MySqlCommand("select * from student_records where col_exam_id= @exam_id and col_teacher_id = " + id + " and stud_id = " + this.Tag + "", con);

            update2.Parameters.AddWithValue("@exam_id", Convert.ToInt32(btn.Tag));


            MySqlDataReader dr = update2.ExecuteReader();

            if (dr.HasRows)
            {
                if (MessageBox.Show("", "already taken exam",  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                   

                }
               
            }
            else {
                con2.Close();
                con2.Open();
                string sqlstatement94 = "select section from accounts where userid = @userid AND userpass = @userpass ";
                MySqlCommand cmd94 = new MySqlCommand(sqlstatement94, con2);
                cmd94.Parameters.AddWithValue("@userid", current);
                cmd94.Parameters.AddWithValue("@userpass", encrypt(passwor));
                string k = Convert.ToString(cmd94.ExecuteScalar());

                cmd94.Dispose();


                con2.Close();






                studentexam f9 = new studentexam(btn.Tag.ToString(), id, Convert.ToInt32(this.Tag));
                f9.Tag = k;
                f9.Show();


            }



        }
        private void StudentForm_Load(object sender, EventArgs e)
        {

           generate2();
            //begin 


            con2.Open();
            string sql101 = "select picture from accounts where userid = '" + Convert.ToInt32(this.Tag) + "'";
            MySqlCommand cmd102 = new MySqlCommand(sql101, con2);
            string pc = Convert.ToString(cmd102.ExecuteScalar());
            con2.Close();
          
            studentpicture.ImageLocation = pc;

            con2.Open();
            string sql102 = "select firstname from accounts where userid = @userid";
            MySqlCommand cmd103 = new MySqlCommand(sql102, con2);
            cmd103.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string tehfname = Convert.ToString(cmd103.ExecuteScalar());
            // txtFname.Text = tehfname;
            con2.Close();

            con2.Open();
            string sql2 = "select middlename from accounts where userid = @userid";
            MySqlCommand cmd21 = new MySqlCommand(sql2, con2);
            cmd21.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string mehfname = Convert.ToString(cmd21.ExecuteScalar());
            //  txtMname.Text = mehfname;
            con2.Close();

            con2.Open();
            string sql3 = "select lastname from accounts where userid = @userid";
            MySqlCommand cmd31 = new MySqlCommand(sql3, con2);
            cmd31.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string lehfname = Convert.ToString(cmd31.ExecuteScalar());
            //txtLname.Text = lehfname;
            con2.Close();
           
            studentname.Text = tehfname + " " + mehfname + " " + lehfname;

            // txtid.Text = this.Tag.ToString();

            con2.Open();
            string sql4 = "select userpass from accounts where userid = @userid";
            MySqlCommand cmd41 = new MySqlCommand(sql4, con2);
            cmd41.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
             lehpass = Convert.ToString(cmd41.ExecuteScalar());
            //txtpass.Text = lehpass;
            con2.Close();
            // txtFname.Enabled = false;
            // txtMname.Enabled = false;
            // txtLname.Enabled = false;
            // txtid.Enabled = false;
            // txtpass.Enabled = false;

            con2.Open();
            string sql5 = "select position from accounts where userid = @userid";
            MySqlCommand cmd51 = new MySqlCommand(sql5, con2);
            cmd51.Parameters.AddWithValue("@userid", Convert.ToInt32(this.Tag));
            string position = Convert.ToString(cmd51.ExecuteScalar());
            //txtpass.Text = lehpass;
            con2.Close();





            //end
            con2.Close();

            con2.Open();
            string sqlstatement94 = "select section from accounts where userid = @userid AND userpass = @userpass ";
            MySqlCommand cmd94 = new MySqlCommand(sqlstatement94, con2);
            cmd94.Parameters.AddWithValue("@userid", current);
            cmd94.Parameters.AddWithValue("@userpass", Class1.encrypt(passwor));
            string k = Convert.ToString(cmd94.ExecuteScalar());
        

            cmd94.Dispose();
         
            con2.Close();

            con2.Open();



            MySqlCommand cmd = new MySqlCommand("select * from tbl_exam where col_exam_date = @date and col_exam_section = @sec", con2);
            cmd.Parameters.AddWithValue("@date",DateTime.Today);

            cmd.Parameters.AddWithValue("@sec", k);
            

            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)

            {
                con.Close();
                con.Open();

                try
                {

                    string sqlstatement = "SELECT count(col_exam_id) FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "' ";
                    MySqlCommand cmd2 = new MySqlCommand(sqlstatement, con);
                    cmd2.Parameters.AddWithValue("@date", DateTime.Today);

                    cmd2.Parameters.AddWithValue("@sec", k);
                    int rowscount = Convert.ToInt32(cmd2.ExecuteScalar());
                    cmd2.Dispose();
                    con.Close();


                    for (int i = 0; i < rowscount; i++)
                    {
                        try
                        {

                            con.Open();

                            string sqlstatement1 = "SELECT col_exam_name FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);
                            cmd1.Parameters.AddWithValue("@date", DateTime.Today);
                            cmd1.Parameters.AddWithValue("@sec", k);
                            string name = Convert.ToString(cmd1.ExecuteScalar());
                       
                   
                            cmd1.Dispose();


                            string sqlstatement2 = "SELECT col_exam_section FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand sec = new MySqlCommand(sqlstatement2, con);
                            sec.Parameters.AddWithValue("@date", DateTime.Today);
                            sec.Parameters.AddWithValue("@sec", k);
                            string section = Convert.ToString(sec.ExecuteScalar());
                            sec.Dispose();


                            string sqlstatement4 = "SELECT col_exam_grade FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand cmd4 = new MySqlCommand(sqlstatement4, con);
                            cmd4.Parameters.AddWithValue("@date", DateTime.Today);
                            string grade = Convert.ToString(cmd4.ExecuteScalar());
                            cmd4.Dispose();

                            string sqlstatement5 = "SELECT col_exam_status FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand cmd5 = new MySqlCommand(sqlstatement5, con);
                            cmd5.Parameters.AddWithValue("@date", DateTime.Today);
                            cmd5.Parameters.AddWithValue("@sec", k);
                            int stats = Convert.ToInt32(cmd5.ExecuteScalar());
                            cmd5.Dispose();

                            string sqlstatement6 = "SELECT col_exam_id FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand cmd6 = new MySqlCommand(sqlstatement6, con);
                            cmd6.Parameters.AddWithValue("@date", DateTime.Today);
                            cmd6.Parameters.AddWithValue("@sec", k);
                            exid = Convert.ToInt32(cmd6.ExecuteScalar());
                            cmd6.Dispose();


                            string idsqlstatement6 = "SELECT col_teacher_id FROM tbl_exam where col_exam_date = @date and col_exam_section = '" + k + "'   LIMIT " + i + " , 1";
                            MySqlCommand idcmd6 = new MySqlCommand(idsqlstatement6, con);
                            idcmd6.Parameters.AddWithValue("@date", DateTime.Today);
                            idcmd6.Parameters.AddWithValue("@sec", k);
                            int teacher_id = Convert.ToInt32(idcmd6.ExecuteScalar());
                            cmd6.Dispose();

                            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(830, 70), Location = new Point(10, i * 100), BackColor = Color.White };
                            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Exam: " + name, Location = new Point(10, 16), Size = new Size(200, 19) });
                           // panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Section:  " + section, Location = new Point(300, 16), Size = new Size(150, 19) });
                            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                            MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                            button.Text = "Take Exam";
                            button.Tag = exid.ToString();
                            button.Location = new Point(625, 20);
                            button.Size = new Size(100, 36);
                            //button.Click += new EventHandler(btn_click);
                            button.Click += (sender2, e2) => btn_click(sender2, e2, teacher_id);
                            if (stats == 1)
                            {
                                button.Enabled = true;


                            }
                            else
                            {
                                button.Enabled = false;
                                button.Hide();

                            }
                            panel1.Controls.Add(button);

                            flowLayoutPanel1.Controls.Add(panel1);

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
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }


            }

            else
            {
                
            }

          record();

        }


        public void generate2()
        {
            try
            {
                con.Close();
                con.Open();
                string cntsqlstatement = "select distinct col_exam_id from student_records where stud_id = "+current+"";
                MySqlCommand cmd = new MySqlCommand(cntsqlstatement, con);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)

                {

                    con.Close();
                    con.Open();

                    string examsqlstatement = "select COUNT(distinct col_exam_id) from student_records where stud_id = " + current + " ";
                    MySqlCommand examcmd = new MySqlCommand(examsqlstatement, con);
                    int rowscount = Convert.ToInt32(examcmd.ExecuteScalar());
                    examcmd.Dispose();



                    for (int i = 0; i < rowscount; i++)
                    {



                        string sqlstatement1 = "SELECT col_exam_name FROM(select distinct col_exam_id, col_exam_name from student_records where stud_id = " + current + ") ename limit " + i+",1";

                        MySqlCommand cmd1 = new MySqlCommand(sqlstatement1, con);


                        string name = Convert.ToString(cmd1.ExecuteScalar());

                        cmd1.Dispose();

                        sqlstatement1 = "SELECT col_exam_id FROM(select distinct col_exam_id, col_exam_name,col_exam_id as id from student_records where stud_id = " + current + ") ename limit " + i+",1";

                        cmd1 = new MySqlCommand(sqlstatement1, con);


                        string exid = Convert.ToString(cmd1.ExecuteScalar());

                        cmd1.Dispose();
                        string sqlstatement2 = "SELECT subject FROM tbl_exam where col_exam_id = "+exid+"";

                        MySqlCommand cmd2 = new MySqlCommand(sqlstatement2, con);


                        string name1 = Convert.ToString(cmd2.ExecuteScalar());
                        cmd2.Dispose();

                        string sqlstatement3 = "SELECT col_exam_date FROM tbl_exam where col_exam_id = " + exid + "";

                        MySqlCommand cmd3 = new MySqlCommand(sqlstatement3, con);


                        string date = Convert.ToString(cmd3.ExecuteScalar());
                        cmd3.Dispose();

                        


                        var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(647, 70), Location = new Point(10, i * 100), BackColor = Color.White };
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Exam: " + name, Location = new Point(10, 40), Size = new Size(200, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Subject:  " + name1, Location = new Point(10, 16), Size = new Size(150, 19) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = date, Location = new Point(300, 40) });
                        panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor, Size = new Size(10, 96), Location = new Point(0, 0) });


                        MaterialSkin.Controls.MaterialRaisedButton button = new MaterialSkin.Controls.MaterialRaisedButton();
                        button.Text = "Analyze";
                        button.Tag = i.ToString();
                        button.Location = new Point(540, 15);
                        button.Size = new Size(76, 43);
                        button.Click += (sender2, e2) => btn_click2(sender2, e2, exid);

                        panel1.Controls.Add(button);








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
                con.Close();
            }


        }
        public string exname;
       
        
        private void btn_click2(object sender, EventArgs e,string tag)
        {


            MaterialSkin.Controls.MaterialRaisedButton btn = (MaterialSkin.Controls.MaterialRaisedButton)sender;



            try
            {
                con.Close();
                con.Open();
                int tabb = Convert.ToInt32(btn.Tag.ToString());

                Console.WriteLine("student2" + current + passwor);
                StudentAnalysis frm4 = new StudentAnalysis(tag, current, passwor);
                this.Hide();
                frm4.Tag = tag;
                frm4.Show();
                


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("fexam error" + ex.ToString());

            }
            finally
            {
                con.Close();
            }
        }

        public void record()
        {

            con.Close();
            con.Open();
            string sqlstatement1 = "SELECT col_exam_name as 'Exam Name', col_exam_date as 'Exam Date',( sum(score)/col_no_of_exams * 50+ 50) as 'Grade'  FROM `student_records`  inner join tbl_exam USING (col_teacher_id,col_exam_id,col_exam_name) where stud_id = "+this.Tag+" GROUP BY col_teacher_id , col_exam_id , stud_id";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            stud_rec.DataSource = dt1;
            stud_rec.DataMember = "users";
            con.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm f2 = new LoginForm();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm f2 = new LoginForm();
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            record();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lg = new LoginForm();
            lg.Show();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
        
            panel1.Height = button8.Height;
            panel1.Top = button8.Top;
            tabControl1.SelectTab(2);
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StudentForm st = new StudentForm(this.Tag.ToString(),lehpass);
            teachersettings techset = new teachersettings(this.Tag.ToString(), lehpass,st);

            techset.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Height = button9.Height;
            panel1.Top = button9.Top;
            tabControl1.SelectTab(0);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
