
using System.Data;

//Usings del sistema 
using Capas.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Negocio
{
    public class N_Organizador
    {
        //<Summary>
        // Clase que avergara la logistica de la entidad organizador
        //</Summary>


        #region Declaraciones


        D_Organizador d_Organizador;

        #endregion

        #region Contructor 
        /// <summary>
        /// Constructor de la clase en la capa de negocio de organizador
        /// </summary>
        public N_Organizador()
        {
            //Instancia 
            d_Organizador = new D_Organizador();

        }

        #endregion

        #region Insertar organizador +
        /// <summary>
        /// Metodo donde se inserta un organizador 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>

        public int insertarOrganizador(E_Organizador e_Or)
        {
            //Variable que recoje el ID
            int ID = 0;

            //Se inserta el organizador y se recibe el ID 
            ID = d_Organizador.InsertarOrganizador(e_Or);


            //Returnando el ID 
            return ID;

        }
        #endregion

        #region obtener organizador +
        /// <summary>
        /// Metodo donde se obtiene un organizador -- todas sus caracteristicas
        /// </summary>
        /// <param name="ID_Evento"></param>
        /// <returns></returns>
        public E_Organizador Obtenerorganizador(int ID_Evento)
        {
            //Entidad que sera retornada 
            E_Organizador e_Organizador = new E_Organizador();

            //Recogiendo los datos devueltos y ejecutando el metodo
            e_Organizador = d_Organizador.ObtenerOrganizador(ID_Evento);

            //Retornando la entidad
            return e_Organizador;
        }


        #endregion

        #region Actualizar Organizador +
        /// <summary>
        /// Metodo donde se actualiza un organizador 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>

        public int ActualizarOrganizador(E_Organizador e_Or)
        {
            //Variable que recoje las filas afectadas 
            int FilasAfectadas = 0;

            //Filas afectadas 
            FilasAfectadas = d_Organizador.ActualizarOrganizador(e_Or);

            //Returnando las filas afectadas 
            return FilasAfectadas;
        }


        #endregion

        //Trabajando los organizadores Globales 

        #region obtener Organizadores Globales +
        /// <summary>
        /// Metodo donde se obtienen los organizadores de la lista de organizadores globales 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerOrganizadoresGlobales()
        {
            //DataTable 
            DataTable DT = new DataTable();

            //Llenando el DataTable 
            DT = d_Organizador.ObteniendoOrganizadoresGlobales();

            //Returnando el DataTable 
            return DT;
        }

        #endregion

        #region Insertar Organizador Global +
        /// <summary>
        /// Metodo donde se inserta un organizador global a la lista de organizadores 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int InsertarOrganizadorGlobal(E_Organizador e_Or)
        {

            //Variable que recoje  las filas afectadas
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas y ejecutando el metodo 
            FilasAfectadas = d_Organizador.AgregandoOrganizadorGlobal(e_Or);

            //Returnando las filas afectadas
            return FilasAfectadas;
        }


        #endregion

        #region  Actualizar Organizador Global +
        /// <summary>
        /// Metodo donde se actualiza un organizador Global 
        /// </summary>
        /// <param name="e_Or"></param>
        /// <returns></returns>
        public int ActualizarOrganizadorGlobal(E_Organizador e_Or)
        {
            //Variable que recoje las Filas afectadas 
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas y ejecutando el metodo 
            FilasAfectadas = d_Organizador.ActualizarOrganizadorGlobal(e_Or);

            //Returnando las filas afectadas 
            return FilasAfectadas;
        }

        #endregion

        #region Eliminar Organizador  global +
        /// <summary>
        /// Metodo donde se elimina un organizador de la lista de organizadores globales 
        /// </summary>
        /// <param name="ID_Or"></param>
        /// <returns></returns>

        public int EliminarOrganizadorGlobal(int ID_Or)
        {
            //Variable que recoje las filas afectadas 
            int FilasAfectadas;

            //Recogiendo las filas afectadas y ejecutando el metodo en la capa de datos
            FilasAfectadas = d_Organizador.EliminarOrganizadorGlobal(ID_Or);

            //Returnando Filas afectadas
            return FilasAfectadas;

        }


        #endregion
    }
}
