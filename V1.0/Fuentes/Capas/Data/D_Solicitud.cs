using System;
using System.Data.SqlClient;
using System.Data;

//Referencias a  las capas del sistema 
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
     public class D_Solicitud
    {
        //<Summary>
        //Clase que manipulara la data de la entidad solicitud
        //</Summary>

        #region Instancias -
            //Cnexion
        private Conexion conexion;


        #endregion

        #region  Variables -

        //Stored procedure
        private String StoredProcedure;
        
        // Filas Afectadas
        private int FilasAfectadas = 0;

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de  la  clase de solicitud en la capa de datos 
        /// </summary>
        public D_Solicitud()
        {
            //Conexion instanciacion 
            conexion = new Conexion();
        }

        #endregion

        #region Obtener Solicitudes -
         
        /// <summary>
        /// Metodo obtener solicitudees el cual devolvera un dataTable con los valores retornados de la base de datos 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerSolicitudes()
        {
            //Asignando Stored procedure
            StoredProcedure = "ObtenerSolicitudes";


            //Conexion string de modo prueba del sistema
            //conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //SQL Command
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Sql Command Type 
            comando.CommandType = CommandType.StoredProcedure;

            //DataAdapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //Data Table
            DataTable DataT = new DataTable();
            //Llenando el DataTable
            DataAD.Fill(DataT);

            //Retornando el datatable
            return DataT;
        }
        #endregion

        #region Crear Solicitud - 
        /// <summary>
        /// Metodo Crear Solicitud el cual espera por parametro una Entidad de solicitud 
        /// </summary>
        /// <param name="e_So"></param>
        /// <returns></returns>
        public int CrearSolicitud(E_Solicitud e_So)
        {
            //Variables
            int ID = 0;

            //Asignando el stored procedure
            StoredProcedure = "CrearSolicitud";


            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //SqlCommand
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command TYpe
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros 
            Comando.Parameters.Add("@Fecha", SqlDbType.NVarChar, 30).Value = e_So.fecha;
            //
            Comando.Parameters.Add("@Aprobacion", SqlDbType.NVarChar, 30).Value = e_So.aprobacion;
            //
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = e_So.usuario;
            //
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = e_So.fechaAprobacion;
            //
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_So.id_Salon;
            

            //Variable devuelta ID_Solicitud

            SqlParameter ID_Solicitud = new SqlParameter("@ID_Solicitud", SqlDbType.Int);
            ID_Solicitud.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Solicitud);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            ID = Convert.ToInt32(Comando.Parameters["@ID_Solicitud"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;


        }

        #endregion

        #region Obtener Solicitud - 
        /// <summary>
        /// Metodo Obtener Solicitud el cual espera un parametro de ID_Solicitud 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public E_Solicitud ObtenerSolicitud(int ID_Solicitud)
        {
            //Creando la entidad
            E_Solicitud e_Solicitud = new E_Solicitud();

         
            //Asignando Stored procedure
            StoredProcedure = "ObtenerSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //CommandType
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
        

            //Variables Devueltas

            //Fecha
            SqlParameter Fecha = new SqlParameter("@Fecha", SqlDbType.SmallDateTime);
            Fecha.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Fecha);
             
            //Aprobacion
            SqlParameter Aprobacion = new SqlParameter("@Aprobacion", SqlDbType.NVarChar,30);
            Aprobacion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Aprobacion);

            //Usuario
            SqlParameter Usuario = new SqlParameter("@Usuario", SqlDbType.NVarChar, 60);
            Usuario.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Usuario);

            //FechaAprobacion
            SqlParameter FechaAprobacion = new SqlParameter("@FechaAprobacion", SqlDbType.SmallDateTime);
            FechaAprobacion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(FechaAprobacion);

            //FechaAprobacion
            SqlParameter ID_Salon = new SqlParameter("@ID_Salon", SqlDbType.Int);
            ID_Salon.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Salon);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            e_Solicitud.id_Solicitud = ID_Solicitud;
            //
            e_Solicitud.fecha = Convert.ToString(Comando.Parameters["@Fecha"].Value);
            //
            e_Solicitud.aprobacion = Convert.ToString(Comando.Parameters["@Aprobacion"].Value);
            //
            e_Solicitud.usuario = Convert.ToString(Comando.Parameters["@Usuario"].Value);
            //
            e_Solicitud.fechaAprobacion = Convert.ToString(Comando.Parameters["@FechaAprobacion"].Value);
            //
            e_Solicitud.id_Salon = Convert.ToInt32(Comando.Parameters["@ID_Salon"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

           

         //Devolviendo la entidad


            return e_Solicitud;
        }


        #endregion 

        #region Actualizar Solicitud - 
        /// <summary>
        /// Metodo Actualizar solicitud 
        /// </summary>
        /// <param name="e_So"></param>
        /// <returns></returns>
        public int ActualizarSolicitud(E_Solicitud e_So)
        {
            //Filas afectadas
            int filasAfectadas = 0;

            //Variable  a la que se le asignara el ID
            int ID = 0;

            //Asignando El stored procedure 
            StoredProcedure = "ActualizarSolicitud";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = e_So.id_Solicitud;
            //
            Comando.Parameters.Add("@Fecha", SqlDbType.NVarChar,30).Value = e_So.fecha;
            //
            Comando.Parameters.Add("@Aprobacion", SqlDbType.NVarChar,30).Value = e_So.aprobacion;
            //
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar,60).Value = e_So.usuario;
            //
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = e_So.fechaAprobacion;
            //
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_So.id_Salon;
            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;



        }


        #endregion

        #region Eliminar Solicitud -
        /// <summary>
        /// Eliminar Solicitud Evento que acepta un Id solicitud y devuelve las Filas Afectadas 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public int EliminarSolicitud(int ID_Solicitud)
        {
            //Variable que retorna  las filas afectadas 
            int filasAfectadas = 0;

            //Asignando el stored procedure 
            StoredProcedure = "EliminarSolicitud";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");


            //SQL Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;

            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;

        }

        #endregion

        #region Aprobar Solicitud -
        /// <summary>
        /// Metodo Aprobar Solicitud El cual acepta como parametros un ID_Solicitud y un Usuario 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int AprobarSolicitud(int ID_Solicitud , String Usuario)
        {
            //Variables
            int filasAfectadas = 0;

            int ID = 0;

            //

            //Asignando el stored procedure 
            StoredProcedure = "AprobarSolicitud";

            //SQl Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;

            //Paramemtros 
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
            //
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = Usuario;
            //
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = Convert.ToString(DateTime.Now);
          
            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
          
        
            return FilasAfectadas;
        }


        #endregion

        #region Desaprobar Solicitud -
        /// <summary>
        /// Desaprobar Solicitud
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int DesaprobarSolicitud(int ID_Solicitud, String Usuario)
        {
            //Variables
            int filasAfectadas = 0;

            int ID = 0;

            //

           //Asignando el stored procedure
            StoredProcedure = "DesaprobarSolicitud";

            //SQL Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //CommandType
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
            //
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = Usuario;
            //
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = Convert.ToString(DateTime.Now);

            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;


        }


        #endregion

    }
}
