using GestionCaja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public override void Eliminar()
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE TIPO_SERVICIO SET DESCRIPCION='{descripcion}',ESTADO='{estado}'");
        }

        public override void Insertar()
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"INSERTA_TIPO_SERVICIO '{descripcion}','{estado}'");
        }
        public static DataTable Visualizar(string consulta = "SELECT * FROM VISTA_TIPO_SERVICIO")
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
        public static void Actualizar(CTipoServicio oldServicio, CTipoServicio newServicio)
        {
            DataManagement = new SqlDataManagement();
            DataManagement.ExecuteCommand($"UPDATE TIPO_DOCUMENTO SET DESCRIPCION='{newServicio.descripcion}',ESTADO='{newServicio.estado}' WHERE ID_TIPO_SERVICIO={oldServicio.id}");
        }
    }
}
