using System;
using System.Windows.Forms;

//usings del sistema
using Capas.Aplicacion;
using Capas.Infraestructura.Entidades;
using Capas.Negocio;


namespace Resa_Pro.Formularios
{
    public partial class UsuariosF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz de gestion  de los usuarios 
        //</Summary>

        #region Declaraciones 
        //Usuarios 
        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();

        //Entidad para el usuairo Autentificado
        E_Usuario e_UsuarioAutentificado = new E_Usuario();
        //Auditorias 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();

        //Xml manager 
        XML_Manager X_m = new XML_Manager();

        //Variable que recogera el error

        string MessageError = "";

        #endregion

        #region Contructor 
        /// <summary>
        /// Contructor de la interfaz de manejo de los usuarios 
        /// </summary>
        /// <param name="e_UsuarioAU"></param>
        public UsuariosF(E_Usuario e_UsuarioAU)
        {
            //Inicializando los componentes 
            InitializeComponent();


            #region inicializando el datasource del grid control 


            GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();

            #endregion

            //Asignando la Entidad araigada a la global 
            e_Usuario = e_UsuarioAU;


            #region Control de usuario

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Usuarios";  // -- - -Opcion

            int ID_OUsuarios = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Crear
            SBAgregarU.Visible = n_Usuario.ObtenerFuncion(ID_OUsuarios, "Crear");
            //Actualizar
            SBActualizarU.Visible = n_Usuario.ObtenerFuncion(ID_OUsuarios, "Actualizar");
            //Eliminar
            SBEliminarU.Visible = n_Usuario.ObtenerFuncion(ID_OUsuarios, "Eliminar");


            #endregion




        }

        #endregion

        #region Agregar Usuario 
        /// <summary>
        /// Evento click sobre el agregar donde se gestionara la creacion de un usuaro 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarU_Click(object sender, EventArgs e)
        {


            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Intanciando la interfaz de crear Usuario 

                CrearUsuarioF c_UsuarioF = new CrearUsuarioF();

                c_UsuarioF.ShowDialog();

                //actualizando el data sorce del grid control de usuarios 

                GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();
            }
            catch (Exception E)
            {

                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Usuarios", "Agregar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;

            }

            finally
            {

                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Usuarios";
                e_Auditoria.tipoOpcion = "Agregar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);


            }





        }





        #endregion

        #region Actualizar Usuario 
        /// <summary>
        /// Evento click sobre el boton actualizar donde se gestiona la actuaizacion de un usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizarU_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara un evento
            //</Summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                int ID_Usuario = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                if (ID_Usuario != 0)
                {

                    //Intanciando la interfaz de Actualizar un usuario 

                    ActualizarUsuario A_Usuario = new ActualizarUsuario(ID_Usuario);

                    A_Usuario.ShowDialog();


                    //actualizando el data sorce del grid control de usuarios 

                    GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();
                }

                else
                {
                    MessageBox.Show(" No hay un usuario seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Usuarios", "Actualizar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Usuarios";
                e_Auditoria.tipoOpcion = "Actualizar" + MessageError;

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }


        }




        #endregion

        #region Eliminar   
        /// <summary>
        /// Evento click sobre el boton eliminar que gestiona la eliminacio de un usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminarU_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            //Preguntar al usuario  si desea eliminarlo
            //Recupera el ID de la del Usuario el cual sera eliminado 

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);
            e_UsuarioAutentificado.id_Usuario = e_Usuario.id_Usuario;

            try
            {

                e_Usuario.id_Usuario = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                if (e_Usuario.id_Usuario != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Desea eliminar el usuario?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {



                        FilasAfectadas = n_Usuario.EliminarUsuario(e_Usuario.id_Usuario);

                        if (FilasAfectadas != 1)
                        {
                            MessageBox.Show("Ocurrio un error al eliminar el usuario", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El usuario se elimino correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();

                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //No hacer nada
                    }

                }
                else
                {
                    MessageBox.Show(" No hay un usuario seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Usuarios", "Eliminar", Convert.ToString(E));

                //Mensaje de error 

                MessageError = E.Message;
            }

            finally
            {
                e_Auditoria.id_Usuario = e_UsuarioAutentificado.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Usuarios";
                e_Auditoria.tipoOpcion = "Eliminar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);

            }


        }
          


    #endregion
}
}