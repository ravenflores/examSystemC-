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
using MaterialSkin;
using MaterialSkin.Controls;

namespace FormLogin
{
    public partial class AdminForm : MaterialSkin.Controls.MaterialForm
    {

        public static string a = "student";
        public static string constr = "datasource = localhost;user = root; password = 1234admin; port = 3306;database = exam_system1;SslMode=none;";
        public static string constring = "server= localhost;user=root;password=1234admin;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring);
        MySqlConnection con = new MySqlConnection(constr);
        string currentusername;
        string currentPassword;
        public AdminForm(string userName, string pass)
        {
            InitializeComponent();
            MaterialSkinManager mat = MaterialSkinManager.Instance;
            mat.AddFormToManage(this);
            mat.Theme = MaterialSkinManager.Themes.LIGHT;

            currentusername = userName;

            currentPassword = pass;




        }

        private void btnRegAcc_Click(object sender, EventArgs e)
        {
            // lblPage.Text = "Home";
            //tabControl1.SelectTab(0);
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            //lblPage.Text = "Add Class";
            //tabControl1.SelectTab(1);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // lblPage.Text = "Import";
            //tabControl1.SelectTab(2);
        }

        private void btnAccSettings_Click(object sender, EventArgs e)
        {
            //  lblPage.Text = "Account Settings";
            // tabControl1.SelectTab(3);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {


            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, adminpicture.Width - 3, adminpicture.Height - 3);
            Region rg = new Region(gp);
            adminpicture.Region = rg;



            con1.Open();
            string sql = "select firstname from accounts where userid = '" + currentusername + "'";
            MySqlCommand cmd45 = new MySqlCommand(sql, con1);
            string f = Convert.ToString(cmd45.ExecuteScalar());
            con1.Close();

            con1.Open();
            string sql1 = "select middlename from accounts where userid = '" + currentusername + "'";
            MySqlCommand cmd46 = new MySqlCommand(sql1, con1);
            string m = Convert.ToString(cmd46.ExecuteScalar());
            con1.Close();


            con1.Open();
            string sql101 = "select picture from accounts where userid = '" + currentusername + "'";
            MySqlCommand cmd101 = new MySqlCommand(sql101, con1);
            string pc = Convert.ToString(cmd101.ExecuteScalar());
            con1.Close();

            adminpicture.ImageLocation = pc;


            con1.Open();
            string sql2 = "select lastname from accounts where userid = '" + currentusername + "'";
            MySqlCommand cmd47 = new MySqlCommand(sql2, con1);
            string l = Convert.ToString(cmd47.ExecuteScalar());
            con1.Close();

            adminname.Text = f + " " + m + " " + l;



            con.Open();
            string sqlstatementgrade = "select grade from class";
            MySqlCommand cmdgrade = new MySqlCommand(sqlstatementgrade, con);
            string grade = Convert.ToString(cmdgrade.ExecuteScalar());

            con.Close();



            con.Open();

            string sqlstatement1 = "select userid,firstname,middlename,lastname,grade,section from accounts where position = 'student'";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            studentlist.DataSource = dt1;
            studentlist.DataMember = "users";
            con.Close();



            con.Open();
            string sqlstatement3 = "select userid,firstname,middlename,lastname,position from accounts where position = 'admin'";
            MySqlDataAdapter adpt3 = new MySqlDataAdapter(sqlstatement3, con);
            DataSet dt3 = new DataSet();
            adpt3.Fill(dt3, "users");
            adminlist.DataSource = dt3;
            adminlist.DataMember = "users";
            con.Close();
            con.Open();

