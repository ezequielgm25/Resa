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
using Capas.Infraestructura.Entidades;
using Capas.Negocio;

namespace Resa_Pro.Formularios
{
    public partial class VerSalon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Clase de la interfaz donde se mostrara toda la informacion concerniente a un salon
        //</Summary>
        #region Instancias

        //Servicio
    
        N_Servicio n_Servicio = new N_Servicio();

        //Inventario 

        N_Inventario n_Inventario = new N_Inventario();

        #endregion
        public VerSalon(E_Salon e_Salon)
        {

            InitializeComponent();

            #region Asignando los valores a los controles

            //nombre
            LBLNombreS.Text = e_Salon.nombre;
            //Ubicacion
            LBLUbicacionS.Text = e_Salon.ubicacion;
            //Capacidad
            LBLCapacidadS.Text = Convert.ToString(e_Salon.capacidad);
            //Estado
            LBLEstadoS.Text = e_Salon.estado;
  


            #endregion 


            #region Obteniendo los servicios y inventarios del salon

            #region Servicios 

            GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

            #endregion

            #region Inventarios
            GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);
            #endregion

            #endregion
        }

    }
}