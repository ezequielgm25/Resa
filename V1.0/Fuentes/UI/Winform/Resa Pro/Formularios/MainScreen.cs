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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraScheduler;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using DevExpress.Xpf;
using DevExpress.XtraGrid;


namespace Resa_Pro.Formularios
{
    public partial class MainScreen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<summary>
        //pantalla principal donde  se manipalaran las incidencias que tendra el usuario sobre el sistema
        //</Summary>

        #region Declaracion Globales 


        //usuarios 
        private N_Usuario n_Usuario;

        private E_Usuario e_Usuario;

        //Salones 

        E_Salon e_Salon = new E_Salon();


        N_Salon n_Salon = new N_Salon();


        //Eventos         

        E_Evento e_Evento = new E_Evento();

        N_Evento n_Evento = new N_Evento();


        #endregion




        public MainScreen(int ID_Usuario)
        {
            /* liberando memoria */
            System.GC.Collect();
            /*----- */


            InitializeComponent();
            InitSkinGallery();

            //Mostrando Datos del usuario en la barra de estado

            //Instanciando las clases

            n_Usuario = new N_Usuario();


            //obteniendo datos del usuario 
            e_Usuario = n_Usuario.ObtenerUsuario(ID_Usuario);

            //Asignando a elementos de la barra de estado los datos
            BarStaticINombreU.Caption = e_Usuario.nombre + " " + e_Usuario.apellido;

            barStaticItemRol.Caption = e_Usuario.rol;

            barItemFecha.Caption = Convert.ToString(System.DateTime.Today.ToString("d"));
            /*----------------------------------------------------------------------------*/

            #region Completando el data source de los grid control 

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();
            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();

            #endregion




        }

        //<summary>
        //Meto que inicializa la galeria de temas de la aplicacion
        //</Summary>

        #region inicializar galeria de Skins
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }





        #endregion


        #region Cerrar Sesion 
        private void BarButtonCerrarSesion_ItemClick(object sender, ItemClickEventArgs e)
        {



            this.Hide();
            Loging loging = new Loging(this);
            loging.ShowDialog();




        }
        #endregion




        #region Salones

        private void BBSalones_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Opcion de  gestion de los salones 

            Salones salones = new Salones();

            salones.ShowDialog();

            //Actualizando el grid control de Salones 

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();


        }

        #endregion


        #region Solicitudes
        private void BBSolicitudes_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Interrfaz solicitudes 

            SolicitudesF solicitudesF = new SolicitudesF();

            solicitudesF.ShowDialog();

            //Actualizando el Grid data despues del cierre de la interfaz 

            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();



        }



        #endregion


        #region Eventos 
        private void BBEventos_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Interfaz de los eventos 

            EventosF eventosF = new EventosF();

            eventosF.ShowDialog();

            //Cuando se corte el dialogo se hara la siguiente accion 
            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();


        }

        #endregion


        #region Click Sobre el grid control eventos 
        private void GCEventos_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region Click Sobre el grid control Salones que actualizara el grid control eventos
        private void GCSalones_Click(object sender, EventArgs e)
        {
            //Actualizando el Datasource de el grid control GCEventos  para mostrar los eventos del salon seleccionado

            int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            if (ID_Salon != 0)
            {

                GCEventos.DataSource = n_Evento.ObtenerEventosPorID(ID_Salon);

            }
            else
            {
                MessageBox.Show("No hay un Salon seleccionado para mostrar sus eventos");
            }

        }


        #endregion
    }
}