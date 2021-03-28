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
    public partial class FrmEstudiante : Form
    {
        private Form formulario;
        private CEstudiante oldEstudiante;
        private CEstudiante newEstudiante;
        private CUsuario usuario;

        public FrmEstudiante(CUsuario usuario)
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

        private void modalidadesDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmModalidadPago(usuario);
            formulario.Show();
            Hide();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.nombreUsuario;

            if (usuario.tipoUsuario == "Empleado")
            {
                empleadoToolStripMenuItem1.Enabled = false;
                tiposDeDocumentosToolStripMenuItem.Enabled = false;
                tiposDePagosToolStripMenuItem.Enabled = false;
                tiposDeServiciosToolStripMenuItem.Enabled = false;
            }

        }



        //******************************************
        private void btnInsertar_Click(object sender, EventArgs e)
        {
                //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
                newEstudiante = new CEstudiante(txtNombre.Text.SQLInyectionClearString(), mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), cmbCarrera.Text, mtxtFechaIngreso.Text, cmbEstado.Text);
                if(newEstudiante.nombre == "" || newEstudiante.fecha == "" || newEstudiante.genero == "" || newEstudiante.carrera == "" || newEstudiante.fechaRegistro == "" || newEstudiante.estado == "")
                {
                    MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
                }
                else
                {
                    newEstudiante.Insertar();//Ejecuta el metodo Insertar del objeto recien creado.
                    dataGridView1.DataSource = CEstudiante.Visualizar();//Viasualiza los cambios en el Dtgv
                    MessageBox.Show("Se han insertado los datos de: " + txtNombre.Text + " en la Base de Datos.", "Insercion correcta");
                    limpiar();//Limpia el atributo .Text de todos los controles de entrada
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para actualizar", "Error al actualizar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al actualizar");
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];// se iguala a row a la fila seleccionada

                //Se instancia oldEmpleado con el segundo constructor de la clase, y se asignan los valores
                //de las celdas de row a oldEmpleado
                oldEstudiante = new CEstudiante(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString());
                MessageBox.Show("Se ha cambiado el estado de: " + row.Cells[1].Value.ToString() + " a Inactivo.", "Eliminacion correcta");
                oldEstudiante.Eliminar();
                dataGridView1.DataSource = CEstudiante.Visualizar();
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
                mtxtFechaIngreso.Enabled = false;
                mtxtCedula.Enabled = false;
                mtxtFechaNac.Enabled = false;

                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];// se iguala a row a la fila seleccionada

                //Se instancia oldEmpleado con el segundo constructor de la clase, y se asignan los valores
                //de las celdas de row a oldEmpleado
                oldEstudiante = new CEstudiante(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(),row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString());

                //Se insertan los valores de oldEmpleado en el atributo .Text de los controles de entrada del formulario
                txtNombre.Text = oldEstudiante.nombre;
                mtxtFechaNac.Text = DateTime.Parse(oldEstudiante.fecha.Replace("-", "")).ToString("dd/MM/yyyy");
                cmbGenero.Text = oldEstudiante.genero;
                mtxtCedula.Text = oldEstudiante.cedula.Replace("-", "");
                cmbCarrera.Text = oldEstudiante.carrera;
                mtxtFechaIngreso.Text = DateTime.Parse(oldEstudiante.fechaRegistro.Replace("-", "")).ToString("dd/MM/yyyy");
                cmbEstado.Text = oldEstudiante.estado;

                btnInsertar.Enabled = false;
                btnActualizar2.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CEstudiante.Visualizar($"SELECT * FROM VISTA_ESTUDIANTE WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //si el Dtgv contiene filas sera igual a el mismo mientras si no tiene sera igual al metodo estatico visualizar de CEstudiante
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CEstudiante.Visualizar() : dataGridView1.DataSource;
        }
        private void limpiar()
        {
            //Se resetea el atributo .Text a todos los controles de entrada del formulario
            txtNombre.Clear();
            txtValor.Clear();
            mtxtCedula.Clear();
            mtxtFechaIngreso.Clear();
            mtxtFechaNac.Clear();
            cmbGenero.SelectedItem = null;
            cmbCarrera.SelectedItem = null;
            cmbEstado.SelectedItem = null;

            txtNombre.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
                newEstudiante = new CEstudiante(txtNombre.Text.SQLInyectionClearString(), mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), cmbCarrera.Text, mtxtFechaIngreso.Text, cmbEstado.Text);

                if (newEstudiante.nombre == "" || newEstudiante.fecha == "" || newEstudiante.genero == "" || newEstudiante.carrera == "" || newEstudiante.fechaRegistro == "" || newEstudiante.estado == "")
                {
                    MessageBox.Show("Se deben completar todos los campos", "Error en la Insercion de datos");
                }
                else
                {
                    //Ejecuta el metodo estatico Actualizar(CPersona oldPersona,CPersona newEmpleado) y 
                    //le pasa el objeto oldEmpleado como primer parametro y newEmpledo como el segundo.
                    CEstudiante.Actualizar(oldEstudiante, newEstudiante);

                    btnActualizar.Enabled = false;
                    btnInsertar.Enabled = true;
                    btnActualizar2.Enabled = true;
                    mtxtCedula.Enabled = true;
                    mtxtFechaIngreso.Enabled = true;
                    mtxtFechaNac.Enabled = true;

                    dataGridView1.DataSource = CEstudiante.Visualizar();
                    MessageBox.Show("Se han actualizado los datos de: " + txtNombre.Text + " en la Base de Datos.", "Actualizacion correcta");
                    limpiar();
                }
            }
            catch 
            {
                MessageBox.Show("Inserte los datos correctamente","Error en la actualizacion de datos");
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
