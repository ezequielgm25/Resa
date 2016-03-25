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

namespace Resa_Pro.Formularios
{
    public partial class MainScreen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<summary>
        //pantalla principal donde  se manipalaran las incidencias que tendra el usuario sobre el sistema
        //</Summary>

        #region Declaracion Globales 

        private N_Usuario n_Usuario;

        private E_Usuario e_Usuario;

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
            BarStaticINombreU.Caption = e_Usuario.nombre +" "+ e_Usuario.apellido;

            barStaticItemRol.Caption = e_Usuario.rol;

            barItemFecha.Caption = Convert.ToString(System.DateTime.Today.ToString("d"));
            /*----------------------------------------------------------------------------*/
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

        /* Click en la opcion de salones de ver salones */
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            Salones salones = new Salones();

            salones.ShowDialog();


        }

     
    }
}