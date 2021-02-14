using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    //Clase CEstudiante hereda de CPersona
   public class CEstudiante:CPersona
    {
        //Atributos unicos de CEmpleado
        public readonly string carrera;
        public readonly string fechaRegistro;
        public readonly string estado;


        /*Constructor CEmpleado, favor usar este constructor para crear el objeto con destino a la base de datos*/
        public CEstudiante(string nombre, string fecha, string genero, string cedula,string carrera,string fechaRegistro,string estado)
        :base(nombre,fecha,genero,cedula)
        {
            this.carrera = carrera;
            this.fechaRegistro = fechaRegistro;
            this.estado = estado;
        }


        /*Constructor CPersona, favor usar este constructor al crear el objeto con informcacion proveniente de la
         base de datos:la diferencia con el constructor anterior es que este recive un argumento mas (int id)
         el cual debe llenarse con el campo ["IDENTIFICADOR"] de la base de datos.*/
        public CEstudiante(int id,string nombre, string fecha, string genero, string cedula, string carrera, string fechaRegistro, string estado)
        : base(nombre, fecha, genero, cedula)
        {
            this.id = id;
            this.carrera = carrera;
            this.fechaRegistro = fechaRegistro;
            this.estado = estado;
        }


        //Sobrescribe el metodo abstracto Insertar() de CPersona y lo implementa
        public override void Insertar()
        {
            dataManagement = new SqlDataManagement();

            //Ejecuta el Stored Procedure["INSERTAR_ESTUDIANTE"]
            dataManagement.ExecuteCommand($"INSERTAR_ESTUDIANTE '{nombre}','{fecha}','{genero}','{cedula}','{carrera}','{fechaRegistro}','{estado}'");
        }


        //Metodo Actualizar(CPersona oldPersona, CPersona newPersona)
        //Como CPersona es hija de CPersona es posible utilizar CPersona como tipo para los parametros
        public static void Actualizar(CEstudiante oldPersona, CEstudiante newPersona)
        {
            dataManagement = new SqlDataManagement();
            CPersona.Actualizar(oldPersona, newPersona);//Ejecuta la version de Actualizar de CPersona

            //Realiza un Update a la tabla empleado insertando los datos de newPersona donde el campo IDENTIFICADOR
            //sea igual a oldPersona.id.Value
            dataManagement.ExecuteCommand($"UPDATE ESTUDIANTE SET CARRERA='{newPersona.carrera}', ESTADO='{newPersona.estado}' WHERE IDENTIFICADOR={oldPersona.id}");

        }


        //Sobrescribe el metodo abstracto Eliminar() de CPersona y lo implementa
        public override void Eliminar()
        {
            dataManagement = new SqlDataManagement();

            //Actualiza a inactivo el campo ESTADO en la tabla EMPLEADO con tal de no borrar datos.
            dataManagement.ExecuteCommand($"UPDATE ESTUDIANTE SET ESTADO='Inactivo' WHERE IDENTIFICADOR={id.Value}");
        }


        //Metodo Visualizar(string Consulta) utiliza un valor por defecto en el argumento consulta
        //con tal de repetir el mismo valor muchas veces por ende siempre que se utilice Visualizar()
        //sin argumentos consulta sera igual a "SELECT * FROM VISTA_PERSONA"
        public static DataTable Visualizar(string consulta = "SELECT * FROM VISTA_ESTUDIANTE")
        {
            dataManagement = new SqlDataManagement();
            DataTable dataTable = new DataTable();

            dataManagement.ExecuteCommand(consulta);
            dataManagement.ExecuteReader();

            //Definicion de las columnas
            dataTable.Columns.Add("Identificador");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Fecha de nacimiento");
            dataTable.Columns.Add("Genero");
            dataTable.Columns.Add("Cedula");
            dataTable.Columns.Add("Carrera");
            dataTable.Columns.Add("Fecha de registro");
            dataTable.Columns.Add("Estado");

            //Lectura de los registros en la base e datos
            while (dataManagement.reader.Read())
                dataTable.Rows.Add(dataManagement.reader["IDENTIFICADOR"], dataManagement.reader["NOMBRE"], dataManagement.reader["FECHA_NACIMIENTO"], dataManagement.reader["GENERO"], dataManagement.reader["CEDULA"], dataManagement.reader["CARRERA"], dataManagement.reader["FECHA_REGISTRO"], dataManagement.reader["ESTADO"]);

            return dataTable;
        }
    }
}
