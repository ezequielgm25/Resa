using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Evento
    {
        //<Summary>
        // Entidad Evento esta clase abarcara las variables y propiedades
        //</Summary>

        #region Variables 

        private int ID_Evento;

        private string Titulo_Evento;

        private String Descripcion;

        private String Tipo;

        private String Topico;

        private string Tiempo_Inicio;

        private string  Tiempo_Final;

        private int ID_Solicitud;




        #endregion

        #region Propiedades 

        public int id_Evento
        {
            get { return ID_Evento; }
            set { ID_Evento = value;}
        }

        public string titulo_Evento
        {
            get { return Titulo_Evento;  }
            set { Titulo_Evento = value; }
        }
         
        public string descripcion
        {
            get { return Descripcion;  }
            set { Descripcion = value; }
        } 
        public string tipo
        {
            get { return Tipo;  }
            set { Tipo = value; }
        }

        public string topico
        {
            get { return Topico;  }
            set { Topico = value; }

        }

        public string tiempo_Inicio
        {
            get { return Tiempo_Inicio; }
            set { Tiempo_Inicio = value; }

        }

        public string  tiempo_Final 
        {
            get { return Tiempo_Final; }
            set { Tiempo_Final = value; }

        }

        public int id_Solicitud
        {
            get { return ID_Solicitud;  }
            set { ID_Solicitud = value; }

        }

        #endregion

    }
}
