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
    public partial class EventosF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz que manejara las opciones y funciones de las solicitudes 
        //</Summary>

        #region Declaraciones

        N_Evento n_Evento = new N_Evento();

        E_Evento e_Evento = new E_Evento();

        //Solicitudes 

        E_Solicitud e_Solicitud = new E_Solicitud();

        N_Solicitud n_Solicitud = new N_Solicitud();

        #endregion

        #region Contructor
        public EventosF()
        {
            InitializeComponent();

            #region Asignando la data source al grid control 

            GCEventos.DataSource = n_Evento.ObtenerEventos();

            #endregion

        }

        #endregion

        #region marcar Un evento
        private void SBAgregarE_Click(object sender, EventArgs e)
        {
            //Instancia de la interfaz 

            CrearEvento C_Evento = new CrearEvento();

            C_Evento.ShowDialog();

            //Actualizando la data de el grid control 
            GCEventos.DataSource = n_Evento.ObtenerEventos();




        }

        #endregion

        #region Eliminar Evento
        private void SBEliminarE_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            //Preguntar al usuario  si desea eliminarlo
            //Recupera el ID de la solicitud la  cual va a ser eliminada
            e_Solicitud.id_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Solicitud"));

            if (e_Solicitud.id_Solicitud != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea eliminar el evento?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {



                    FilasAfectadas = n_Solicitud.EliminarSolicitud(e_Solicitud.id_Solicitud);

                    if (FilasAfectadas != 1)
                    {
                        MessageBox.Show("Ocurrio un error al eliminar el evento");
                    }
                    else
                    {
                        MessageBox.Show("El evento se elimino correctamente");

                        GCEventos.DataSource = n_Evento.ObtenerEventos();

                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    //No hacer nada
                }

            }
            else
            {
                MessageBox.Show(" No hay Evento seleccionado ");
            }

        }

        #endregion


        #region Actualizar Evento 
        private void SBActualizarE_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara un evento
            //</Summary>

            int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Solicitud"));
            string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));

            if (ID_Solicitud != 0)
            {

                ActualizarEvento AS_Form = new ActualizarEvento(ID_Solicitud, Nombre_Salon);

                AS_Form.ShowDialog();

                //Actualizar el grid 

                GCEventos.DataSource = n_Evento.ObtenerEventos();
            }

            else
            {
                MessageBox.Show(" No hay un evento seleccionado");
            }

        }

        #endregion

        #region Visulizar Eventos

        private void GCEventos_DoubleClick(object sender, EventArgs e)
        {
            //<Summary>
            // Se Visualizara una solicitud 
            //</Summary>


            int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Solicitud"));
            string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));

            if (ID_Solicitud != 0)
            {

                VerEvento AS_Form = new VerEvento(ID_Solicitud, Nombre_Salon);

                AS_Form.ShowDialog();



            }

            else
            {
                MessageBox.Show(" No hay un evento seleccionado");
            }

        }





    }


    #endregion
}
