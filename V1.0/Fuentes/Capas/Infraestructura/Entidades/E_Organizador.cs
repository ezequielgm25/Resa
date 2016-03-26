using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Organizador
    {
        //<Summary>
        // Clase que contendra las variables y propiedades de la entidad organizador
        //</Summary> 

        #region Variables

        private int ID_Organizador;

        private string Nombre;

        private string Descripcion;

        private String CorreoElectronico;

        private int ID_Evento;
  
        #endregion

        #region Propiedades

        public int id_Organizador
        {
            get { return ID_Organizador;  }
            set { ID_Organizador = value; }
        }

        public string nombre
        {
            get { return Nombre;  }
            set { Nombre = value; }
        }

        public string descripcion
        {
            get { return Descripcion;  }
            set { Descripcion = value; }
        }


        public string correoElectronico
        {
            get { return CorreoElectronico;  }
            set { CorreoElectronico = value; }
        }

        public int id_Evento
        {
            get { return ID_Evento;  }
            set { ID_Evento = value; }
        }
        #endregion
    }

}
