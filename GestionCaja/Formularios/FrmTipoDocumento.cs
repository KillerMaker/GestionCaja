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
    public partial class FrmTipoDocumento : Form
    {
        public FrmTipoDocumento()
        {
            InitializeComponent();
        }
        Form formulario;

        private void FrmDocumento_Load(object sender, EventArgs e)
        {

        }


        //MENU
        private void estudiantesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante();
            formulario.Show();
            Hide();
        }

        private void empleadoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado();
            formulario.Show();
            Hide();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoDocumento();
            formulario.Show();
            Hide();
        }

        private void tiposDeServiciosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoServicio();
            formulario.Show();
            Hide();
        }

        private void tiposDePagosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoPago();
            formulario.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            Hide();
        }
    }
}
