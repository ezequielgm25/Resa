using System;
using System.Windows.Forms;

//Usings del sistema
using Capas.Negocio;
using Capas.Infraestructura.Entidades;
using Capas.Aplicacion;

namespace Resa_Pro.Formularios
{
    public partial class VerSolicitud : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz donde se visualizara  las caracteristicas de una  solicitud
        //</Summary>


        #region Declaraciones - 
        //Salones
        N_Salon n_Salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

        //Solicitudes
        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();
        //Eventos 
        E_Evento e_Evento = new E_Evento();

        N_Evento n_Evento = new N_Evento();
        //Organizadores
        E_Organizador e_Organizador = new E_Organizador();

        N_Organizador n_Organizador = new N_Organizador();

        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();

        //Auditoria 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();
        //Xml manager 
        XML_Manager X_m = new XML_Manager();
        //Variable que recogera el error

        string MessageError = "";


        #endregion

        #region Contructor -
        /// <summary>
        /// Contructor de la interfaz de  visualizacion de una solicitud la cual acepta como parametros " Un ID de una solicitud , Nombre de un salon , Una entidad de un usuario"
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="Nombre_Salon"></param>
        /// <param name="e_UsuarioAU"></param>
        public VerSolicitud(int ID_Solicitud, string Nombre_Salon, E_Usuario e_UsuarioAU)
        {
            //Inicializando los componentes 

            InitializeComponent();

            //Asignando el nombre del salon
            e_Salon.nombre = Nombre_Salon;
            e_Solicitud.id_Solicitud = ID_Solicitud;


            //Asignando los datos a los controles 

            AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);

            //Asignando e_Usuario   a la goblal

            e_Usuario = e_UsuarioAU;



            #region Control de usuario

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Solicitudes";  // -- - -Opcion

            int ID_OSalones = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Aprobar
            SBAprobar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Aprobar");
            //Desaprobar
            SBDesaprobar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Aprobar");


            #endregion

        }

        #endregion

        #region  Asignando los datos a los controles -
        /// <summary>
        /// Metodo asignar Datos el cual asigna todos los datos 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="nombre"></param>
        public void AsignarDatos(int ID_Solicitud, String nombre)
        {

            //Asignando la informacion a las Entidades 
            //Solicitudes
            e_Solicitud = n_Solicitud.ObtenerSolicitud(ID_Solicitud);
            //Eventos
            e_Evento = n_Evento.ObtenerEvento(ID_Solicitud);
            //Organizador
            e_Organizador = n_Organizador.Obtenerorganizador(e_Evento.id_Evento);

            //Asignando la informacion de la solicitud

            LBLFecha.Text = e_Solicitud.fecha;
            //Estado de aprobacion
            LBLEstado.Text = e_Solicitud.aprobacion;

            //Fecha de aprobacion
            LBLFechaAprobacion.Text = e_Solicitud.fechaAprobacion;
            //Usuario 
            LBLUsuario.Text = e_Solicitud.usuario;

            //Asignando el nombre del salon 

            LBLSalon.Text = e_Salon.nombre;

            //Asignando la informacion a los controles 

            LBLTituloE.Text = e_Evento.titulo_Evento;
            //Tipo
            LBLTipoE.Text = e_Evento.tipo;
            //Tipico
            LBLTopico.Text = e_Evento.topico;
            //Descripcion
            LBLDescripcioinE.Text = e_Evento.descripcion;

            //Tiempo 

            LBLTiempoI.Text = e_Evento.tiempo_Inicio;
            LBLTiempoF.Text = e_Evento.tiempo_Final;

            //Organizador 

            LBLNombreO.Text = e_Organizador.nombre;
            //Descripcion
            LBLDescripcionO.Text = e_Organizador.descripcion;
            //Correo Organizaddor
            LBLCorreoO.Text = e_Organizador.correoElectronico;





        }
        #endregion

        #region Aprobar Solicitud -
        /// <summary>
        /// Evento click sobre el boton Aprobar el cual gectionara la aprobacion de una solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {


                //Aprobar solicitud  evento que retornara 
                if (LBLEstado.Text != "Aprobada")
                {
                    int FilaAfectada = n_Solicitud.AprobarSolicitud(e_Solicitud.id_Solicitud, e_Usuario.nombre);


                    //Verificacion 
                    if (FilaAfectada == 0)
                    {
                        //Mensaje de error
                        MessageBox.Show("Ocurrio un error al aprobar la solicitud ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        //Mensaje Positivo 
                        MessageBox.Show("Solcitud fue aprobada satifactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizar los datos en el formulario 
                        AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);
                    }

                }
                else
                {
                    MessageBox.Show("Solcitud ya esta aprobada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            //Se captura una excepcion  se muestra al usuario y se guarda un error en el XMl 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Solicitudes", "Aprobar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;

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
                e_Auditoria.tipoOpcion = "Aprobar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }



        #endregion

        #region Desaprobar Solicitud -

        /// <summary>
        /// Evento click sobre el boton desaprobar donde se desaprobara una solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBDesaprobar_Click(object sender, EventArgs e)
        {
            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {

                if (LBLEstado.Text != "No aprobada")
                {
                    //Filas afectadas 
                    int FilaAfectada = n_Solicitud.DesaprobarSolicitud(e_Solicitud.id_Solicitud, e_Usuario.nombre);

                    //Verificacion 
                    if (FilaAfectada == 0)
                    {
                        //mensaje de error 
                        MessageBox.Show("Ocurrio un error al desaprobar la solicitud ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Mensaje positivo 
                        MessageBox.Show("Solcitud fue desaprobada Satifactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizar los datos en el formulario 
                        AsignarDatos(e_Solicitud.id_Solicitud, e_Salon.nombre);

                    }

                }
                else
                {
                    MessageBox.Show("Solcitud ya no ha sido aprobada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //Se captura una excepcion  se muestra al usuario y se guarda un error en el XMl 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Solicitudes", "Desaprobar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;

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
                e_Auditoria.tipoOpcion = "Desaprobar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }

        #endregion
    }
}