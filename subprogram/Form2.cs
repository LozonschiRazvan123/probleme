using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subprogram
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Console.Write("n = ");
            int n = int.Parse(Interaction.InputBox("Give me a number: "));
            Console.WriteLine("Introduceti elementele vectorului:");
            int[] vector = new int[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Give me an element for " + (i+1) + " position"));
            }
            Console.Write("a = ");
            int a = int.Parse(Interaction.InputBox("Give me a number: "));
            int numar = 0;
            for (int i = 0; i < n; i++)
            {
                if (vector[i] > a)
                {
                    numar++;
                }
            }
            Console.WriteLine("Numarul de valori mai mari decat " + a + " este " +
           numar + ".");*/

            int n = int.Parse(Interaction.InputBox("Give me a numeber: "));
            int[] v = new int[n];
            for (int i = 0; i < v.Length; i++)
                v[i] = int.Parse(Interaction.InputBox("Give me an element: "));
            for(int i=0;i<v.Length;i++)
            {
                int s = v[i] + v[i + 1];
                Array.Resize(ref v, v.Length + 1);
                for (int j = v.Length - 2; j >= i + 1; j--)
                    v[j + 1] = v[j];
                v[i + 1] = s;
            }
            for (int i = 0; i < v.Length; i++)
                MessageBox.Show(v[i] + " ");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] values = new int[] { 1, 3, 4, 5, 9, 4 };
            int sum = 0;
            for(int i=1;i<values.Length;i++)
                if(values[i] > trackBar1.Value)
                    sum+=values[i];
            MessageBox.Show("The sum is " + sum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Increment(-10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int s = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (numericUpDown1.Value < matrix[i,j])
                        s += matrix[i,j];
            MessageBox.Show("The sum is " + s);
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
        }
    }
}
