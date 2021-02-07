using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace GestionCaja
{
    //Clase CEmpleado la cual hereda de la clase CPersona
   public class CEmpleado:CPersona
    {
        //Atributos unicos de CEmpleado
        public readonly string tandaLabor;
        public readonly decimal porcientoComision;
        public readonly string fechaIngreso;
        public readonly string estado;
        public readonly decimal sueldo;

        //Constructor de inicializacion de datos de CEmpleado, favor usar siempre este onstructor 
        public CEmpleado(string nombre, string fecha, string genero, string cedula,string tandaLabor,decimal porcientoComision,string fechaIngreso,string estado, decimal sueldo)
        :base(nombre,fecha,genero,cedula)
        {
            this.id = null;
            this.tandaLabor = tandaLabor;
            this.porcientoComision = porcientoComision;
            this.fechaIngreso = fechaIngreso;
            this.estado = estado;
            this.sueldo = sueldo;
        }

        public CEmpleado(int id,string nombre, string fecha, string genero, string cedula, string tandaLabor, decimal porcientoComision, string fechaIngreso, string estado, decimal sueldo)
       : base(nombre, fecha, genero, cedula)
        {
            this.id = id;
            this.tandaLabor = tandaLabor;
            this.porcientoComision = porcientoComision;
            this.fechaIngreso = fechaIngreso;
            this.estado = estado;
            this.sueldo = sueldo;
        }

        public override void Insertar()
        {
            dataManagement = new SqlDataManagement();
            dataManagement.ExecuteCommand("INSERTAR_EMPLEADO '" + nombre + "','" +fecha + "','" +genero + "','" +cedula + "','" +tandaLabor + "'," +porcientoComision + ",'" + fechaIngreso + "','" + sueldo + "','" +estado + "'");
        }

        public static void Actualizar(CEmpleado oldPersona, CEmpleado newPersona)
        {
            dataManagement = new SqlDataManagement();
            CPersona.Actualizar(oldPersona, newPersona);
            dataManagement.ExecuteCommand("UPDATE EMPLEADO SET TANDA_LABOR='"+newPersona.tandaLabor+"',PORCIENTO_COMISION="+(newPersona.porcientoComision/100)+",SUELDO="+newPersona.sueldo+"WHERE IDENTIFICADOR="+oldPersona.id.Value);
           
        }

        public override void Eliminar()
        {
            //lalalalala
            dataManagement = new SqlDataManagement();
            dataManagement.ExecuteCommand("UPDATE EMPLEADO SET ESTADO='INACTIVO' WHERE INDENTIFICADOR="+id.Value);
        }

        public static DataTable Visualizar(string consulta= "SELECT * FROM VISTA_EMPLEADO")
        {
            dataManagement = new SqlDataManagement();
            DataTable dataTable= new DataTable();

            dataManagement.ExecuteCommand(consulta);
            dataManagement.ExecuteReader();

            dataTable.Columns.Add("Identificador");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Fecha de nacimiento");
            dataTable.Columns.Add("Genero");
            dataTable.Columns.Add("Cedula");
            dataTable.Columns.Add("Tanda Laboral");
            dataTable.Columns.Add("Porcetaje de comision");
            dataTable.Columns.Add("Fecha de ingreso");
            dataTable.Columns.Add("Estado");
            dataTable.Columns.Add("Sueldo");
            dataTable.Columns.Add("Tipo de cliente");
            

            while (dataManagement.reader.Read())
            {
                dataTable.Rows.Add(dataManagement.reader["IDENTIFICADOR"], dataManagement.reader["NOMBRE"], dataManagement.reader["FECHA_NACIMIENTO"], dataManagement.reader["GENERO"], dataManagement.reader["CEDULA"], dataManagement.reader["TANDA_LABOR"], dataManagement.reader["PORCIENTO_COMISION"],dataManagement.reader["FECHA_INGRESO"],dataManagement.reader["ESTADO"], dataManagement.reader["SUELDO"], dataManagement.reader["TIPO_CLIENTE"]);
            }

            return dataTable;
                
        }
    }
}
