using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Aplicacion
{
    public class ConexionAplicacion
    {

        //<summary>
        //Clase de gestionara de prueba de conexion 
        //</summary>

        #region Propiedades

        private bool enlaceDB;

        public bool EnlaceDB
        {
            get { return enlaceDB; }
            set { enlaceDB = value; }
        }

        private Capas.Data.Conexion Enlace = new Capas.Data.Conexion();

        #endregion
    

        #region Prueba de conexion 


        public void PruebaConexion()
        {

            enlaceDB = Enlace.Conectar();
            
            if(enlaceDB == true)
            {
                Enlace.Desconectar();
            }
             

            
        }


        #endregion






    }
}
