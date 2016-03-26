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
    class D_Evento
    {
        //<Summary>
        //Clase que manipulara la data de la entidad evento
        //</Summary>

        #region Instancias

        private Conexion conexion;


        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        #endregion

        #region Contructor

        public D_Evento()
        {
            conexion = new Conexion();
        }

        #endregion

        #region Crear Evento 
        
        public int CrearEvento(E_Evento e_Ev)
        {
            int ID = 0;

            StoredProcedure = "CrearEvento";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Titulo_Evento", SqlDbType.NVarChar, 100).Value = e_Ev.titulo_Evento;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 300).Value = e_Ev.descripcion;
            Comando.Parameters.Add("@Tipo", SqlDbType.NVarChar,100).Value = e_Ev.tipo;
            Comando.Parameters.Add("@Topico", SqlDbType.NVarChar, 150).Value = e_Ev.topico;
            Comando.Parameters.Add("@Tiempo_Inicio", SqlDbType.NVarChar, 30).Value = e_Ev.tiempo_Inicio;
            Comando.Parameters.Add("@Tiempo_Final", SqlDbType.NVarChar, 30).Value = e_Ev.tiempo_Final;
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
        
        public int ActualizarEvento(E_Evento e_Ev)
        {
            int filasAfectadas = 0;

            int ID = 0;

            StoredProcedure = "ActualizarEvento";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Evento", SqlDbType.Int).Value = e_Ev.id_Evento;
            Comando.Parameters.Add("@Titulo_Evento", SqlDbType.NVarChar, 100).Value = e_Ev.titulo_Evento;
            Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 300).Value = e_Ev.descripcion;
            Comando.Parameters.Add("@Tipo", SqlDbType.NVarChar, 100).Value = e_Ev.tipo;
            Comando.Parameters.Add("@Topico", SqlDbType.NVarChar, 150).Value = e_Ev.topico;
            Comando.Parameters.Add("@Tiempo_Inicio", SqlDbType.NVarChar,30).Value = e_Ev.tiempo_Inicio;
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

        public int VerificarFechas(DateTime FechaI , DateTime FechaF, int ID_Salon)
        {
            string FI = Convert.ToString(FechaI);
            String FF = Convert.ToString(FechaF);

            StoredProcedure = "VerificarFechas";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
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

        public E_Evento ObtenerEvento(int ID_Solicitud)
        {
            //Entidad 

            E_Evento e_Evento = new E_Evento();

            StoredProcedure = "ObtenerEvento";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Solicitud", SqlDbType.Int).Value = ID_Solicitud;


            //Variables Devueltas

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




    }
}
