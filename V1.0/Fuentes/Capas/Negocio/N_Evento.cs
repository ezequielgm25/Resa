using System;

//Usings del sistema 
using Capas.Data;
using Capas.Infraestructura.Entidades;
using System.Data;


namespace Capas.Negocio
{
    public class N_Evento
    {
        //<Summary>
        // Clase que avergara la logistica de la entidad evento
        //</Summary>


        #region Declaraciones
        DataTable DataT;

        D_Evento d_Evento;

        #endregion

        #region Contructor 
        /// <summary>
        /// Constructor de la clase de evento en la capa de negocio
        /// </summary>
        public N_Evento()
        {
            //Instancias
            DataT = new DataTable();
            d_Evento = new D_Evento();

        }

        #endregion

        #region Crear Evento -
        /// <summary>
        /// Metodo donde se guarda un evento en el sistema 
        /// </summary>
        /// <param name="e_Ev"></param>
        /// <returns></returns>
        public int CrearEvento(E_Evento e_Ev)
        {
            //Variable que recupera el ID
            int ID = 0;

            //Recuperando el ID y ejecutando el metodo
            ID = d_Evento.CrearEvento(e_Ev);

            //Retornando resultados
            return ID;

        }


        #endregion

        #region Verificar Fechas -
        /// <summary>
        /// Metodo donde se verifican las fechas insertadas para el evento 
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFinal"></param>
        /// <param name="ID_Salon"></param>
        /// <returns></returns>
        public int VerificarFechas(DateTime FechaInicio, DateTime FechaFinal, int ID_Salon)
        {
            //Variable que recoje el resultado
            int Resultado;

            //Recogiendo el resultado y ejecutando el metodo 
            Resultado = d_Evento.VerificarFechas(FechaInicio, FechaFinal, ID_Salon);

            //Retornando el resultado 
            return Resultado;

        }


        #endregion

        #region obtenerEvento -
        /// <summary>
        /// Metodo donde se obtiene un evento con todas sus caracteristicas 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public E_Evento ObtenerEvento(int ID_Solicitud)
        {
            //Entidad evento
            E_Evento e_Evento = new E_Evento();

            //Llenando la entidad evento 
            e_Evento = d_Evento.ObtenerEvento(ID_Solicitud);


            //Returnando la entidad
            return e_Evento;
        }


        #endregion

        #region Actualizar Evento -
        /// <summary>
        /// Metodo donde se actualiza un evento 
        /// </summary>
        /// <param name="e_Ev"></param>
        /// <returns></returns>
        public int ActualizarEvento(E_Evento e_Ev)
        {
            //Variable que recoje las filas afectadas 
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas 
            FilasAfectadas = d_Evento.ActualizarEvento(e_Ev);

            //Retornando filas afectadas
            return FilasAfectadas;
        }


        #endregion

        #region Obtener Eventos -
        /// <summary>
        /// Metodo donde se obtienen todos los eventos 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEventos()
        {
            //DataTable 
            DataT = d_Evento.ObtenerEventos();

            //Returnando 
            return DataT;
        }

        #endregion

        #region Obtener Eventos Detallados -
        /// <summary>
        /// Metodo donde se obtienen los eventos  -- los cuales seran presentados en el grid control de la pantalla principal
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEventosDetallados()
        {
            //Llenando DataTable
            DataT = d_Evento.ObtenerEventosDetallados();

            //Reournando 
            return DataT;
        }


        #endregion

        #region Obtener Eventospor ID 
        /// <summary>
        /// Metodo donde se obtienen los eventos por ID 
        /// </summary>
        /// <param name="ID_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerEventosPorID(int ID_Salon)
        {
            //LLenando DataTable 
            DataT = d_Evento.ObtenerEventosPorID(ID_Salon);

            //Returnando el mismo 
            return DataT;
        }

        #endregion

    }
}
