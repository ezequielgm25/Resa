using System;
using Capas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;

//Using del sistema 
namespace Capas.Data
{
    public class D_Servicio
    {
        //<Summary>
        //Clase donde se maneja las consultas a la base de datos de la entidad Servicio
        //<Summary>

        #region Instancias


        //Intancia de la clase conexion
        private Conexion conexion;


        #endregion

        #region  Variables

        //Variables
        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor
        /// <summary>
        /// Contructor de la  clase de data servicio parte logica de la iteracion con la base de datos de los servicios
        /// </summary>
        public D_Servicio()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Agregar Servicio 
        /// <summary>
        /// metodo agregar un servicio el cual inserta un servicio en la base de datos 
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int AgregarServicio(E_Servicio e_Servicio)
        {

            StoredProcedure = "AgregarServicio";


            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");


            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Servicio", SqlDbType.NVarChar, 100).Value = e_Servicio.servicio;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Servicio.id_Salon;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;
        }

        #endregion

        #region Obtener Servicios 
        /// <summary>
        /// Metodo donde se optien los servicios que pertenecen a un sistema 
        /// </summary>
        /// <param name="id_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerServicios(int id_Salon)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerServicios";

            //Command
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Tipo de comando
            comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = id_Salon;
            //Sql Adapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //DataTable
            DataTable DataT = new DataTable();

            //Llenando el DataAD
            DataAD.Fill(DataT);

            //Returnando el DataT
            return DataT;
        }

        #endregion

        #region Eliminar Servicio
        /// <summary>
        /// Metodo donde se elimina un servicio a un  salon
        /// </summary>
        /// <param name="ID_Servicio"></param>
        /// <returns></returns>

        public int EliminarServicio(int ID_Servicio)
        {
            //Stored procedure
            StoredProcedure = "EliminarServicio";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros 
            Comando.Parameters.Add("@ID_Servicio", SqlDbType.Int).Value = ID_Servicio;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region Obtener Servicios Globales
        /// <summary>
        /// Metodo donde se obtienen los servicios que seran caracteristicos de los Salones 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerServiciosGlobales()
        {
            //Stored procedure
            StoredProcedure = "ObtenerServiciosGlobales";
            //Command
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Tipo de comando 
            comando.CommandType = CommandType.StoredProcedure;

            //Data adapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);
            //DataTable
            DataTable DataT = new DataTable();
            //LLenando  el dataT
            DataAD.Fill(DataT);
            //Retornando la data
            return DataT;


        }

        #endregion

        #region Eliminar Servicios Globales
        /// <summary>
        /// Metodo donde se elimina un servicio que pertenece a la lista de los servicios caracteristicos de los salones
        /// </summary>
        /// <param name="ID_Servicio"></param>
        /// <returns></returns>
        public int EliminarServicioGlobales(int ID_Servicio)
        {
            //Stored procedure 
            StoredProcedure = "EliminarServicioGlobal";
            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@ID_Servicio", SqlDbType.Int).Value = ID_Servicio;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;

        }

        #endregion

        #region Insertar un Servicio Global
        /// <summary>
        /// Metodo donde se inserta un servicio global el cual pertenecera a la lista de servicios caracteristicos de los salones
        /// </summary>
        /// <param name="Servicio"></param>
        /// <returns></returns>
        public int InsertarServicioGlobal(String Servicio)
        {
            //Stored procedure
            StoredProcedure = "InsertarServicioGlobal";


            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@Servicio", SqlDbType.NVarChar, 100).Value = Servicio;


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region verificar existencia del servicio

        /// <summary>
        /// Metodo donde se verifica la existencia de un servicio en un salon
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int VerificarExistenciaDeServicio(E_Servicio e_Servicio)
        {

            //Varaible que devolvera la  variable 
            int Resultado = 0;
            //Entidad 


            //Stored procedure
            StoredProcedure = "VerificarExistenciaServicio";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("Servicio", SqlDbType.NVarChar, 100).Value = e_Servicio.servicio;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Servicio.id_Salon;



            //Variables Devueltas

            SqlParameter Result = new SqlParameter("@Result", SqlDbType.Int);
            Result.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Result);



            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            Resultado = Convert.ToInt32(Comando.Parameters["@Result"].Value);



            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado
            return Resultado;
        }

        #endregion

        #region Eliminar Servicio por Nombre y ID 
        /// <summary>
        /// Metodo Donde se eliminar un servicio con los parametros de nombre y ID
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int EliminarSercvicioXS_ID(E_Servicio e_Servicio)
        {
            //Stored procedure
            StoredProcedure = "EliminarServicioXS_ID";

            //Sql Commando
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@Servicio", SqlDbType.NVarChar, 100).Value = e_Servicio.servicio;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Servicio.id_Salon;

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
