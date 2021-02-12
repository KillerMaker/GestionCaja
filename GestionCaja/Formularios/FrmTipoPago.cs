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
    public partial class FrmTipoPago : Form
    {
        public FrmTipoPago()
        {
            InitializeComponent();
        }
        Form formulario;


        private void FrmPago_Load(object sender, EventArgs e)
        {

        }
        //MENU
        private void estudiantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante();
            formulario.Show();
            Hide();
        }

        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado();
            formulario.Show();
            Hide();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoDocumento();
            formulario.Show();
            Hide();
        }

        private void tiposDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoServicio();
            formulario.Show();
            Hide();
        }

        private void tiposDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoPago();
            formulario.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            Hide();
        }

        private void limpiar()
        {
            rtxtDescripcion.Clear();
            cmbEstado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
