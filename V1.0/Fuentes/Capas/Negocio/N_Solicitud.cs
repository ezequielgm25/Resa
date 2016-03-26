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

        #region Declaraciones
        DataTable DataT;

        D_Solicitud d_Solicitud;

        #endregion

        #region Contructor 
        public N_Solicitud()
        {
            DataT = new DataTable();
            d_Solicitud= new D_Solicitud();

        }

        #endregion

        #region Obtener Solicitudes
        public DataTable ObtenerSolicitudes()
        {

            DataT = d_Solicitud.ObtenerSolicitudes();


            return DataT;

        }

        #endregion

        #region Crear Solicitudes
        public int CrearSolicitud(E_Solicitud e_So)
        {
            int ID = 0;

            ID = d_Solicitud.CrearSolicitud(e_So);

            return ID;

        }



        #endregion

        #region obtenerSolicitud
        public E_Solicitud ObtenerSolicitud(int ID_Solicitud)
        {
            E_Solicitud e_Solicitud = new E_Solicitud();

            e_Solicitud = d_Solicitud.ObtenerSolicitud(ID_Solicitud);


            return e_Solicitud;
        }


        #endregion

        #region Actualizar Solicitud 

        public int ActualizarSolicitud(E_Solicitud e_So)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Solicitud.ActualizarSolicitud(e_So);


            return FilasAfectadas;
        }


        #endregion

        #region Eliminar Solicitud 
        
        public int EliminarSolicitud(int ID_Solicitud)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Solicitud.EliminarSolicitud(ID_Solicitud);


            return FilasAfectadas;
        }


        #endregion


        #region Aprobar Solcisitud 
        public int AprobarSolicitud(int ID_Solicitud, String usuario)
        {
            int FilasAfectada = 0;

            FilasAfectada = d_Solicitud.AprobarSolicitud(ID_Solicitud , usuario);


            return FilasAfectada;
        }


        #endregion

        #region Desaprobar Solicitud 
        public int DesaprobarSolicitud(int ID_Solicitud, String usuario)
        {
            int FilasAfectada = 0;

            FilasAfectada = d_Solicitud.DesaprobarSolicitud(ID_Solicitud, usuario);


            return FilasAfectada;
        }

        #endregion


    }
}
