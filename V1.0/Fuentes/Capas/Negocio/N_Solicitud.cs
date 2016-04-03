using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capas.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Negocio
{
    public class N_Solicitud
    {
        //<Summary>
        // Clase Que manejara la logistica en la capa de negocio de la entidad solicitud 
        //</Summary>

        #region Declaraciones -
            //DataTable
        DataTable DataT;
         //Solicitudes capa data 
        D_Solicitud d_Solicitud;

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la clase de negocio solicitud
        /// </summary>
        public N_Solicitud()
        {
            //DataTable
            DataT = new DataTable();

            d_Solicitud= new D_Solicitud();

        }

        #endregion

        #region Obtener Solicitudes -
        /// <summary>
        /// Metodo Obtener Solicitudes el cual devuelve un DataTable 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerSolicitudes()
        {
            //Ejecutando el metodo y obteniendo el resultado
            DataT = d_Solicitud.ObtenerSolicitudes();

            //Resultados devueltoss
            return DataT;

        }

        #endregion

        #region Crear Solicitudes -
        /// <summary>
        /// Metodo Crear Solicitud el cual espera como parametro una entidad solicitud y devuelve su ID
        /// </summary>
        /// <param name="e_So"></param>
        /// <returns></returns>
        public int CrearSolicitud(E_Solicitud e_So)
        {
            int ID = 0;

            ID = d_Solicitud.CrearSolicitud(e_So);

            return ID;

        }



        #endregion

        #region obtenerSolicitud -
        /// <summary>
        /// Metodo Obtener Solicitud el cual espera como parametro un ID de una solicitud y devuelve una entidad solicitud 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public E_Solicitud ObtenerSolicitud(int ID_Solicitud)
        {
            //Instanciando la solicitud
            E_Solicitud e_Solicitud = new E_Solicitud();

            //Ejecutando el metodo en la capa de datos 
            e_Solicitud = d_Solicitud.ObtenerSolicitud(ID_Solicitud);

            //Retornando la entidad de solicitud
            return e_Solicitud;
        }


        #endregion

        #region Actualizar Solicitud -
        /// <summary>
        /// Metodo Actualizar solicitud el cual espera como parametro una entidad Solicitud  y devuelve las filas afectadas
        /// </summary>
        /// <param name="e_So"></param>
        /// <returns></returns>
        public int ActualizarSolicitud(E_Solicitud e_So)
        {
            //Variables 
            int FilasAfectadas = 0;

            //Ejecutando el metodo en la capa de datos y esperando el resultado 
            FilasAfectadas = d_Solicitud.ActualizarSolicitud(e_So);

            //Retornando las Filas Afectadas 
            return FilasAfectadas;
        }


        #endregion

        #region Eliminar Solicitud -
        /// <summary>
        /// Metodo Eliminar una solicitud 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <returns></returns>
        public int EliminarSolicitud(int ID_Solicitud)
        {
            //Variables 
            int FilasAfectadas = 0;
            //-----//
            
            //Ejecutando el metodo en la capa de datos 
            FilasAfectadas = d_Solicitud.EliminarSolicitud(ID_Solicitud);

            //Retornando las Filas Aafectadas 
            return FilasAfectadas;
        }


        #endregion

        #region Aprobar Solcisitud -
        /// <summary>
        /// Metodo Aprobar Solicitud  Espera como parametros un ID de una solicitud y un usuario
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int AprobarSolicitud(int ID_Solicitud, String usuario)
        {
            //Filas Afectadas
            int FilasAfectada = 0;

            //Ejecutando el metodo en la capa de data de la solicitud
            FilasAfectada = d_Solicitud.AprobarSolicitud(ID_Solicitud , usuario);

            //Retornando el Valor
            return FilasAfectada;
        }


        #endregion

        #region Desaprobar Solicitud -
        /// <summary>
        /// DEsaprobar Solicitud  espera como parametros un ID de una solicitud  y un usuario 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int DesaprobarSolicitud(int ID_Solicitud, String usuario)
        {
            //Filas Afectadas 
            int FilasAfectada = 0;

            //Ejecutando el metodo en la capa de data de la solicitud 
            FilasAfectada = d_Solicitud.DesaprobarSolicitud(ID_Solicitud, usuario);

            //Retornando las Filas Afectadas 
            return FilasAfectada;
        }

        #endregion


    }
}
