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
    public partial class FrmTipoPago : Form
    {
        public FrmTipoPago(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }
        private Form formulario;
        private CTipoPago oldPago;
        private CTipoPago newPago;
        private CUsuario usuario;

        private void FrmPago_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.nombreUsuario;

        }
        //MENU
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
            formulario = new Form1(usuario);
            formulario.Show();
            Hide();
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

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                oldPago = new CTipoPago(int.Parse(row.Cells[0].Value.ToString()),row.Cells[1].Value.ToString(),row.Cells[2].Value.ToString());
                oldPago.Eliminar();

                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.");
                dataGridView1.DataSource = CTipoPago.Visualizar();
                limpiar();

            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            newPago = new CTipoPago(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            if (newPago.descripcion == "" || newPago.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            }
            else
            {
                newPago.Insertar();
                dataGridView1.DataSource = CTipoPago.Visualizar();

                MessageBox.Show("Se ha insertado un nuevo tipo de Pago", "Insercion Correcta");
                limpiar();
            }  
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento", "Error al actualizar datos");

            else if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("Seleccione un elemento", "Error al actualizar datos");

            else
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                btnInsertar.Enabled = false;
                btnActualizar2.Enabled = false;
                btnActualizar.Enabled = true;

                oldPago = new CTipoPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                /*cmbEstado.SelectedItem = from ComboBox.ObjectCollection item in cmbEstado.Items 
                                         * where cmbEstado.Items.ToString().Contains(oldPago.estado)
                                           select item;  */

                //cmbCampo.SelectedIndex = oldPago.estado == "Activo" ? 0 : -1;

                rtxtDescripcion.Text = oldPago.descripcion;
                cmbEstado.Text = oldPago.estado;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CTipoPago.Visualizar() : dataGridView1.DataSource;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            newPago = new CTipoPago(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            if (newPago.descripcion == "" || newPago.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            } else
            {
                CTipoPago.Actualizar(oldPago, newPago);

                dataGridView1.DataSource = CTipoPago.Visualizar();

                btnActualizar.Enabled = false;
                btnInsertar.Enabled = true;
                btnActualizar2.Enabled = true;

                MessageBox.Show("Se ha actualizado el tipo de Servicio", "Actualizacion Correcta");
                limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CTipoPago.Visualizar($"SELECT * FROM TIPO_PAGO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text}'");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
