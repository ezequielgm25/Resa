using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Infraestructura.Entidades;
using System.Data.SqlClient;
using System.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
    public class D_Usuario:Conexion
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias

        E_Usuario e_usuario = new E_Usuario();

        private Conexion conexion;
        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        
        #endregion

        #region Contructor

        public D_Usuario()
        {
            conexion = new Conexion();
        }

        #endregion


        #region Obtener Usuario 
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {

            StoredProcedure = "ObtenerUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;


            //Variable devuelta nombre
            SqlParameter Nombre = new SqlParameter("@Nombre", SqlDbType.VarChar,50);
            Nombre.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Nombre);
            //Variable devuelta Apellido
            SqlParameter Apellido = new SqlParameter("@Apellido", SqlDbType.VarChar, 50);
            Apellido.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Apellido);
            //Variable devuelta Rol
            SqlParameter Rol = new SqlParameter("@Rol", SqlDbType.VarChar, 50);
            Rol.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Rol);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            e_usuario.nombre = Convert.ToString(Comando.Parameters["@Nombre"].Value);
            e_usuario.apellido = Convert.ToString(Comando.Parameters["@Apellido"].Value);
            e_usuario.rol = Convert.ToString(Comando.Parameters["@Rol"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
        
            return e_usuario;
        }

        #endregion 


    }
}
