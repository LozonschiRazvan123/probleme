using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "eu")
                label1.Text = "tu";
            else label1.Text = "eu";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "label2")
                label2.Text = "label1";
            else label2.Text = "label2";
        }
    }
}
