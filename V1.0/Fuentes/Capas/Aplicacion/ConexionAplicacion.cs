
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

        /// <summary>
        /// Metodo que probara la conexion a la base de datos 
        /// </summary>
        public void PruebaConexion()
        {

            //Prueba la conexionAplicacion
            enlaceDB = Enlace.Conectar();
            //Si es verdadera cierra la misma 
            if(enlaceDB == true)
            {
                Enlace.Desconectar();
            }
             

            
        }


        #endregion

    }
}
