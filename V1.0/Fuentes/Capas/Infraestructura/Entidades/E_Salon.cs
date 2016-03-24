using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Salon
    {
        //<Summary>
        //Clase Entidad de los salones
        //</Summary>

        #region Variables

        private int ID_Salon;

        private string Nombre;

        private string Ubicacion;

        private int Capacidad;

        private string Estado;

        
        #endregion


        #region Propiedades 

        public int id_Salon
        {
            get { return ID_Salon; }
            set { ID_Salon = value;}
        }

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string ubicacion 
        {
            get { return Ubicacion; }
            set { Ubicacion = value; }
        }
        public int capacidad
        {
            get { return Capacidad; }
            set { Capacidad = value; }
        }


        public string estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        #endregion


    }
}
