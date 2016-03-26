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
    public class D_Organizador
    {

        //<Summary>
        // Clase que manipulara la data de la entidad Organizador
        //</Summary>

        #region Instancias

        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor

        public D_Organizador()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Insertar organizador

        public int InsertarOrganizador(E_Organizador e_Or)
        {
            int ID = 0;

            StoredProcedure = "InsertarOrganizador";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = e_Or.nombre;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 150).Value = e_Or.descripcion;
            Comando.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar, 100).Value = e_Or.correoElectronico;
            Comando.Parameters.Add("@ID_Evento", SqlDbType.Int).Value = e_Or.id_Evento;
          
            //Variable devuelta ID_Organizador

            SqlParameter ID_Organizador = new SqlParameter("@ID_Organizador", SqlDbType.Int);
            ID_Organizador.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Organizador);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            ID = Convert.ToInt32(Comando.Parameters["@ID_Organizador"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;

        }
        #endregion

        #region Actualizar organizador 

        public int ActualizarOrganizador(E_Organizador e_Or)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "ActualizarOrganizador";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Organizador", SqlDbType.Int).Value = e_Or.id_Organizador;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = e_Or.nombre;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 150).Value = e_Or.descripcion;
            Comando.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar, 100).Value = e_Or.correoElectronico;
            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;

        }


        #endregion


        #region obtener Organizador

        public E_Organizador ObtenerOrganizador(int ID_Evento)
        {
            //Entidad 

            E_Organizador e_Organizador = new E_Organizador();

            StoredProcedure = "ObtenerOrganizador";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Evento", SqlDbType.Int).Value = ID_Evento;


            //Variables Devueltas

            SqlParameter ID_Organizador = new SqlParameter("@ID_Organizador", SqlDbType.Int);
            ID_Organizador.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Organizador);

            //Nombre
            SqlParameter Nombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 100);
            Nombre.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Nombre);

            //Descripcion
            SqlParameter Descripcion = new SqlParameter("@Descripcion", SqlDbType.NVarChar, 150);
            Descripcion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Descripcion);

            //Correo Electronico
            SqlParameter CorreoElectronico = new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar, 100);
            CorreoElectronico.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(CorreoElectronico);

           

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            e_Organizador.id_Organizador = Convert.ToInt32(Comando.Parameters["@ID_Organizador"].Value);
            e_Organizador.nombre = Convert.ToString(Comando.Parameters["@Nombre"].Value);
            e_Organizador.descripcion = Convert.ToString(Comando.Parameters["@Descripcion"].Value);
            e_Organizador.correoElectronico = Convert.ToString(Comando.Parameters["@CorreoElectronico"].Value);
        

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 



            //Devolviendo la entidad

            return e_Organizador; 
        }

        #endregion

    }
}
