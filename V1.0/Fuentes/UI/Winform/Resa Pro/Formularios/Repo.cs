using System;

//Usings del sistema 
using Capas.Aplicacion;
using Capas.Infraestructura.Entidades;
using Capas.Negocio;
using CrystalDecisions.CrystalReports.Engine;

namespace Resa_Pro.Formularios
{
    public partial class Repo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz que gestionara  la generacion  y imprimicion de los reportes 
        //</Summary>

        //usuarios 
        private N_Usuario n_Usuario = new N_Usuario();

        private E_Usuario e_UsuarioAU = new E_Usuario();

        //Salones 
        #region Reportes 

        /// <summary>
        /// Constructor de la interfaz donde se manipulan los reportes 
        /// </summary>
        /// <param name="e_U"></param>
        public Repo(E_Usuario e_U)
        {
            InitializeComponent();

            #region Control de seguridad


          

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_U.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Reportes";  // -- - -Opcion

            int ID_OReportes = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Imprimir
            CrystalReportV.ShowPrintButton = n_Usuario.ObtenerFuncion(ID_OReportes, "Imprimir");


                #endregion


        }

        #endregion

        #region Metodo donde se gestiona el reporte de los eventos registrados en el sistema 
        /// <summary>
        /// Metodo donde se gestiona el reporte de los eventos registrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBReportesEventos_Click(object sender, EventArgs e)
        {
            //Instancia de la clase de majeno de XML
            XML_Manager mArchivo = new XML_Manager();

            //Asignando la direccion del documento
            string ReporteEventos = mArchivo.directorioBaseAplicacion() + @"\Reportes\rpteventos.rpt";

            //Instancia del objeto report document
            ReportDocument RDEventos = new ReportDocument();
            
            //CArgando el documento 
            RDEventos.Load(@ReporteEventos);

            //Asignando el reportResource 
            CrystalReportV.ReportSource = RDEventos;

            //Refrescando el RV 
            CrystalReportV.Refresh();


        }

#endregion

        #region Reporte de usuarios

        /// <summary>
        /// Metodo donde se gestiona el reporte de los usuarios en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBReportarUsuarios_Click(object sender, EventArgs e)
        {
            //Instancia de la clase de manejo de XML
            XML_Manager mArchivo = new XML_Manager();

            //Asignando la direccion del documento 
            string ReporteDeUsuarios = mArchivo.directorioBaseAplicacion() + @"\Reportes\ReporteUsuarios.rpt";

            //Instanciando la clase de report document 
            ReportDocument ReporteUsuarios = new ReportDocument();

            //Cargando el  documento
            ReporteUsuarios.Load(@ReporteDeUsuarios);

            //Asignando el reportSource 
            CrystalReportV.ReportSource = ReporteUsuarios;

            //Refrescando el RV
            CrystalReportV.Refresh();
        }
#endregion

        #region Reporte de los organizadores
        /// <summary>
        /// Metodo donde se gestiona el reporte de los organizadores registrados en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Instancia de la clase de manejo de los XML
            XML_Manager mArchivo = new XML_Manager();

            //Asignando la direccion del archivo de reporte
            string ReporteDeOrganizadores = mArchivo.directorioBaseAplicacion() + @"\Reportes\ReporteOrganizadores.rpt";

            //Instancia del objeto report document
            ReportDocument ReporteOrganizadores = new ReportDocument();

            //Cargando el  documento 
            ReporteOrganizadores.Load(@ReporteDeOrganizadores);

            //Asignando el report resource al crystal report view 
            CrystalReportV.ReportSource = ReporteOrganizadores;

            //Refrescando el RPV
            CrystalReportV.Refresh();
        }

#endregion

        #region Reporte de porcentajes de arrendamiento de los salones
        /// <summary>
        /// Metodo donde se gestiona el reporte que da las estadisticas de arrendamientos de los salones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBPorcentajeI_Click(object sender, EventArgs e)
        {
            //Instancias de la clase de manejo de XML
            XML_Manager mArchivo = new XML_Manager();

            //Asignando la direccion del documento
            string ReporteDePorcentajesItinerarios = mArchivo.directorioBaseAplicacion() + @"\Reportes\ObtenerPorcentajeSolicitudesSalones.rpt";

            //Instanciando un objeto report Document
            ReportDocument ReporteItinerarios = new ReportDocument();

            //Cargando el documento
            ReporteItinerarios.Load(@ReporteDePorcentajesItinerarios);

            //Asignando el report resource al crystal report
            CrystalReportV.ReportSource = ReporteItinerarios;

            //Refrescando el CV
            CrystalReportV.Refresh();
        }

#endregion

        #region Reporte de  estadistica global de los estados de las solicitudes
        /// <summary>
        /// Metodo donde se controla la manipulacion del reporte Global de los porcentajes de estados de las solicitudes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBReporteGlobal_Click(object sender, EventArgs e)
        {
            //Instancia de la clase de manejo de XML
            XML_Manager mArchivo = new XML_Manager();

            //Asignanddo la direccion
            string ReporteDePorcentajeGlobalSolicitudes = mArchivo.directorioBaseAplicacion() + @"\Reportes\ReportePorcentajeGlobalSolicitudes.rpt";

            //Instanciando un objeto reportDocument
            ReportDocument ReportePorcentajeGlobal = new ReportDocument();

            //Cargando el documento
            ReportePorcentajeGlobal.Load(@ReporteDePorcentajeGlobalSolicitudes);

            //Asignando el report resource al Rview
            CrystalReportV.ReportSource = ReportePorcentajeGlobal;

            //Refrescando el CV
            CrystalReportV.Refresh();
        }

#endregion
    }
}