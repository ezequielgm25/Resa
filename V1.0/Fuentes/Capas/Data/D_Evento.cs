using System;
using Capas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Capas.Data
{
    class D_Evento
    {
        //<Summary>
        //Clase que manipulara la data de la entidad evento
        //</Summary>

        #region Instancias

            //Intanciando la conexion 
        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        public D_Evento()
        {
            //Conexion 
            conexion = new Conexion();
        }

        #endregion

        #region Crear Evento 
        /// <summary>
        /// Metodo en la capa de datos para crear un evento  espera una entidad Evento
        /// </summary>
        /// <param name="e_Ev"></param>
        /// <returns></returns>
        public int CrearEvento(E_Evento e_Ev)
        {
            int ID = 0;
            //Stored procedure 
            StoredProcedure = "CrearEvento";

            //Sql Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            //Titulo Evento 
            Comando.Parameters.Add("@Titulo_Evento", SqlDbType.NVarChar, 100).Value = e_Ev.titulo_Evento;
            //Descripcion 
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 300).Value = e_Ev.descripcion;
            //Tipo 
            Comando.Parameters.Add("@Tipo", SqlDbType.NVarChar,100).Value = e_Ev.tipo;
            //Topico 
            Comando.Parameters.Add("@Topico", SqlDbType.NVarChar, 150).Value = e_Ev.topico;
            //Tiempo Inicio 
            Comando.Parameters.Add("@Tiempo_Inicio", SqlDbType.NVarChar, 30).Value = e_Ev.tiempo_Inicio;
            //Tiempo Final 
            Comando.Parameters.Add("@Tiempo_Final", SqlDbType.NVarChar, 30).Value = e_Ev.tiempo_Final;
            //ID Solicitud
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = e_Ev.id_Solicitud;

            //Variable devuelta ID_Evento

            SqlParameter ID_Evento = new SqlParameter("@ID_Evento", SqlDbType.Int);
            ID_Evento.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Evento);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            ID = Convert.ToInt32(Comando.Parameters["@ID_Evento"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;


        }
        #endregion

        #region Actualizar Evento 
        /// <summary>
        /// Metodo para actualizar un evento -- El cual espera una entidad de evento 
        /// </summary>
        /// <param name="e_Ev"></param>
        /// <returns></returns>
        public int ActualizarEvento(E_Evento e_Ev)
        {
            //Filas Afectadas
            int filasAfectadas = 0;

            int ID = 0;

            //Stored procedure
            StoredProcedure = "ActualizarEvento";
          

            //SQL Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
            //ID Evento
            Comando.Parameters.Add("@ID_Evento", SqlDbType.Int).Value = e_Ev.id_Evento;
            //Titulo Evento
            Comando.Parameters.Add("@Titulo_Evento", SqlDbType.NVarChar, 100).Value = e_Ev.titulo_Evento;
            //Descripcion 
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 300).Value = e_Ev.descripcion;
            //Tipo 
            Comando.Parameters.Add("@Tipo", SqlDbType.NVarChar, 100).Value = e_Ev.tipo;
            //Topico
            Comando.Parameters.Add("@Topico", SqlDbType.NVarChar, 150).Value = e_Ev.topico;
            //Tiempo de inicio
            Comando.Parameters.Add("@Tiempo_Inicio", SqlDbType.NVarChar,30).Value = e_Ev.tiempo_Inicio;
            //Tiempo Final 
            Comando.Parameters.Add("@Tiempo_Final", SqlDbType.NVarChar,30).Value = e_Ev.tiempo_Final;

            //Variable devuelta ID_Salon

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return FilasAfectadas;

        }


        #endregion

        #region Verificar Fechas 
        /// <summary>
        /// Metodo para la verificacion de fechas -- Espera las fechas y el ID del Salon
        /// </summary>
        /// <param name="FechaI"></param>
        /// <param name="FechaF"></param>
        /// <param name="ID_Salon"></param>
        /// <returns></returns>
        public int VerificarFechas(DateTime FechaI , DateTime FechaF, int ID_Salon)
        {
            //Asignando la las Fechas 
            string FI = Convert.ToString(FechaI);
            String FF = Convert.ToString(FechaF);

            //Stored procedure 
            StoredProcedure = "VerificarFechas";
            //SQL Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros 
            Comando.Parameters.Add("@Tiempo_Inicio", SqlDbType.NVarChar, 30).Value =FI;

            Comando.Parameters.Add("@Tiempo_Final", SqlDbType.NVarChar, 30).Value = FF;

            Comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = ID_Salon;

            //Variable devuelta MSG

            SqlParameter MSG = new SqlParameter("@MSG", SqlDbType.Int);
            MSG.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(MSG);

            


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            int resultado = Convert.ToInt16(Comando.Parameters["@MSG"].Value);
              
          
            //Cerrando la conexion 
            conexion.Desconectar();

            return resultado;

        }


        #endregion

        #region Obtener Evento
        /// <summary>
        /// Metodo para obtener un evento -- espera el id de una solicitud --
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public E_Evento ObtenerEvento(int ID_Solicitud)
        {
            //Entidad 

            E_Evento e_Evento = new E_Evento();

            //Stored procedure 
            StoredProcedure = "ObtenerEvento";

            //Sql Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Tipe 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;

            //Variables Devueltas

            //ID Evento 
            SqlParameter ID_Evento = new SqlParameter("@ID_Evento", SqlDbType.Int);
            ID_Evento.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Evento);

            //Titulo_Evento
            SqlParameter Titulo_Evento = new SqlParameter("@Titulo_Evento", SqlDbType.NVarChar, 100);
            Titulo_Evento.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Titulo_Evento);

            //Descripcion
            SqlParameter Descripcion = new SqlParameter("@Descripcion", SqlDbType.NVarChar, 300);
            Descripcion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Descripcion);

            //Tipo
            SqlParameter Tipo = new SqlParameter("@Tipo", SqlDbType.NVarChar,100);
            Tipo.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Tipo);

            //Topico
            SqlParameter Topico = new SqlParameter("@Topico", SqlDbType.NVarChar,150);
            Topico.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Topico);

            //Tiempo Inicial
            SqlParameter Tiempo_Inicio = new SqlParameter("@Tiempo_Inicio", SqlDbType.SmallDateTime);
            Tiempo_Inicio.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Tiempo_Inicio);
            //Tiempo Final
            SqlParameter Tiempo_Final = new SqlParameter("@Tiempo_Final", SqlDbType.SmallDateTime);
            Tiempo_Final.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Tiempo_Final);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            e_Evento.id_Evento = Convert.ToInt32(Comando.Parameters["@ID_Evento"].Value);
            e_Evento.titulo_Evento = Convert.ToString(Comando.Parameters["@Titulo_Evento"].Value);
            e_Evento.descripcion = Convert.ToString(Comando.Parameters["@Descripcion"].Value);
            e_Evento.tipo = Convert.ToString(Comando.Parameters["@Tipo"].Value);
            e_Evento.topico = Convert.ToString(Comando.Parameters["@Topico"].Value);
            e_Evento.tiempo_Inicio = Convert.ToString(Convert.ToDateTime(Comando.Parameters["@Tiempo_Inicio"].Value));
            e_Evento.tiempo_Final = Convert.ToString(Convert.ToDateTime(Comando.Parameters["@Tiempo_Final"].Value));

         
            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 



            //Devolviendo la entidad
            return e_Evento;
        }

        #endregion

        #region  Obtener Eventos 
        /// <summary>
        /// Metodo para obtener eventos -- Devuelbe un datatable con los datos concernientes de la base de datos --
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEventos()
        {
            //Stored Procedure 
            StoredProcedure = "ObtenerEventos";

           
            //Comando 
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Tipo
            comando.CommandType = CommandType.StoredProcedure;

            //SQl Adapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);
            //Datatable 
            DataTable DataT = new DataTable();

            //Limpiando el DT
            DataT.Clear();

            //Llenandolo
            DataAD.Fill(DataT);

            //Retornandolo 
            return DataT;

        }
        #endregion

        #region Obtener Eventos Detallados 
        /// <summary>
        /// Metodo Obtener Eventos Detallados el cual devuelbe los eventos a visualizar en la pantalla principal
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEventosDetallados()
        {

            //Stored procedure 
            StoredProcedure = "ObtenerEventosDetallados";

            //Comando 
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Tipo de comando 
            comando.CommandType = CommandType.StoredProcedure;

            //SQL Adapter 
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //SQL DATAT
            DataTable DataT = new DataTable();

            //Limpiando el DT
            DataT.Clear();

            //Completandolo 
            DataAD.Fill(DataT);

            //Retornandolo 
            return DataT;


        }


        #endregion

        #region Obtener Eventos por ID
        /// <summary>
        /// Metodos que devuelbe los eventos por Salon -- Para la opcion de pantalla principal mostrar los eventos de un salon --
        /// </summary>
        /// <param name="ID_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerEventosPorID(int ID_Salon)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerEventosDetalladosXID";

            //Commmand 
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Command Type 
            comando.CommandType = CommandType.StoredProcedure;
            //Parametros 

            // --- ID Salon ---
            comando.Parameters.Add("@ID_Salon", SqlDbType.Int).Value = ID_Salon;

            // SQL DataAdapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //DataT
            DataTable DataT = new DataTable();

            //Limpiando el DT
            DataT.Clear();

            //LLenandolo 
            DataAD.Fill(DataT);

            //Retornandolo 
            return DataT;

        }

        #endregion


    }
}
