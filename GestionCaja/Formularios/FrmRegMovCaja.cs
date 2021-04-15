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
using MetroFramework;
using MetroFramework.Forms;

namespace GestionCaja.Formularios
{
    public partial class FrmRegMovCaja : MetroForm
    {
        private Form formulario;
        private CUsuario usuario;
        private CRegMovCaja regMovCaja;
        private DataTable data;
        private SqlDataManagement dataManagement;
        private List<string> listaServicioDocumentoVal;
        private List<int> listaServicioDocumentoKey;
        private List<string> listaTipoPagoVal;
        private List<int> listaTipoPagoKey;

        public FrmRegMovCaja(CUsuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listaServicioDocumentoVal= new List<string>();
            listaServicioDocumentoKey = new List<int>();

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
                    listaServicioDocumentoVal.Add(data.Rows[i].Field<string>("Descripcion"));
                    listaServicioDocumentoKey.Add(int.Parse(data.Rows[i].Field<string>("id")));
                    cmbTipoDocumento.Items.Add(listaServicioDocumentoVal[i]);
                    
                }

            }
                
        }
        private void rbtnServicio_CheckedChanged(object sender, EventArgs e)
        {
            listaServicioDocumentoVal = new List<string>();
            listaServicioDocumentoKey = new List<int>();

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
                    listaServicioDocumentoVal.Add(data.Rows[i].Field<string>("Descripcion"));
                    listaServicioDocumentoKey.Add(int.Parse(data.Rows[i].Field<string>("id")));
                    cmbTipoServicio.Items.Add(listaServicioDocumentoVal[i]);
                }
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string tipoPago="";
            string tipoServicio="";
            string tipoDocumento="";

            string[] vendedor = new string[2];
            vendedor = txtVendedor.Text.Split(" ".ToCharArray());

            string[] cliente = new string[2];
            cliente = txtCliente.Text.Split(" ".ToCharArray());

            for (int i=0;i<=listaTipoPagoVal.Count-1;i++)
            {
                if (listaTipoPagoVal[i] == cmbTipoPago.Text)
                {
                    tipoPago = listaTipoPagoKey[i].ToString();
                    break;
                }
            }
            if (rbtnDocumento.Checked == true)
            {
                for (int i = 0; i <= listaServicioDocumentoVal.Count - 1; i++)
                {
                    if (listaServicioDocumentoVal[i] == cmbTipoDocumento.Text)
                    {
                        tipoDocumento = listaServicioDocumentoKey[i].ToString();
                        break;
                    }
                }
                

                regMovCaja = new CRegMovCaja(vendedor[0], cliente[0], tipoPago, mtxtFecha.Text, decimal.Parse(mtxtMonto.Text.Replace(",", "").Replace("RD$", "")), cmbEstado.Text, tipoDocumento);
            }
            else
            {
                for (int i = 0; i <= listaServicioDocumentoVal.Count - 1; i++)
                {
                    if (listaServicioDocumentoVal[i] == cmbTipoServicio.Text)
                    {
                        tipoServicio = listaServicioDocumentoKey[i].ToString();
                        break;
                    }
                }
                regMovCaja = new CRegMovCaja(vendedor[0], cliente[0], tipoServicio, tipoPago, mtxtFecha.Text, decimal.Parse(mtxtMonto.Text.Replace(",", "").Replace("RD$", "")), cmbEstado.Text);
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
            dataManagement = new SqlDataManagement();
            
            // Llenando el comboBox Vendedor
            dataManagement.ExecuteCommand("SELECT IDENTIFICADOR, NOMBRE FROM VISTA_EMPLEADO");
            dataManagement.ExecuteReader();

            while (dataManagement.reader.Read())
            {
                txtVendedor.Items.Add(dataManagement.reader["IDENTIFICADOR"].ToString() + "  " + dataManagement.reader["NOMBRE"]);
            }

            dataManagement.connection.Close();
            //Llenando el comboBox Cliente 
            dataManagement.ExecuteCommand("SELECT ID_PERSONA, NOMBRE FROM PERSONA");
            dataManagement.ExecuteReader();

            while (dataManagement.reader.Read())
            {
                txtCliente.Items.Add(dataManagement.reader["ID_PERSONA"].ToString() + "  " + dataManagement.reader["NOMBRE"]);
            }

            dataManagement.connection.Close();

            listaTipoPagoVal = new List<string>();
            listaTipoPagoKey = new List<int>();
            data = new DataTable();

            data.Columns.Add("id");
            data.Columns.Add("Descripcion");
            dataManagement.ExecuteCommand("SELECT * FROM TIPO_PAGO WHERE ESTADO = 'Activo'");
            dataManagement.ExecuteReader();

            while (dataManagement.reader.Read())
            {
                data.Rows.Add(dataManagement.reader["ID_TIPO_PAGO"], dataManagement.reader["DESCRIPCION"]);
            }
            dataManagement.connection.Close();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                listaTipoPagoVal.Add(data.Rows[i].Field<string>("Descripcion"));
                listaTipoPagoKey.Add(int.Parse(data.Rows[i].Field<string>("id")));
                cmbTipoPago.Items.Add(listaTipoPagoVal[i]);
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

        private void movimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulario = new FrmRegMovCaja(usuario);
            formulario.Show();
            this.Hide();
        }
    }
}
//GG WP
