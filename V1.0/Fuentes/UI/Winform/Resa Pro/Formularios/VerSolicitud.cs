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
    public partial class VerSolicitud : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz donde se visualizara  las caracteristicas de una  solicitud
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

        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();


        #endregion

        public VerSolicitud(int ID_Solicitud, string Nombre_Salon,E_Usuario e_UsuarioAU)
        {
            InitializeComponent();

            //Asignando el nombre del salon
            e_Salon.nombre = Nombre_Salon;
            e_Solicitud.id_Solicitud = ID_Solicitud;


            //Asignando los datos a los controles 

            AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);

            //Asignando e_Usuario   a la goblal

            e_Usuario = e_UsuarioAU;


            #region Control de usuario

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Solicitudes";  // -- - -Opcion

            int ID_OSalones = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Aprobar
            SBAprobar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Aprobar");
            //Desaprobar
            SBDesaprobar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Aprobar");
         

            #endregion

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



        #region Aprobar Solicitud 

        private void simpleButton1_Click(object sender, EventArgs e)
        {



            int FilaAfectada = n_Solicitud.AprobarSolicitud(e_Solicitud.id_Solicitud, e_Usuario.nombre);

            if(FilaAfectada == 0)
            {
                MessageBox.Show("Ocurrio un error al aprobar la solicitud ");
            }
            else
            {
                MessageBox.Show("Solcitud aprobada Satifactoriamente");

                AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);
            }
            

        }



        #endregion

        #region Desaprobar Solicitud
        private void SBDesaprobar_Click(object sender, EventArgs e)
        {

            int FilaAfectada = n_Solicitud.DesaprobarSolicitud(e_Solicitud.id_Solicitud, e_Usuario.nombre);

            if (FilaAfectada == 0)
            {
                MessageBox.Show("Ocurrio un error al desaprobar la solicitud ");
            }
            else
            {
                MessageBox.Show("Solcitud fue desaprobada Satifactoriamente");
                AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);

            }




        }

        #endregion
    }
}