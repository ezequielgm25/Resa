using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
    public class D_Usuario
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias

        E_Usuario e_usuario = new E_Usuario();

        #endregion


        public E_Usuario ObtenerUsuario()
        {





            return e_usuario;
        }



    }
}
