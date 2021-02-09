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
        protected string descripcion;
        protected string estado;
        static protected SqlDataManagement DataManagement;

        public abstract void Insertar();
        public abstract void Eliminar();
    }

}
