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

namespace Form3
{
    public partial class Form2 : Form
    {
        public struct Client
        {
            public int codClient;
            public string numeClient;
            public string adresa;
            public double limitaCredit;
        }
        public struct Factura
        {
            public int nrFactura;
            public DateTime dataFactura;
            public double valFact;
            public Client clientFactura;
        }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Client c1;
            c1.codClient = 100;
            c1.numeClient = "SC ALFA SRL";
            c1.adresa = "str. Profitului";
            c1.limitaCredit = 5000;
            //MessageBox.Show(c1.numeClient + " " + c1.adresa + " " + c1.limitaCredit);
            Factura[] listaFacturi = new Factura[5];
            for (int i = 0; i < listaFacturi.Length; i++)
            {
                listaFacturi[i].nrFactura = i + 1;
                listaFacturi[i].clientFactura = c1;
                int ziua, luna, anul;
                ziua = Int32.Parse(Interaction.InputBox("Ziua emiterii facturii nr. " + (i + 1)));
                luna = Int32.Parse(Interaction.InputBox("Luna emiterii facturii nr. " + (i + 1)));
                anul = Int32.Parse(Interaction.InputBox("Anul emiterii facturii nr. " + (i + 1)));
                listaFacturi[i].dataFactura = new DateTime(anul, luna, ziua);
                listaFacturi[i].valFact = double.Parse(Interaction.InputBox("Valoarea facturii nr. " + (i + 1)));
            }
            for (int i = 0; i < listaFacturi.Length; i++)
                Console.WriteLine("Factura nr. " + listaFacturi[i].nrFactura + " a fost emisa clientului " + listaFacturi[i].clientFactura.numeClient + " la data de " + listaFacturi[i].dataFactura.Day + "/" + listaFacturi[i].dataFactura.Month + "/" + listaFacturi[i].dataFactura.Year + " are valoarea " + listaFacturi[i].valFact);
        }
    }
}
