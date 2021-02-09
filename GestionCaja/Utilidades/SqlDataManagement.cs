using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionCaja
{
    //Clase para manejo de la base de datos
   public class SqlDataManagement
    {
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }

        //Coneccion de Guillermo: "Data Source= HP_840_DE_GUILL\\SQLEXPRESS; Initial Catalog = GESTION_CAJAS; Integrated Security = True"
        public SqlDataManagement(string con= "Data Source= HP_840_DE_GUILL\\SQLEXPRESS; Initial Catalog = GESTION_CAJAS; Integrated Security = True")
        {
            try
            {
                connection = new SqlConnection(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al conectarse con la base de datos");
            }

        }
        public void ExecuteCommand(string com)
        {
            command = new SqlCommand(com, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error en la consulta de datos");
            }
        }
        public SqlDataReader ExecuteReader()
        {
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                command= new SqlCommand("");
                return reader;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al leer datos de la base de datos");
                throw new NotImplementedException();
            }
        }
        
    }
}
