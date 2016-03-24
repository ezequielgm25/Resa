using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
  public   class E_Inventario
    {

        #region Variables
        private int ID_Inventario;

        private String Inventario;

        private int ID_Salon;

        #endregion

        #region Propiedades

        public int id_Inventario
        {
            get { return ID_Inventario; }
            set { ID_Inventario = value; }
        }

        public string inventario
        {
            get { return Inventario; }
            set { Inventario = value; }
        }

        public int id_Salon
        {
            get { return ID_Salon; }
            set { ID_Salon = value; }
        }

        #endregion

    }
}
