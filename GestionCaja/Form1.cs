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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        Form formulario;
        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante();
            formulario.Show();
            this.Hide();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado();
            formulario.Show();
            this.Hide();
        }

        private void registroDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmRegMovCaja();
            formulario.Show();
            this.Hide();
        }
    }
}
