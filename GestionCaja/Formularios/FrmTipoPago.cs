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
        CTipoPago oldPago;
        CTipoPago newPago;

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
            cmbEstado.SelectedItem = null;
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

                dataGridView1.DataSource = CTipoPago.Visualizar();
            }
               
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            newPago = new CTipoPago(rtxtDescripcion.Text, cmbEstado.Text);
            newPago.Insertar();
            dataGridView1.DataSource = CTipoPago.Visualizar();
            limpiar();
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



                oldPago = new CTipoPago(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                //cmbEstado.SelectedItem = from ComboBox.ObjectCollection item in cmbEstado.Items where cmbEstado.Items.ToString().Contains(oldPago.estado) select item;
                //cmbCampo.SelectedIndex = oldPago.estado == "Activo" ? 0 : -1;
                //cmbCampo.SelectedItem=cmbCampo.Items.
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
            newPago = new CTipoPago(rtxtDescripcion.Text, cmbEstado.Text);
            CTipoPago.Actualizar(oldPago, newPago);

            dataGridView1.DataSource = CTipoPago.Visualizar();

            btnActualizar.Enabled = false;
            btnInsertar.Enabled = true;
            btnActualizar2.Enabled = true;

            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CTipoPago.Visualizar($"SELECT * FROM TIPO_PAGO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text}'");
        }
    }
}
