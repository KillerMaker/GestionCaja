using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    abstract class CTipo
    {
        protected int? id;
        public string descripcion { get; protected set; }
        public string estado { get; protected set;}
        static protected SqlDataManagement DataManagement;

        public abstract void Insertar();
        public abstract void Eliminar();
    }

}
