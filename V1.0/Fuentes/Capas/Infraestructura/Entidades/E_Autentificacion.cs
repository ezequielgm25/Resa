using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Autentificacion
    {

        //<Summary>
        //Clase  que gestionata la entidad que se llevara a cabo para el inicio de sesion en el sistema 
        //</Summary>

        #region Variables

        private string Usuario;

        private string Contraseña;

        #endregion

        #region Propiedades

        //Propiedad para el Usuario
        public string usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        //Propiedad de  la contraseña
        public String contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }

        //Propiedad para la Contraseña
        #endregion



    }
}
