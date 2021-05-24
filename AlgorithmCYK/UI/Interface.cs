using AlgorithmCYK.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmCYK
{
    public partial class Interface : Form
    {
        string infoText = "Ingrese la gramatica en forma normal de Chomsky (FNC), use una linea por cada instruccion (ver ejemplo) \n" +
            " \n" +
            "S->BA|AB \n" +
            "A->CA|a \n" +
            "B->BB|b \n" +
            "C->BA|c";


        public Interface()
        {
            InitializeComponent();
            labelInfo.Text = infoText;
            this.Text = "Algoritmo CYK";
            this.Icon = new Icon("../../docs/fear.ico");
        }

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            if(textBoxGramatica.Text == "" || textBoxPalabra.Text == "")
            {
                MessageBox.Show("Introduzca una gramatica y palabra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CYK auxcyk = new CYK(textBoxPalabra.Text, textBoxGramatica.Lines);
                MessageBox.Show(auxcyk.start());
            }
            
        }
    }
}
