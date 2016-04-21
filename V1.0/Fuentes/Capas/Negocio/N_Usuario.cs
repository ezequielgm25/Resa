using System;
using Capas.Data;
using Capas.Infraestructura.Entidades;
using System.Data;

namespace Capas.Negocio
{
    public class N_Usuario
    {

        //<Summary>
        // Clase de donde se gestionara las iteracciones en la capa de negocio de la entidad usuario
        //</Summary>

        #region Declaraciones 

        private D_Usuario d_Usuario;

        private E_Usuario e_Usuario;

        #endregion

        #region Contructor 
        /// <summary>
        /// Constructor de la  clase  de  usuario en la capa de negocio
        /// </summary>
        public N_Usuario()
        {
            //Instancias 
            d_Usuario = new D_Usuario();

            e_Usuario = new E_Usuario();


        }

        #endregion

        #region Obtener Usuario
        /// <summary>
        /// Metodo de obtener un usuario Espera un ID de usuario como parametro y retorna una entidad
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {
            //Se le asigna la entidad devuelta 
            e_Usuario = d_Usuario.ObtenerUsuario(ID_Usuario);

            // se retorna
            return e_Usuario;
        }

        #endregion

        #region Obtener Usuarios 
        /// <summary>
        /// Metodo donde se obtienen los usuarios almacenados en el sistema
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerUsuarios()
        {
            //DataTable 
            DataTable DT = new DataTable();
            //Llenando DataTable
            DT = d_Usuario.ObteneruSuarios();


            //Retornando el mismo
            return DT;


        }


        #endregion

        #region Verificar Existencia de usuario +
        /// <summary>
        /// Metodo donde se verifica la existencia de un usuario en el sistema para evitar la repeticion
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int VerficarExistenciaUsuario(String Usuario)
        {

            //Esperando el resultado 
            int Resultado = d_Usuario.VerificarExistenciaDeUsuario(Usuario);

            //Devolviendo el resultado 
            return Resultado;
        }



        #endregion

        #region Insertar Rol +
        /// <summary>
        /// Metodo donde se inserta un rol a un usuario 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="ID_GrupoUsuario"></param>
        /// <returns></returns>
        public int InsertarRol(String Rol, int ID_GrupoUsuario)
        {
            //Esperando el ID del mismo 
            int ID = d_Usuario.InsertarRol(Rol, ID_GrupoUsuario);
            //Returnando el ID del rol asignado all Usuario 
            return ID;
        }


        #endregion

        #region Insertar usuario +
        /// <summary>
        /// Metodo en el cual se inserta un usuario al sistema 
        /// </summary>
        /// <param name="e_U"></param>
        /// <returns></returns>

        public int InsertarUsuario(E_Usuario e_U)
        {
            //Se espera como resultado un ID de usuario
            int ID = d_Usuario.InsertarUsuario(e_U);

            //Se retorna el mismo
            return ID;
        }


        #endregion

        #region  Insertar perfil +
        /// <summary>
        /// Metodo donde se inserta un perfil a un usuario  y se retorna el ID del mismo
        /// </summary>
        /// <param name="perfil"></param>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public int InsertarPerfil(string perfil, int ID_Usuario)
        {
            //Se inserta y se recupera el ID del mismo 
            int ID = d_Usuario.InsertarPerfil(perfil, ID_Usuario);
            //ID 
            return ID;
        }


        #endregion

        #region Insertar Opcion +
        /// <summary>
        /// Metodo para insertar una opcion a un usuario y devolver el ID de la misma 
        /// </summary>
        /// <param name="Opcion"></param>
        /// <param name="ID_Perfil"></param>
        /// <returns></returns>
        public int InsertarOpcion(string Opcion, int ID_Perfil)
        {
            //Recuperando el Id y insertando la opcion 
            int ID = d_Usuario.InsertarOpcion(Opcion, ID_Perfil);

            //Retornando ID
            return ID;

        }


        #endregion

        #region Insertar Funcion +
        /// <summary>
        /// Metodo donde se inserta una funcion a un usuario 
        /// </summary>
        /// <param name="Funcion"></param>
        /// <param name="Estado"></param>
        /// <param name="ID_Opcion"></param>
        /// <returns></returns>
        public int InsertarFuncion(string Funcion, bool Estado, int ID_Opcion)
        {

            //Recuperando las filas Afectadas 
            int FilasAfectadas = d_Usuario.InsertarFuncion(Funcion, Estado, ID_Opcion);

            //Retornando las filas Afectadas 
            return FilasAfectadas;

        }



        #endregion

