using GestionCaja.Entidades;
using GestionCaja.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCaja.Formularios
{
    public partial class FrmModalidadPago : Form
    {
        public FrmModalidadPago(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private Form formulario;
        private CModalidadPago oldModalidad;
        private CModalidadPago newModalidad;
        private CUsuario usuario;

        private void FrmModalidadPago_Load(object sender, EventArgs e)
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

        private void modalidadesDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmModalidadPago(usuario);
            formulario.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newModalidad = new CModalidadPago(rtxtDescripcion.Text.SQLInyectionClearString(), (int)numericUpDown1.Value, cmbEstado.Text);
            if (newModalidad.descripcion == "" || newModalidad.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            }
            else
            {
                newModalidad.Insertar();
                MessageBox.Show("Se ha insertado una nueva modalidad de pago", "Insercion Correcta");

                dataGridView1.DataSource = CModalidadPago.Visualizar();
            }
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

                oldModalidad = new CModalidadPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()), row.Cells[3].Value.ToString());

                rtxtDescripcion.Text = oldModalidad.descripcion;
                numericUpDown1.Value = oldModalidad.numeroCuota;
                cmbEstado.Text = oldModalidad.estado;

                dataGridView1.DataSource = CModalidadPago.Visualizar();
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            newModalidad = new CModalidadPago(rtxtDescripcion.Text.SQLInyectionClearString(), (int)numericUpDown1.Value, cmbEstado.Text);
            if (newModalidad.descripcion == "" || newModalidad.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            }
            else
            {
                CModalidadPago.Actualizar(oldModalidad, newModalidad);

                dataGridView1.DataSource = CModalidadPago.Visualizar();

                btnActualizar.Enabled = false;
                btnInsertar.Enabled = true;
                btnActualizar2.Enabled = true;

                MessageBox.Show("Se ha actualizado la modalidad de pagos", "Actualizacion Correcta");
                limpiar();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CModalidadPago.Visualizar() : dataGridView1.DataSource;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CModalidadPago.Visualizar($"SELECT * FROM MODALIDAD_PAGO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento", "Error al actualizar datos");

            else if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("Seleccione un elemento", "Error al actualizar datos");

            else
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                oldModalidad = new CModalidadPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()) , row.Cells[3].Value.ToString());
                oldModalidad.Eliminar();

                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.");
                dataGridView1.DataSource = CModalidadPago.Visualizar();
                limpiar();

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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            formulario = new FrmExportaciones((DataTable)dataGridView1.DataSource, this);
            formulario.Show();
        }

        private void estudiantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