            string sqlstatement4 = "select userid,firstname,middlename,lastname,position from accounts where position = 'teacher'";
            MySqlDataAdapter adpt4 = new MySqlDataAdapter(sqlstatement4, con);
            DataSet dt4 = new DataSet();
            adpt4.Fill(dt4, "users");
            teacherlist.DataSource = dt4;
            teacherlist.DataMember = "users";
            con.Close();
            con.Open();
            string sqlstatement5 = "select grade,section from class ";
            MySqlDataAdapter adpt5 = new MySqlDataAdapter(sqlstatement5, con);
            DataSet dt5 = new DataSet();
            adpt5.Fill(dt5, "class");
            classlist.DataSource = dt5;
            classlist.DataMember = "class";
            con.Close();
        }
        public void reloadstud()
        {
            con.Open();

            string sqlstatement1 = "select userid,firstname,middlename,lastname,grade,section from accounts where position = 'student'";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            studentlist.DataSource = dt1;
            studentlist.DataMember = "users";
            con.Close();
        }
        public void reloadadmin()
        {
            con.Open();

            string sqlstatement3 = "select userid,firstname,middlename,lastname,position from accounts where position = 'admin'";
            MySqlDataAdapter adpt3 = new MySqlDataAdapter(sqlstatement3, con);
            DataSet dt3 = new DataSet();
            adpt3.Fill(dt3, "users");
            adminlist.DataSource = dt3;
            adminlist.DataMember = "users";
            con.Close();
        }
        public void reloadclass()
        {
            con.Open();
            string sqlstatement5 = "select grade,section from class ";
            MySqlDataAdapter adpt5 = new MySqlDataAdapter(sqlstatement5, con);
            DataSet dt5 = new DataSet();
            adpt5.Fill(dt5, "class");
            classlist.DataSource = dt5;
            classlist.DataMember = "class";
            con.Close();
        }
        public void reloadteach()
        {
            con.Open();
            string sqlstatement4 = "select userid,firstname,middlename,lastname,position from accounts where position = 'teacher'";
            MySqlDataAdapter adpt4 = new MySqlDataAdapter(sqlstatement4, con);
            DataSet dt4 = new DataSet();
            adpt4.Fill(dt4, "users");
            teacherlist.DataSource = dt4;
            teacherlist.DataMember = "users";
            con.Close();
        }





        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInsRegister_Click(object sender, EventArgs e)
        {

        }


        private void btnInsSearch_Click(object sender, EventArgs e)
        {

        }



        private void btnstudReg_Click(object sender, EventArgs e)
        {

        }



        private void btnstudSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdReg_Click(object sender, EventArgs e)
        {

        }


