using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja
{
    public class CRegMovCaja
    {
        public readonly int idEmpleado;
        public readonly int idPersona;
        public readonly string servicio;
        public readonly string tipoDocumento;
        public readonly string formaPago;
        public readonly string fechaMovimiento;
        public readonly decimal monto;
        public readonly string estado;

        public CRegMovCaja(int idEmpleado,int idPersona,string servicio, string tipoDocumento,string formaPago,string fechaMovimiento,decimal monto,string estado)
        {
            this.idEmpleado = idEmpleado;
            this.idPersona = idPersona;
            this.servicio = servicio;
            this.tipoDocumento = tipoDocumento;
            this.formaPago = formaPago;
            this.fechaMovimiento = fechaMovimiento;
            this.monto = monto;
            this.estado = estado;
        }
    }
}
