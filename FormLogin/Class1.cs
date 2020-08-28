using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Security.Cryptography;
using MaterialSkin;


namespace FormLogin
{
    class Class1
    {

        public static string constring2 = "server= localhost;user=root;password=root;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con2 = new MySqlConnection(constring2);
        public static string constring1 = "server= localhost;user=root;password=root;port=3306;database=exam_system1;SSL Mode=none";
        MySqlConnection con1 = new MySqlConnection(constring1);

        public static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        public static string decrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

     





    }

 



    class TransparentTabControl : TabControl
    {
        private List<Panel> pages = new List<Panel>();

        public void MakeTransparent()
        {
            if (TabCount == 0) throw new InvalidOperationException();
            var height = GetTabRect(0).Bottom;
            // Move controls to panels
            for (int tab = 0; tab < TabCount; ++tab)
            {
                var page = new Panel
                {
                    Left = this.Left,
                    Top = this.Top + height,
                    Width = this.Width,
                    Height = this.Height - height,
                    BackColor = Color.Transparent,
                    Visible = tab == this.SelectedIndex
                };
                for (int ix = TabPages[tab].Controls.Count - 1; ix >= 0; --ix)
                {
                    TabPages[tab].Controls[ix].Parent = page;
                }
                pages.Add(page);
                this.Parent.Controls.Add(page);
            }
            this.Height = height /* + 1 */;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            for (int tab = 0; tab < pages.Count; ++tab)
            {
                pages[tab].Visible = tab == SelectedIndex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) foreach (var page in pages) page.Dispose();
            base.Dispose(disposing);
        }
    }
    class MultipleSlidingPAnel
    {
        Panel span;
        Button button;
        bool horizontal;
        bool hidden;
        int size;
        string hText;
        string sText;
        Timer t;

        public MultipleSlidingPAnel(ref Panel p, ref Button b, bool hor, string hText, string stext)
        {
            this.span = p;
            this.button = b;
            this.horizontal = hor;
            hidden = true;
            size = 409;
            this.hText = hText;
            this.sText = stext;

            b.Click += new EventHandler(button_clicked);

            t = new Timer();
            t.Interval = 5;
            t.Tick += new EventHandler(t_tick);
        }
        void ChangeSize(int val)
        {


            span.Width += val;

            if (span.Width >= size || span.Width <= 0)//C:\Users\Pau\Documents\exam\thesis3.0\kamote capstone222\kamote capstone\LAST\FormLogin\FormLogin\Class1.cs
            {
                t.Stop();
                hidden = !hidden;
            }


        }
        private void t_tick(object sender, EventArgs e)
        {
            if (hidden) ChangeSize(+20);
            else ChangeSize(-20);
        }

        private void button_clicked(object sender, EventArgs e)
        {

            if (!hidden) button.Text = sText;
            else button.Text = hText;
            t.Start();
        }
    }
}
