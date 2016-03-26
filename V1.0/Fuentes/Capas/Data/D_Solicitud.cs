using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
     public class D_Solicitud
    {
        //<Summary>
        //Clase que manipulara la data de la entidad solicitud
        //</Summary>

        #region Instancias

        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor

        public D_Solicitud()
        {
            conexion = new Conexion();
        }

        #endregion


        #region Obtener Solicitudes 

        public DataTable ObtenerSolicitudes()
        {

            StoredProcedure = "ObtenerSolicitudes";

            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            DataTable DataT = new DataTable();

            DataAD.Fill(DataT);

            return DataT;
        }
        #endregion


        #region Crear Solicitud 

        public int CrearSolicitud(E_Solicitud e_So)
        {
            int ID = 0;

            StoredProcedure = "CrearSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Fecha", SqlDbType.NVarChar, 30).Value = e_So.fecha;
            Comando.Parameters.Add("@Aprobacion", SqlDbType.NVarChar, 30).Value = e_So.aprobacion;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = e_So.usuario;
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = e_So.fechaAprobacion;
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

        #region Obtener Solicitud 

        public E_Solicitud ObtenerSolicitud(int ID_Solicitud)
        {
            //Creando la entidad
            E_Solicitud e_Solicitud = new E_Solicitud();

         

            StoredProcedure = "ObtenerSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
        

            //Variables Devueltas

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
            e_Solicitud.fecha = Convert.ToString(Comando.Parameters["@Fecha"].Value);
            e_Solicitud.aprobacion = Convert.ToString(Comando.Parameters["@Aprobacion"].Value);
            e_Solicitud.usuario = Convert.ToString(Comando.Parameters["@Usuario"].Value);
            e_Solicitud.fechaAprobacion = Convert.ToString(Comando.Parameters["@FechaAprobacion"].Value);
            e_Solicitud.id_Salon = Convert.ToInt32(Comando.Parameters["@ID_Salon"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

           

         //Devolviendo la entidad


            return e_Solicitud;
        }


        #endregion 

        #region Actualizar Solicitud 

        public int ActualizarSolicitud(E_Solicitud e_So)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "ActualizarSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = e_So.id_Solicitud;
            Comando.Parameters.Add("@Fecha", SqlDbType.NVarChar,30).Value = e_So.fecha;
            Comando.Parameters.Add("@Aprobacion", SqlDbType.NVarChar,30).Value = e_So.aprobacion;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar,60).Value = e_So.usuario;
            Comando.Parameters.Add("@FechaAprobacion", SqlDbType.NVarChar, 30).Value = e_So.fechaAprobacion;
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

        #region Eliminar Solicitud
        
        public int EliminarSolicitud(int ID_Solicitud)
        {
            int filasAfectadas = 0;

            StoredProcedure = "EliminarSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
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

        #region Aprobar Solicitud 

        public int AprobarSolicitud(int ID_Solicitud , String Usuario)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "AprobarSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = Usuario;
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

        #region Desaprobar Solicitud

        public int DesaprobarSolicitud(int ID_Solicitud, String Usuario)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "DesaprobarSolicitud";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 60).Value = Usuario;
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
