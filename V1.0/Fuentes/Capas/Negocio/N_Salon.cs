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

        #region Declaraciones
        DataTable DataT;

        D_Salon d_Salon;

        #endregion

        #region Contructor 
        public N_Salon()
        {
            DataT = new DataTable();
            d_Salon = new D_Salon();

        }

        #endregion

        #region Obtener Salones
        public DataTable ObtenerSalones()
        {

            DataT = d_Salon.ObtenerSalones(); 


            return DataT;

        }

        #endregion

        #region Crear Salon 

        public int CrearSalon(E_Salon e_s)
        {
            int ID = 0;

            ID = d_Salon.CrearSalon(e_s);   

            return ID;
        }
        #endregion

        #region Actualizar Salones

        public int ActualizarSalon(E_Salon e_Salon)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Salon.ActualizarSalon(e_Salon);

            return FilasAfectadas;
        }

        #endregion

        #region Elimar Salon
        public int EliminarSalon(int ID_Salon)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Salon.EliminarSalon(ID_Salon);

            return FilasAfectadas;
        }

        #endregion


        #region Obtener ID Y Nombre de todos los Salones 

        public DataTable ObtenerID_NombreDeSalones()
        {
            //Retornara los Id y nombres de los salones
            DataT = d_Salon.ObtenerID_NombreDeSalones();

            return DataT;

        }

        #endregion

    }
}
