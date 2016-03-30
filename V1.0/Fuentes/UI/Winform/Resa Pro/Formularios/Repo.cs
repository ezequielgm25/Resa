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
using Capas.Aplicacion;
using Capas.Infraestructura.Entidades;
using Capas.Negocio;

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
            //CRPVeventos.ShowPrintButton = n_Usuario.ObtenerFuncion(ID_OReportes, "Imprimir");

            XML_Manager mArchivo = new XML_Manager();

            string direccionbase = mArchivo.directorioBaseAplicacion() + @"\Reportes\rpteventos.rpt";
           
            CrystalReportV.ReportSource = @direccionbase;



            #endregion


        }
    }
}