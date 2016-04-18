using System;
using Capas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Capas.Data
{
    public class D_Auditoria
    {

        //<Summary>
        // Clase en la cual se interactuara con la base de datos con todas las funciones concernientes a auditoria  
        //</Summary>

        #region Variables
     
        private String StoredProcedure;

        private int FilasAfectadas = 0;

        private Conexion conexion;

        #endregion

        #region Contructor
        
        public D_Auditoria()
        {
            //Instancia de la conexion 
            conexion = new Conexion();
        }

        #endregion

        #region Insertar Auditoria


        /// <summary>
        /// Metodo donde se inserta una auditoria a un usuario  -- Enlazado por su ID -- 
        /// </summary>
        /// <param name="e_Au"></param>
        /// <returns></returns>
        public  int InsertarAuditoria(E_Auditoria e_Au)
        {
            //Stored procedure
            StoredProcedure = "InsertarAuditoria";

            //Ejecucion del command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de command a ejecutar
            Comando.CommandType = CommandType.StoredProcedure;

            //Asignando los parametros 
            //ID
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = e_Au.id_Usuario;
            //Tipo Usuario
            Comando.Parameters.Add("@TipoUsuario", SqlDbType.NVarChar, 100).Value = e_Au.tipoUsuario;
            //Fecha Entrada
            Comando.Parameters.Add("@Fecha_Entrada", SqlDbType.NVarChar, 30).Value = e_Au.fecha_Entrada;
            //Fecha Salida
            Comando.Parameters.Add("@Fecha_Salida", SqlDbType.NVarChar, 30).Value = e_Au.fecha_Salida;
            //Opcion
            Comando.Parameters.Add("@Opcion", SqlDbType.NVarChar, 100).Value = e_Au.opcion;
            //Tipo opcion
            Comando.Parameters.Add("@Tipo_Opcion", SqlDbType.NVarChar, 100).Value = e_Au.tipoOpcion ;
                      

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

         

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo Las FilasAfectadas 

            return FilasAfectadas;


        }

        #endregion

    }
}
