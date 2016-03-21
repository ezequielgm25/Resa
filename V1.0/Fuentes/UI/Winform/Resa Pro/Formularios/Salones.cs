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
    public partial class Salones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Salones()
        {
            InitializeComponent();
        }

        private void SBCrear_Click(object sender, EventArgs e)
        {
            CrearSalonF C_Salon = new CrearSalonF();

            C_Salon.ShowDialog();


        }

        private void SBActualizar_Click(object sender, EventArgs e)
        {
            ActualizarSalon A_Salon = new ActualizarSalon();

            A_Salon.ShowDialog();

            VerSalon V_Salon = new VerSalon();

            V_Salon.ShowDialog();
        }
    }
}