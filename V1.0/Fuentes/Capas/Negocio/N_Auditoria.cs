
//Usings del sistema
using Capas.Data;
using Capas.Infraestructura.Entidades;

namespace Capas.Negocio
{
    public class N_Auditoria
    {

        //<Summary>
        // Clase de donde se gestionara las iteracciones en la capa de negocio de la entidad auditoria
        //</Summary>

        #region Declaraciones 

        private D_Auditoria d_Auditoria;

        private E_Auditoria e_Auditoria;

        #endregion

        #region Contructor 
        /// <summary>
        /// Constructor de la clase auditoria en la capa de negocio
        /// </summary>
        public N_Auditoria()
        {
            //Instancias 
            d_Auditoria = new D_Auditoria();

            e_Auditoria = new E_Auditoria();


        }

        #endregion

        #region Insertar Auditoria +
        /// <summary>
        /// Metodo donde se inserta una auditoria a un usuario 
        /// </summary>
        /// <param name="e_Au"></param>
        /// <returns></returns>
        public int InsertarAuditoria(E_Auditoria e_Au )
        {

            //Recogiendo las filas afectadas
            int FilasAfectadas = d_Auditoria.InsertarAuditoria(e_Au);

            //Retornando 
            return FilasAfectadas;
        }
        


        #endregion


    }
}
