using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public N_Auditoria()
        {
            d_Auditoria = new D_Auditoria();

            e_Auditoria = new E_Auditoria();


        }

        #endregion


        #region Insertar Auditoria '
        public int InsertarAuditoria(E_Auditoria e_Au )
        {


            int FilasAfectadas = d_Auditoria.InsertarAuditoria(e_Au);

            return FilasAfectadas;
        }
        


        #endregion


    }
}
