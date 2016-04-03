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
using Capas.Aplicacion;
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
namespace Resa_Pro.Formularios
{
    public partial class SolicitudesF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // interfaz que manejara las opciones y funciones de las solicitudes 
        //</Summary>

        #region Declaraciones -
        //Solicitud 
        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();
        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();
        //Auditorias 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();
        //Xml manager 
        XML_Manager X_m = new XML_Manager();

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la interfaz de  solicitudes que acepta como parametros una entida de usuario 
        /// </summary>
        /// <param name="e_UsuarioAU"></param>
        public SolicitudesF(E_Usuario e_UsuarioAU)
        {

            //Inicializando los componentes
            InitializeComponent();

            #region Obteniendo las Solicitudes 

            GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();

            #endregion

            //Asignando e_Usuario   a la goblal

            e_Usuario = e_UsuarioAU;


            #region Control de usuario  -- Control de usuarios --

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
        #endregion

        #region Agregar Solicitud - 
        /// <summary>
        /// Evento click sobre el boton agregar en el cual se gestionara agregar una solicitud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Solicitudes", "Crear", Convert.ToString(E));
            }

            //Agregando una auditoria  al usuario 
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

        #region Actualizar Solicitudes -
        /// <summary>
        /// Evento click sobre el boton actualizar donde se gestionara la Actualizacion de una solicitud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<summary>
            //se actualizara una solicitud 
            //</summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Recogiendo los datos seleccionados de la grid view 
                int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));

                //Restificando los datos 
                if (ID_Solicitud != 0)
                {
                    //Instanciando el forms de solicitudes y enviando los parametros concernientes 
                    ActualizarSolicitudesF AS_Form = new ActualizarSolicitudesF(ID_Solicitud, Nombre_Salon);

                    AS_Form.ShowDialog();

                    //Actualizar el grid 

                    GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();
                }

                else
                {
                    //Mensaje de que no hay nada seleccionado en la grid view 
                    MessageBox.Show(" No hay una solicitud seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            //Capturando la excepcion  y mostrandola al usuario y guardando el error 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Solicitudes", "Actualizar", Convert.ToString(E));
            }

            //Asignandole finalmente la auditoria al usuario 
            finally
            {
                //Asignandole los datos a la entidad Auditoria 
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

        #region Eliminar- 
        /// <summary>
        /// Evento click sobre el  boton eliminar el cual gestionara la eliminacion de una solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminar_Click(object sender, EventArgs e)
        {
            //Variable que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Recupera el ID de la solicitud la  cual va a ser eliminada
                e_Solicitud.id_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                if (e_Solicitud.id_Solicitud != 0)
                {

                    //Preguntar al usuario  si desea eliminarlo
                    DialogResult dialogResult = MessageBox.Show("Desea eliminar la Solicitud?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {


                        // Se ejecuta el metodo de eliminar solicitud en la capa de negocio 
                        FilasAfectadas = n_Solicitud.EliminarSolicitud(e_Solicitud.id_Solicitud);

                        //Se verifica las filas afectadas 
                        if (FilasAfectadas != 1)
                        {
                            //Mensaje de error
                            MessageBox.Show("Ocurrio un error al eliminar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //De lo contrario 
                        else
                        {
                            //Mensaje  Positivo
                            MessageBox.Show("La solicitud se elimino correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Actualizando el datasource principal de solicitudes 
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
                    MessageBox.Show(" No hay solicitud Seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            }
            //Se captura una excepcion  se muestra al usuario y se guarda un error en el XMl 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Solicitudes", "Eliminar", Convert.ToString(E));
            }

            //Se agregara una auditoria a un usuario 
            finally
            {
                //Asignando los parametros a una entidad Auditoria 

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

        #region Ver Solicitudes -
        /// <summary>
        /// Evento Double click sobre el grid view Que permitira visualizar una solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            //<Summary>
            // Se Visualizara una solicitud 
            //</Summary>

            //Recogiendo los datos seleccionados en la grid view
            int ID_Solicitud = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            string Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Salon"));


            //Verificando los datos 
            if (ID_Solicitud != 0)
            {
                //Instanciando una interfaz de visualizacion de una solicitud 
                VerSolicitud AS_Form = new VerSolicitud(ID_Solicitud, Nombre_Salon, e_Usuario);

                AS_Form.ShowDialog();

                //Actualizar el grid 

                GCSolicitudes.DataSource = n_Solicitud.ObtenerSolicitudes();
            }
            //De lo contrario 
            else
            {
                //Mensaje de error 
                MessageBox.Show("No hay una solicitud seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }







        #endregion

    }

}