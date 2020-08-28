using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin
{
    public partial class results : Form
    {
        public results(double a)
        {
            InitializeComponent();

      

            label2.Text = Convert.ToInt32(a).ToString();
        }

        private void results_Load(object sender, EventArgs e)
        {

        }
    }
}
