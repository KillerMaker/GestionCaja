using GestionCaja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    class CTipoDocumento:CTipo
    {

        public CTipoDocumento(string descripcion, string estado)
        {
            id = null;
            this.descripcion = descripcion;
            this.estado = estado;
        }
        public CTipoDocumento(int id, string descripcion, string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }
    }
}
