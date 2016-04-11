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
using DevExpress.XtraEditors;
using System.Data.SqlClient;

using Capas.Infraestructura.Entidades;
using Capas.Negocio;
using Capas.Aplicacion;

namespace Resa_Pro.Formularios
{
    public partial class CrearSalonF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //Interfaz que gestionara la creacion de un nuevo salon 
        //</Summary>

        #region Declaraciones -

        //Entidad Salon
        N_Salon n_salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

        //Entidad Servicio
        E_Servicio e_Servicio = new E_Servicio();

        N_Servicio n_Servicio = new N_Servicio();

        //Entidad Inventario
        E_Inventario e_Inventario = new E_Inventario();

        N_Inventario n_Inventario = new N_Inventario();
        //Usuario
        E_Usuario e_UsuarioAU = new E_Usuario();

        //Xml manager 
        XML_Manager X_m = new XML_Manager();

        #endregion

        #region Constructor -
        /// <summary>
        /// Metodo contructor de la  interfaz 
        /// </summary>
        public CrearSalonF(E_Usuario e_Usuario)
        {
            //Se inicializan los componentes 
            InitializeComponent();

            //Asignando los valores de la entidad de usuario recivida como parametro a la entidad global
            e_UsuarioAU = e_Usuario;

            #region Insertando los servicios y inventarios a los CheckedListBox

            //Servicios
            DataTable SqlDT = new DataTable();
            SqlDT = n_Servicio.ObtenerServiciosGlobales();

            CKDListServicios.DataSource = SqlDT;
            CKDListServicios.ValueMember = "ID";
            CKDListServicios.DisplayMember = "Servicio";

       

            #endregion


            #region Agregando opciones al combobox de estado 
            //Agregando  las opciones de los combobox 
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");

            #endregion


        }
        #endregion

       
        #region Crear Salon 
        /// <summary>
        /// Evento click sobre el boton crear que gestionara la funcion de creacion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBCrearSalon_Click(object sender, EventArgs e)
        {
            /*
            //Obtener fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Verifica los controles si tienen data 

                if (TENombre.EditValue == "" || TEDireccion.EditValue == "" || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
                {
                    //Mensaje de informacion para el usuario de que  todos los datos deben ser completados 
                    XtraMessageBox.Show("Todos los datos deben ser completados", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //Si los controles estan completos se inicia el proceso de creacion del salon 
                else
                {

                    #region Asignando Datos a la entidad de salon 
                    //se asignan los datos a una entidad salon 

                    e_Salon.nombre = Convert.ToString(TENombre.EditValue);
                    e_Salon.ubicacion = Convert.ToString(TEDireccion.EditValue);
                    e_Salon.capacidad = Convert.ToInt32(TECapacidad.EditValue);
                    e_Salon.estado = Convert.ToString(CBEstado.SelectedItem);

                    #endregion


                    //Se crea un salon y se recupera un ID del mismo 
                    e_Salon.id_Salon = n_salon.CrearSalon(e_Salon);

                    //Se verifica el resultado  
                    if (e_Salon.id_Salon == null)
                    {
                        //Mensaje de error 
                        MessageBox.Show("Nose pudo guardar el salon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Se inicia el proceso de agregar "Inventarios" y "Servicios"
                    else
                    {

                        #region  Desactivar controles del grupo  de controles de la creacion de salon
                        //Se desactivan  los controles destinados para la creacion de los salones  

                        TENombre.Enabled = false;
                        TEDireccion.Enabled = false;
                        TECapacidad.Enabled = false;
                        CBEstado.Enabled = false;
                        SBCrearSalon.Enabled = false;

                        #endregion

                        #region Se habilitan los controles de los grupos de servicios y inventarios 

                        //Se activan los controles desactivados con anterioridad 

                        //Servicios
                     
                        //Inventarios
                      


                        #endregion
                    }

                }

            }
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_UsuarioAU.id_Usuario), "Salones", "Crear", Convert.ToString(E));

            }

            */


        }





