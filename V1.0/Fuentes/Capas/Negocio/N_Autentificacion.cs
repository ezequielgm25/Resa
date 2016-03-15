using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Negocio
{
     public class N_Autentificacion
    {
        //<Summary>
        //Clase logica que retornara a la precentacion si el logeo es exitoso
        //</Summary>

        #region Variables
        private int ID_Usuario;

        private int verificacion = 0;
        #endregion

        #region instancias

        private D_Autentificacion D_Autentificacion;

        #endregion

        #region Constructor 
        public N_Autentificacion()
        {
            D_Autentificacion = new D_Autentificacion();

            verificacion = 0;

        }

        #endregion

        #region Verificar Usuario

        public int  VerificarUsuario(E_Autentificacion E_AutentificacionP)
        {

            ID_Usuario = D_Autentificacion.VerificarUsuario(E_AutentificacionP);
            
            return ID_Usuario;
        }


        #endregion

    }
}
