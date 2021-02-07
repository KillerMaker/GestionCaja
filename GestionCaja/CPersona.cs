using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja
{
    //Clase abstracta padre de CEmpleado y CEstudiante
    public abstract class CPersona
    {
        /*Campo nullable int, el cual tendra un valor distinto de null unicamente al momento de actualizar
         Cuando se tenga que instanciar el objeto de tipo CPersona oldPersona*/
        public int? id { get; protected set; }
        
        //Atributos de Persona.
        public readonly string nombre;
        public readonly string fecha;
        public readonly string genero;
        public readonly string cedula;

        // Variable global estatica utilizada para comunicarce con la base de datos.
        static protected SqlDataManagement dataManagement;

        //Constructor de CPersona donde se inicializan los atributos de la misma.
        public CPersona(string nombre, string fecha,string genero,string cedula)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.genero = genero;
            this.cedula = cedula;
        }

        //Metodo abstracto para Insertar CPersona's en la base de datos
        public abstract void Insertar();

        //Metodo abstracto para Eliminar CPersona's(modificar el campo estado a "Inactivo") en la base de datos.
        public abstract void Eliminar();

        /*Metodo estatico Actualizar el cual utiliza dos parametros de tipo CPersona oldPersona y newPersona
         oldPersona debera tomar los datos actuales de registro que se desea actualizar, mientras que new persona los nuevos*/ 
        public static void Actualizar(CPersona oldPersona, CPersona newPersona)
        {
            dataManagement = new SqlDataManagement();
            dataManagement.ExecuteCommand("UPDATE PERSONA SET NOMBRE='" + newPersona.nombre + "',GENERO='" + newPersona.genero + "' FROM PERSONA P INNER JOIN EMPLEADO E ON E.ID_PERSONA=P.ID_PERSONA WHERE IDENTIFICADOR="+oldPersona.id);
        }
    }
}
