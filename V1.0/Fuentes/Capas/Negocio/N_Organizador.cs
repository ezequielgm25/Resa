using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public N_Organizador()
        {
          
            d_Organizador = new D_Organizador();

        }

        #endregion

        #region Insertar organizador
        public int insertarOrganizador(E_Organizador e_Or)
        {
            int ID = 0;

            ID = d_Organizador.InsertarOrganizador(e_Or);

            return ID;

        }
        #endregion

        #region obtener organizador
        public E_Organizador Obtenerorganizador(int ID_Evento)
        {
            E_Organizador e_Organizador= new E_Organizador();

            e_Organizador = d_Organizador.ObtenerOrganizador(ID_Evento);


            return e_Organizador;
        }


        #endregion

        #region Actualizar Organizador

        public int ActualizarOrganizador(E_Organizador e_Or)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Organizador.ActualizarOrganizador(e_Or);


            return FilasAfectadas;
        }


        #endregion

        //Trabajando los organizadores Globales 

        #region obtener Organizadores Globales
        public DataTable ObtenerOrganizadoresGlobales()
        {
            DataTable DT = new DataTable();

            DT = d_Organizador.ObteniendoOrganizadoresGlobales();

            return DT;
        }

        #endregion

        #region Insertar Organizador Global 
        public int InsertarOrganizadorGlobal(E_Organizador e_Or)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Organizador.AgregandoOrganizadorGlobal(e_Or);

            return FilasAfectadas;
        }


        #endregion


        #region  Actualizar Organizador Global
        public int ActualizarOrganizadorGlobal(E_Organizador e_Or)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Organizador.ActualizarOrganizadorGlobal(e_Or);

            return FilasAfectadas;
        }

        #endregion

        #region Eliminar Organizador 
        public int EliminarOrganizadorGlobal(int ID_Or)
        {
            int FilasAfectadas;

            FilasAfectadas = d_Organizador.EliminarOrganizadorGlobal(ID_Or);

            return FilasAfectadas;

        }


        #endregion
    }
}
