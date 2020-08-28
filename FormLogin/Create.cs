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
    public partial class Create : Form
    {

        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring);
        string currentuser;
        string currentpass;
        int idofexam;

        public Create(string user, string pass)
        {
            InitializeComponent();
          
            currentuser = user;
            currentpass = pass;
            this.TransparencyKey = (BackColor);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grp_Enter(object sender, EventArgs e)
        {

        }
        int a = 0;
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (a == 10)
            { }
            else
            {
                a++;
            }

            var panel1 = new MaterialSkin.Controls.MaterialDivider() { Size = new Size(441, 90), Location = new Point(0, 0), BackColor = Color.White, Tag = a };// adding

            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = panel1.Tag + ":", Location = new Point(10, 20), Size = new Size(40, 19), ForeColor = Color.White, Font = new Font("Calibri", 12.0f) });
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "items:", Location = new Point(50, 20), Size = new Size(55, 19), ForeColor = Color.White, Font = new Font("Calibri", 12.0f) });
            // panel1.Controls.Add(new NumericUpDown {  Location = new Point(110, 20), Size = new Size(40, 19),Value = 1,Tag = 1,Minimum = 1,Maximum = 100});
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "type:", Location = new Point(170, 20), Size = new Size(45, 19), ForeColor = Color.White, Font = new Font("Calibri", 12.0f) });

            NumericUpDown num2 = new NumericUpDown();
            num2.Size = new Size(40, 19);
            num2.Value = 1;
            num2.Tag = "1";
            num2.Minimum = 1;
            num2.Maximum = 100;
            num2.Location = new Point(110, 20);

            NumericUpDown num = new NumericUpDown();
            num.Size = new Size(40, 19);
            num.Value = 1;
            num.Tag = "2";
            num.Minimum = 1;
            num.Maximum = 20;
            num.Location = new Point(195, 50);
            // md.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Adjustable", Location = new Point(195, 50), Size = new Size(45, 19), ForeColor = Color.White, Font = new Font("Calibri", 12.0f) });

            MaterialSkin.Controls.MaterialLabel ml = new MaterialSkin.Controls.MaterialLabel();
            ml.Text = "Adjustable";
            ml.Location =new Point(195, 50);
            ml.ForeColor = Color.White;
            ml.Font = new Font("Calibri", 12.0f);
            ml.Hide();


            panel1.Controls.Add(num2);
            panel1.Controls.Add(num);
            panel1.Controls.Add(ml);

            ComboBox cbo = new ComboBox();
            cbo.Items.Add("Multiple Choice");
            cbo.Items.Add("Identification");
            cbo.Items.Add("true or false");
            cbo.Items.Add("Photo Guest");
            cbo.Items.Add("Enumeration");
            cbo.Items.Add("Essay");
            cbo.Location = new Point(220, 20);
            cbo.SelectedValueChanged += (sender2, e2) => btn_enumerate(sender2, e2, num2, cbo,num, ml);
            panel1.Controls.Add(cbo);
            panel1.Controls.Add(new MaterialSkin.Controls.MaterialLabel { Text = "Point Per Item:", Location = new Point(50, 50), Size = new Size(130, 19), ForeColor = Color.White, Font = new Font("Calibri", 12.0f) });
            // panel1.Controls.Add(new NumericUpDown { Location = new Point(), Size = new Size(), Value = 1,Tag = 2,Minimum = 1 });
            flowLayoutPanel1.Controls.Add(panel1);
            if (flowLayoutPanel1.Controls.Count == 10)
            {
                add.Enabled = false;
            }
        }

        NumericUpDown number;
        NumericUpDown number2;
        ComboBox cbo;
        MaterialSkin.Controls.MaterialLabel md;
        public void btn_enumerate(object sender, EventArgs e, dynamic p, dynamic q,dynamic r,dynamic s)
        {
            md = s;
            if (p is NumericUpDown)
            {
                NumericUpDown number2 = (NumericUpDown)p;
                if (number2.Tag.ToString() == "1")
                {

                    number = number2;
                }


            }
            number2 = r;
            number2.Hide();
            cbo = (ComboBox)q;
            if (cbo.Text == "Essay")
            {
                number.Maximum = 5;

                md.Show();

            }
            else
            {
                number.Maximum = 100;
                md.Hide();
                number2.Show();
            }


           


          
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (a == 0)
            { }
            else
            {

                a--;
            }


            foreach (Control a in flowLayoutPanel1.Controls)
            {

                if (a is MaterialSkin.Controls.MaterialDivider)
                {
                    MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)a;
                     if (Convert.ToInt32(td.Tag) == flowLayoutPanel1.Controls.Count)
                    {

                        Console.WriteLine("gumana");
                        Console.WriteLine("count"+flowLayoutPanel1.Controls.Count);
                        flowLayoutPanel1.Controls.Remove(a);

                    }

                    else {

                        Console.WriteLine("d gumana");
                    }
                }

                if (flowLayoutPanel1.Controls.Count < 10)
                {
                    add.Enabled = true;
                }
            }
        }
        public static NumericUpDown nud = new NumericUpDown();
        public static ComboBox cb = new ComboBox();
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            decimal items = 0;
            decimal ppi = 0;
       
            try
            {

                foreach (Control a in flowLayoutPanel1.Controls)
                {

                    if (a is MaterialSkin.Controls.MaterialDivider)
                    {
                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)a;

                        foreach (Control b in td.Controls)
                        {
                            if (b is ComboBox){

                                cb = (ComboBox)b;

                            }

                          
                                Console.WriteLine("di gumana essay");
                                if (b is NumericUpDown)
                                {

                                    nud = (NumericUpDown)b;

                                    if (nud.Tag.ToString() == "1")

                                    {


                                        items = nud.Value;
                                        Console.WriteLine("items" + items);

                                    }

                                    if (nud.Tag.ToString() == "2")

                                    {

                                        ppi = nud.Value;
                                        Console.WriteLine("ppi" + ppi);
                                        total += (items * ppi);
                                        Console.WriteLine(total + "totality");
                                    }


                                    Console.WriteLine(total + "total");

                                }

                            
                               

                        }

                        if (cb.Text == "Essay")
                        {

                            total = 0;
                        }
                        Console.WriteLine(total);
                    }


                }
            

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
                cmd.Parameters.AddWithValue("@parts", flowLayoutPanel1.Controls.Count);

                cmd.Parameters.AddWithValue("@stats", 0);
                cmd.Parameters.AddWithValue("@grade", sgrade.Text);
                cmd.Parameters.AddWithValue("@sec", ssection.Text);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@subject", subject.Text);

                cmd.ExecuteNonQuery();


            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex+"error");
            }

            finally {

                con.Close();
                Console.WriteLine("ok done");
            }


