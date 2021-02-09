using GestionCaja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    class CTipoServicio:CTipo
    {
        public CTipoServicio(string descripcion, string estado)
        {
            id = null;
            this.descripcion = descripcion;
            this.estado = estado;
        }
        public CTipoServicio(int id, string descripcion, string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }
    }
}
