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
using GestionCaja.Formularios;
using GestionCaja.Utilidades;

namespace GestionCaja
{
    public partial class FrmTipoServicio : Form
    {
        public FrmTipoServicio(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private CTipoServicio oldServicio;
        private CTipoServicio newServicio;
        private Form formulario;
        private CUsuario usuario;
        

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

        private void modalidadesDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmModalidadPago(usuario);
            formulario.Show();
            Hide();
        }

        private void limpiar()
        {
            rtxtDescripcion.Clear();
            cmbEstado.SelectedItem = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            newServicio = new CTipoServicio(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            if (newServicio.descripcion == "" || newServicio.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            }
            else
            {
                CTipoServicio.Actualizar(oldServicio, newServicio);
                dataGridView1.DataSource = CTipoServicio.Visualizar();

                MessageBox.Show("Se ha actualizado el tipo de Servicio", "Actualizacion Correcta");
                limpiar();

                btnActualizar.Enabled = false;
                btnActualizar2.Enabled = true;
                btnInsertar.Enabled = true;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            newServicio = new CTipoServicio(rtxtDescripcion.Text.SQLInyectionClearString(), cmbEstado.Text);
            if (newServicio.descripcion == "" || newServicio.estado == "")
            {
                MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
            } else
            {
                newServicio.Insertar();

                MessageBox.Show("Se ha insertado un nuevo tipo de Servicio", "Insercion Correcta");
                limpiar();
                dataGridView1.DataSource = CTipoServicio.Visualizar();
            }
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento", "Error en la insercion de datos");

            else if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("Seleccione un elemento", "Error en la insercion de datos");

            else
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                oldServicio = new CTipoServicio(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                rtxtDescripcion.Text = oldServicio.descripcion;
                cmbEstado.Text = oldServicio.estado;

                btnActualizar.Enabled = true;
                btnInsertar.Enabled = false;
                btnActualizar2.Enabled = false;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CTipoServicio.Visualizar() : dataGridView1.DataSource;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento", "Error en la insercion de datos");

            else if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("Seleccione un elemento", "Error en la insercion de datos");

            else
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                oldServicio = new CTipoServicio(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                oldServicio.Eliminar();

                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.","Cambio Correcto");
                dataGridView1.DataSource = CTipoServicio.Visualizar();
                limpiar();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CTipoServicio.Visualizar($"SELECT * FROM TIPO_SERVICIO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");
        }

        private void FrmTipoServicio_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.nombreUsuario;
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
    }
}
