//Using 
using System.Data.SqlClient;
//Using de las capas
using Capas.Aplicacion;

namespace Capas.Data
{
    public class Conexion
    {
        //<summary>
        //Clase que gestionara la apertura y la desconexion con la base de datos 
        //</summary>

        #region Propiedades

        //Instancia de la clase de xml manager  
        private Capas.Aplicacion.XML_Manager XmlFile;

        //Conexion Que extraera El String Del XMl  AppConfig.XML

        private  SqlConnection ResaConexion;


        //Variable
        private bool Brecha;

        //Propiedades
        public bool brecha
        {
            get { return Brecha; }
            set { Brecha = value; }


        }

        public SqlConnection resaconexion
        {
            get { return ResaConexion; }
            set { ResaConexion = value; }

        }

        #endregion

        #region Contructor sin parametros
        /// <summary>
        /// Constructor de Conexion 
        /// </summary>
        public Conexion()
        {
            //Xml File  instanciacion 
            XmlFile = new Capas.Aplicacion.XML_Manager();
            //Buscando el String Conection de la base de datos 
            ResaConexion = new SqlConnection(XmlFile.BuscarElementoArchivoXMl("SqlServer", "", "App-Config.xml"));
        }

        #endregion

        #region Conectar
        /// <summary>
        /// Metodo Conectar que enlaza la conexion a la base de datos 
        /// </summary>
        /// <returns></returns>
        public bool Conectar()
        {
            //Se reviza el estado 
            if (ResaConexion.State == System.Data.ConnectionState.Open)
            {
                 //Se retorna  el estado 
                return Brecha = true;
            }

               //Si la conexion no esta abierta intentara lo siguiente 
            try
            {
                //Se abre la misma 
                ResaConexion.Open();

                if (ResaConexion != null)
                {
                    this.Brecha = true;
                }
                else
                {
                    this.Brecha = false;
                }

            }
            catch (SqlException SQLE)
            {
                #region Manejo de Excepcion Envio de error
                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmail(SQLE.Message);
                #endregion

            }

          
            return this.Brecha;
        }
        #endregion

        #region Desconectar

        /// <summary>
        /// Metodo de desconectar se deselanza la conexion con la base de datos 
        /// </summary>
        public void Desconectar()
        {
            //Se verifica el estado de la  conexion a la base de datos 
            if (ResaConexion.State == System.Data.ConnectionState.Closed)
            {
                //retorno 
                return;
            }
            else
            {
               
                try
                {
                    ResaConexion.Close();
                }
                catch (SqlException SQLE)
                {
                    #region Manejo de Excepcion Envio de error
                    //Enviando un email  a la cuenta de soporte la excepcion
                    Email email = new Email();
                    //Enviando
                    email.enviarEmail(SQLE.Message);
                    #endregion

                }

            }
        }
        #endregion
    }
}
