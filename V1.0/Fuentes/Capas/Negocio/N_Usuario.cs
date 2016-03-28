using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public N_Usuario()
        {
            d_Usuario = new D_Usuario();

            e_Usuario = new E_Usuario();


        }

        #endregion

        #region Obtener Usuario
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {

            e_Usuario = d_Usuario.ObtenerUsuario(ID_Usuario);


            return e_Usuario;
        }

        #endregion

        #region Obtner Usuarios 
        public DataTable ObtenerUsuarios()
        {
            DataTable DT = new DataTable();

            DT = d_Usuario.ObteneruSuarios();



            return DT;


        }


        #endregion

        #region Verificar Existencia de usuario
        public int VerficarExistenciaUsuario(String Usuario)
        {

            int Resultado = d_Usuario.VerificarExistenciaDeUsuario(Usuario);


            return Resultado;
        }



        #endregion


        #region Insertar Rol 
        public int InsertarRol(String Rol, int ID_GrupoUsuario)
        {
            int ID = d_Usuario.InsertarRol(Rol, ID_GrupoUsuario);

            return ID;
        }


        #endregion


        #region Insertar usuario 

        public int InsertarUsuario(E_Usuario e_U)
        {

            int ID = d_Usuario.InsertarUsuario(e_U);

            return ID;
        }


        #endregion


        #region  Insertar perfil
        public int InsertarPerfil(string perfil, int ID_Usuario)
        {

            int ID = d_Usuario.InsertarPerfil(perfil, ID_Usuario);


            return ID;
        }


        #endregion


        #region Insertar Opcion
        public int InsertarOpcion(string Opcion, int ID_Perfil)
        {

            int ID = d_Usuario.InsertarOpcion(Opcion, ID_Perfil);


            return ID;

        }


        #endregion



        #region Insertar Funcion
        public int InsertarFuncion(string Funcion, bool Estado, int ID_Opcion)
        {
            int FilasAfectadas = d_Usuario.InsertarFuncion(Funcion, Estado, ID_Opcion);


            return FilasAfectadas;

        }



        #endregion



        #region Informacion detallada de un usuario 

        public E_Usuario ObtenerInformacionDetallada(int ID_Usuario)
        {

            e_Usuario = d_Usuario.ObtenerInformacionDetallada(ID_Usuario);


            return e_Usuario;
        }

        #endregion


        #region Optener El ID_Perfil 

        public int ObtenerPerfil(int ID_Usuario)
        {
            int ID = d_Usuario.obtenerPerfil(ID_Usuario);

            return ID;
        }


        #endregion


        #region Optener ID_Opcion 

        public int ObtenerIDOpcion(string Opcion , int ID_Perfil)
        {

            int ID = d_Usuario.ObtenerID_Opcion(Opcion, ID_Perfil);

            return ID;
        }


        #endregion


        #region Obtener Funcion 
        public Boolean ObtenerFuncion( int ID_Opcion, String Funcion)
        {

            Boolean  Resultado = d_Usuario.ObtenerFuncion(ID_Opcion, Funcion);

  

            return Resultado;
        }



        #endregion


        #region Actualizar Rol 
       public int ActualizarRol(string Rol , int ID_GRupoUsuario, int ID_Rol)
        {


            int FilasAfectadas = d_Usuario.ActualizarRol(Rol, ID_GRupoUsuario, ID_Rol);


            return FilasAfectadas;
        }



        #endregion

        #region Actualizar Usuario 

        public int ActualizarUsuario(E_Usuario E_U)
        {


            int FilasAfectadas = d_Usuario.ActualizarUsuario(E_U);


            return FilasAfectadas;
        }


        #endregion

        #region Actualizar Perfil
        public int ActualizarPerfil(int ID_Usuario , string perfil)
        {

            int FilasAfectadas = d_Usuario.ActualizarPerfil(ID_Usuario, perfil);


            return FilasAfectadas;
        }


        #endregion


        #region  Actuallizar Funcion
        public int ActualizarFuncion(int ID_Opcion, String Funcion,bool Estado)
        {

            int FilasAfectadas = d_Usuario.ActualizarFuncion(ID_Opcion , Funcion , Estado);


            return FilasAfectadas;
        }


        #endregion


        #region Eliminar Usuario
        public int EliminarUsuario(int ID_Usuario)
        {

            int FilasAfectadas = d_Usuario.EliminarUsuario(ID_Usuario);

            return FilasAfectadas;
        }



        #endregion

    }
}
