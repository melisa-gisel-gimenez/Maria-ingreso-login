using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iglesia
{
    public partial class PPTesoreria : Form
    {
        public PPTesoreria()
        {
            InitializeComponent();
        }

        private void generarInformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ACA FALTA  MOSTRAR LO QUE GENERA LOS INFORMES. 
        }

        private void acercaDeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AcercaDe Form1 = new AcercaDe();
            Form1.ShowDialog();
        }

        private void modificarIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar_Ingresos Form1 = new Modificar_Ingresos();
            Form1.ShowDialog();
        }

        private void agregarIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarIngresos Form1 = new AgregarIngresos();
            Form1.ShowDialog();
        }

        private void agregarEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarEgresos Form1 = new AgregarEgresos();
            Form1.ShowDialog();
        }

        private void modificarEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar_Egresos Form1 = new Modificar_Egresos();
            Form1.ShowDialog();
        }
    }
}
