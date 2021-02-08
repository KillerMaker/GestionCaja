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
    public partial class FrmEmpleado :Form
    {
        private Form formulario;
        private CEmpleado oldEmpleado;
        private CEmpleado newEmpleado;

        public FrmEmpleado()
        {
            InitializeComponent();
        }


        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante();
            formulario.Show();
            this.Hide();
        }

        private void registroDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmRegMovCaja();
            formulario.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            newEmpleado= new CEmpleado(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-",""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text, decimal.Parse(txtSueldo.Text));
            newEmpleado.Insertar();
            dataGridView1.DataSource= CEmpleado.Visualizar();
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newEmpleado = new CEmpleado(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text, decimal.Parse(txtSueldo.Text));
            CEmpleado.Actualizar(oldEmpleado, newEmpleado);

            btnActualizar.Enabled = false;
            btnInsertar.Enabled = true;
            btnActualizar2.Enabled = true;

            dataGridView1.DataSource = CEmpleado.Visualizar();
            limpiar();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = CEmpleado.Visualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CEmpleado.Visualizar("SELECT * FROM VISTA_EMPLEADO WHERE "+cmbCampo.Text+" "+cmbCriterio.Text+" '"+txtValor.Text+"'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para actualizar", "Error al actualizar");

            else if (dataGridView1.SelectedRows.Count>1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al actualizar");
            else 
            {
                mtxtFechaIngreso.Enabled = false;
                mtxtCedula.Enabled = false;
                mtxtFechaNac.Enabled = false;

                DataGridViewRow row = new DataGridViewRow();
                row= dataGridView1.SelectedRows[0];

                oldEmpleado = new CEmpleado(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(),decimal.Parse( row.Cells[6].Value.ToString()), row.Cells[7].Value.ToString(),row.Cells[8].Value.ToString(), decimal.Parse(row.Cells[9].Value.ToString()));
                
                txtNombre.Text = oldEmpleado.nombre;
                mtxtFechaNac.Text = DateTime.Parse( oldEmpleado.fecha.Replace("-","")).ToString("dd/MM/yyyy");
                cmbGenero.Text = oldEmpleado.genero;
                mtxtCedula.Text = oldEmpleado.cedula.Replace("-","");
                txtLaboral.Text = oldEmpleado.tandaLabor;
                nudComision.Value = oldEmpleado.porcientoComision*100;
                mtxtFechaIngreso.Text = DateTime.Parse( oldEmpleado.fechaIngreso.Replace("-","")).ToString("dd/MM/yyyy");
                txtSueldo.Text = oldEmpleado.sueldo.ToString();
                txtEstado.Text = oldEmpleado.estado;

                btnInsertar.Enabled = false;
                btnActualizar2.Enabled = false;
                btnActualizar.Enabled = true;
            }

        }
        private void limpiar()
        {
            txtEstado.Clear();
            txtLaboral.Clear();
            txtNombre.Clear();
            txtSueldo.Clear();
            txtValor.Clear();
            mtxtCedula.Clear();
            mtxtFechaIngreso.Clear();
            mtxtFechaNac.Clear();
            nudComision.Value = 0;

            txtNombre.Focus();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1?CEmpleado.Visualizar():dataGridView1.DataSource;
        }
    }
}
