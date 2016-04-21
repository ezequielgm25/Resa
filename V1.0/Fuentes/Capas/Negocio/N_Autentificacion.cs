//Usings del sistema 
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
        /// <summary>
        /// Constructor de la clase autentificacion en la capa de negocio
        /// </summary>
        public N_Autentificacion()
        {
            // instancias 
            D_Autentificacion = new D_Autentificacion();

            verificacion = 0;

        }

        #endregion

        #region Verificar Usuario
        /// <summary>
        /// Metodo donde se verifica el usuario -- Autentificacion --
        /// </summary>
        /// <param name="E_AutentificacionP"></param>
        /// <returns></returns>
        public int VerificarUsuario(E_Autentificacion E_AutentificacionP)
        {

            //Se ejecuta el metodo y se espera el ID del usuario como retorno
            ID_Usuario = D_Autentificacion.VerificarUsuario(E_AutentificacionP);

            //Retorno de id de usuario 
            return ID_Usuario;
        }


        #endregion

    }
}
