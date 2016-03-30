using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            conexion = new Conexion();
        }

        #endregion



        #region Insertar Auditoria 
        public  int InsertarAuditoria(E_Auditoria e_Au)
        {
            StoredProcedure = "InsertarAuditoria";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = e_Au.id_Usuario;
            Comando.Parameters.Add("@TipoUsuario", SqlDbType.NVarChar, 100).Value = e_Au.tipoUsuario;
            Comando.Parameters.Add("@Fecha_Entrada", SqlDbType.NVarChar, 30).Value = e_Au.fecha_Entrada;
            Comando.Parameters.Add("@Fecha_Salida", SqlDbType.NVarChar, 30).Value = e_Au.fecha_Salida;
            Comando.Parameters.Add("@Opcion", SqlDbType.NVarChar, 100).Value = e_Au.opcion;
            Comando.Parameters.Add("@Tipo_Opcion", SqlDbType.NVarChar, 100).Value = e_Au.tipoOpcion ;
                      

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
