using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCaja.Utilidades;

namespace GestionCaja.Entidades
{
    class RegMovCaja
    {
        public readonly int? id;
        public readonly CEmpleado empleado;
        public readonly CPersona cliente;
        public readonly int? idTipoServicio;
        public readonly int? idTipoDocumento;
        public readonly int idTipoPago;
        public readonly string fecha;
        public readonly decimal monto;
        public readonly string estado;

        static protected SqlDataManagement dataManagement;

        //Constructor que utiliza tipo de servicio con procedencia de la BD
        public RegMovCaja(int id,CEmpleado empleado, CPersona cliente, int idTipoServicio, int idTipoPago, string fecha, decimal monto, string estado)
        {
            this.id = id;
            this.empleado = empleado;
            this.cliente = cliente;
            this.idTipoServicio = idTipoServicio;
            this.idTipoPago = idTipoPago;
            this.fecha = fecha;
            this.monto = monto;
            this.estado = estado;
        }
        //Constructor que utiliza tipo de servicio con direccion a la BD
        public RegMovCaja(CEmpleado empleado,CPersona cliente,int idTipoServicio, int idTipoPago, string fecha,decimal monto,string estado)
        {
            this.empleado = empleado;
            this.cliente = cliente;
            this.idTipoServicio = idTipoServicio;
            this.idTipoPago = idTipoPago;
            this.fecha = fecha;
            this.monto = monto;
            this.estado = estado;
        }

        public void x(int? i)
        {
            Console.WriteLine(i);
        }
          
        public RegMovCaja(int id,CEmpleado empleado, CPersona cliente, int idTipoPago, string fecha, decimal monto, string estado, int idTipoDocumento)
        {
            this.id = id;
            this.empleado = empleado;
            this.cliente = cliente;
            this.idTipoDocumento = idTipoDocumento;
            this.idTipoPago = idTipoPago;
            this.fecha = fecha;
            this.monto = monto;
            this.estado = estado;

        }
        public RegMovCaja(CEmpleado empleado, CPersona cliente, int idTipoPago, string fecha, decimal monto, string estado, int idTipoDocumento)
        {
            this.empleado = empleado;
            this.cliente = cliente;
            this.idTipoDocumento = idTipoDocumento;
            this.idTipoPago = idTipoPago;
            this.fecha = fecha;
            this.monto = monto;
            this.estado = estado;
        }
        public void Insertar()
        {
            dataManagement = new SqlDataManagement();

            if(idTipoServicio.HasValue)
                dataManagement.ExecuteCommand($"EXEC INSERTAR_REG_MOV_CAJA {empleado.id}, {cliente.id}, {idTipoServicio.Value}, {idTipoPago}, {fecha}, {monto}, {estado}");
            else
                dataManagement.ExecuteCommand($"EXEC INSERTAR_REG_MOV_CAJA {empleado.id}, {cliente.id}, {idTipoDocumento.Value}, {idTipoPago}, {fecha}, {monto}, {estado}");
        }
        public void Eliminar()
        {
            dataManagement = new SqlDataManagement();

            dataManagement.ExecuteCommand("");
        }
    }
}
