using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace probleme
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        DataSet dataset;
        DataTable datatable;
        OleDbDataReader reader;
        int currentLine;
        public Form1()
        {
            connection=new OleDbConnection();
            string conexiune = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=D:\\MasiniDB.accdb;" +
                "Persist Security Info=False;";
            connection.ConnectionString = conexiune;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            currentLine = 0;
            carShow();
        }
        private void loadData()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection=connection;
                command.CommandText = "SELECT * FROM Masini";
                reader = command.ExecuteReader();
                datatable = new DataTable("Cars");
                datatable.Load(reader);
                dataset = new DataSet();
                dataset.Tables.Add(datatable);
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }
        private void carShow()
        {
            textBox1.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[0].ToString();
            textBox2.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[1].ToString();
            textBox3.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[2].ToString();
            textBox4.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[3].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentLine == dataset.Tables["Cars"].Rows.Count - 1)
                currentLine = 0;
            else currentLine++;
            carShow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentLine == 0)
                currentLine = dataset.Tables["Cars"].Rows.Count - 1;
            else currentLine--;
            carShow();
        }
    }
}
