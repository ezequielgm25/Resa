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
    public class N_Salon
    {
        //<Summary>
        //Clase de la capa de negocio de la entidad salon que administrara la logistica 
        //</Summary>

        #region Declaraciones -
        DataTable DataT;

        D_Salon d_Salon;

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la clase de N_Salon
        /// </summary>
        public N_Salon()
        {
            //Asignando las instancias
            DataT = new DataTable();
            d_Salon = new D_Salon();

        }

        #endregion

        #region Obtener Salones -
        /// <summary>
        /// Metodo obtener los salones debuelve un DataTable 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerSalones()
        {
            //Se ejecuta el evento en la capa de data
            DataT = d_Salon.ObtenerSalones(); 

           //Se retorna el resultado 
            return DataT;

        }

        #endregion

        #region Crear Salon -
        /// <summary>
        /// Metodo de crear salon el cual retorna el ID del salon y acepta como parametro una entidad de salon
        /// </summary>
        /// <param name="e_s"></param>
        /// <returns></returns>
        public int CrearSalon(E_Salon e_s)
        {
            //Variable que recogera el ID 
            int ID = 0;

            //SE ejecuta el metodo de la capa Data 
            ID = d_Salon.CrearSalon(e_s);   

            //Se retorna el ID 
            return ID;
        }
        #endregion

        #region Actualizar Salones -
        /// <summary>
        /// Metoodo de actualizar un salon el cual acepta como parametro una entidad Salon y devuelve  un numero de filas afectadas
        /// </summary>
        /// <param name="e_Salon"></param>
        /// <returns></returns>
        public int ActualizarSalon(E_Salon e_Salon)
        {
            //Variable que recogera las filas Afectadas 
            int FilasAfectadas = 0;
            //Evento de actualizacion de un salon en la capa de datos 
            FilasAfectadas = d_Salon.ActualizarSalon(e_Salon);

            //Retornando las filas afectadas
            return FilasAfectadas;
        }

        #endregion

        #region Elimar Salon -
        /// <summary>
        /// Metodo de eliminar un salon que acepta como parametro un ID_Usuario  y devuelve las filas afectadas 
        /// </summary>
        /// <param name="ID_Salon"></param>
        /// <returns></returns>
        public int EliminarSalon(int ID_Salon)
        {
            //Variable que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Metodo en la capa data que elimina un salon 
            FilasAfectadas = d_Salon.EliminarSalon(ID_Salon);


            //se retorna las Filas Afectadas 
            return FilasAfectadas;
        }

        #endregion

        #region Obtener ID Y Nombre de todos los Salones  - 
        /// <summary>
        /// Metodo que obtiene solo dos caracteristicas de los salones "ID" y "Nombre"
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerID_NombreDeSalones()
        {
            //Retornara los Id y nombres de los salones
            DataT = d_Salon.ObtenerID_NombreDeSalones();

            //Retorna el DataTable 
            return DataT;

        }

        #endregion

        //Trabajando las Ubicaciones dinamicas 

        #region Obtener Ubicaciones Globales
        public DataTable ObtenerUbicacionesGlobales()
        {

            //Se ejecuta el evento en la capa de data
            DataT = d_Salon.ObtenerUbicacionesGlobales();


            //Se retorna el resultado 
            return DataT;


        }

        #endregion

        #region Agregar Ubicacion Global 
        public int AgregarUbicacionGlobal(string Ubicacion)
        {
            int FilasAfectadas;

            FilasAfectadas = d_Salon.AgregarUbicacionGlobal(Ubicacion);


            return FilasAfectadas;
        }


        #endregion


        #region Eliminar Ubicacion Global 
        public int EliminarUbicacionGlobal(int ID_Ubicacion)
        {
            int FilasAfectadas;

            FilasAfectadas = d_Salon.EliminarUbicacionGlobal(ID_Ubicacion);

            return FilasAfectadas;


        }
        #endregion

    }
}
