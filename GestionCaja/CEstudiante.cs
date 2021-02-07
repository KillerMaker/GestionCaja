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

        public static void Actualizar(CEstudiante oldPersona, CEstudiante newPersona)
        {
            throw new NotImplementedException();
        }

        public override void Eliminar()
        {
            throw new NotImplementedException();
        }

        public override void Insertar()
        {
            throw new NotImplementedException();
        }
        public new System.Data.DataTable Visualizar(string consulta = "SELECT * FROM VISTA_ESTUDIANTE")
        {
            throw new NotImplementedException();
        }
    }
}
