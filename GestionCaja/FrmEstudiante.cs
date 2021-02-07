using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCaja
{
    public partial class FrmEstudiante : Form
    {
        public FrmEstudiante()
        {
            InitializeComponent();
        }

        Form formulario;
        private void registroDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmRegMovCaja();
            formulario.Show();
            this.Hide();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado();
            formulario.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            this.Hide();
        }
    }
}