//adding of parts

            try {

                decimal items1 = 0;
                decimal ppi1 = 0;
                string parttype = "";


                foreach (Control a in flowLayoutPanel1.Controls)
                {

                    if (a is MaterialSkin.Controls.MaterialDivider)
                    {
                        MaterialSkin.Controls.MaterialDivider td = (MaterialSkin.Controls.MaterialDivider)a;

                        foreach (Control b in td.Controls)
                        {

                            if (b is NumericUpDown)
                            {

                                nud = (NumericUpDown)b;

                                if (nud.Tag.ToString() == "1")

                                {


                                    items1 = nud.Value;

                                    Console.WriteLine("pt" + items1);
                                }

                                if (nud.Tag.ToString() == "2")

                                {

                                    ppi1 = nud.Value;
                                    Console.WriteLine("pt" + ppi1);

                                }


                              

                            }

                            if (b is ComboBox)
                            {

                                ComboBox type = (ComboBox)b;

                                parttype = type.Text;
                                Console.WriteLine("pt"+parttype);
                            }

            

                        }

                        con.Close();
                        con.Open();
                        string sqlstatement = "insert into tbl_parts(col_part_type,col_part_points,col_exam_id,col_part_no,col_part_items)values(@type,@points,(select count(*) from tbl_exam  where tbl_exam.col_teacher_id = @teacher_id),@part_no,@item)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con);
                        cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                        cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                        cmd.Parameters.AddWithValue("@part_no", td.Tag);
                        cmd.Parameters.AddWithValue("@item", items1);
                        cmd.Parameters.AddWithValue("@type", parttype);
                        cmd.Parameters.AddWithValue("@points", ppi1);

                        cmd.ExecuteNonQuery();
                    }


                }



            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex + "error");
            }

            finally
            {

                con.Close();
                Console.WriteLine("ok done");
            }


            try {
        
             
                con.Close();
                con.Open();
                string examid = "select count(*) from tbl_exam  where tbl_exam.col_teacher_id = @teacher_id";
               
                MySqlCommand examcmd = new MySqlCommand(examid, con);
                examcmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                int examcmdcount = Convert.ToInt32(examcmd.ExecuteScalar());
                examcmd.Dispose();
                idofexam = examcmdcount;
                Console.WriteLine(idofexam + "id");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex + "error");
            }

            finally
            {

                con.Close();
                Console.WriteLine("ok done");
            }

            this.Hide();
            ReEditExam f1 = new ReEditExam(idofexam.ToString(), currentuser, currentpass);
            f1.Tag = this.Tag;
            f1.Show();

        }

        private void sgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ssection.Items.Clear();
            con.Open();
            string sql = string.Format(@"SELECT section FROM class WHERE grade='{0}'", sgrade.Text);
            MySqlCommand sqlcmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                ssection.Items.Add(dr.GetString("section"));
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm f2 = new StudentForm(currentuser, currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtExamName_Click(object sender, EventArgs e)
        {

        }
    }
}
