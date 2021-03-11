using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionCaja.Entidades;

namespace GestionCaja
{
    public partial class Form1 : Form
    {

        private CUsuario usuario;
        private Form formulario;

        public Form1(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = usuario.nombreUsuario;
            if(usuario.tipoUsuario=="Empleado")
            {
                empleadoToolStripMenuItem1.Enabled = false;
                tiposDeDocumentosToolStripMenuItem.Enabled = false;
                tiposDePagosToolStripMenuItem.Enabled = false;
                tiposDeServiciosToolStripMenuItem.Enabled = false;
            }
        }

        private void estudiantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante(usuario);
            formulario.Show();
            Hide();
        }

        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoDocumento(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoServicio(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmTipoPago(usuario);
            formulario.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1(this.usuario);
            formulario.Show();
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
