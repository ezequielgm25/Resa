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

        #region Obtener Servicios Globales
        public DataTable ObtenerServiciosGlobales()
        {
            //Declarando data Adapter
            DataTable DataT = new DataTable();
            //instanciando el metodo y recogiendo el resultado
            DataT = d_Servicio.ObtenerServiciosGlobales();
            //Returnando el dataT
            return DataT;
        }

        #endregion

        #region Eliminar Servicio Global

        public int  EliminarServicioGlobal(int ID_S)
        {

            int FilasAfectadas;

            FilasAfectadas = d_Servicio.EliminarServicioGlobales(ID_S);

            return FilasAfectadas;

        }



        #endregion

        #region Insertar Un servicio Global 

        public int InsertarServicioGlobal(String Servicio)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Servicio.InsertarServicioGlobal(Servicio);

            return FilasAfectadas;

        }


        #endregion


        #region Verificar Existencia del Servicio 
        public int VerificarExistenciaDeServicio(E_Servicio e_Servicio)
        {
            int Resultado = 0;

            Resultado = d_Servicio.VerificarExistenciaDeServicio(e_Servicio);


            return Resultado;

        }



        #endregion

        #region Eliminar Servicio por servicio y ID
        public int EliminarSercvicioXS_ID(E_Servicio e_Servicio)
        {
            int FilasAfectadas;

            FilasAfectadas = d_Servicio.EliminarSercvicioXS_ID(e_Servicio);

            return FilasAfectadas;

        }
        #endregion 

    }
}
