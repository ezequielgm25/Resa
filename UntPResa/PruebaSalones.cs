using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;


using Capas.Aplicacion;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using Capas.Data;


namespace UntPResa
{
    [TestClass]
    public class PruebaSalones
    {


        [TestMethod]
        public void ProbandoCreacionSa()
        {
            //Intanciando las clases


            //Negocio
            N_Salon n_Salon = new N_Salon();
            //Entidad
            E_Salon e_Salon = new E_Salon();

            e_Salon.nombre = "La casa de pedro";
            e_Salon.capacidad = 10;
            e_Salon.estado = "Inactivo";
            e_Salon.ubicacion = "Al lado de juana";

            int NoTexpected = 0;

            e_Salon.id_Salon = n_Salon.CrearSalon(e_Salon);

            Assert.AreNotEqual(NoTexpected, e_Salon.id_Salon);
        }
        [TestMethod]
        public void ProbandoActualizacionSa()
        {

            //Intanciando las clases

            //Negocio
            N_Salon n_Salon = new N_Salon();
            //Entidad
            E_Salon e_Salon = new E_Salon();

            e_Salon.nombre = "La casa de Ezequiel";
            e_Salon.capacidad = 10;
            e_Salon.estado = "Inactivo";
            e_Salon.ubicacion = "Al lado de juana";
            e_Salon.id_Salon = 63;

            int NoTexpected = 0;

            int FilasAfectadas = n_Salon.ActualizarSalon(e_Salon);

            Assert.AreNotEqual(NoTexpected, FilasAfectadas);



        }

        [TestMethod]
        public void ProbandoEliminandoSa()
        {

            //Intanciando las clases

            //Negocio
            N_Salon n_Salon = new N_Salon();
            //Entidad
            E_Salon e_Salon = new E_Salon();

          
            e_Salon.id_Salon = 25;

            int NoTexpected = 0;

            int FilasAfectadas = n_Salon.EliminarSalon(e_Salon.id_Salon);

            Assert.AreNotEqual(NoTexpected, FilasAfectadas);



        }

        [TestMethod]
        public void PruebaObtenerSalones()
        {

            //Intanciando las clases

            //Negocio
            N_Salon n_Salon = new N_Salon();

            Assert.IsNotNull(n_Salon.ObtenerSalones());

        }

        [TestMethod]
        public void PruebaAgregarInventario()
        {

            //Intanciando las clases

            //Negocio
            N_Inventario n_Inventario = new N_Inventario();
            //Entidad
            E_Inventario e_Inventario = new E_Inventario();

            e_Inventario.inventario = "Cocina";

            e_Inventario.id_Salon = 20;

            Assert.AreNotEqual(0,n_Inventario.AgregarInventario(e_Inventario));

        }

        [TestMethod]
        public void PruebaAgregarServicio()
        {

            //Intanciando las clases

            //Negocio
            N_Servicio n_Servicio = new N_Servicio();
            //Entidad
            E_Servicio e_Servicio = new E_Servicio();

            e_Servicio.servicio = "Limpiar";
            e_Servicio.descripcion = "Un Equipo de limpieza";
            e_Servicio.id_Salon = 20;
            Assert.AreNotEqual(0, n_Servicio.AgregarServicio(e_Servicio));

        }


    }
}
