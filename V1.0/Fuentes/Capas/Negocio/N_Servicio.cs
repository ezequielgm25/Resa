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
    public class N_Servicio
    {
        //<Summary>
        //Clase de la capa de negocio de los servicios encargada de la logistica 
        //</Summary>

        #region Declaraciones
        
        D_Servicio d_Servicio;

        #endregion

        #region Contructor 
        public N_Servicio()
        {
            
            d_Servicio = new D_Servicio();

        }

        #endregion

        #region Agregar Servicio
         
          public int AgregarServicio(E_Servicio e_Servicio)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Servicio.AgregarServicio(e_Servicio);

            return FilasAfectadas;
        }

        #endregion

        #region Obtener Servicios

        public DataTable ObtenerServicios(int id_Salon)
        {
            DataTable DataT = new DataTable();

            DataT = d_Servicio.ObtenerServicios(id_Salon);

            return DataT; 
        }
        #endregion

        #region Eliminar Servicio

        public int EliminarServicio(int ID_Servicio)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Servicio.EliminarServicio(ID_Servicio);


            return FilasAfectadas;


        }

        #endregion


    }
}
