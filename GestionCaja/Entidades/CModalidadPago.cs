using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionCaja.Utilidades;

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

        public static DataTable Visualizar(string consulta="SELECT * FROM MODALIDAD_PAGO")
        {
            DataTable dataTable = new DataTable()
                ;
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand(consulta);
            DataManagement.ExecuteReader();

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");
            dataTable.Columns.Add("Numero de Cuotas");
            dataTable.Columns.Add("Estado");

            while (DataManagement.reader.Read())
                dataTable.Rows.Add(DataManagement.reader["ID_TIPO_DOCUMENTO"], DataManagement.reader["DESCRIPCION"],DataManagement.reader["CANTIDAD_CUOTAS"], DataManagement.reader["ESTADO"]);

            return dataTable;
        }

        public static void Actualizar(CModalidadPago newModalidad, CModalidadPago oldModalidad)
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE MODALIDAD_PAGO SET DESCRIPCION='{newModalidad.descripcion}',CANTIDAD_CUOTAS={newModalidad.numeroCuota},ESTADO='{newModalidad.estado}' WHERE ID_TIPO_DOCUMENTO={oldModalidad.id}");
        }
        public override void Eliminar()
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE MODALIDAD_PAGO SET ESTADO='Inactivo' WHERE ID_TIPO_DOCUMENTO={id.Value}");
        }

        public override void Insertar()
        {
            DataManagement = new SqlDataManagement();
<<<<<<< HEAD
            DataManagement.ExecuteCommand($"INSERTAR_MODALIDAD_PAGO '{descripcion}', '{numeroCuota}', '{estado}'");
        }

        public static DataTable Visualizar(string consulta = "SELECT * FROM MODALIDAD_PAGO")
        {
            DataTable dataTable = new DataTable()
                ;
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand(consulta);
            DataManagement.ExecuteReader();

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Estado");

            while (DataManagement.reader.Read())
                dataTable.Rows.Add(DataManagement.reader["ID_TIPO_DOCUMENTO"], DataManagement.reader["DESCRIPCION"], DataManagement.reader["CANTIDAD_CUOTAS"] ,DataManagement.reader["ESTADO"]);

            return dataTable;
        }

        public static void Actualizar(CModalidadPago oldModalidad, CModalidadPago newModalidad)
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE MODALIDAD_PAGO SET DESCRIPCION='{newModalidad.descripcion}', CANTIDAD_CUOTAS='{newModalidad.numeroCuota}' ,ESTADO='{newModalidad.estado}' WHERE ID_TIPO_DOCUMENTO={oldModalidad.id}");
=======
            DataManagement.ExecuteCommand($"INSERTAR_MODALIDAD_PAGO '{descripcion}',{numeroCuota},'{estado}'");
>>>>>>> 599639ed3d8b802140b35a2c5d95a408cce41781
        }
    }
}
