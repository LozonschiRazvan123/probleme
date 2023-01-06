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
                connection.Close();
            }
        }
        private void carShow()
        {
            textBox1.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[0].ToString();
            textBox2.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[1].ToString();
            textBox3.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[2].ToString();
            textBox4.Text = dataset.Tables["Cars"].Rows[currentLine].ItemArray[3].ToString();
            textBox5.Text = cota_de_asigurare(double.Parse(dataset.Tables["Cars"].Rows[currentLine].ItemArray[3].ToString())).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "INSERT INTO Masini (codMasina, denMasina, Marca, Pret) VALUES (@codMasina, @denMasina, @Marca, @Pret)";
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("codMasina", textBox1.Text);
                command.Parameters.AddWithValue("denMasina", textBox2.Text);
                command.Parameters.AddWithValue("Marca", textBox3.Text);
                command.Parameters.AddWithValue("Pret", int.Parse(textBox4.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Cars was added successfully!");
                
                connection.Close();
                loadData();
                currentLine = dataset.Tables["Cars"].Rows.Count-1;
                carShow();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "DELETE FROM Masini WHERE codMasina=@c";
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("codMasina", int.Parse(textBox1.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Cars was deleted successfully!");
                currentLine = dataset.Tables["Cars"].Rows.Count - 1;
                connection.Close();
                loadData();
                
                carShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "UPDATE Masini SET denMasina=?, Marca=?, Pret=? WHERE codMasina=?";
                command.Connection = connection;
                command.Parameters.Clear();

                
                command.Parameters.AddWithValue("denMasina", textBox2.Text);
                command.Parameters.AddWithValue("Marca", textBox3.Text);
                command.Parameters.AddWithValue("Pret", int.Parse(textBox4.Text));
                command.Parameters.AddWithValue("codMasina", int.Parse(textBox1.Text));

                command.ExecuteNonQuery();
                MessageBox.Show("Cars was updated successfully!");

                connection.Close();
                loadData();
                carShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
                connection.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public double cota_de_asigurare(double x)
        {
            if (x <= 20000)
                return x * 0.03;
            else if (x <= 40000)
                return x * 0.35;
            else if (x <= 60000)
                return x * 0.5;
            else return x * 0.6;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //double val = double.Parse(dataset.Tables["Cars"].Rows[currentLine].ItemArray[3].ToString());
            //textBox5.Text = cota_de_asigurare(val).ToString();
        }
    }
}
