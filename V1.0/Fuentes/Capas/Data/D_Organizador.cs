﻿using System;
using System.Data;
using System.Data.SqlClient;

//Using de las capas del sistema 
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

        #region Insertar organizador +
        /// <summary>
        /// Metodo donde se inserta un organizador al sistema
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int InsertarOrganizador(E_Organizador e_Or)
        {
            //Variable que recogera el ID
            int ID = 0;

            //Stored procedure 
            StoredProcedure = "InsertarOrganizador";

           
            //SQL Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
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

        #region Actualizar organizador + 
        /// <summary>
        /// Metodo donde se actualizara un organizador en la base de datos 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int ActualizarOrganizador(E_Organizador e_Or)
        {
            //Variable que recoje las filas afectadas
            int filasAfectadas = 0;


            //Stored procedure 
            StoredProcedure = "ActualizarOrganizador";


            //Sql Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
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

        #region obtener Organizador +
        /// <summary>
        /// Metodo en el cual se optienen los organizadores 
        /// </summary>
        /// <param name="ID_Evento"></param>
        /// <returns></returns>
        public E_Organizador ObtenerOrganizador(int ID_Evento)
        {
            //Entidad 
            E_Organizador e_Organizador = new E_Organizador();

            //Stored procedure
            StoredProcedure = "ObtenerOrganizador";

            //Sql Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
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

        //Trabajando los organizadores Globales 

        #region Obteniendo los organizadores Globales +
        /// <summary>
        /// Metodo Donde se obtienen los organizadores Globales  -- Organizadores que estaran en una tabla como referencia que podran ser manipulados
        /// </summary>
        /// <returns></returns>
        public DataTable ObteniendoOrganizadoresGlobales()
        {

            //Stored procedure
            StoredProcedure = "ObtenerOrganizadoresGlobales";
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

        #region Agregando Organizador Global +
        /// <summary>
        /// Metodo donde se agrega un organizador Global a la lista 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int AgregandoOrganizadorGlobal(E_Organizador e_Or)
        {
            //Variable que recoge las filas Afectadas
            int FilasAfectadas = 0;

            StoredProcedure = "InsertarOrganizadorGlobal";

            
            //SQL Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = e_Or.nombre;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 150).Value = e_Or.descripcion;
            Comando.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar, 100).Value = e_Or.correoElectronico;




            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return FilasAfectadas;

        }


        #endregion

        #region Actualizando organizador Global +
        /// <summary>
        /// Metodo en el cual se actualiza las caracteristicas de un organizador 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int ActualizarOrganizadorGlobal(E_Organizador e_Or)
        {
            int filasAfectadas = 0;


            StoredProcedure = "ActualizarORganizadorGlobal";

            
            //Sql Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
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

        #region Eliminando organizador Global +
        /// <summary>
        /// Evento donde se elimina un organizador de la lista de organizadores Globales 
        /// </summary>
        /// <param name="ID_Organizador"></param>
        /// <returns></returns>
        public int EliminarOrganizadorGlobal(int ID_Organizador)
        {
            //Stored procedure
            StoredProcedure = "EliminarOrganizadorGlobal";

            //Sql command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command type
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
            Comando.Parameters.Add("@ID_Organizador", SqlDbType.Int).Value = ID_Organizador;




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
