﻿using System;
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
    public partial class FrmEstudiante : Form
    {
        public FrmEstudiante()
        {
            InitializeComponent();
        }

        private Form formulario;
        private CEstudiante oldEstudiante;
        private CEstudiante newEstudiante;

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmEmpleado();
            formulario.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new Form1();
            formulario.Show();
            this.Hide();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
            newEstudiante = new CEstudiante(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""),cmbCarrera.Text,mtxtFechaIngreso.Text,cmbEstado.Text);

            newEstudiante.Insertar();//Ejecuta el metodo Insertar del objeto recien creado.
            dataGridView1.DataSource = CEstudiante.Visualizar();//Viasualiza los cambios en el Dtgv
            limpiar();//Limpia el atributo .Text de todos los controles de entrada
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

                oldEstudiante.Eliminar();
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
            dataGridView1.DataSource = CEstudiante.Visualizar($"SELECT * FROM VISTA_ESTUDIANTE WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text}'");
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
            cmbGenero.Text = "";
            cmbCarrera.Text = "";
            cmbEstado.Text = "";

            txtNombre.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Crea un objeto CEmpleado con los valores .text de los controles de entrada del formulario.
            newEstudiante = new CEstudiante(txtNombre.Text, mtxtFechaNac.Text, cmbGenero.Text, mtxtCedula.Text.Replace("-", ""), cmbCarrera.Text,mtxtFechaIngreso.Text,cmbEstado.Text);

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
            limpiar();
        }
    }
}
