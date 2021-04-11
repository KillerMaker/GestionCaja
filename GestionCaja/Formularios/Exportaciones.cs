using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCaja.Formularios
{
    public partial class FrmExportaciones : Form
    {
        private DataTable Datatable;
        private Form Origin;
        private string Header;
        private string Path;
        private string Name;
        private string User;
 
        public FrmExportaciones(DataTable oDt, Form procedencia)
        {
            InitializeComponent();
            this.Datatable = oDt;
            this.Origin = procedencia;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Name = txtNombre.Text;
            Path = txtRuta.Text;


            writeFileHeader("sep=,");
            writeFileLine(Header);

            foreach (DataRow row in Datatable.Rows)
            {
                string linea = "";
                foreach (DataColumn dc in Datatable.Columns)
                {
                    linea += row[dc].ToString() + ",";
                }
                writeFileLine(linea);
            }

            Process.Start(Path + Name + ".csv");

            this.Close();
        }

        private void writeFileLine(string pLine)
        {
            using (System.IO.StreamWriter w = File.AppendText(Path + Name + ".csv"))
            {
                w.WriteLine(pLine);
            }
        }
        private void writeFileHeader(string pLine)
        {
            using (System.IO.StreamWriter w = File.CreateText(Path+Name+".csv"))
            {
                w.WriteLine(pLine);
            }
        }

        private void Exportaciones_Load(object sender, EventArgs e)
        {
            //User Amauris: amaur_pa6bdby
            User = "amaur_pa6bdby";

            if (Origin is FrmEmpleado)
            {
                Header = "Identificador, Nombre, Fecha de Nacimiento, Genero, Cedula, Saldo, Tanda Laboral, Porciento de Comision, Fecha de Ingreso, Estado, Sueldo, Tipo de Cliente, Tipo de Usuario";
                Name = "Empleado-" + DateTime.Now.ToString("dd-MM-yyyy");
                Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Empleado";
            }
            else if (Origin is FrmEstudiante)
            {
                Header = "Identificador, Nombre, Fecha de Nacimiento, Genero, Cedula, Saldo, Carrera, Fecha de Registro, Estado";
                Name = "Estudiante-" + DateTime.Now.ToString("dd-MM-yyyy");
                Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Estudiante";
            }
            else if (Origin is FrmTipoDocumento || Origin is FrmTipoServicio || Origin is FrmTipoPago)
            {
                Header = "Id, Descripcion, Estado";
                if (Origin is FrmTipoDocumento)
                {
                    Name = "Tipo Documento-" + DateTime.Now.ToString("dd-MM-yyyy");
                    Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Tipo Documento";
                }
                else if (Origin is FrmTipoServicio)
                {
                    Name = "Tipo Servicio-" + DateTime.Now.ToString("dd-MM-yyyy");
                    Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Tipo Servicio";
                }
                else
                {
                    Name = "Tipo Pago-" + DateTime.Now.ToString("dd-MM-yyyy");
                    Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Tipo Pago";
                }

            }
            else if (Origin is FrmModalidadPago)
            {
                Header = "Id, Descripcion, Cantidad de Coutas, Estado";
                Name = "Tipo Documento-" + DateTime.Now.ToString("dd-MM-yyyy");
                Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Tipo Documento";
            }
            else if (Origin is FrmRegMovCaja)
            {
                Header = "Id, Nombre Encargado, Nombre Cliente, Id Cliente, Tipo Servicio, Tipo Documento, Tipo Pago, Fecha, Monto, Estado";
                Name = "Registro de Movimientos de Caja-" + DateTime.Now.ToString("dd-MM-yyyy");
                Path = $@"C:\Users\{User}\source\repos\GestionCaja\GestionCaja\Exportaciones\Registro de Movimiento de Caja";
            }

            txtNombre.Text = Name;
            txtRuta.Text = Path;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

