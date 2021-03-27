using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    class CModalidadPago : CTipo
    {
        public readonly int numeroCuota;

        public CModalidadPago(int id, string descripcion,int numeroCuota,string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.numeroCuota = numeroCuota;
            this.estado = estado;
        }
        public CModalidadPago(string descripcion, int numeroCuota, string estado)
        {
            id = null;
            this.descripcion = descripcion;
            this.numeroCuota = numeroCuota;
            this.estado = estado;
        }
        public override void Eliminar()
        {
            throw new NotImplementedException();
        }

        public override void Insertar()
        {
            throw new NotImplementedException();
        }
    }
}
