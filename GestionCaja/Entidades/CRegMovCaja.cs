using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCaja.Utilidades;
using System.Data;

namespace GestionCaja.Entidades
{
    class CRegMovCaja
    {
        public readonly int? id;
        public readonly string empleado;
        public readonly string cliente;
        public readonly string idTipoServicio;
        public readonly string idTipoDocumento;
        public readonly string idTipoPago;
        public readonly string fecha;
        public readonly decimal monto;
        public readonly string estado;


        static protected SqlDataManagement dataManagement;

        //Constructor que utiliza tipo de servicio con Origin de la BD
        public CRegMovCaja(int? id, string empleado, string cliente, string idTipoServicio, string idTipoPago, string fecha, decimal monto, string estado)
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
        public CRegMovCaja(string empleado, string cliente, string idTipoServicio, string idTipoPago, string fecha, decimal monto, string estado)
        {
            this.empleado = empleado;
            this.cliente = cliente;
            this.idTipoServicio = idTipoServicio;
            this.idTipoPago = idTipoPago;
            this.fecha = fecha;
            this.monto = monto;
            this.estado = estado;
        }


        //Constructor que utiliza tipo de documento con Origin de la BD
        public CRegMovCaja(int id, string empleado, string cliente, string idTipoPago, string fecha, decimal monto, string estado, string idTipoDocumento)
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
        //Constructor que utiliza tipo de documento con direccion a la BD
        public CRegMovCaja(string empleado, string cliente, string idTipoPago, string fecha, decimal monto, string estado, string idTipoDocumento)
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

            if(idTipoServicio!=null)
                dataManagement.ExecuteCommand($"EXEC INSERTAR_REG_MOV_CAJA {empleado}, {cliente}, {idTipoServicio}, null, {idTipoPago}, '{fecha}', {monto}, '{estado}'");
            else
                dataManagement.ExecuteCommand($"EXEC INSERTAR_REG_MOV_CAJA {empleado}, {cliente}, null, {idTipoDocumento}, {idTipoPago}, '{fecha}', {monto}, '{estado}'");
        }
        public void Eliminar()
        {
            dataManagement = new SqlDataManagement();

            dataManagement.ExecuteCommand($"UPDATE REG_MOV_CAJA SET ESTADO_REG_MOV_CAJA ='Inactivo' WHERE ID_REG_MOV_CAJA ={id}");
        }
        public static DataTable Visualizar(string consulta="SELECT * FROM VISTA_REG_MOV_CAJA")
        {
            DataTable dataTable = new DataTable();
            dataManagement = new SqlDataManagement();

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Nombre Encargado");
            dataTable.Columns.Add("Nombre Cliente");
            dataTable.Columns.Add("ID Cliente");
            dataTable.Columns.Add("Tipo Servicio");
            dataTable.Columns.Add("Tipo Documento");
            dataTable.Columns.Add("Tipo Pago");
            dataTable.Columns.Add("Fecha");
            dataTable.Columns.Add("Monto");
            dataTable.Columns.Add("Estado");

            dataManagement.ExecuteCommand(consulta);
            dataManagement.ExecuteReader();

            while(dataManagement.reader.Read())
            {
                dataTable.Rows.Add(dataManagement.reader["ID_REG_MOV_CAJA"], dataManagement.reader["NOMBRE ENCARGADO"], dataManagement.reader["NOMBRE CLIENTE"], dataManagement.reader["ID_CLIENTE"], dataManagement.reader["TIPO DE SERVICIO"], dataManagement.reader["TIPO DE DOCUMENTO"], dataManagement.reader["TIPO DE PAGO"], dataManagement.reader["FECHA_REG_MOV_CAJA"], dataManagement.reader["MONTO_REG_MOV_CAJA"], dataManagement.reader["ESTADO_REG_MOV_CAJA"]);
            }
            return dataTable;
        }
        public static void Actualizar(CRegMovCaja regMovCaja, string estado)
        {
            dataManagement = new SqlDataManagement();

            dataManagement.ExecuteCommand($@"UPDATE REG_MOV_CAJA SET ESTADO_REG_MOV_CAJA = '{estado}' WHERE ID_REG_MOV_CAJA = {regMovCaja.id}"); 
        }
    }
}
