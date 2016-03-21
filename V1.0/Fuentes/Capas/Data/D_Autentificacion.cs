using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capas.Infraestructura.Entidades;

namespace Capas.Data
{
    class D_Autentificacion:Conexion
    {

        //<Summary>
        //Clase verificara el usuario en la base de datos 
        //</Summary>

        #region Variables
        private int Autentificacion;

        private String StoredProcedure;
    
        private int FilasAfectadas = 0;

        private Conexion conexion;

        #endregion

        #region Contructor 
        public D_Autentificacion()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Verificar Usuario

        public int  VerificarUsuario(E_Autentificacion E_AutentificacionP)
        {
            
            StoredProcedure = "LoginUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure,conexion.resaconexion );
            
            // Conectar a la base de datos

             conexion.Conectar();
            
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = E_AutentificacionP.usuario;
            Comando.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = E_AutentificacionP.contraseña;

            
            SqlParameter Result = new SqlParameter("@Result", SqlDbType.Int );
            Result.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Result);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();
            
            //Asigna el resultado devuelto por el stored procedure
            Autentificacion = Convert.ToInt32(Comando.Parameters["@Result"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();
         
            //Devolviendo el resultado 
            return Autentificacion;
  
        }

        #endregion

    }
}
