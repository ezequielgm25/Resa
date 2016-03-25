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

namespace Resa_Pro.Formularios
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Solicitudes()
        {
            InitializeComponent();
        }

        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            //Instancia de la interfaz de crear solicitud 

            AgregarSolicitud A_Solicitud = new AgregarSolicitud();

            A_Solicitud.ShowDialog();

        }
    }
}