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
        #region Instancias - 

        //Servicio
    
        N_Servicio n_Servicio = new N_Servicio();

        //Inventario 

        N_Inventario n_Inventario = new N_Inventario();

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la interfaz  de ver salones la cual acepta como parametro una entidad salon
        /// </summary>
        /// <param name="e_Salon"></param>
        public VerSalon(E_Salon e_Salon)
        {
            //Inicializando los componentes 
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
            //Obteniendo los servicios 
            GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

            #endregion

            #region Inventarios
            //obteniendo los  los inventarios 
            GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);
            #endregion

            #endregion
        }

        #endregion
    }
}