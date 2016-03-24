using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capas.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
    public class D_Salon: Conexion
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias

        E_Salon e_Salon = new E_Salon();

        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor

        public D_Salon()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Obtener Salones
        public DataTable ObtenerSalones()
        {
         
                StoredProcedure = "ObtenerSalones";
      
                SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DataAD = new SqlDataAdapter(comando);

                DataTable DataT = new DataTable();

                DataAD.Fill(DataT);

                return DataT;

          
        }
        #endregion

        #region Crear Salon

        public int CrearSalon(E_Salon e_S)
        {
            int ID= 0;

            StoredProcedure = "CrearSalon";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar,100).Value = e_S.nombre;
            Comando.Parameters.Add("@Ubicacion", SqlDbType.NVarChar,100).Value = e_S.ubicacion;
            Comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = e_S.capacidad;
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar,100).Value = e_S.estado;

            //Variable devuelta ID_Salon

            SqlParameter ID_Salon  = new SqlParameter("@ID_Salon", SqlDbType.Int);
            ID_Salon.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Salon);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            ID = Convert.ToInt32(Comando.Parameters["@ID_Salon"].Value);
           
            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;
        }

        #endregion

        #region Actualizar Salon

        public int ActualizarSalon(E_Salon e_S)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "ActualizarSalon";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = e_S.id_Salon;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = e_S.nombre;
            Comando.Parameters.Add("@Ubicacion", SqlDbType.NVarChar, 100).Value = e_S.ubicacion;
            Comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = e_S.capacidad;
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 100).Value = e_S.estado;

            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;
        }

        #endregion

        #region Eliminar Salon
        public int EliminarSalon(int ID_Salon)
        {
            int filasAfectadas = 0;

            StoredProcedure = "EliminarSalon";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = ID_Salon;
            
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