        private void btnAddNewClass_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog op1 = new OpenFileDialog();
            if (op1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 this.txtChooseFile.Text = op1.FileName;

             }*/
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            /* if (txtLoad.Text == "")
              {
                  MessageBox.Show("Empty Sheet No!");
              }

              else
              {
                  try
                  {

                      string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtChooseFile.Text + ";Extended Properties=Excel 12.0;";
                      OleDbConnection conn = new OleDbConnection(PathConn);

                      OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from[" + txtLoad.Text + "$]", PathConn);
                      DataTable dt = new DataTable();
                      adapter.Fill(dt);
                      dtgImport.DataSource = dt;

                  }
                  catch (MySqlException ex)
                  {
                      MessageBox.Show("" + ex);
                  }
              }*/
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm6 = new LoginForm();
            frm6.Show();
        }

        private void btnAdSearch_Click(object sender, EventArgs e)
        {

        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* ssection.Items.Clear();
             con.Open();
             string sql = string.Format(@"SELECT section FROM class WHERE grade='{0}'", sgrade.Text);
             MySqlCommand sqlcmd = new MySqlCommand(sql, con);
             MySqlDataReader dr = sqlcmd.ExecuteReader();
             while (dr.Read())
             {
                 ssection.Items.Add(dr.GetString("section"));
             }

             con.Close();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;
            tabsss.SelectTab(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            tabsss.SelectTab(1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Height = button10.Height;
            panel4.Top = button10.Top;
            tabsss.SelectTab(2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addteach addteach = new addteach(this);
            addteach.Show();



        }

        private void button6_Click(object sender, EventArgs e)
        {

            addstudent addstud = new addstudent(this);
            addstud.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addadmin addadmin = new addadmin(this);
            addadmin.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
            tabsss.SelectTab(3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addclass addclas = new addclass(this);
            addclas.Show();
        }

        private void teachersearch_OnValueChanged(object sender, EventArgs e)
        {

        }
        public void searchstud()
        {
            con.Open();

            string sqlstatement1 = "select userid,firstname,middlename,lastname,grade,section from accounts where position = 'student'AND userid like '%" + studsearch.Text + "%'";
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sqlstatement1, con);
            DataSet dt1 = new DataSet();
            adpt1.Fill(dt1, "users");
            studentlist.DataSource = dt1;
            studentlist.DataMember = "users";
            con.Close();
        }
        public void searchadmin()
        {
            con.Open();

            string sqlstatement3 = "select userid,firstname,middlename,lastname,position from accounts where position = 'admin'AND userid like '%" + adminsearch.Text + "%' ";

            MySqlDataAdapter adpt3 = new MySqlDataAdapter(sqlstatement3, con);
            DataSet dt3 = new DataSet();
            adpt3.Fill(dt3, "users");
            adminlist.DataSource = dt3;
            adminlist.DataMember = "users";
            con.Close();
        }
        public void searchclass()
        {
            con.Open();
            string sqlstatement5 = "select grade,section from class where section like '%" + classssearch.Text + "%'";
            MySqlDataAdapter adpt5 = new MySqlDataAdapter(sqlstatement5, con);
            DataSet dt5 = new DataSet();
            adpt5.Fill(dt5, "class");
            classlist.DataSource = dt5;
            classlist.DataMember = "class";
            con.Close();
        }
        public void searchteach()
        {
            con.Open();
            string sqlstatement4 = "select userid,firstname,middlename,lastname,position from accounts where position = 'teacher' AND userid like '%" + teachersearch.Text + "%'";
            MySqlDataAdapter adpt4 = new MySqlDataAdapter(sqlstatement4, con);
            DataSet dt4 = new DataSet();
            adpt4.Fill(dt4, "accounts");
            teacherlist.DataSource = dt4;
            teacherlist.DataMember = "accounts";
            con.Close();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            searchteach();
        }

        private void AdminForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void teachersearch_TextChanged(object sender, EventArgs e)
        {
            if (teachersearch.Text.Count() == 0)
            {
                reloadteach();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            searchstud();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            searchadmin();
        }

        private void studsearch_TextChanged(object sender, EventArgs e)
        {
            if (teachersearch.Text.Count() == 0)
            {
                reloadstud();
            }
        }

        private void adminsearch_TextChanged(object sender, EventArgs e)
        {
            if (teachersearch.Text.Count() == 0)
            {
                reloadadmin();
            }
        }

        private void classssearch_TextChanged(object sender, EventArgs e)
        {
            if (teachersearch.Text.Count() == 0)
            {
                reloadclass();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frmlog = new LoginForm();
            frmlog.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            settings set = new settings(currentusername, currentPassword);
            set.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string selectedid = teacherlist.CurrentRow.Cells["userid"].Value.ToString();

            con.Open();
            string fname = "select firstname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd46 = new MySqlCommand(fname, con);
            string f = Convert.ToString(cmd46.ExecuteScalar());
            con.Close();


            con.Open();
            string mname = "select middlename from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd47 = new MySqlCommand(mname, con);
            string m = Convert.ToString(cmd47.ExecuteScalar());
            con.Close();


            con.Open();
            string lname = "select lastname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd48 = new MySqlCommand(lname, con);
            string n = Convert.ToString(cmd48.ExecuteScalar());
            con.Close();





            if (MessageBox.Show("Are you sure you to delete" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                con.Open();
                string delete = "delete from accounts where userid = '" + selectedid + "'";
                MySqlCommand cmd = new MySqlCommand(delete, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list !");
                con.Close();
            }
            reloadteach();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            string selectedid = studentlist.CurrentRow.Cells["userid"].Value.ToString();
            con.Close();
            con.Open();
            string fname = "select firstname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd46 = new MySqlCommand(fname, con);
            string f = Convert.ToString(cmd46.ExecuteScalar());
            con.Close();


            con.Open();
            string mname = "select middlename from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd47 = new MySqlCommand(mname, con);
            string m = Convert.ToString(cmd47.ExecuteScalar());
            con.Close();


            con.Open();
            string lname = "select lastname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd48 = new MySqlCommand(lname, con);
            string n = Convert.ToString(cmd48.ExecuteScalar());
            con.Close();





            if (MessageBox.Show("Are you sure you to delete" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                con.Open();
                string delete = "delete from accounts where userid = '" + selectedid + "'";
                MySqlCommand cmd = new MySqlCommand(delete, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list !");
                con.Close();
            }
            reloadstud();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string selectedid = adminlist.CurrentRow.Cells["userid"].Value.ToString();

            con.Open();
            string fname = "select firstname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd46 = new MySqlCommand(fname, con);
            string f = Convert.ToString(cmd46.ExecuteScalar());
            con.Close();


            con.Open();
            string mname = "select middlename from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd47 = new MySqlCommand(mname, con);
            string m = Convert.ToString(cmd47.ExecuteScalar());
            con.Close();


            con.Open();
            string lname = "select lastname from accounts where userid = '" + selectedid + "'";
            MySqlCommand cmd48 = new MySqlCommand(lname, con);
            string n = Convert.ToString(cmd48.ExecuteScalar());
            con.Close();





            if (MessageBox.Show("Are you sure you to delete" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                con.Open();
                string delete = "delete from accounts where userid = '" + selectedid + "'";
                MySqlCommand cmd = new MySqlCommand(delete, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted" + " " + "'" + f + "'" + " " + "'" + m + "'" + " " + "'" + n + "'" + " " + "from the list !");
                con.Close();
            }
            reloadadmin();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string gr = classlist.CurrentRow.Cells["grade"].Value.ToString();
            string sec = classlist.CurrentRow.Cells["section"].Value.ToString();







            if (MessageBox.Show("Are you sure you to delete" + " " + "'" + gr + "'" + " " + "'" + sec + "'" + " " + " " + "from the list?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                con.Open();
                string delete = "delete from class where section = '" + sec + "' AND grade = '" + gr + "'";
                MySqlCommand cmd = new MySqlCommand(delete, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted" + " " + "'" + gr + "'" + " " + "'" + sec + "'" + " " + " " + "from the list !");
                con.Close();
            }
            reloadclass();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            searchclass();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialSingleLineTextField3_Click_2(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField5_Click_1(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            int ac = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string a1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string a2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string a3 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string a4 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string a5 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string a6 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string a7 = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string a8 = dataGridView1.Rows[i].Cells[7].Value.ToString();

                if (a4 == "")
                {
                    Console.WriteLine("gumana");
                }
                //hassss
           

                using (MySqlCommand update2 = new MySqlCommand("select * from accounts where userid = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + " ", con))

                {
                    using (MySqlDataReader dr = update2.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            MessageBox.Show(dataGridView1.Rows[i].Cells[0].Value.ToString() + " account is existing please remove it or change the userid");
                            ac += 1;
                        }
                       

                    }
                       

                }
                Console.WriteLine("ay"+a);







                //reading if existint       if(a == 0)
          


            }
                if (ac == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    


                        con.Close();
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand(@"Insert into accounts (userid,userpass,firstname,middlename,lastname,position,grade,section) values (" + dataGridView1.Rows[i].Cells[0].Value.ToString() + ",'" + Class1.encrypt(dataGridView1.Rows[i].Cells[1].Value.ToString()) + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[6].Value.ToString() + ",'" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "')", con);

                        cmd.ExecuteNonQuery();


                    
                }

                MessageBox.Show("accouts inserted");
                studentlist.Refresh();
            }
          



          
            con.Close();

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Empty Sheet No!");
            }

            else
            {


           
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string file = ""; //variable for the Excel File Location 
                DataTable dt = new DataTable(); //container for our excel data 
                DataRow row; DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog. 
                if (result == DialogResult.OK) // Check if Result == "OK". 
                {
                    file = openFileDialog1.FileName; //get the filename with the location of the file 
                    try
                    { //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file 
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                        Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[numericUpDown1.Value];
                        Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
                        int rowCount = excelRange.Rows.Count; //get row count of excel data 
                        int colCount = excelRange.Columns.Count; // get column count of excel data 
                                                                 //Get the first Column of excel file which is the Column Name 
                        for (int i = 1; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                            }
                            break;
                        }
                        //Get Row Data of Excel 
                        int rowCounter; //This variable is used for row index number 
                        for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data 
                        {
                            row = dt.NewRow(); //assign new row to DataTable 
                            rowCounter = 0; for (int j = 1; j <= colCount; j++) //Loop for available column of excel data 
                            { //check if cell is empty 
                                if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                                {
                                    row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                                }
                                else
                                {
                                    row[i] = "";
                                }
                                rowCounter++;
                            }
                            dt.Rows.Add(row);
                            //add row to DataTable 
                        }
                        dataGridView1.DataSource = dt; //assign DataTable as Datasource for DataGridview //close and clean excel process 
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }

            }
          
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
     
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel4.Height = button18.Height;
            panel4.Top = button18.Top;
            tabsss.SelectTab(4);
        }

        private void teacherlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
