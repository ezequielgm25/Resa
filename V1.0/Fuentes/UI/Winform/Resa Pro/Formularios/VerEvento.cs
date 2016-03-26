using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class VerEvento : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        //<Summary>
        // Interfaz donde se visualizara  las caracteristicas de un evento
        //</Summary>


        #region Declaraciones
        //Salones
        N_Salon n_Salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

        //Solicitudes
        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();
        //Eventos 
        E_Evento e_Evento = new E_Evento();

        N_Evento n_Evento = new N_Evento();
        //Organizadores
        E_Organizador e_Organizador = new E_Organizador();

        N_Organizador n_Organizador = new N_Organizador();

        #endregion
        public VerEvento(int ID_Solicitud , string Nombre_Salon)
        {
            InitializeComponent();

            //Asignando el nombre del salon
            e_Salon.nombre = Nombre_Salon;
            e_Solicitud.id_Solicitud = ID_Solicitud;


            //Asignando los datos a los controles 

            AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);
        }


        #region  Asignando los datos a los controles 

        public void AsignarDatos(int ID_Solicitud, String nombre)
        {

            //Asignando la informacion a las Entidades 
            e_Solicitud = n_Solicitud.ObtenerSolicitud(ID_Solicitud);
            e_Evento = n_Evento.ObtenerEvento(ID_Solicitud);
            e_Organizador = n_Organizador.Obtenerorganizador(e_Evento.id_Evento);

            //Asignando la informacion de la solicitud

            LBLFecha.Text = e_Solicitud.fecha;
            LBLEstado.Text = e_Solicitud.aprobacion;


            LBLFechaAprobacion.Text = e_Solicitud.fechaAprobacion;
            LBLUsuario.Text = e_Solicitud.usuario;

            //Asignando el nombre del salon 

            LBLSalon.Text = e_Salon.nombre;

            //Asignando la informacion a los controles 

            LBLTituloE.Text = e_Evento.titulo_Evento;
            LBLTipoE.Text = e_Evento.tipo;
            LBLTopico.Text = e_Evento.topico;
            LBLDescripcioinE.Text = e_Evento.descripcion;

            //Tiempo 

            LBLTiempoI.Text = e_Evento.tiempo_Inicio;
            LBLTiempoF.Text = e_Evento.tiempo_Final;

            //Organizador 

            LBLNombreO.Text = e_Organizador.nombre;
            LBLDescripcionO.Text = e_Organizador.descripcion;
            LBLCorreoO.Text = e_Organizador.correoElectronico;





        }
        #endregion

      
    }
}