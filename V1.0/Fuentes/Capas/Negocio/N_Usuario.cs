using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Data;
using Capas.Infraestructura.Entidades;
namespace Capas.Negocio
{
   public class N_Usuario
    {

        //<Summary>
        // Clase de donde se gestionara las iteracciones en la capa de negocio de la entidad usuario
        //</Summary>

        #region Declaraciones 

       private  D_Usuario d_Usuario;

       private  E_Usuario e_Usuario;

        #endregion

        #region Contructor 

        public N_Usuario()
        {
             d_Usuario = new D_Usuario();

             e_Usuario = new E_Usuario();


        }

        #endregion

        #region Obtener Usuario
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {

            e_Usuario = d_Usuario.ObtenerUsuario(ID_Usuario);


            return e_Usuario;
        }

        #endregion



    }
}
