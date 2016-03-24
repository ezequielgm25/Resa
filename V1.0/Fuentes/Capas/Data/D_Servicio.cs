using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Data;
using Capas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace Capas.Data
{
    public class D_Servicio
    {
        //<Summary>
        //Clase donde se maneja las consultas a la base de datos de la entidad Servicio
        //<Summary>

        #region Instancias

       

        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor

        public D_Servicio()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Agregar Servicio 

        public int AgregarServicio(E_Servicio e_Servicio)
        {

            StoredProcedure = "AgregarServicio";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos
            
            conexion.Conectar();
            
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Servicio", SqlDbType.NVarChar, 100).Value = e_Servicio.servicio;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 250).Value = e_Servicio.descripcion;
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

        public DataTable ObtenerServicios(int id_Salon)
        {
            StoredProcedure = "ObtenerServicios";

            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);


            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = id_Salon;
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            DataTable DataT = new DataTable();

            DataAD.Fill(DataT);

            return DataT;
        }

        #endregion


        #region Eliminar Servicio

        public int EliminarServicio(int ID_Servicio)
        {

            StoredProcedure = "EliminarServicio";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Servicio", SqlDbType.Int).Value = ID_Servicio;
          
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
