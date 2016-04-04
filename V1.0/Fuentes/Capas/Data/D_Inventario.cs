using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capas.Negocio;
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

        public D_Inventario()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Agregar Inventario

        public int AgregarInventario(E_Inventario e_Inventario)
        {

            StoredProcedure = "AgregarInventario";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
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


        #region Obtener Inventarios

        public DataTable ObtenerInventarios(int id_Salon)
        {
            StoredProcedure = "ObtenerInventarios";

            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);


            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = id_Salon;
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            DataTable DataT = new DataTable();

            DataAD.Fill(DataT);

            return DataT;
        }

        #endregion


        #region Eliminar Inventario

        public int EliminarInventario(int ID_Inventario)
        {

            StoredProcedure = "EliminarInventario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Inventario", SqlDbType.Int).Value = ID_Inventario;

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
