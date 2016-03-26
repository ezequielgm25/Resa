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
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
namespace Resa_Pro.Formularios
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // interfaz que manejara las opciones y funciones de las solicitudes 
        //</Summary>

        #region Declaraciones

        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();


         #endregion



        public Solicitudes()
        {
            InitializeComponent();

            #region Obteniendo las Solicitudes 

            GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();

            #endregion


        }


        #region Agregar Solicitud 
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            //Instancia de la interfaz de crear solicitud 

            AgregarSolicitud A_Solicitud = new AgregarSolicitud();

            A_Solicitud.ShowDialog();

            //Actualizando la data en el grid control 
            GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();



        }






        #endregion

        #region Actualizar Solicitudes 
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara una solicitud 
            //</Summary>

            int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));

            if (ID_Solicitud != 0)
            {

                ActualizarSolicitudesF AS_Form = new ActualizarSolicitudesF(ID_Solicitud, Nombre_Salon);

                AS_Form.ShowDialog();

                //Actualizar el grid 

                GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();
            }

            else
            {
                MessageBox.Show(" No hay una solicitud seleccionada");
            }

        }

        #endregion


        #region Eliminar 
        private void SBEliminar_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            //Preguntar al usuario  si desea eliminarlo
            //Recupera el ID de la solicitud la  cual va a ser eliminada
            e_Solicitud.id_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            if (e_Solicitud.id_Solicitud != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea eliminar la Solicitud?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {



                    FilasAfectadas = n_Solicitud.EliminarSolicitud(e_Solicitud.id_Solicitud);

                    if (FilasAfectadas != 1)
                    {
                        MessageBox.Show("Ocurrio un error al eliminar la solicitud");
                    }
                    else
                    {
                        MessageBox.Show("La solicitud se elimino correctamente");

                        GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();

                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    //No hacer nada
                }

            }
            else
            {
                MessageBox.Show(" No hay solicitud Seleccionada ");
            }


        }

        #endregion
    }
}