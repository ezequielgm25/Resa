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
        //Clase de la capa de negocio de los inventarios encargada de la logistica D:\Resa\V1.0\Fuentes\Capas\Negocio\N_Inventario.cs
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

        #region Obtener Inventarios Globales
        public DataTable ObtenerInventariosGlobales()
        {
            //Declarando data Adapter
            DataTable DataT = new DataTable();
            //instanciando el metodo y recogiendo el resultado
            DataT = d_Inventario.ObtenerInventariosGlobales();
            //Returnando el dataT
            return DataT;
        }

        #endregion

        #region Eliminar Inventario Global

        public int EliminarInventarioGlobal(int ID_I)
        {

            int FilasAfectadas;

            FilasAfectadas = d_Inventario.EliminarInventariosGlobales(ID_I);

            return FilasAfectadas;

        }



        #endregion

        #region Insertar Un Inventario Global 

        public int InsertarInventarioGlobal(String Inventario)
        {
            int FilasAfectadas = 0;

            FilasAfectadas = d_Inventario.InsertarInventarioGlobal(Inventario);

            return FilasAfectadas;

        }


        #endregion

        #region Verificar Existencia del Inventario 
        public int VerificarExistenciaDeInventario(E_Inventario e_Inventario)
        {
            int Resultado = 0;

            Resultado = d_Inventario.VerificarExistenciaDeInventario(e_Inventario);


            return Resultado;

        }
        #endregion


        #region Eliminar inventario por servicio y ID
        public int EliminarSercvicioXS_ID(E_Inventario e_Inventario)
        {
            int FilasAfectadas;

            FilasAfectadas = d_Inventario.EliminarInventarioXS_ID(e_Inventario);

            return FilasAfectadas;

        }
        #endregion 

    }
}
