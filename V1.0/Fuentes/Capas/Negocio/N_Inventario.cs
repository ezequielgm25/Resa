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
    public class N_Inventario
    {
        //<Summary>
        //Clase de la capa de negocio de los inventarios encargada de la logistica 
        //</Summary>

        #region Declaraciones

        D_Inventario d_Inventario;

        #endregion

        #region Contructor 
        public N_Inventario()
        {

            d_Inventario = new D_Inventario();

        }

        #endregion

        #region Agregar Inventario

        public int AgregarInventario(E_Inventario e_Inventario)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Inventario.AgregarInventario(e_Inventario);

            return FilasAfectadas;
        }

        #endregion

        #region Obtener Inventarios

        public DataTable ObtenerInventarios(int id_Salon)
        {
            DataTable DataT = new DataTable();

            DataT = d_Inventario.ObtenerInventarios(id_Salon);

            return DataT;
        }
        #endregion


        #region Eliminar Inventario

        public int EliminarInventario(int ID_Inventario)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Inventario.EliminarInventario(ID_Inventario);


            return FilasAfectadas;


        }

        #endregion


    }
}
