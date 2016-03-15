﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capas.Infraestructura.Entidades
{
    public class E_Usuario
    {
        //<Summary>
        //Entidad de usuario que almacenara los datos del usuario que utiliza el sistema 
        //</Summary>

        #region  Variables 
        private int ID_Usuario;

        private string Nombre;

        private String Apellido;

        private string Usuario;

        private string Contraseña;

        private int ID_Rol;


        #endregion

        #region  Propiedades

        public int id_Usuario
        {
            get { return ID_Usuario; }
            set { ID_Usuario = value; }
        }

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string apeliido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        public string usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public string contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }
        
        public int id_rol
        {
            get { return ID_Rol;  }
            set { ID_Rol = value; }
        }

        #endregion
    }
}