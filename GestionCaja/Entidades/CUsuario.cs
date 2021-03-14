using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
   public class CUsuario
    {
        public readonly int? id;
        public readonly string nombreUsuario;
        public readonly string password;
        public readonly string tipoUsuario;

      public CUsuario(int id, string nombreUsuario,string password,string tipoUsuario)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.tipoUsuario = tipoUsuario;
        }
        public CUsuario(string nombreUsuario, string password, string tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.tipoUsuario = tipoUsuario;
        }
    }
}
