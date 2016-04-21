using System;
using System.Data;

//Usings del sistema 
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
        /// <summary>
        /// Constructor de la clase de inventario en la capa de negocio
        /// </summary>
        public N_Inventario()
        {
            //instancia 
            d_Inventario = new D_Inventario();

        }

        #endregion

        #region Agregar Inventario +
        /// <summary>
        /// Metodo donde se agrega un inventario a un salon
        /// </summary>
        /// <param name="e_Inventario"></param>
        /// <returns></returns>
        public int AgregarInventario(E_Inventario e_Inventario)
        {
            //Variable que recoje las filas afectadas 
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas y ejecutando el metodo 
            FilasAfectadas = d_Inventario.AgregarInventario(e_Inventario);


            //Returnando las filas afectadas 
            return FilasAfectadas;
        }

        #endregion

        #region Obtener Inventarios +
        /// <summary>
        /// Metodo donde se obtienen los inventarios de un salon 
        /// </summary>
        /// <param name="id_Salon"></param>
        /// <returns></returns>
        public DataTable ObtenerInventarios(int id_Salon)
        {
            //DataTable
            DataTable DataT = new DataTable();

            //Ejecutando metodo y llenando el datatable
            DataT = d_Inventario.ObtenerInventarios(id_Salon);

            //Returnando el DataTable
            return DataT;
        }
        #endregion

        #region Eliminar Inventario +
        /// <summary>
        /// Metodo donde se elimina un inventario de un salon 
        /// </summary>
        /// <param name="ID_Inventario"></param>
        /// <returns></returns>
        public int EliminarInventario(int ID_Inventario)
        {
            //Filas  afectadas
            int FilasAfectadas = 0;

            //Recogiendo las filas afectadas 
            FilasAfectadas = d_Inventario.EliminarInventario(ID_Inventario);

            //Retornando
            return FilasAfectadas;


        }

        #endregion

        #region Obtener Inventarios Globales +
        /// <summary>
        /// Metodo donde se obtienen los inventarios globales de los salones
        /// </summary>
        /// <returns></returns>
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

        #region Eliminar Inventario Global +
        /// <summary>
        /// Metodo donde se elimina un inventario global de la lista 
        /// </summary>
        /// <param name="ID_I"></param>
        /// <returns></returns>

        public int EliminarInventarioGlobal(int ID_I)
        {
            //Filas afectadas
            int FilasAfectadas;

            //Recogiendo las filas afectadas 
            FilasAfectadas = d_Inventario.EliminarInventariosGlobales(ID_I);

            //Returnando las filas afectadas 
            return FilasAfectadas;

        }



        #endregion

        #region Insertar Un Inventario Global +
        /// <summary>
        /// Metodo donde se inserta un inventario global a la lista 
        /// </summary>
        /// <param name="Inventario"></param>
        /// <returns></returns>

        public int InsertarInventarioGlobal(String Inventario)
        {
            //Filas afectadas
            int FilasAfectadas = 0;

            //Filas afectadas 
            FilasAfectadas = d_Inventario.InsertarInventarioGlobal(Inventario);

            //Returnando filas afectadas 
            return FilasAfectadas;

        }


        #endregion

        #region Verificar Existencia del Inventario +
        /// <summary>
        /// Metodo donde se verifica la existencia de un inventario en  un salon 
        /// </summary>
        /// <param name="e_Inventario"></param>
        /// <returns></returns>

        public int VerificarExistenciaDeInventario(E_Inventario e_Inventario)
        {
            //Variable que espera el resultado 
            int Resultado = 0;

            //Recogiendo resultado
            Resultado = d_Inventario.VerificarExistenciaDeInventario(e_Inventario);

            //Retornando
            return Resultado;

        }
        #endregion

        #region Eliminar inventario por servicio y ID +
        /// <summary>
        /// Metodo donde se elimina un inventario de  u
        /// </summary>
        /// <param name="e_Inventario"></param>
        /// <returns></returns>
        public int EliminarInventarioXS_ID(E_Inventario e_Inventario)
        {
            //Variable que recojera las filas afectadas
            int FilasAfectadas;

            //Recogiendo las filas afectadas y ejecutando los metodos 
            FilasAfectadas = d_Inventario.EliminarInventarioXS_ID(e_Inventario);

            //Returnando las filas afectadas
            return FilasAfectadas;

        }
        #endregion 

    }
}
