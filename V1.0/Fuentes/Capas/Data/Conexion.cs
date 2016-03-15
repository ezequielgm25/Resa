using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


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

        protected SqlConnection ResaConexion;

        private bool Brecha;


        public bool brecha
        {
            get { return Brecha; }
            set { Brecha = value; }


        }

        #endregion


        #region Contructor sin parametros
        public Conexion()
        {

            XmlFile = new Capas.Aplicacion.XML_Manager();

            ResaConexion = new SqlConnection(XmlFile.BuscarElementoArchivoXMl("SqlServer", "", "App-Config.xml"));
        }

        #endregion

        #region Conectar
        public bool Conectar()
        {

            if (ResaConexion.State == System.Data.ConnectionState.Open)
            {
                return Brecha = true;
            }

               //Si la conexion no esta abierta intentara lo siguiente 
            try
            {
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

                #endregion

            }

            //Codigo para el Manejo de la auditoria 

            finally
            {

            }

            return this.Brecha;
        }
        #endregion

        #region Desconectar 
        public void Desconectar()
        {
            if (ResaConexion.State == System.Data.ConnectionState.Closed)
            {
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

                    #endregion

                }

                //Codigo para el Manejo de la auditoria 

                finally
                {

                }
            }
        }
        #endregion
    }
}
