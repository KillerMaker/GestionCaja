using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GestionCaja.Entidades
{
    class CTipoPago:CTipo
    {
        /*Necesito crear los siguientes objetos en la base de datos:
         
           1: Tabla TIPO_PAGO(ID_TIPO_PAGO INT PK, DESCRIPCION VARCHAR(300), ESTADO VARCHAR(50)).
           2: Stored Procedure INSERTA_TIPO_PAGO(@DESCRIPCION VARCHAR(300), ESTADO VARCHAR(50)).
        */
        public CTipoPago(string descripcion, string estado)
        {
            id = null;
            this.descripcion = descripcion;
            this.estado = estado;
        }
        public CTipoPago(int id, string descripcion, string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public override void Eliminar()
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE TIPO_PAGO SET DESCRIPCION='{descripcion}',ESTADO='{estado}'");
        }

        public override void Insertar()
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"INSERTA_TIPO_PAGO '{descripcion}','{estado}'");
        }
        public static DataTable Visualizar(string consulta = "SELECT * FROM TIPO_PAGO")
        {
            DataTable dataTable = new DataTable();
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand(consulta);

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");
            dataTable.Columns.Add("Estado");

            while (DataManagement.reader.Read())
                dataTable.Rows.Add(DataManagement.reader["ID"], DataManagement.reader["DESCRIPCION"], DataManagement.reader["ESTADO"]);

            return dataTable;
        }
        public static void Actualizar(CTipoPago oldPago, CTipoPago newPago)
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE TIPO_DOCUMENTO SET DESCRIPCION='{newPago.descripcion}',ESTADO='{newPago.estado}' WHERE ID_TIPO_PAGO={oldPago.id}");
        }
    }
}
