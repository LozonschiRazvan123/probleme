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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(textBox1.Text))
                MessageBox.Show("Elementul a fost deja adaugat!");
            else listBox1.Items.Add(textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<listBox1.SelectedItems.Count;i++)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
