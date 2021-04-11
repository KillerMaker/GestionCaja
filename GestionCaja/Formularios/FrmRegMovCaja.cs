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

namespace GestionCaja.Formularios
{
    public partial class FrmRegMovCaja : Form
    {
        private Form formulario;
        private CUsuario usuario;
        private CRegMovCaja regMovCaja;
        private DataTable data;
        private SqlDataManagement dataManagement;
        private List<string> lista;
        private List<int> lista2;
        private List<string> lista3;
        private List<int> lista4;
        public FrmRegMovCaja(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lista= new List<string>();
            lista2 = new List<int>();

            cmbTipoDocumento.Items.Clear();
            if (rbtnDocumento.Checked == true)
            {
                cmbTipoDocumento.Enabled = true;
                cmbTipoServicio.Enabled = false;

                data = new DataTable();
                dataManagement = new SqlDataManagement();

                data.Columns.Add("id");
                data.Columns.Add("Descripcion");
                dataManagement.ExecuteCommand("SELECT * FROM TIPO_DOCUMENTO WHERE ESTADO = 'Activo'");
                dataManagement.ExecuteReader();

                while(dataManagement.reader.Read())
                {
                   data.Rows.Add( dataManagement.reader["ID_TIPO_DOCUMENTO"],dataManagement.reader["DESCRIPCION"]);
                }

                for(int i =0;i<data.Rows.Count;i++)
                {
                    lista.Add(data.Rows[i].Field<string>("Descripcion"));
                    lista2.Add(int.Parse(data.Rows[i].Field<string>("id")));
                    cmbTipoDocumento.Items.Add(lista[i]);
                    
                }

            }
                
        }
        private void rbtnServicio_CheckedChanged(object sender, EventArgs e)
        {
            lista = new List<string>();
            lista2 = new List<int>();

            cmbTipoServicio.Items.Clear();
            if (rbtnServicio.Checked == true)
            {
                cmbTipoDocumento.Enabled = false;
                cmbTipoServicio.Enabled = true;

                data = new DataTable();
                dataManagement = new SqlDataManagement();

                data.Columns.Add("id");
                data.Columns.Add("Descripcion");
                dataManagement.ExecuteCommand("SELECT * FROM TIPO_SERVICIO WHERE ESTADO = 'Activo'");
                dataManagement.ExecuteReader();

                while (dataManagement.reader.Read())
                {
                    data.Rows.Add(dataManagement.reader["ID_TIPO_SERVICIO"], dataManagement.reader["DESCRIPCION"]);
                }

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    lista.Add(data.Rows[i].Field<string>("Descripcion"));
                    lista2.Add(int.Parse(data.Rows[i].Field<string>("id")));
                    cmbTipoServicio.Items.Add(lista[i]);
                }
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string tipoPago="";
            string tipoServicio="";
            string tipoDocumento="";

            for(int i=0;i<lista.Count-1;i++)
            {
                if (lista3[i] == cmbTipoPago.Text)
                {
                    tipoPago = lista4[i].ToString();
                    break;
                }
            }
            if (rbtnDocumento.Checked == true)
            {
                for (int i = 0; i < lista.Count - 1; i++)
                {
                    if (lista[i] == cmbTipoDocumento.Text)
                    {
                        tipoDocumento = lista2[i].ToString();
                        break;
                    }
                }
                regMovCaja = new CRegMovCaja(txtVendedor.Text.SQLInyectionClearString(), txtCliente.Text.SQLInyectionClearString(), tipoPago, mtxtFecha.Text, decimal.Parse(mtxtMonto.Text), cmbEstado.Text, tipoDocumento);
            }
            else
            {
                for (int i = 0; i < lista.Count - 1; i++)
                {
                    if (lista[i] == cmbTipoServicio.Text)
                    {
                        tipoServicio = lista2[i].ToString();
                        break;
                    }
                }
                regMovCaja = new CRegMovCaja(txtVendedor.Text, txtCliente.Text, tipoServicio, tipoPago, mtxtFecha.Text, decimal.Parse(mtxtMonto.Text), cmbEstado.Text);
            }

            regMovCaja.Insertar();
            dataGridView1.DataSource = CRegMovCaja.Visualizar();
            limpiar();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtVendedor.Text = "";
            txtCliente.Text = "";
            rbtnDocumento.Checked = false;
            rbtnServicio.Checked = false;
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Enabled = false;
            cmbTipoServicio.Items.Clear();
            cmbTipoServicio.Enabled = false;
            cmbTipoPago.Text = "";
            mtxtFecha.Text = "";
            mtxtMonto.Text = "";
            cmbEstado.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para Eliminar", "Error al Eliminar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al Eliminar");
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];

                if (row.Cells[4].Value.ToString() == "")
                    regMovCaja = new CRegMovCaja(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), decimal.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString(), row.Cells[5].Value.ToString());

                else
                    regMovCaja = new CRegMovCaja(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), decimal.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString());

                regMovCaja.Eliminar();
                dataGridView1.DataSource = CRegMovCaja.Visualizar();
            }
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            string estado;
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Seleccione un elemento para Eliminar", "Error al Eliminar");

            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Seleccione solo un elemento por favor", "Error al Eliminar");
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];

                if(row.Cells[4].Value.ToString()=="")
                    regMovCaja = new CRegMovCaja(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), decimal.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString(), row.Cells[5].Value.ToString());

                else
                    regMovCaja = new CRegMovCaja(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), decimal.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString());

                if (regMovCaja.estado == "Activo")
                    estado = "Inactivo";
                else
                    estado = "Activo";

                CRegMovCaja.Actualizar(regMovCaja, estado);
                dataGridView1.DataSource = CRegMovCaja.Visualizar();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CRegMovCaja.Visualizar($"SELECT * FROM VISTA_REG_MOV_CAJA WHERE {cmbCampo.Text} {cmbCriterio.Text} '{txtValor.Text.SQLInyectionClearString()}'");
        }

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

        private void modalidadesDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmModalidadPago(usuario);
            Hide();
            formulario.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGridView1.Rows.Count < 1 ? CRegMovCaja.Visualizar() : dataGridView1.DataSource;
        }

        private void FrmRegMovCaja_Load(object sender, EventArgs e)
        {
            label1.Text = usuario.nombreUsuario;
            lista3 = new List<string>();
            lista4 = new List<int>();

            data = new DataTable();
            dataManagement = new SqlDataManagement();

            data.Columns.Add("id");
            data.Columns.Add("Descripcion");
            dataManagement.ExecuteCommand("SELECT * FROM TIPO_PAGO WHERE ESTADO = 'Activo'");
            dataManagement.ExecuteReader();

            while (dataManagement.reader.Read())
            {
                data.Rows.Add(dataManagement.reader["ID_TIPO_PAGO"], dataManagement.reader["DESCRIPCION"]);
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                lista3.Add(data.Rows[i].Field<string>("Descripcion"));
                lista4.Add(int.Parse(data.Rows[i].Field<string>("id")));
                cmbTipoPago.Items.Add(lista3[i]);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formulario = new Login();
            formulario.Show();
            Hide();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            formulario = new FrmExportaciones((DataTable)dataGridView1.DataSource, this);
            formulario.Show();
        }
    }
}
