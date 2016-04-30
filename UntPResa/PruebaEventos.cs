
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace UntPResa
{
    [TestClass]
    public class PruebaEventos
    {
        [TestMethod]
        public void ProbandoCrearEvento()
        {

            //Negocio
            N_Evento n_Evento = new N_Evento();
            //Entidad
            E_Evento e_Evento = new E_Evento();

            e_Evento.titulo_Evento = "La casa de pedro";
            e_Evento.descripcion = "La comelona";
            e_Evento.tipo = "Fectivo";
            e_Evento.topico = "Inactivo";
            e_Evento.tiempo_Inicio = Convert.ToString(DateTime.Now);;
            e_Evento.tiempo_Final = Convert.ToString(DateTime.Now);
            e_Evento.id_Solicitud = 77;
            int NoTexpected = 0;

            e_Evento.id_Evento = n_Evento.CrearEvento(e_Evento);

            Assert.AreNotEqual(NoTexpected, e_Evento.id_Evento);

            

        }


        [TestMethod]
        public void ProbandoActualizarEvento()
        {

            //Negocio
            N_Evento n_Evento = new N_Evento();
            //Entidad
            E_Evento e_Evento = new E_Evento();



            e_Evento.titulo_Evento = "La casa de pedro";
            e_Evento.descripcion = "La comelona";
            e_Evento.tipo = "Fectivo";
            e_Evento.topico = "Inactivo";
            e_Evento.tiempo_Inicio = Convert.ToString(DateTime.Now); ;
            e_Evento.tiempo_Final = Convert.ToString(DateTime.Now);

            e_Evento.id_Evento = 67;

            int NotExpected = 0;


            Assert.AreNotEqual(NotExpected, n_Evento.ActualizarEvento(e_Evento));


        }

        [TestMethod]
        public void PruebaObtenerEventos()
        {
            //Negocio
            N_Evento n_Evento = new N_Evento();
            //Entidad
            E_Evento e_Evento = new E_Evento();


            //Verifica que no venga vacio el DataTable 
            Assert.IsNotNull(n_Evento.ObtenerEventos());


        }



    }
}
