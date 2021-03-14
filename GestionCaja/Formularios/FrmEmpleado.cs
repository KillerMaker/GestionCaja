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
    public partial class FrmEmpleado :Form
    {
        private Form formulario;
        private CEmpleado oldEmpleado;
        private CEmpleado newEmpleado;
        private CUsuario usuario;

        public FrmEmpleado(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
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




        //Boton de Insertar datos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
                newEmpleado = new CEmpleado(txtNombre.Text.SQLInyectionClearString(), mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text, decimal.Parse(txtSueldo.Text.Replace(",", "").Replace("RD$", "")), cmbTipoUsuario.Text);
                if (newEmpleado.cedulaValida == false)
                {
                    MessageBox.Show("Cedula Invalida", "Error en la Insercion de datos");
                }
                else
                {
                    newEmpleado.Insertar();//Ejecuta el metodo Insertar del objeto recien creado.
                    MessageBox.Show("Se han insertado los datos de: " + txtNombre.Text + " en la Base de Datos.", "Insercion Correcta");
                    limpiar();//Limpia el atributo .Text de todos los controles de entrada
                    dataGridView1.DataSource = CEmpleado.Visualizar();//Viasualiza los cambios en el Dtgv
                }
            }
            catch
            {
                MessageBox.Show("Inserte los datos correctamente","Error en la insercion de datos");
            }
               
        }

        //Boton de Confirmar Actualizar datos
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
                newEmpleado = new CEmpleado(txtNombre.Text.SQLInyectionClearString(), mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), txtLaboral.Text, (nudComision.Value) / 100, mtxtFechaIngreso.Text, txtEstado.Text.SQLInyectionClearString(), decimal.Parse(txtSueldo.Text.Replace(",", "").Replace("RD$", "")), cmbTipoUsuario.Text);

                //Ejecuta el metodo estatico Actualizar(CPersona oldPersona,CPersona newEmpleado) y 
                //le pasa el objeto oldEmpleado como primer parametro y newEmpledo como el segundo.
                CEmpleado.Actualizar(oldEmpleado, newEmpleado);

                btnActualizar.Enabled = false;
                btnInsertar.Enabled = true;
                btnActualizar2.Enabled = true;
                mtxtCedula.Enabled = true;
                mtxtFechaIngreso.Enabled = true;
                mtxtFechaNac.Enabled = true;

                dataGridView1.DataSource = CEmpleado.Visualizar();
                MessageBox.Show("Se han actualizado los datos de: " + txtNombre.Text + " en la Base de Datos.", "Actualizacion Correcta");
                limpiar();
            }
            catch
            {
                MessageBox.Show("Inserte los datos correctamente", "Error en la insercion de datos");
            }
            
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.nombreUsuario;
            
        }

        //Boton de busqueda personalizada
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CEmpleado.Visualizar($"SELECT * FROM VISTA_EMPLEADO WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");

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
                oldEmpleado = new CEmpleado(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(),decimal.Parse( row.Cells[6].Value.ToString()), row.Cells[7].Value.ToString(),row.Cells[8].Value.ToString(), decimal.Parse(row.Cells[9].Value.ToString()),"");
                
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
            txtEstado.SelectedItem = null;
            txtLaboral.SelectedItem = null;
            txtNombre.Clear();
            txtSueldo.Clear();
            txtValor.Clear();
            mtxtCedula.Clear();
            mtxtFechaIngreso.Clear();
            mtxtFechaNac.Clear();
            nudComision.Value = 0;
            cmbGenero.SelectedItem = null;
            cmbTipoUsuario.SelectedItem = null;

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
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para Eliminar", "Error al Eliminar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al Eliminar");
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];// se iguala a row a la fila seleccionada

                //Se instancia oldEmpleado con el segundo constructor de la clase, y se asignan los valores
                //de las celdas de row a oldEmpleado
                oldEmpleado = new CEmpleado(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), decimal.Parse(row.Cells[6].Value.ToString()), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), decimal.Parse(row.Cells[9].Value.ToString()),"");
                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.", "Eliminacion Correcta");
                oldEmpleado.Eliminar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

    }
}
