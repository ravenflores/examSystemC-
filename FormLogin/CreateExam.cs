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
    public partial class CreateExam : MaterialSkin.Controls.MaterialForm
    {

        public static string constring = "server=localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con = new MySqlConnection(constring);
        public static string constring2 = "server=localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con2 = new MySqlConnection(constring2);
        string currentuser;
        string currentpass;
        public CreateExam(string user,string pass)
        {
            InitializeComponent();
            currentuser = user;
            currentpass = pass;
        }

        private void CreateExam_Load(object sender, EventArgs e)
        {
            panell1.BackColor = Color.FromArgb(26,32,38);
            panel2.BackColor = Color.FromArgb(26, 32, 38);
            panel3.BackColor = Color.FromArgb(26, 32, 38);
            panel4.BackColor = Color.FromArgb(26, 32, 38);
            btnSave.BackColor = Color.FromArgb(26, 32, 38);
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                if (nudPart.Value == 1)
                {
                    total = item1.Value * pp1.Value;

                }

                else if (nudPart.Value == 2)
                {
                    total = (item1.Value * pp1.Value) + (item2.Value * pp2.Value);

                }
                else if (nudPart.Value == 3)
                {
                    total = (item1.Value * pp1.Value) + (item2.Value * pp2.Value) + (item3.Value * pp3.Value);

                }
                else if (nudPart.Value == 4)
                {
                    total = (item1.Value * pp1.Value) + (item2.Value * pp2.Value) + (item3.Value * pp3.Value) + (item4.Value * pp4.Value);
                }

                con2.Open();

                string sqlstatement = "Insert into tbl_exam(col_exam_name,col_exam_parts,col_exam_grade,col_exam_section,col_exam_date,col_exam_duration_hrs,col_exam_duration_mins,col_exam_status,col_teacher_id,col_no_of_exams) "+
                    "values(@exam_name, @parts, @grade, @sec, @date, @hrs, @mins,@stats,@teacher_id,@total)";


                MySqlCommand cmd = new MySqlCommand(sqlstatement, con2);
                cmd.Parameters.AddWithValue("@hrs", nudHr.Value);
                cmd.Parameters.AddWithValue("@mins", nudMin.Value);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                cmd.Parameters.AddWithValue("@date", dtpExamDate.Value);
              //  cmd.Parameters.AddWithValue("@classname", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@parts", nudPart.Value);
         
                cmd.Parameters.AddWithValue("@stats", 0);
                cmd.Parameters.AddWithValue("@grade", sgrade.Text);
                cmd.Parameters.AddWithValue("@sec", ssection.Text);
                cmd.Parameters.AddWithValue("@total", total);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("second code error" + ex.ToString());

            }
            finally
            {
                con2.Close();
            }

            String[,] a = new String[4, 3];
            if (nudPart.Value >= 1)
            {

                a[0, 0] = item1.Value.ToString();
                a[1, 0] = item2.Value.ToString();
                a[2, 0] = item3.Value.ToString();
                a[3, 0] = item4.Value.ToString();

                a[0, 1] = cbo1.Text.ToString();
                a[1, 1] = cbo2.Text.ToString();
                a[2, 1] = cbo3.Text.ToString();
                a[3, 1] = cbo4.Text.ToString();

                a[0, 2] = pp1.Value.ToString();
                a[1, 2] = pp2.Value.ToString();
                a[2, 2] = pp3.Value.ToString();
                a[3, 2] = pp4.Value.ToString();


                //generate the exam loops
                for (int part = 0; part <nudPart.Value; part++)
                {
                    try
                    {
                        con2.Close();
                        con2.Open();
                        string sqlstatement = "insert into tbl_parts(col_part_type,col_part_points,col_exam_id,col_part_no,col_part_items)values(@type,@points,(select col_exam_id from tbl_exam where col_exam_name = @exam_name),@part_no,@item)";
                        MySqlCommand cmd = new MySqlCommand(sqlstatement, con2);
                        cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                        cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);
                        cmd.Parameters.AddWithValue("@part_no", (part + 1));
                        cmd.Parameters.AddWithValue("@exam_id", nudPart.Value.ToString());
                        cmd.Parameters.AddWithValue("@item", a[part, 0]);
                        cmd.Parameters.AddWithValue("@type", a[part, 1]);
                        cmd.Parameters.AddWithValue("@points", a[part, 2]);
                
                        cmd.ExecuteNonQuery();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                    finally
                    {
                        con2.Close();
                    }
                }

            }

            string current_id = "";
            try
            {
                con2.Open();
               
                string sqlstatement = "select col_exam_id from tbl_exam where col_exam_name = @exam_name";
                MySqlCommand cmd = new MySqlCommand(sqlstatement, con2);
                cmd.Parameters.AddWithValue("@teacher_id", this.Tag);
                cmd.Parameters.AddWithValue("@exam_name", txtExamName.Text);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                 current_id = dr.GetString("col_exam_id");
                }

                con2.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                con2.Close();
            }



            //part id

            this.Hide();
            ReEditExam f1 = new ReEditExam(current_id,currentuser,currentpass);
            f1.Tag = this.Tag;
            f1.Show();
        }

   /*     public int generateid()
        {
            MySqlCommand cmd = new MySqlCommand("select count(exam_id) from exams  where teacher_id = " + this.Tag + "", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            i++;
            cmd.Dispose();
            return i;
        } */

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorForm f2 = new InstructorForm(currentuser,currentpass);
            f2.Tag = this.Tag;
            f2.Show();
        }

        private void cdoGrade_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudHr_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nudPart_ValueChanged(object sender, EventArgs e)
        {
            if (nudPart.Value == 2)
            {
                panell1.Show();
                panel2.Show();
                panel3.Hide();
                panel4.Hide();

            }
            if (nudPart.Value == 3)
            {
                panell1.Show();
                panel2.Show();
                panel3.Show();
                panel4.Hide();

            }
            if (nudPart.Value == 4)
            {
                panell1.Show();
                panel2.Show();
                panel3.Show();
                panel4.Show();

            }
            if (nudPart.Value == 1)
            {
                panell1.Show();
                panel2.Hide();
                panel3.Hide();
                panel4.Hide();

            }


        }

        private void ssection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
