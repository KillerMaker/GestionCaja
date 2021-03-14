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
using GestionCaja.Utilidades;

namespace GestionCaja
{
    public partial class FrmTipoDocumento : Form
    {
        public FrmTipoDocumento(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }
        
        private Form formulario;
        private CTipoDocumento oldDocumento;
        private CTipoDocumento newDocumento;
        private CUsuario usuario;

        private void FrmDocumento_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.nombreUsuario;

        }


        //MENU
        private void estudiantesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante(usuario);
            formulario.Show();
            Hide();
        }

        private void empleadoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoDocumento(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDeServiciosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoServicio(usuario);
            formulario.Show();
            Hide();
        }

        private void tiposDePagosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new FrmTipoPago(usuario);
            formulario.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formulario = new Form1(usuario);
            formulario.Show();
            Hide();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            newDocumento = new CTipoDocumento(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            newDocumento.Insertar();
            MessageBox.Show("Se ha insertado un nuevo tipo de documento", "Insercion Correcta");

            dataGridView1.DataSource = CTipoDocumento.Visualizar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para actualizar", "Error al actualizar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al actualizar");

            else
            {
                btnActualizar.Enabled = true;
                btnInsertar.Enabled = false;

                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];

                oldDocumento = new CTipoDocumento(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                rtxtDescripcion.Text = oldDocumento.descripcion;
                cmbEstado.Text = oldDocumento.estado;

                dataGridView1.DataSource = CTipoDocumento.Visualizar();
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            newDocumento = new CTipoDocumento(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            CTipoDocumento.Actualizar(oldDocumento, newDocumento);

            btnInsertar.Enabled = true;
            btnActualizar.Enabled = false;
            btnActualizar2.Enabled = true;

            MessageBox.Show("Se ha actualizado el tipo de documento", "Actualizacion Correcta");
            limpiar();
            dataGridView1.DataSource= CTipoDocumento.Visualizar();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CTipoDocumento.Visualizar() : dataGridView1.DataSource;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CTipoDocumento.Visualizar($"SELECT * FROM TIPO_DOCUMENTO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para actualizar", "Error al actualizar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al actualizar");

            else
            {

                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];

                oldDocumento = new CTipoDocumento(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.","Cambio Correcto");
                oldDocumento.Eliminar();
                dataGridView1.DataSource = CTipoDocumento.Visualizar();
            }
        }

        private void limpiar()
        {
            rtxtDescripcion.Clear();
            cmbEstado.SelectedItem = null;
            rtxtDescripcion.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
