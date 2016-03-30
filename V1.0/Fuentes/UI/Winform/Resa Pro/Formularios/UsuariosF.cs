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

        #endregion


        #region Contructor 
        public UsuariosF(E_Usuario e_UsuarioAU)
        {
            InitializeComponent();


            #region inicializando el datasource del grid control 


            GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();

            #endregion


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
                MessageBox.Show(Convert.ToString(E));


            }

            finally
            {

                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Usuarios";
                e_Auditoria.tipoOpcion = "Agregar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);


            }





        }





        #endregion


        #region actualizar Usuario 
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
                    MessageBox.Show(" No hay un usuario seleccionado");
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
                e_Auditoria.opcion = "Usuarios";
                e_Auditoria.tipoOpcion = "Actualizar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }


        }




        #endregion


        #region Eliminar 
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
                    DialogResult dialogResult = MessageBox.Show("Desea eliminar el Usuario?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {



                        FilasAfectadas = n_Usuario.EliminarUsuario(e_Usuario.id_Usuario);

                        if (FilasAfectadas != 1)
                        {
                            MessageBox.Show("Ocurrio un error al eliminar el usuario");
                        }
                        else
                        {
                            MessageBox.Show("El Usuario se elimino correctamente");

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
                    MessageBox.Show(" No hay un usuario seleccionado ");
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E));
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