        #endregion

        #region Servicios 

        #region Eliminar Servicio Global 
        private void SBEliminarS_Click(object sender, EventArgs e)
        {
            int FilasAfectadas;

            if (CKDListServicios.SelectedItems.Count == 1)
            {


                int ID = Convert.ToInt32(CKDListServicios.SelectedValue);

                MessageBox.Show(Convert.ToString(ID));

                FilasAfectadas = n_Servicio.EliminarServicioGlobal(ID);

                if (FilasAfectadas != 0)
                {

                    MessageBox.Show("El servicio se elimino correctamente!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Servicios
                    DataTable SqlDT = new DataTable();
                    SqlDT = n_Servicio.ObtenerServiciosGlobales();

                    CKDListServicios.DataSource = SqlDT;
                    CKDListServicios.ValueMember = "ID";
                    CKDListServicios.DisplayMember = "Servicio";
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar el servicio"," Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se debe selccionar un servicio para ser eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


        #endregion

        #region Agregar Servicio Global
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            if(TBServicio.Text != "")
            {

                FilasAfectadas = n_Servicio.InsertarServicioGlobal(TBServicio.Text);

                if(FilasAfectadas != 0)
                {
                    MessageBox.Show("El servicio se agrego correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Servicios
                    DataTable SqlDT = new DataTable();
                    SqlDT = n_Servicio.ObtenerServiciosGlobales();

                    CKDListServicios.DataSource = SqlDT;
                    CKDListServicios.ValueMember = "ID";
                    CKDListServicios.DisplayMember = "Servicio";

                    //Limpiando el campo de servicio 

                    TBServicio.Clear();

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Se debe completar el campo de servicio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        #endregion


        #endregion

        #region Inventarios

        #region Eliminar Inventario Global


        #endregion


        #region Eliminar Inventario Global 


        #endregion

        #endregion

        /*
        #region Servicios -

        //<summary>
        // Seccion donde se agregaran los servicios  y quitaran los servicios al salon
        //</summary>

        #region Agregar Servicio 


        /// <summary>
        /// Evento click del boton agregar en el cual se agregara un servicio al salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            //variable que recogera las filas afectadas
            int FilasAfectadas = 0;

            try
            {
                //Verificacion de los controles "Que contengan data"
                if (TBNombreS.Text == "" || TBDescripcionS.Text == "")
                {
                    //mensaje de informacion de que los controles deben estar completos 
                    MessageBox.Show("Los campos de servicio y descripcion deben tener informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                //Si los controles estan completos se ejecuta la siguiente fraccion de codigo
                else
                {
                    #region Asignando los valores a la entidad de servicios

                    //Se completa la entidad de servicios 

                    e_Servicio.servicio = Convert.ToString(TBNombreS.Text);
                    e_Servicio.descripcion = Convert.ToString(TBDescripcionS.Text);
                    e_Servicio.id_Salon = e_Salon.id_Salon;

                    #endregion

                    #region Agregando el servicio al salon
                    //Se agrega el servicio al salon 


                    FilasAfectadas = n_Servicio.AgregarServicio(e_Servicio);

                    //Se verifica las filas afectadas 
                    if (FilasAfectadas == 0)
                    {
                        //En este caso se muestra un mensaje de error a guardar el servicio 
                        MessageBox.Show("Ocurrio un error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                    //Si no ocurrio un error se muestra el siguiente mensaje 
                    else
                    {

                        //Mensaje positivo en la insercion 
                        MessageBox.Show(" El servicio se agrego correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #region Obteniendo Servicios
                        //Se completa el datasource del grid control destinado a presentar los  datos de un servicio 
                        GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

                        #endregion

                        #region Limpiando los controles 

                        //Se limpian los controles consernientes   a los servicios 
                        TBNombreS.Clear();
                        TBDescripcionS.Clear();
                        #endregion



                    }

                    #endregion



                }

            }
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        #endregion

        #region QuitarServicio


        /// <summary>
        /// Evento Click del boton quitar el cual quitara un servicio al salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SBQuitarS_Click(object sender, EventArgs e)
        {
            //variable que recogera las filas afectadas 
            int FilasAfectadas = 0;

            try
            {
                //Se recoge el ID del servicio 
                int ID_Servicio = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                if (ID_Servicio != 0)
                {

                    //Ejecutar el metodo en la capa de negocio de eliminar el servicio

                    FilasAfectadas = n_Servicio.EliminarServicio(ID_Servicio);

                    //Verificacion de las filas afectadas
                    if (FilasAfectadas != 1)
                    {
                        //Mensaje negativo 
                        MessageBox.Show("El servicio no fue eliminado ocurrio un error al eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //De lo contrario se ejecuta 
                    else
                    {
                        //Mensaje positivo
                        MessageBox.Show("El servicio fue eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Actualizando el data source de la GRID Control  de servicios

                        GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

                    }


                }
                else
                {
                    //Mensaje de que el grid no contiene data

                    MessageBox.Show("No hay un servicio seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #endregion

        #region Inventarios -

        //<summary>
        // Seccion donde se gestionaran los servicios del salon 
        //</summary>

        #region Agregar inventario - 

        /// <summary>
        /// Evento click  del boton agregar el cual gestionara la funcion de agregar un inventario al salon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarI_Click(object sender, EventArgs e)
        {
            //Variables que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Verificacion si control esta completo 
            if (TBNombreIV.Text == "")
            {
                //Mensaje  de sugerencia 
                MessageBox.Show("El Campo de inventario esta vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            //En caso de que el los controles tengan data se ejecuta lo siguiente 
            else
            {

                #region Asignando los valores a la entidad de inventarios

                //Se asignan los valores a la entidad 

                e_Inventario.inventario = Convert.ToString(TBNombreIV.Text);

                e_Inventario.id_Salon = e_Salon.id_Salon;

                #endregion

                #region Agregando el inventario al salon

                //Agregando inventario al sistema
                FilasAfectadas = n_Inventario.AgregarInventario(e_Inventario);

                // Verificacion de las filas afectadas 
                if (FilasAfectadas == 0)
                {
                    //mensaje negativo
                    MessageBox.Show("Ocurrio un error al guardar los datos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

                //En caso de lo contrario 

                else
                {

                    //mensje positivo 
                    MessageBox.Show(" El inventario se agrego correctamente ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Obteniendo inventarios

                    //precentando los inventarios del salon
                    GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Inventario.id_Salon);

                    #endregion

                    #region Limpiando los controles 
                    //Limpiando  el control  

                    TBNombreIV.Clear();

                    #endregion



                }

            }

        }

        #endregion

        #endregion

        #region Quitar inventario -
        /// <summary>
        ///  Evento click sobre el boton quitar el que gestionara la funcion de eliminar un inventario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBQuitarI_Click(object sender, EventArgs e)
        {
            //variable que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Se recoge el  id del inventario del grid view 
            int ID_Inventario = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ID"));

            if (ID_Inventario != 0)
            {
                //Ejecutar el metodo en la capa de negocio de eliminar el servicio

                FilasAfectadas = n_Inventario.EliminarInventario(ID_Inventario);

                //se verifica las filas afectadas
                if (FilasAfectadas != 1)
                {
                    //mensaje negativo
                    MessageBox.Show("El inventario no fue eliminado ocurrio un error al eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    //Mensaje positivo 
                    MessageBox.Show("El inventario Fue eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualizando el data source de la GRID Control 

                    GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);

                }

            }
            else
            {
                //Mensaje de error  de que no hay ningun inventario seleccionado para quitar

                MessageBox.Show("No hay ningun inventario seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }




        #endregion

        #endregion
    */


    }
}