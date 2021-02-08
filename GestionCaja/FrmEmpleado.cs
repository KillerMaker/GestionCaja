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

        //Menu
        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEstudiante();
            formulario.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            this.Hide();
        }


        //Boton de Insertar datos
        private void button1_Click(object sender, EventArgs e)
        {
            //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
            newEmpleado= new CEmpleado(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-",""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text, decimal.Parse(txtSueldo.Text));

            newEmpleado.Insertar();//Ejecuta el metodo Insertar del objeto recien creado.
            dataGridView1.DataSource= CEmpleado.Visualizar();//Viasualiza los cambios en el Dtgv
            limpiar();//Limpia el atributo .Text de todos los controles de entrada
        }

        //Boton de Confirmar Actualizar datos
        private void button2_Click(object sender, EventArgs e)
        {
            //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
            newEmpleado = new CEmpleado(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text, decimal.Parse(txtSueldo.Text));

            //Ejecuta el metodo estatico Actualizar(CPersona oldPersona,CPersona newEmpleado) y 
            //le pasa el objeto oldEmpleado como primer parametro y newEmpledo como el segundo.
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

        //Boton de busqueda personalizada
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CEmpleado.Visualizar("SELECT * FROM VISTA_EMPLEADO WHERE "+cmbCampo.Text+" "+cmbCriterio.Text+" '"+txtValor.Text+"'");
        }

        //Boton de Actualizar datos
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
                row= dataGridView1.SelectedRows[0];// se iguala a row a la fila seleccionada

                //Se instancia oldEmpleado con el segundo constructor de la clase, y se asignan los valores
                //de las celdas de row a oldEmpleado
                oldEmpleado = new CEmpleado(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(),decimal.Parse( row.Cells[6].Value.ToString()), row.Cells[7].Value.ToString(),row.Cells[8].Value.ToString(), decimal.Parse(row.Cells[9].Value.ToString()));
                
                //Se insertan los valores de oldEmpleado en el atributo .Text de los controles de entrada del formulario
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

        //Funcion para limpiar los controles
        private void limpiar()
        {
            //Se resetea el atributo .Text a todos los controles de entrada del formulario
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

        //DataGridView evento click
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //si el Dtgv contiene filas sera igual a el mismo mientras si no tiene sera igual al metodo estatico visualizar de CEmpleado
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1?CEmpleado.Visualizar():dataGridView1.DataSource;
        }

        //Boton de Eliminar datos(cambiar el valor del campo ESTADO a Inactivo)
        private void button3_Click(object sender, EventArgs e)
        {
            oldEmpleado.Eliminar();
        }
    }
}
