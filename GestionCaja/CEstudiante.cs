using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja
{
   public class CEstudiante:CPersona
    {
        public readonly string carrera;
        public readonly string fechaRegistro;
        public readonly string estado;

        public CEstudiante(string nombre, string fecha, string genero, string cedula,string carrera,string fechaRegistro,string estado)
        :base(nombre,fecha,genero,cedula)
        {
            this.carrera = carrera;
            this.fechaRegistro = fechaRegistro;
            this.estado = estado;
        }
        public CEstudiante(int id,string nombre, string fecha, string genero, string cedula, string carrera, string fechaRegistro, string estado)
        : base(nombre, fecha, genero, cedula)
        {
            this.id = id;
            this.carrera = carrera;
            this.fechaRegistro = fechaRegistro;
            this.estado = estado;
        }

        public override void Insertar()
        {
            dataManagement = new SqlDataManagement();

            //Ejecuta el Stored Procedure ["INSERTAR_ESTUDIANTE"]
            //dataManagement.ExecuteCommand("INSERTAR_EMPLEADO '" + nombre + "','" + fecha + "','" + genero + "','" + cedula + "','" + tandaLabor + "'," + porcientoComision + ",'" + fechaIngreso + "','" + sueldo + "','" + estado + "'");
        }

        public static void Actualizar(CEstudiante oldPersona, CEstudiante newPersona)
        {
            throw new NotImplementedException();
        }

        public override void Eliminar()
        {
            throw new NotImplementedException();
        }

        public  DataTable Visualizar(string consulta = "SELECT * FROM VISTA_ESTUDIANTE")
        {
            throw new NotImplementedException();
        }
    }
}
