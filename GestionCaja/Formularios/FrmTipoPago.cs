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
    public partial class FrmTipoPago : Form
    {
        public FrmTipoPago()
        {
            InitializeComponent();
        }
        Form formulario;
        CTipoPago newTipoPago;
        CTipoPago oldTipoPago;


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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            newTipoPago = new CTipoPago(rtxtDescripcion.Text, cmbEstado.Text);
            newTipoPago.Insertar();

            dataGridView1.DataSource = CTipoPago.Visualizar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            newTipoPago = new CTipoPago(rtxtDescripcion.Text, cmbEstado.Text);
            CTipoPago.Actualizar(oldTipoPago, newTipoPago);

            btnInsertar.Enabled = true;
            btnActualizar.Enabled = false;
            dataGridView1.DataSource =CTipoPago.Visualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para actualizar", "Error al Eliminar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al Eliminar");

            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];

                oldTipoPago = new CTipoPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                oldTipoPago.Eliminar();
                dataGridView1.DataSource = CTipoPago.Visualizar();
            }
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

                oldTipoPago = new CTipoPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                rtxtDescripcion.Text = oldTipoPago.descripcion;
                cmbEstado.Text = oldTipoPago.estado;

                dataGridView1.DataSource = CTipoPago.Visualizar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CTipoPago.Visualizar($"SELECT * FROM TIPO_PAGO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text}'");

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CTipoPago.Visualizar() : dataGridView1.DataSource;

        }
    }
}
