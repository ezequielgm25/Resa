using System;
using System.Windows.Forms;

using System.Text.RegularExpressions;
//---//
using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class OrganizadoresF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz que manejara el CRUD de los organizadores
        //</Summary>

        #region Declaraciones -- 

        //Organizadores
        E_Organizador e_Organizador = new E_Organizador();

        N_Organizador n_Organizador = new N_Organizador();

        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la interfaz de organizadores donde se gestiona el CRUD de los organizadores globales 
        /// </summary>
        public OrganizadoresF()
        {
            InitializeComponent();

            //Asignando el datasorce al grid control 

            GCOrganizadores.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();


        }

        #endregion

        #region Agregar Organizador 
        /// <summary>
        /// Metodo donde se agrega un organizador a la lista de organizadores globales 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregar_Click(object sender, EventArgs e)
        {
            //Verificacion de los campos 
            if (TBNombreO.Text == "" || TBDescripcionO.Text == "" || TBCorreoO.Text == "" || VEmail(TBCorreoO.Text) != true)
            {
                if (TBCorreoO.Text != "" && VEmail(TBCorreoO.Text) != true)
                {

                    //Mensaje de informacion de los campos no estan completos o debidamente llenos
                    MessageBox.Show("El correo esta mal escrito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    //Mensaje de informacion de los campos no estan completos o debidamente llenos
                    MessageBox.Show("Todos los campos deben contener Informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //Asignando los datos a la entidad de organizador

                //Nombre
                e_Organizador.nombre = TBNombreO.Text;
                //Descripcion
                e_Organizador.descripcion = TBDescripcionO.Text;
                //correoElectronico
                e_Organizador.correoElectronico = TBCorreoO.Text;


                //Guardando el organizador 

                int FilasAfectadas = n_Organizador.InsertarOrganizadorGlobal(e_Organizador);

                //Verificando los datos
                if (FilasAfectadas == 0)
                {
                    //Mensaje de error
                    MessageBox.Show("Ocurrio un error al guardar el organizador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    //Mensaje positivo se guardo correctamente

                    MessageBox.Show("El organizador se guardo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Actualizando el datasource 

                    GCOrganizadores.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();



                }


            }

        }
        #endregion

        #region Verificar Email 
        /// <summary>
        /// Metodo donde se verifica la correcta forma del correo electronico 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool VEmail(String Email)
        {
            //Variable que contendra la expresion de validacion del email  
            String expresion;
            //Asignando la expresion de validacion 
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            //Varificando 
            if (Regex.IsMatch(Email, expresion))
            {
                //Desicion 
                if (Regex.Replace(Email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Actualizar Organizador
        /// <summary>
        /// Metodo donde se actualiza las caracteristicas de un organizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            int ID_Organizador = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));


            if (ID_Organizador != 0)
            {

                //Revizando que todos los campos esten completamente llenos 
                if (TBNombreO.Text == "" || TBDescripcionO.Text == "" || TBCorreoO.Text == "" || VEmail(TBCorreoO.Text) != true)
                {
                    if (TBCorreoO.Text != "" && VEmail(TBCorreoO.Text) != true)
                    {

                        //Mensaje de informacion de los campos no estan completos o debidamente llenos
                        MessageBox.Show("El correo esta mal escrito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    else
                    {
                        //Mensaje de informacion de los campos no estan completos o debidamente llenos
                        MessageBox.Show("Todos los campos deben contener Informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //Asignando los datos a la entidad de organizador

                    //Nombre
                    e_Organizador.nombre = TBNombreO.Text;
                    //Descripcion
                    e_Organizador.descripcion = TBDescripcionO.Text;
                    //correoElectronico
                    e_Organizador.correoElectronico = TBCorreoO.Text;


                    //Guardando el organizador 

                    int FilasAfectadas = n_Organizador.ActualizarOrganizadorGlobal(e_Organizador);

                    //Verificando los datos
                    if (FilasAfectadas == 0)
                    {
                        //Mensaje de error
                        MessageBox.Show("Ocurrio un error al actualizar el organizador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //De lo contrario 
                    else
                    {
                        //Mensaje positivo se guardo correctamente

                        MessageBox.Show("El organizador se actualizo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        //Actualizando el datasource 

                        GCOrganizadores.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();

                        //Limpiando los controles 

                        TBNombreO.Text = "";
                        TBDescripcionO.Text = "";
                        TBCorreoO.Text = "";


                    }


                }


            }
            else
            {
                //mensaje  de que el Grid view esta vacio 

                MessageBox.Show(" No hay ninguna ubicacion a eliminar seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        #endregion

        #region Click en la grid control
        /// <summary>
        /// Evento click en el grid control de organizadores 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCOrganizadores_Click(object sender, EventArgs e)
        {
            //Asignando la data a la entidad

            e_Organizador.id_Organizador = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            e_Organizador.nombre = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

            e_Organizador.descripcion = Convert.ToString(gridView1.GetFocusedRowCellValue("Descripcion"));

            e_Organizador.correoElectronico = Convert.ToString(gridView1.GetFocusedRowCellValue("Correo"));

            //Asignando  a los controles 

            TBNombreO.Text = e_Organizador.nombre;
            TBDescripcionO.Text = e_Organizador.descripcion;
            TBCorreoO.Text = e_Organizador.correoElectronico;



        }

        #endregion

        #region Eliminar 
        /// <summary>
        /// Metodo donde se elimina un  organizador global del sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminar_Click(object sender, EventArgs e)
        {
            //Filas afectadas 
            int FilasAfectadas;
            //ID organizador 
            int ID_Organizador = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));


            if (ID_Organizador != 0)
            {

                //Preguntar al usuario  si desea eliminarlo  "Este es el dialogo en el que se le preguntara al usuario la confirmacion de la eliminacion "
                DialogResult dialogResult = MessageBox.Show("Desea eliminar el organizador?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                //Si el dialogo result resulta  positivo 
                if (dialogResult == DialogResult.Yes)
                {


                    //Variables que recuperara las filas afectadas 
                    FilasAfectadas = n_Organizador.EliminarOrganizadorGlobal(ID_Organizador);

                    //Si no se afecto ninguna fila es por que hubo un error en el sistema  el cual se le presenta al usuario
                    if (FilasAfectadas != 1)
                    {
                        MessageBox.Show("Ocurrio un error al eliminar el organizador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //De lo contrario se mostrara un mensaje con la informacion positiva de que se elimino el salon 
                    else
                    {
                        MessageBox.Show("El organizador se elimino Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GCOrganizadores.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();

                        //Limpiando los controles 

                        TBNombreO.Text = "";
                        TBDescripcionO.Text = "";
                        TBCorreoO.Text = "";

                    }

                }
                //Si la iteracion con el dialogo result fue negativa  "No se hara nada "
                else if (dialogResult == DialogResult.No)
                {
                    //No se hace nada 
                }

            }

            else
            {
                //mensaje  de que el Grid view esta vacio 

                MessageBox.Show(" No hay ninguna ubicacion a eliminar seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }

        #endregion
    }
}