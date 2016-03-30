using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Auditoria
    {
        //<Summary>
        // Clase de la entidad auditoria la cual contendra todas las caracteristicas y propiedades de  una auditoria
        //</Summary>

        #region Caracteristicas

        private int ID_Auditoria;

        private int ID_Usuario;

        private string TipoUsuario;

        private string Fecha_Entrada;

        private string Fecha_Salida;

        private string Opcion;

        private string Tipo_Opcion;


        #endregion

        #region Propiedades 

        public int id_Auditoria
        {
            get { return ID_Auditoria;  }
            set { ID_Auditoria = value; }
        }

        public int id_Usuario
        {
            get { return ID_Usuario; }
            set { ID_Usuario = value; }
        }

        public string tipoUsuario
        {
            get { return TipoUsuario; }
            set { TipoUsuario = value; }
        }

        public string fecha_Entrada
        {
            get { return Fecha_Entrada; }
            set { Fecha_Entrada = value; }
        }

        public string fecha_Salida
        {
            get { return Fecha_Salida; }
            set { Fecha_Salida = value; }
        }

        public string opcion
        {
            get { return Opcion; }
            set { Opcion = value; }
        }

        public string tipoOpcion
        {
            get { return Tipo_Opcion; }
            set { Tipo_Opcion = value; }
        }
        #endregion


    }
}
