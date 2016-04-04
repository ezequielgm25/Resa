using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Capas.Data;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using System.Data;

namespace UntPResa
{
    [TestClass]
    public class PruebaSolicitudes
    {
        [TestMethod]
        public void PruebaObtenerSolicitudes()
        {
            //Negocio
            N_Solicitud n_Solicitud = new N_Solicitud();
            //Entidad
            E_Solicitud e_Solicitud = new E_Solicitud();


            //Verifica que no venga vacio el DataTable 
            Assert.IsNotNull(n_Solicitud.ObtenerSolicitudes());


        }

        [TestMethod]
        public void PruebaCrearSolicitud()
        {
            //Negocio
            N_Solicitud n_Solicitud = new N_Solicitud();
            //Entidad
            E_Solicitud e_Solicitud = new E_Solicitud();

            e_Solicitud.id_Salon = 20;
            e_Solicitud.usuario = "No Aprobada";
            e_Solicitud.fecha = Convert.ToString(DateTime.Now);
            e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);
            e_Solicitud.aprobacion = "Aprobada";

            int NotExpected = 0;
            
            Assert.AreNotEqual(NotExpected,n_Solicitud.CrearSolicitud(e_Solicitud));


        }

        [TestMethod]
        public void PruebaActualizarSolicitud()
        {
            //Negocio
            N_Solicitud n_Solicitud = new N_Solicitud();
            //Entidad
            E_Solicitud e_Solicitud = new E_Solicitud();

            e_Solicitud.id_Salon = 28;
            e_Solicitud.usuario = "No Aprobada";
            e_Solicitud.fecha = Convert.ToString(DateTime.Now);
            e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);
            e_Solicitud.aprobacion = "Aprobada";
            e_Solicitud.id_Solicitud = 61;

            int NotExpected = 0;

            Assert.AreNotEqual(NotExpected, n_Solicitud.ActualizarSolicitud(e_Solicitud));


        }

        [TestMethod]
        public void PruebaEliminarSolicitud()
        {
            //Negocio
            N_Solicitud n_Solicitud = new N_Solicitud();
            //Entidad
            E_Solicitud e_Solicitud = new E_Solicitud();

        
            e_Solicitud.id_Solicitud = 62;

            int NotExpected = 0;

            Assert.AreNotEqual(NotExpected, n_Solicitud.EliminarSolicitud(e_Solicitud.id_Solicitud));


        }


        [TestMethod]
        public void PruebaInsertarOrganizador()
        {
            //Negocio
            N_Organizador n_Organizador = new N_Organizador();
            //Entidad
            E_Organizador e_Organizador = new E_Organizador();

            //Llenando la Entidad
            e_Organizador.nombre = "Julio El mocano";
            e_Organizador.descripcion = "El mas Loco de todos";
            e_Organizador.correoElectronico = "Julito.com el maricom";
            e_Organizador.id_Evento = 50;
            int NotExpected = 0;

            Assert.AreNotEqual(NotExpected, n_Organizador.insertarOrganizador(e_Organizador));


        }
        [TestMethod]
        public void PruebaActualizarOrganizador()
        {
            //Negocio
            N_Organizador n_Organizador = new N_Organizador();
            //Entidad
            E_Organizador e_Organizador = new E_Organizador();

            //Llenando la Entidad

            e_Organizador.nombre = "Pepe To";
            e_Organizador.descripcion = "El mas Loco de todos";
            e_Organizador.correoElectronico = "Julito.com el maricom";
            e_Organizador.id_Organizador = 39;

            int NotExpected = 0;

            Assert.AreNotEqual(NotExpected, n_Organizador.ActualizarOrganizador(e_Organizador));


        }





    }
}

