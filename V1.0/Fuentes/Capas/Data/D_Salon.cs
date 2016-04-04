﻿using System;
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
    public class D_Salon : Conexion
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias -

        //Salon 
        E_Salon e_Salon = new E_Salon();
        //Conexion
        private Conexion conexion;


        #endregion

        #region  Variables - 


        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la clase 
        /// </summary>
        public D_Salon()
        {
            //Asignando la conexion 
            conexion = new Conexion();
        }

        #endregion

        #region Obtener Salones -

        /// <summary>
        /// Metodo ObtenerSalones el cual retornara  una DataTable 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerSalones()
        {
            //Asignando el Stored Procedura 
            StoredProcedure = "ObtenerSalones";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //Un se SQL command al que se le pasan el stored procedute la conexion
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);
            //El tipo de comando
            comando.CommandType = CommandType.StoredProcedure;

            //Un DataAdapter 
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);
            //Un dataTable
            DataTable DataT = new DataTable();

            //se limpia 
            DataT.Clear();

            //Se llena  la DataTable 
            DataAD.Fill(DataT);

            return DataT;


        }
        #endregion

        #region Crear Salon -
        /// <summary>
        /// Metodo CrearSalon El cual acepta una entidad Salin como parametro y retorna un Id del mismo
        /// </summary>
        /// <param name="e_S"></param>
        /// <returns></returns>
        public int CrearSalon(E_Salon e_S)
        {
            //Variable  que recogera el ID
            int ID = 0;
            //Asignando el StoredProcedure
            StoredProcedure = "CrearSalon";



            //SQl Command --Asignadosele sus correspondientes parametros

            //resaConexion Prueba 
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos



            conexion.Conectar();
            //Asignando el command Type 
            Comando.CommandType = CommandType.StoredProcedure;
            //Agregando los parametros 
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = e_S.nombre;
            Comando.Parameters.Add("@Ubicacion", SqlDbType.NVarChar, 100).Value = e_S.ubicacion;
            Comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = e_S.capacidad;
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 100).Value = e_S.estado;

            //Variable devuelta ID_Salon

            SqlParameter ID_Salon = new SqlParameter("@ID_Salon", SqlDbType.Int);
            ID_Salon.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Salon);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            ID = Convert.ToInt32(Comando.Parameters["@ID_Salon"].Value);

            //Cerrando la conexion 
            //  conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;
        }

        #endregion

        #region Actualizar Salon -

        public int ActualizarSalon(E_Salon e_S)
        {
            //Variables que recogera las filas afectadas 

            int filasAfectadas = 0;

            int ID = 0;

            //Asignando el stored procedure 
            StoredProcedure = "ActualizarSalon";

            //Conexion string de modo prueba del sistema


            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //SQl Command con sus correspondientes parametros
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //Asignando command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Agregando los parametros
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

        #region Eliminar Salon -
        public int EliminarSalon(int ID_Salon)
        {
            //Variables que recogera las filas afectadas 

            int filasAfectadas = 0;

            //Asignando el stored procedure 
            StoredProcedure = "EliminarSalon";

            //Conexion string de modo prueba del sistema
            conexion.resaconexion = new SqlConnection("Data Source = Ezequiel; Initial Catalog = ResaDB; Integrated Security = true");

            //Sql commando con sus correspondientes parametros 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Asignando el tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Agregando los parametros 
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

        #region Obtener Salones ID y nombres -

        public DataTable ObtenerID_NombreDeSalones()
        {
            //Asignaando el stored procedure 
            StoredProcedure = "ObtenerSalonesID_N";

            //SQl command con sus correspondientes  parametros 
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //asignando los tipi de command 
            comando.CommandType = CommandType.StoredProcedure;

            //SQl Adapter 
            SqlDataAdapter DataAD_SalonesID_Nombre = new SqlDataAdapter(comando);
            //Datable 
            DataTable DataT = new DataTable();

            //Limpiando la DataTable 
            DataT.Clear();
            //LLenando la Data Table 
            DataAD_SalonesID_Nombre.Fill(DataT);

            //Retornanda la DataTable 
            return DataT;


        }

        #endregion

    }
}
