using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Data;
using Capas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;

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
        public N_Evento()
        {
            DataT = new DataTable();
            d_Evento = new D_Evento();

        }

        #endregion


        #region Crear Evento 

        public int CrearEvento(E_Evento e_Ev)
        {
            int ID = 0;

            ID = d_Evento.CrearEvento(e_Ev);

            return ID;

        }


        #endregion


        #region Verificar Fechas 
        public int VerificarFechas(DateTime FechaInicio, DateTime FechaFinal, int ID_Salon)
        {
            int Resultado;


             Resultado = d_Evento.VerificarFechas(FechaInicio, FechaFinal, ID_Salon);

             return Resultado;

        }


        #endregion

        #region obtenerEvento
        public E_Evento ObtenerEvento(int ID_Solicitud)
        {
            E_Evento e_Evento = new E_Evento();

            e_Evento= d_Evento.ObtenerEvento(ID_Solicitud);

           

            return e_Evento;
        }


        #endregion

        #region Actualizar Evento

        public int ActualizarEvento(E_Evento e_Ev)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Evento.ActualizarEvento(e_Ev);


            return FilasAfectadas;
        }


        #endregion


        #region Obtener Eventos 
        public DataTable ObtenerEventos()
        {
            DataT = d_Evento.ObtenerEventos();

            return DataT;
        }

        #endregion
    }
}