        #region Informacion detallada de un usuario +
        /// <summary>
        /// Obteniendo Informacion detallada  de un usuario a travez de su ID
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>

        public E_Usuario ObtenerInformacionDetallada(int ID_Usuario)
        {

            //Se completa una entidad con los datos devueltos 
            e_Usuario = d_Usuario.ObtenerInformacionDetallada(ID_Usuario);

            //Se retornan los datos 
            return e_Usuario;
        }

        #endregion

        #region Optener El ID_Perfil  +
        /// <summary>
        /// Metodo donnde se obtiene El ID del perfil de un usuario 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>

        public int ObtenerPerfil(int ID_Usuario)
        {
            //Se recupera el ID
            int ID = d_Usuario.obtenerPerfil(ID_Usuario);
            //Se retorna el ID
            return ID;
        }


        #endregion

        #region Optener ID_Opcion +
        /// <summary>
        /// Metodo donde se obtiene el ID de la opcion de un usuario 
        /// </summary>
        /// <param name="Opcion"></param>
        /// <param name="ID_Perfil"></param>
        /// <returns></returns>

        public int ObtenerIDOpcion(string Opcion, int ID_Perfil)
        {
            //Se recupera el ID 
            int ID = d_Usuario.ObtenerID_Opcion(Opcion, ID_Perfil);
            //ID 
            return ID;
        }


        #endregion

        #region Obtener Funcion +
        /// <summary>
        /// Metodo donde se obtiene si una funcion esta activa para un usuario 
        /// </summary>
        /// <param name="ID_Opcion"></param>
        /// <param name="Funcion"></param>
        /// <returns></returns>
        public Boolean ObtenerFuncion(int ID_Opcion, String Funcion)
        {
            //Variable que obtiene el usuario 
            Boolean Resultado = d_Usuario.ObtenerFuncion(ID_Opcion, Funcion);


            //Returnando el resultado
            return Resultado;
        }



        #endregion

        #region Actualizar Rol +
        /// <summary>
        /// Metodo donde se actualiza un rol de un usuario 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="ID_GRupoUsuario"></param>
        /// <param name="ID_Rol"></param>
        /// <returns></returns>
        public int ActualizarRol(string Rol, int ID_GRupoUsuario, int ID_Rol)
        {

            //Recogienndo el resultado
            int FilasAfectadas = d_Usuario.ActualizarRol(Rol, ID_GRupoUsuario, ID_Rol);

            //Devolviendo el resultado 
            return FilasAfectadas;
        }



        #endregion

        #region Actualizar Usuario  + 
        /// <summary>
        /// Metodo donde se actualizan las caracteristicas de un usuario 
        /// </summary>
        /// <param name="E_U"></param>
        /// <returns></returns>
        public int ActualizarUsuario(E_Usuario E_U)
        {

            //Retornando el resultado si hubo filas afectadas
            int FilasAfectadas = d_Usuario.ActualizarUsuario(E_U);

            //Devolviendo   Las filas afectadas 
            return FilasAfectadas;
        }


        #endregion

        #region Actualizar Perfil +
        /// <summary>
        /// Metodo donde se actualiza un perfil de un usuario 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <param name="perfil"></param>
        /// <returns></returns>
        public int ActualizarPerfil(int ID_Usuario, string perfil)
        {
            //Recogiendo las filasAfectadas
            int FilasAfectadas = d_Usuario.ActualizarPerfil(ID_Usuario, perfil);

            //Retornando las filas Afectadas 
            return FilasAfectadas;
        }


        #endregion

        #region  Actuallizar Funcion +
        /// <summary>
        /// Metodo donde se actualiza la funcion -- se activa o se desactiva una funcion a un usuario --
        /// </summary>
        /// <param name="ID_Opcion"></param>
        /// <param name="Funcion"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public int ActualizarFuncion(int ID_Opcion, String Funcion, bool Estado)
        {
            //Recogiendo el resultado 
            int FilasAfectadas = d_Usuario.ActualizarFuncion(ID_Opcion, Funcion, Estado);

            //Returnando las FilasAfectadas
            return FilasAfectadas;
        }


        #endregion

        #region Eliminar Usuario +
        /// <summary>
        /// Metodo Donde se elimina un usuario de la base de datos 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public int EliminarUsuario(int ID_Usuario)
        {
            //Recogiendo las dilas afectadas en la base de datos 
            int FilasAfectadas = d_Usuario.EliminarUsuario(ID_Usuario);

            //Retornando las filas afectadas 
            return FilasAfectadas;
        }



        #endregion

    }
}
