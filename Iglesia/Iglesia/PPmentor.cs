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
    public partial class PPmentor : Form
    {
        public PPmentor()
        {
            InitializeComponent();
        }

        private void reunionesDeMentoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroReunionesMentor Form1 = new RegistroReunionesMentor();
            Form1.ShowDialog();
        }

        private void postulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostulacionesRevisar Form1 = new PostulacionesRevisar();
            Form1.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe Form1 = new AcercaDe();
            Form1.ShowDialog();
        }
    }
}
