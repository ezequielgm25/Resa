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
         


        #endregion


        #region Contructor 
        public UsuariosF()
        {
            InitializeComponent();


            #region inicializando el datasource del grid control 


            GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();

            #endregion


        }

        #endregion


        #region Agregar Usuario 
        private void SBAgregarU_Click(object sender, EventArgs e)
        {
            //Intanciando la interfaz de crear Usuario 

            CrearUsuarioF c_UsuarioF = new CrearUsuarioF();

            c_UsuarioF.ShowDialog();

            //actualizando el data sorce del grid control de usuarios 

            GCUsuarios.DataSource = n_Usuario.ObtenerUsuarios();

            
        }





        #endregion


        #region actualizar Usuario 
        private void SBActualizarU_Click(object sender, EventArgs e)
        {
            //<Summary>
            // Se actualizara un evento
            //</Summary>

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




        #endregion


        #region Eliminar 
        private void SBEliminarU_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            //Preguntar al usuario  si desea eliminarlo
            //Recupera el ID de la del Usuario el cual sera eliminado 

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

        

        #endregion
    }
}