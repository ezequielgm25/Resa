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

namespace Resa_Pro.Formularios
{
    public partial class MainScreen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<summary>
        //pantalla principal donde  se manipalaran las incidencias que tendra el usuario sobre el sistema
        //</Summary>

        public MainScreen()
        {
            InitializeComponent();
            InitSkinGallery();

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

        private void button1_Click(object sender, EventArgs e)
        {
            CrearSalonF Fsalon = new CrearSalonF();
            Fsalon.Show();
        }
    }
}