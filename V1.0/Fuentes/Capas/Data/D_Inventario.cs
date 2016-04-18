using System;
using System.Data;
using System.Data.SqlClient;

//Using capas del sistema
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
    public class D_Inventario
    {
        //<Summary>
        //Clase donde se maneja las consultas a la base de datos de la entidad Inventario
        //<Summary>

        #region Instancias



        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor
        /// <summary>
        /// Constructor del sistema 
        /// </summary>
        public D_Inventario()
        {
            // instancia de la clase conexion
            conexion = new Conexion();
        }

        #endregion

        #region Agregar Inventario +
        /// <summary>
        /// Metodo donde se agrega un inventario a un salon
        /// </summary>
        /// <param name="e_Inventario"></param>
        /// <returns></returns>
        public int AgregarInventario(E_Inventario e_Inventario)
        {

            //Stored procedure
            StoredProcedure = "AgregarInventario";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //SQL Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@Inventario", SqlDbType.NVarChar, 100).Value = e_Inventario.inventario;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Inventario.id_Salon;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region Obtener Inventarios +
        /// <summary>
        /// Metodo donde se obtienen los inventarios de un salon 
        /// </summary>
        /// <param name="id_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerInventarios(int id_Salon)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerInventarios";

            //Sql Command
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Commando Type
            comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = id_Salon;

            //Sql DataAdapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //DataTable
            DataTable DataT = new DataTable();

            //Llenando el DataAdapter
            DataAD.Fill(DataT);

            //Retornando el DataTable
            return DataT;
        }

        #endregion

        #region Eliminar Inventario +
        /// <summary>
        /// Metodo donde se elimina un inventario a un salon 
        /// </summary>
        /// <param name="ID_Inventario"></param>
        /// <returns></returns>
        public int EliminarInventario(int ID_Inventario)
        {
            //Stored procedure
            StoredProcedure = "EliminarInventario";

            //Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            Comando.Parameters.Add("@ID_Inventario", SqlDbType.Int).Value = ID_Inventario;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region Obtener Inventarios Globales +
        /// <summary>
        /// Metodo donde se obtienen los inventarios globales
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerInventariosGlobales()
        {
            //Stored procedure
            StoredProcedure = "ObtenerInventariosGlobales";
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

        #region Eliminar Inventarios Globales +
        /// <summary>
        /// Metodo donde se elimina un inventario en la lista de inventarios globales
        /// </summary>
        /// <param name="ID_Inventario"></param>
        /// <returns></returns>
        public int EliminarInventariosGlobales(int ID_Inventario)
        {
            //Stored procedure
            StoredProcedure = "EliminarInventarioGlobal";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            Comando.Parameters.Add("@ID_Inventario", SqlDbType.Int).Value = ID_Inventario;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region Insertar un Inventario Global +
        /// <summary>
        /// metodo donde se inserta un inventario global a la lista de inventarios que englobaran todos los salones
        /// </summary>
        /// <param name="Inventario"></param>
        /// <returns></returns>
        public int InsertarInventarioGlobal(String Inventario)
        {

            //Stored procedure 
            StoredProcedure = "InsertarInventarioGlobal";


            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            Comando.Parameters.Add("@Inventario", SqlDbType.NVarChar, 100).Value = Inventario;


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region verificar existencia del inventario
       
         /// <summary>
         /// Metodo Donde se verifica la existencia de un inventario en un salon
         /// </summary>
         /// <param name="e_Inventario"></param>
         /// <returns></returns>
        public int VerificarExistenciaDeInventario(E_Inventario e_Inventario)
        {

            //Varaible que devolvera la  variable 
            int Resultado = 0;
            //Entidad 

            //Stored procedure
            StoredProcedure = "VerificarExistenciaInventario";
            //Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("Inventario", SqlDbType.NVarChar, 100).Value = e_Inventario.inventario;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Inventario.id_Salon;



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


        #region Eliminar Inventario por Nombre y ID 
        /// <summary>
        /// Metodo donde se eliminar un inventario  de un salon
        /// </summary>
        /// <param name="e_Inventario"></param>
        /// <returns></returns>
        public int EliminarInventarioXS_ID(E_Inventario e_Inventario)
        {
            //Stored procedure
            StoredProcedure = "EliminarInventarioXS_ID";

            //Sql Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@Inventario", SqlDbType.NVarChar, 100).Value = e_Inventario.inventario;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_Inventario.id_Salon;

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
