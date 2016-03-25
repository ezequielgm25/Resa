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
    public partial class AgregarSolicitud : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AgregarSolicitud()
        {
            InitializeComponent();
            DateEditTInicio.EditValue = Convert.ToDateTime( "2016-03-24 01:00:00.000");

            MessageBox.Show(Convert.ToString(Convert.ToDateTime("2016-03-24 01:00:00.000")));
        }

        private void GCOrganizador_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}