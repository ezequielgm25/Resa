using System;
using System.Data;
using System.Data.SqlClient;
//Capas del sistema 
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
        /// <summary>
        /// Contructor de la clase Autentificacion  -- Manipula la parte de logeo del usuario  --
        /// </summary>
        public D_Autentificacion()
        {
            //Instanciando la conexion
            conexion = new Conexion();
        }

        #endregion

        #region Verificar Usuario
        /// <summary>
        /// Metodo de verificacion de la conexion 
        /// </summary>
        /// <param name="E_AutentificacionP"></param>
        /// <returns></returns>
        public int  VerificarUsuario(E_Autentificacion E_AutentificacionP)
        {
            //Stored procedure 
            StoredProcedure = "LoginUsuario";
            //Comando 
            SqlCommand Comando = new SqlCommand(StoredProcedure,conexion.resaconexion );
            
            // Conectar a la base de datos

             conexion.Conectar();
            
            //Command Type 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            //Usuario
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = E_AutentificacionP.usuario;
            //PassWord
            Comando.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = E_AutentificacionP.contraseña;

            
            //Resultados
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
