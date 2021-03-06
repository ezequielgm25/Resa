﻿using System;
using System.Windows.Forms;

//Usings del sistema 
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using Capas.Aplicacion;

namespace Resa_Pro.Formularios
{
    public partial class EventosF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz que manejara las opciones y funciones de las solicitudes 
        //</Summary>

        #region Declaraciones - 

        N_Evento n_Evento = new N_Evento();

        E_Evento e_Evento = new E_Evento();

        //Solicitudes 

        E_Solicitud e_Solicitud = new E_Solicitud();

        N_Solicitud n_Solicitud = new N_Solicitud();
        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();
        //Auditorias 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();
        //Xml manager 
        XML_Manager X_m = new XML_Manager();

        //Variable que recogera los errores en el sistema 
        string MessageError = "";

        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la interfaz  Eventos la cual espera como parametro una entidad de un usuario
        /// </summary>
        /// <param name="e_UsuarioAU"></param>
        public EventosF(E_Usuario e_UsuarioAU)
        {

            //Inicializando los componentes 
            InitializeComponent();

            #region Asignando la data source al grid control 

            GCEventos.DataSource = n_Evento.ObtenerEventos();

            #endregion

            //Asignando e_Usuario   a la goblal

             e_Usuario = e_UsuarioAU;

 
            #region Control de usuario -- Control de acceso -- 

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Eventos";  // -- - -Opcion
            
            //obteniendo  el ID de la obcion de Eventos  de este usuario 
            int ID_OEventos = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Crear
            SBAgregarE.Visible = n_Usuario.ObtenerFuncion(ID_OEventos, "Crear");
            //Actualizar
            SBActualizarE.Visible = n_Usuario.ObtenerFuncion(ID_OEventos, "Actualizar");
            //Eliminar
            SBEliminarE.Visible = n_Usuario.ObtenerFuncion(ID_OEventos, "Eliminar");

            #endregion
        }

        #endregion

        #region Marcar Un evento
        /// <summary>
        /// Evento click del boton agregar  que maneja la funcion de agregar un evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarE_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Instancia de la interfaz 

                CrearEvento C_Evento = new CrearEvento(e_Usuario);

                C_Evento.ShowDialog();

                //Actualizando la data de el grid control 
                GCEventos.DataSource = n_Evento.ObtenerEventos();
            }
            //Se captura una excepcion 
            catch (Exception E)
            {
                
                MessageBox.Show(Convert.ToString(E.Message), "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Eventos", "Crear", Convert.ToString(E));

                //Mensaje de error

                MessageError = E.Message;
            }

            //Agregando una auditoria  al usuario 
            finally
            {
                //Asignando los parametros a la entidad de auditoria

                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Eventos";
                e_Auditoria.tipoOpcion = "Agregar" + MessageError;

                //Insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }



        }

        #endregion

        #region Eliminar Evento
        /// <summary>
        /// Evento donde se  elimina  un evento 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminarE_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try {

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
                            MessageBox.Show("Ocurrio un error al eliminar el evento","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El evento se elimino correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show(" No hay evento seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception E)
            {
                MessageBox.Show(Convert.ToString(E.Message) , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Eventos", "Eliminar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;

            }
            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Eventos";
                e_Auditoria.tipoOpcion = "Eliminar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }


        }

        #endregion

        #region Actualizar Evento 
        /// <summary>
        /// Evento click en el boton actualizar donde se gestionara la actualizacion de un evento 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizarE_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara un evento
            //</Summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try {

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
                    MessageBox.Show(" No hay un evento seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch(Exception E)
            {
                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Eventos", "Actualizar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Eventos";
                e_Auditoria.tipoOpcion = "Actualizar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }


        }

        #endregion

        #region Visulizar Eventos
        /// <summary>
        /// Evento click sobre el grid control de  eventos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show(" No hay un evento seleccionado" ,"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }





    }


    #endregion
}
