using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
   public  class E_Servicio
    {

        #region Variables
        private int ID_Servicio;

        private String Servicio;

        private string Descripcion;

        private int ID_Salon;

        #endregion

        #region Propiedades

        public int id_servicio
        {
            get { return ID_Servicio;  }
            set { ID_Servicio = value; }
        }

        public string servicio
        {
            get { return Servicio;  }
            set { Servicio = value; }
        }

        public string descripcion
        {
            get { return Descripcion;  }
            set { Descripcion = value; }
        }

        public int id_Salon
        {
            get { return ID_Salon;  }
            set { ID_Salon = value; }
        }

        #endregion



    }
}
