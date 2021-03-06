using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionCaja.Entidades;


namespace GestionCaja
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private SqlDataManagement dataManagement = new SqlDataManagement();
        private Form1 formulario;
        private CUsuario usuario;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataManagement.ExecuteCommand($"SELECT TOP 1 * FROM USUARIO WHERE NOMBRE_USUARIO='{textBox1.Text}' AND PASSWORD='{textBox2.Text}'");
            dataManagement.ExecuteReader();

            bool s=false;
            while(dataManagement.reader.Read())
            {
                if (dataManagement.reader.HasRows)
                {
                    usuario = new CUsuario(int.Parse(dataManagement.reader["ID_USUARIO"].ToString()), dataManagement.reader["NOMBRE_USUARIO"].ToString(), dataManagement.reader["PASSWORD"].ToString(), dataManagement.reader["TIPO_USUARIO"].ToString());
                    formulario = new Form1(usuario);
                    formulario.Show();
                    s = true;
                    Hide();
                }
            }

            dataManagement.connection.Close();

            if(s==false)
                MessageBox.Show("Usuario no valido", "Error en Login");
        }
    }
}
