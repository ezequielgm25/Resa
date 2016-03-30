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
    public partial class SolicitudesF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // interfaz que manejara las opciones y funciones de las solicitudes 
        //</Summary>

        #region Declaraciones
        //Solicitud 
        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();
        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();
        //Auditorias 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();


        #endregion



        public SolicitudesF(E_Usuario e_UsuarioAU)
        {
            InitializeComponent();

            #region Obteniendo las Solicitudes 

            GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();

            #endregion

            //Asignando e_Usuario   a la goblal

            e_Usuario = e_UsuarioAU;


            #region Control de usuario

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Solicitudes";  // -- - -Opcion

            int ID_OSolicitudes = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Agregar
            SBAgregarS.Visible = n_Usuario.ObtenerFuncion(ID_OSolicitudes, "Crear");
            //Actualizar
            SBActualizar.Visible = n_Usuario.ObtenerFuncion(ID_OSolicitudes, "Actualizar");
            //Eliminar
            SBEliminar.Visible = n_Usuario.ObtenerFuncion(ID_OSolicitudes, "Eliminar");

            #endregion


        }


        #region Agregar Solicitud 
        private void SBAgregarS_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Instancia de la interfaz de crear solicitud 

                AgregarSolicitud A_Solicitud = new AgregarSolicitud(e_Usuario);

                A_Solicitud.ShowDialog();

                //Actualizando la data en el grid control 
                GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();
            }
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E));
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Solicitudes";
                e_Auditoria.tipoOpcion = "Agregar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }






        #endregion

        #region Actualizar Solicitudes 
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara una solicitud 
            //</Summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
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
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E));
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Solicitudes";
                e_Auditoria.tipoOpcion = "Actualizar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
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

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {

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
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E));
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Solicitudes";
                e_Auditoria.tipoOpcion = "Eliminar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }


        }

        #endregion


        #region Ver Solicitudes
        private void GCSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            //<Summary>
            // Se Visualizara una solicitud 
            //</Summary>


            int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));

            if (ID_Solicitud != 0)
            {

                VerSolicitud AS_Form = new VerSolicitud(ID_Solicitud, Nombre_Salon, e_Usuario);

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

    }

}