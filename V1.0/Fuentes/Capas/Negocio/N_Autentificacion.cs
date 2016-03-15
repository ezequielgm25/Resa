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
        private bool Autentificacion;

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

        public bool VerificarUsuario(E_Autentificacion E_AutentificacionP)
        {

           verificacion = D_Autentificacion.VerificarUsuario(E_AutentificacionP);

            if(verificacion == 1)
            {
                Autentificacion = true;
            }
            else
            {
                Autentificacion = false;
            }
            
            return Autentificacion;
        }


        #endregion

    }
}
