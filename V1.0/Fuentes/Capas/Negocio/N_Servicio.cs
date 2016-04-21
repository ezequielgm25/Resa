using System;



//Usings del sistema
using Capas.Data;
using Capas.Infraestructura.Entidades;
using System.Data;

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

        #region Contructor +
        /// <summary>
        /// Constructor del sistema 
        /// </summary>
        public N_Servicio()
        {
            //Instancia de la clase de servicio en la capa de datos 
            d_Servicio = new D_Servicio();

        }

        #endregion

        #region Agregar Servicio +
        /// <summary>
        /// Metodo donde se agrega un servicio a un salon 
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int AgregarServicio(E_Servicio e_Servicio)
        {
            //Filas afectadas
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas
            FilasAfectadas = d_Servicio.AgregarServicio(e_Servicio);

            //Returnando las filas afectadas
            return FilasAfectadas;
        }

        #endregion

        #region Obtener Servicios +
        /// <summary>
        /// Metodo Donde se obtienen los servicios de los salon 
        /// </summary>
        /// <param name="id_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerServicios(int id_Salon)
        {
            //DataTable
            DataTable DataT = new DataTable();

            //Llenando el DataTable
            DataT = d_Servicio.ObtenerServicios(id_Salon);

            //Returnando el DataTable
            return DataT;
        }
        #endregion

        #region Eliminar Servicio +
        /// <summary>
        /// metodo donde se elimina un servicio del sistema 
        /// </summary>
        /// <param name="ID_Servicio"></param>
        /// <returns></returns>

        public int EliminarServicio(int ID_Servicio)
        {
            //Filas Afectadas 
            int FilasAfectadas = 0;

            //Recogiendo las filas Afectadas 
            FilasAfectadas = d_Servicio.EliminarServicio(ID_Servicio);

            //Retornando las mismas 
            return FilasAfectadas;


        }

        #endregion

        #region Obtener Servicios Globales +
        /// <summary>
        /// Obteniendo los servicios globales se obtiene la lista de servicios globales de los salones 
        /// </summary>
        /// <returns></returns>
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

        #region Eliminar Servicio Global +
        /// <summary>
        /// Metodo donde se eliminar un servicio global osea de la lista de servicios comunes en los salones 
        /// </summary>
        /// <param name="ID_S"></param>
        /// <returns></returns>

        public int EliminarServicioGlobal(int ID_S)
        {
            //Variable que recoje las filas afectadas
            int FilasAfectadas;

            //Recogiendo las filas afectadas 
            FilasAfectadas = d_Servicio.EliminarServicioGlobales(ID_S);

            //Returnando las filas afectadas
            return FilasAfectadas;

        }



        #endregion

        #region Insertar Un servicio Global +
        /// <summary>
        /// Metodo donde se inserta un servicio a la lista de servicios globales de los salones
        /// </summary>
        /// <param name="Servicio"></param>
        /// <returns></returns>
        public int InsertarServicioGlobal(String Servicio)
        {
            //Variable que recogera las filas afectadas
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas 
            FilasAfectadas = d_Servicio.InsertarServicioGlobal(Servicio);

            //Retornando las filas afectadas
            return FilasAfectadas;

        }


        #endregion

        #region Verificar Existencia del Servicio  +
        /// <summary>
        /// Metodo donde se verifica la existencia de un servicio en un salon
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int VerificarExistenciaDeServicio(E_Servicio e_Servicio)
        {
            //Variable que recojera el resultado 
            int Resultado = 0;

            //Recogiendo el resultado 
            Resultado = d_Servicio.VerificarExistenciaDeServicio(e_Servicio);


            //Retornando el resultado 
            return Resultado;

        }



        #endregion

        #region Eliminar Servicio por servicio y ID +
        /// <summary>
        /// Metodo donde se elimina un servicio por y ID del salon 
        /// </summary>
        /// <param name="e_Servicio"></param>
        /// <returns></returns>
        public int EliminarSercvicioXS_ID(E_Servicio e_Servicio)
        {
            //Filas afectadas 
            int FilasAfectadas;

            //Recogiendo las filas afectadas devuelta
            FilasAfectadas = d_Servicio.EliminarSercvicioXS_ID(e_Servicio);

            //Returnando las filas afectadas
            return FilasAfectadas;

        }
        #endregion 

    }
}
