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
using DevExpress.XtraEditors;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class ActualizarSalon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //Clase de la interfaz de actualizacion de un formulario
        //</Summary>

        #region Instancias -
            //Salon
        E_Salon et_Salon = new E_Salon();
        N_Salon n_Salon = new N_Salon();

        //Servicio
        E_Servicio e_Servicio = new E_Servicio();
        N_Servicio n_Servicio = new N_Servicio();

        //Inventario 
        E_Inventario e_Inventario = new E_Inventario();
        N_Inventario n_Inventario = new N_Inventario();

        #endregion

        #region Constructor -
         
        /// <summary>
        /// Contructor de la interfaz salon la cual espera una entidad salon como parametro 
        /// </summary>
        /// <param name="e_Salon"></param>
        public ActualizarSalon(E_Salon e_Salon)
        {
            //Inicializando los componentes
            InitializeComponent();

            //<summary>
            //Se asignaran los valores a los  a los controles correspondientes en la interfaz
            //</summary>

            //Asignando la los datos  de la entidad parametrica a la entidad global de la interfaz
            
            //----------------//
            et_Salon = e_Salon;
            //---------------//
            #region Asignando valores 

            //Parte de controles de un salon 

            TENombreS.EditValue = e_Salon.nombre;
            TEDireccion.EditValue = e_Salon.ubicacion;
            TECapacidad.EditValue = e_Salon.capacidad;

            #region Agregando opciones al combobox de estado 

            //Se agregan las opciones al comboBox 

            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");

            #endregion

            #region Asignando la opcion de la entidad all comboBox 

            if(e_Salon.estado == "Activo")
            {
                CBEstado.SelectedIndex = CBEstado.Items.IndexOf("Activo");
            }
            if(e_Salon.estado == "Inactivo")
            {
                CBEstado.SelectedIndex = CBEstado.Items.IndexOf("Inactivo");
            }

            #endregion




            #endregion

            #region Obteniendo los servicios y inventarios del salon

            #region Servicios 
            // Se obtienen los servicios de ese salon 
            GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

            #endregion

            #region Inventarios
            // Se obtienen los inventarios de  ese salon
            GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);
            #endregion

            #endregion


        }
        #endregion

        #region Actualizar  Salon -
        /// <summary>
        /// Evento Click sobre el boton actualizar el cual gestionara la funcion actualizar  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<summary>
            // Actualizar  Caracteristicas principales de un salon
            //</summary>

            //Asignando coleccion de  datos a la entidad 

            //----------//
            //Variable que recoge las filas afectadas 
            int FilasAfectadas = 0;

            //Se verifica si los controles estan llenos  o contienen data 
            if (TENombreS.EditValue == "" || TEDireccion.EditValue == "" || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
            {
                //Mensaje de informacion de que los controles deben estar debidadmente completados 
                MessageBox.Show("Todos los datos deben ser completados","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }

            // De lo contrario 
            else
            {

                #region Asignando Datos a la entidad de salon 

                // Se asigan los datos a la entidad de salones 

                et_Salon.nombre = Convert.ToString(TENombreS.EditValue);
                et_Salon.ubicacion = Convert.ToString(TEDireccion.EditValue);
                et_Salon.capacidad = Convert.ToInt32(TECapacidad.EditValue);
                et_Salon.estado = Convert.ToString(CBEstado.SelectedItem);

                #endregion

                //  Se ejecuta la actualizacion del salon 
                FilasAfectadas = n_Salon.ActualizarSalon(et_Salon);

                //Se verifica las filas afectadas 
                if (FilasAfectadas != 1 )
                {

                    //Mensaje de error en la actualizacion 
                   MessageBox.Show("Nose pudo guardar el salon","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    //Mensaje Positivo 
                    MessageBox.Show("Salon actualizado satisffactoriamente","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
         

                }

            }





        }



        #endregion

        #region Servicios -

        //<summary>
        // Seccion donde se agregaran los servicios  y quitaran los servicios al salon
        //</summary>


        #region Agregar Servicio - 
        /// <summary>
        /// Evento Click Sobre el boton Agregar el cual se hara la funcion de agregar un usuario al salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            //Variable que recogera las filas afectadas en la actualizacion 
            int FilasAfectadas = 0;

            //Verificacion de que los controles contegan data 
            if (TBNombreS.Text == "" || TBDescripcionS.Text == "")
            {
                //Mensaje de informacion de  que los controles estan vacios 
                MessageBox.Show("Los campos de servicio y descripcion deben tener informacion","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }
            // De lo contrario
            else
            {
                #region Asignando los valores a la entidad de servicios

                //Se asignan los datos  a la entidad de servicios 

                e_Servicio.servicio = Convert.ToString(TBNombreS.Text);
                e_Servicio.descripcion = Convert.ToString(TBDescripcionS.Text);
                e_Servicio.id_Salon = et_Salon.id_Salon;

                #endregion

                #region Agregando el servicio al salon

                //Ejecutando  la funcion de agregar servicios 
                FilasAfectadas = n_Servicio.AgregarServicio(e_Servicio);

                //Verificacion de las filas afectadas 
                if (FilasAfectadas == 0)
                {
                     //Mensaje de error en la insercion 
                    MessageBox.Show("Ocurrio un error al guardar los datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);


                }

                //De lo contrario
                else
                {

                    //Mensaje Positivo
                   MessageBox.Show(" El servicio se agrego correctamente ","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    #region Obteniendo Servicios

                    //Se obtienen los servicios consernientes al  salon 
                    GCServicios.DataSource = n_Servicio.ObtenerServicios(et_Salon.id_Salon);

                    #endregion

                    #region Limpiando los controles 

                    // Se limpian los controles 
                    TBNombreS.Clear();
                    TBDescripcionS.Clear();
                    #endregion 



                }

                #endregion



            }
        }

        #endregion

        #region Quitar Servicio -
        /// <summary>
        /// Evento click en el boton quitar en el cual se eliminara un evento del sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SBQuitarS_Click(object sender, EventArgs e)
        {
            // Varible que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Se recoje el ID del servicio del grid view el cual sera eliminado

            int ID_Servicio = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            if (ID_Servicio != 0)
            {

                //Ejecutar el metodo en la capa de negocio de eliminar el servicio

                FilasAfectadas = n_Servicio.EliminarServicio(ID_Servicio);

                //Verificacion de las filas afectadas
                if (FilasAfectadas != 1)
                {
                    //Mensaje Negativo
                    MessageBox.Show("El servicio no fue eliminado ocurrio un error al eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //De lo contrario 
                else
                {
                    //Mensaje Positivo
                    MessageBox.Show("El servicio Fue eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualizando el data source de la GRID Control de servicios  

                    GCServicios.DataSource = n_Servicio.ObtenerServicios(et_Salon.id_Salon);

                }

            }
            else
            {
                //Mensaje de  error de  que no hay nada seleccionado en el grid 
                MessageBox.Show("No hay ningun servicio seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #endregion

        #region Inventarios -
        //<summary>
        // Seccion donde se agregaran los inventarios  y quitaran los inventarios al salon
        //</summary>



        #region Agregar Inventario -
        /// <summary>
        /// Evento click  sobre el boton de agregar el cual manejara la funcion de agregar inventario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SBAgregarIV_Click(object sender, EventArgs e)
        {
            //Variables que recogera las filas afectadas
            int FilasAfectadas = 0;

            //Verificacion de los controles
            if (TBNombreIV.Text == "")
            {
                //Mensaje de informacion de que los controles estan vacios
                MessageBox.Show("El Campo de inventario esta vacio","Informacion" , MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
            // De lo contrario 
            else
            {
                #region Asignando los valores a la entidad de inventarios

                e_Inventario.inventario = Convert.ToString(TBNombreIV.Text);

                e_Inventario.id_Salon = et_Salon.id_Salon;

                #endregion

                #region Agregando el inventario al salon

                //Se ejecuta la funcion de agregar inventario 
                FilasAfectadas = n_Inventario.AgregarInventario(e_Inventario);

                // se verifican las filas afectadas
                if (FilasAfectadas == 0)
                {
                    //mensaje de error
                    MessageBox.Show("Ocurrio un error al guardar los datos ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);


                }
                //De lo contrario  
                else
                {

                    //mensaje positivo 
                    MessageBox.Show(" El inventario se agrego correctamente ","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    #region Obteniendo inventarios

                    //Se actualiza el data source del grid view 
                    GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Inventario.id_Salon);

                    #endregion

                    #region Limpiando los controles 

                    // Se limpian los controles del grid view 
                    TBNombreIV.Clear();

                    #endregion



                }
                #endregion
            }



        }




        #endregion

        #region Quitar Inventario -
        /// <summary>
        /// Evento click sobre el boton quitar en el cual se realizara la funcion de eliminar un inventario de un salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBQuitarIV_Click(object sender, EventArgs e)
        {
            //Variable que recogera las filas afectadas 
            int FilasAfectadas = 0;

            //Se recoge el ID del inventario del grid view 
            int ID_Inventario = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ID"));


            if (ID_Inventario != 0)
            {
                //Ejecutar el metodo en la capa de negocio de eliminar el servicio

                FilasAfectadas = n_Inventario.EliminarInventario(ID_Inventario);

                //Se verifica las Fillas Afectadas
                if (FilasAfectadas != 1)
                {
                    //Men saje de eeror al eliminar el inventario 
                    MessageBox.Show("El inventario no fue eliminado ocurrio un error al eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    //mensaje Positivo 
                    MessageBox.Show("El inventario Fue eliminado correctamente");

                    //Actualizando el data source de la GRID Control 

                    GCInventarios.DataSource = n_Inventario.ObtenerInventarios(et_Salon.id_Salon);

                }

            }

            else
            {
                //Mensaje de error mostrado al usuario de que no hay nada seleleccionado en el grid 
                MessageBox.Show("No hay ningun inventario seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
        #endregion

       

        #endregion

    }
}