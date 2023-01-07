using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercitiu_1
{
    public partial class Form1 : Form
    {
        OleDbConnection conection;
        DataSet dataset;
        DataTable datatable;
        OleDbDataReader reader;
        int liniecurent;
        public Form1()
        {
            InitializeComponent();
            conection=new OleDbConnection();
            string conexiune = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=D:\\ApartamenteDB.accdb;" +
                "Persist Security Info=False;";
            conection.ConnectionString = conexiune;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            showApartament();
            liniecurent = 0;
        }
        private void LoadData()
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                comand.CommandText = "SELECT * FROM Apartamente";
                reader=comand.ExecuteReader();
                datatable = new DataTable("Apartament");
                datatable.Load(reader);
                dataset = new DataSet();
                dataset.Tables.Add(datatable);
                conection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error is: " + ex.Message.ToString());
                conection.Close();
            }
        }
        private void showApartament()
        {
            textBox1.Text = dataset.Tables["Apartament"].Rows[liniecurent].ItemArray[0].ToString();
            textBox2.Text = dataset.Tables["Apartament"].Rows[liniecurent].ItemArray[1].ToString();
            textBox3.Text = dataset.Tables["Apartament"].Rows[liniecurent].ItemArray[2].ToString();
            textBox4.Text = dataset.Tables["Apartament"].Rows[liniecurent].ItemArray[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (liniecurent == 0)
                liniecurent = dataset.Tables["Apartament"].Rows.Count - 1;
            else liniecurent--;
            showApartament();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (liniecurent == dataset.Tables["Apartament"].Rows.Count - 1)
                liniecurent = 0;
            else liniecurent++;
            showApartament();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                comand.CommandText = "SELECT * FROM Apartamente WHERE pretEstimativ=@pret";
                comand.Parameters.Clear();
                comand.Parameters.AddWithValue("pret", textBox4.Text);
                reader = comand.ExecuteReader();
                datatable = new DataTable("Apartament");
                datatable.Load(reader);
                dataset = new DataSet();
                dataset.Tables.Add(datatable);
                for (int i = 0; i < dataset.Tables["Apartament"].Rows.Count; i++)

                    MessageBox.Show("Numele proprietarilor sunt: " + dataset.Tables["Apartament"].Rows[i].ItemArray[1].ToString());
                
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error is " + ex.Message.ToString());
                conection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
