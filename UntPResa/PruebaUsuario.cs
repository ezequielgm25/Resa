using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*  - - -  - - */
using Capas.Negocio;
using Capas.Infraestructura.Entidades;


namespace UntPResa
{
    [TestClass]
    public class PruebaUsuario
    {
        [TestMethod]
        public void ObtenerUsuarios()
        {
            //Negocio
            N_Usuario n_Usuario = new N_Usuario();
            //Entidad
            E_Usuario e_Usuario = new E_Usuario();


            //Verifica que no venga vacio el DataTable 
            Assert.IsNotNull(n_Usuario.ObtenerUsuarios());
        }

        [TestMethod]
        public void ProbandoCrearUsuario()
        {

            //Negocio
            N_Usuario n_Usuario = new N_Usuario();
            //Entidad
            E_Usuario e_Usuario = new E_Usuario();

            e_Usuario.nombre = "Rogelio";
            e_Usuario.apellido = "Cruz";
            e_Usuario.contraseña = "1234";
            e_Usuario.usuario = "RogeC";
            e_Usuario.estado = "Activo";
            e_Usuario.id_Rol = 33;

            int NoTexpected = 0;

            e_Usuario.id_Usuario = n_Usuario.InsertarUsuario(e_Usuario);

            Assert.AreNotEqual(NoTexpected, e_Usuario.id_Usuario);



        }

        [TestMethod]
        public void ProbandoActualizarUsuario()
        {

            //Negocio
            N_Usuario n_Usuario = new N_Usuario();
            //Entidad
            E_Usuario e_Usuario = new E_Usuario();




            e_Usuario.nombre = "Rogelio";
            e_Usuario.apellido = "Cruz";
            e_Usuario.contraseña = "1234";
            e_Usuario.usuario = "RogeC";
            e_Usuario.estado = "Activo";
           

            e_Usuario.id_Usuario = 27;

            int NotExpected = 0;


            Assert.AreNotEqual(NotExpected, n_Usuario.ActualizarUsuario(e_Usuario));


        }




    }
}
