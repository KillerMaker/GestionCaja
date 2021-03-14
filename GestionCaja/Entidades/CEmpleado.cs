using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace GestionCaja.Entidades
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
        public readonly string tipoUsuario;


        /*Constructor CEmpleado, favor usar este constructor para crear el objeto con destino a la base de datos*/
        public CEmpleado(string nombre, string fecha, string genero, string cedula,string tandaLabor,decimal porcientoComision,string fechaIngreso,string estado, decimal sueldo,string tipoUsuario)
        :base(nombre,fecha,genero,cedula)//Utiliza el constructor de la clase padre CPersona
        {
            this.id = null;
            this.tandaLabor = tandaLabor;
            this.porcientoComision = porcientoComision;
            this.fechaIngreso = fechaIngreso;
            this.estado = estado;
            this.sueldo = sueldo;
            this.tipoUsuario = tipoUsuario;
        }


        /*Constructor CEmpleado, favor usar este constructor al crear el objeto con informcacion proveniente de la
         base de datos:la diferencia con el constructor anterior es que este recive un argumento mas (int id)
         el cual debe llenarse con el campo ["IDENTIFICADOR"] de la base de datos.*/
        public CEmpleado(int id,string nombre, string fecha, string genero, string cedula, string tandaLabor, decimal porcientoComision, string fechaIngreso, string estado, decimal sueldo,string tipoUsuario)
       : base(nombre, fecha, genero, cedula)
        {
            this.id = id;
            this.tandaLabor = tandaLabor;
            this.porcientoComision = porcientoComision;
            this.fechaIngreso = fechaIngreso;
            this.estado = estado;
            this.sueldo = sueldo;
            this.tipoUsuario = tipoUsuario;
        }


        //Sobrescribe el metodo abstracto Insertar() de CPersona y lo implementa
        public override void Insertar()
        {
            dataManagement = new SqlDataManagement();

            //Ejecuta el Stored Procedure ["INSERTAR_EMPLEADO"]
            dataManagement.ExecuteCommand("INSERTAR_EMPLEADO '" + nombre + "','" +fecha + "','" +genero + "','" +cedula + "','" +tandaLabor + "'," +porcientoComision + ",'" + fechaIngreso + "','" + sueldo + "','" +tipoUsuario+"','"+estado + "'");
        }


        //Metodo Actualizar(CPersona oldPersona, CPersona newPersona)
        //Como CEmpleado es hija de CPersona es posible utilizar CEmpleado como tipo para los parametros
        public static void Actualizar(CEmpleado oldPersona, CEmpleado newPersona)
        {
            dataManagement = new SqlDataManagement();
            CPersona.Actualizar(oldPersona, newPersona);//Ejecuta la version de Actualizar de CPersona

            //Realiza un Update a la tabla empleado insertando los datos de newPersona donde el campo IDENTIFICADOR
            //sea igual a oldPersona.id.Value
            dataManagement.ExecuteCommand(@"UPDATE EMPLEADO SET TANDA_LABOR='"+newPersona.tandaLabor+"',PORCIENTO_COMISION="+(newPersona.porcientoComision/100)+",SUELDO="+newPersona.sueldo+",ESTADO='"+newPersona.estado+"' WHERE IDENTIFICADOR="+oldPersona.id.Value
                                         +" UPDATE USUARIO SET TIPO_USUARIO ='"+newPersona.tipoUsuario+"' WHERE ID_EMPLEADO="+oldPersona.id);
           
        }


        //Sobrescribe el metodo abstracto Eliminar() de CPersona y lo implementa
        public override void Eliminar()
        {
            dataManagement = new SqlDataManagement();

            //Actualiza a inactivo el campo ESTADO en la tabla EMPLEADO con tal de no borrar datos.
            dataManagement.ExecuteCommand("UPDATE EMPLEADO SET ESTADO='Inactivo' WHERE IDENTIFICADOR=" + id.Value);
        }


        //Metodo Visualizar(string Consulta) utiliza un valor por defecto en el argumento consulta
        //con tal de repetir el mismo valor muchas veces por ende siempre que se utilice Visualizar()
        //sin argumentos consulta sera igual a "SELECT * FROM VISTA_EMPLEADO"
        public static DataTable Visualizar(string consulta= "SELECT * FROM VISTA_EMPLEADO E INNER JOIN USUARIO U ON U.ID_EMPLEADO=E.IDENTIFICADOR")
        {
            dataManagement = new SqlDataManagement();
            DataTable dataTable= new DataTable();

            dataManagement.ExecuteCommand(consulta);
            dataManagement.ExecuteReader();

            //Definicion de las columnas
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
            dataTable.Columns.Add("Tipo de Usuario");

            try
            {
                while (dataManagement.reader.Read())
                    dataTable.Rows.Add(dataManagement.reader["IDENTIFICADOR"], dataManagement.reader["NOMBRE"], dataManagement.reader["FECHA_NACIMIENTO"], dataManagement.reader["GENERO"], dataManagement.reader["CEDULA"], dataManagement.reader["TANDA_LABOR"], dataManagement.reader["PORCIENTO_COMISION"], dataManagement.reader["FECHA_INGRESO"], dataManagement.reader["ESTADO"], dataManagement.reader["SUELDO"], dataManagement.reader["TIPO_CLIENTE"],dataManagement.reader["TIPO_USUARIO"]);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //Lectura de los registros en la base e datos

            return dataTable;
                
        }
    }
}
