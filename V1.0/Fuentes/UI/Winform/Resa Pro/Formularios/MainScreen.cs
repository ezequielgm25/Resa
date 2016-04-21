using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
//Usings del sistema
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using Capas.Aplicacion;


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

        private E_Usuario e_UsuarioAU;

        //Salones 

        E_Salon e_Salon = new E_Salon();


        N_Salon n_Salon = new N_Salon();


        //Eventos         

        E_Evento e_Evento = new E_Evento();

        N_Evento n_Evento = new N_Evento();


        //Usuarios

        E_Auditoria e_Auditoria = new E_Auditoria();

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Usuario e_Usuario = new  E_Usuario();
        #endregion



        #region Contructor
        /// <summary>
        /// Constructor de la interfaz "Pantalla principal"
        /// </summary>
        /// <param name="ID_Usuario"></param>
        public MainScreen(int ID_Usuario)
        {
            /* liberando memoria */
            System.GC.Collect();
            /*----- */

            //Iniciando los componentes
            InitializeComponent();

            //Iniciando la Galaria de skins de devspress
            InitSkinGallery();

            //Mostrando Datos del usuario en la barra de estado

            //Instanciando las clases

            n_Usuario = new N_Usuario();


            //obteniendo datos del usuario 
            e_UsuarioAU = n_Usuario.ObtenerUsuario(ID_Usuario);

            //Asignando el ID_Usuario 

            e_UsuarioAU.id_Usuario = ID_Usuario;


            //Asignando a elementos de la barra de estado los datos
            BarStaticINombreU.Caption = e_UsuarioAU.nombre + " " + e_UsuarioAU.apellido;

            barStaticItemRol.Caption = e_UsuarioAU.rol;

            barItemFecha.Caption = Convert.ToString(System.DateTime.Today.ToString("d"));
            /*----------------------------------------------------------------------------*/



            #region Completando el data source de los grid control 

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();
            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();

            #endregion


            #region Seguridad  autentificando el usuario 



            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(ID_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Usuarios";  // -- - -Opcion

            int ID_OUsuarios = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

            //Usuarios 
            if (n_Usuario.ObtenerFuncion(ID_OUsuarios, "Ver") == true || n_Usuario.ObtenerFuncion(ID_OUsuarios, "Crear") == true || n_Usuario.ObtenerFuncion(ID_OUsuarios, "Actualizar") == true || n_Usuario.ObtenerFuncion(ID_OUsuarios, "Eliminar") == true)
            {

                RBPUsuarios.Visible = true;

            }
            else
            {
                RBPUsuarios.Visible = false;
            }

            //Reportes 
            Opcion = "Reportes";  // -- - -Opcion

            int ID_OReportes= n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

            if(n_Usuario.ObtenerFuncion(ID_OReportes, "Imprimir") == true || n_Usuario.ObtenerFuncion(ID_OReportes, "Generar") == true)
            {
                RBPReportes.Visible = true;
            }
            else
            {
                RBPReportes.Visible = false;
            }


            #endregion


            #region Cambiando el tema de los formularios

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Black");

            #endregion


        }

        #endregion

        //<summary>
        //Meto que inicializa la galeria de temas de la aplicacion
        //</Summary>

        #region inicializar galeria de Skins
        /// <summary>
        /// Metodo que inicializa la galeria de skins de devexpress
        /// </summary>
        void InitSkinGallery()
        {
            // -- Metodo de 
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        #endregion

        #region Cerrar Sesion 
        /// <summary>
        /// Metodo donde se cierra la session en el sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonCerrarSesion_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Se oculata este 
            this.Hide(); 
            //Se llama la interfaz del loging 
            Loging loging = new Loging(this);
            //Se muestra 
            loging.ShowDialog();




        }
        #endregion

        #region Salones
        /// <summary>
        /// Evento click en el grid control de salones el cual hace que se precenten los eventos correspondientes de salones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BBSalones_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Opcion de  gestion de los salones 

            Salones salones = new Salones(e_UsuarioAU);

            salones.ShowDialog();

            //Actualizando el grid control de Salones 

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            //Cuando se corte el dialogo se hara la siguiente accion 
            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();


        }

        #endregion
  
        #region Solicitudes
        /// <summary>
        /// Evento click donde se maneja la session de las solicitudes del sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBSolicitudes_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Interrfaz solicitudes 

            SolicitudesF solicitudesF = new SolicitudesF(e_UsuarioAU);

            solicitudesF.ShowDialog();

            //Actualizando el Grid data despues del cierre de la interfaz 

            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();



        }



        #endregion

        #region Eventos 
        /// <summary>
        /// Evento click donde se maneja la session de eventos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBEventos_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Interfaz de los eventos 

            EventosF eventosF = new EventosF(e_UsuarioAU);

            eventosF.ShowDialog();

            //Cuando se corte el dialogo se hara la siguiente accion 
            GCEventos.DataSource = n_Evento.ObtenerEventosDetallados();


        }

        #endregion

        #region Click Sobre el grid control eventos 
        /// <summary>
        /// Evento click sobre el grid control eventos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCEventos_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Click Sobre el grid control Salones que actualizara el grid control eventos
        /// <summary>
        /// Evento click sobre el grid control salones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show("No hay un Salon seleccionado para mostrar sus eventos","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        #endregion

        #region Usuarios 
        /// <summary>
        /// Evento click donde se controla la session de usuarios en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            //<Summary>
            // Interfaz donde se gestionara los usuarios 
            //</Summary>

            UsuariosF F_Usuarios = new UsuariosF(e_UsuarioAU);

            //Mostrando la interfaz 
            F_Usuarios.ShowDialog();


        }

        #endregion

        #region  Reportes 
        /// <summary>
        /// Evento click donde se controla session de reportes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBReportes_ItemClick(object sender, ItemClickEventArgs e)
        {
            //<Summary>
            // Interfaz donde se gestionara los Reportes 
            //</Summary>


            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {

                Repo R = new Repo(e_UsuarioAU);

                R.ShowDialog();
            }
            catch(Exception E)
            {
                MessageBox.Show(Convert.ToString(E.Message));

                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmail(E.Message);
            }

            finally
            {
                e_Auditoria.id_Usuario = e_UsuarioAU.id_Usuario;
                e_Auditoria.tipoUsuario = e_UsuarioAU.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Reportes";
                e_Auditoria.tipoOpcion = "Generar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }



        }

        #endregion
    }
}