using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
   public class E_Solicitud
    {
        //<Summary>
        //Clase de la entidad Solicitud 
        //</Summary>

        #region Variables

        private int ID_Solicitud;

        private String Fecha;

        private String Aprobacion;

        private String Usuario;

        private String FechaAprobacion;

        private int ID_Salon;


        #endregion

        #region  Propiedades

        public int id_Solicitud
        {
            get { return ID_Solicitud; }
            set { ID_Solicitud = value; }
        }

        public String fecha
        {
            get { return Fecha;  }
            set { Fecha = value; }
        } 

        public string aprobacion
        {
            get { return Aprobacion;  }
            set { Aprobacion = value; }
        }
        public string usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public string fechaAprobacion
        {
            get { return FechaAprobacion; }
            set { FechaAprobacion = value; }
        }

        public int id_Salon
        {
            get { return ID_Salon;  }
            set { ID_Salon = value; }
        }

        #endregion


    }
}
