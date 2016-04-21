using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//Usings del sistema 
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

            //Asignando las direcciones al combobox

            CBUbicacion.DataSource = n_salon.ObtenerUbicacionesGlobales();
            CBUbicacion.DisplayMember = "Ubicacion";

            //Deseleccionando el items predeterminado 
            CBUbicacion.SelectedItem = null;

            #region Insertando los servicios y inventarios a los CheckedListBox

            //Servicios
            //DataTable 
            DataTable SqlDT = new DataTable();
            //Llenando datatable
            SqlDT = n_Servicio.ObtenerServiciosGlobales();
            //Asignando datatable
            CKDListServicios.DataSource = SqlDT;
            CKDListServicios.ValueMember = "ID";
            CKDListServicios.DisplayMember = "Servicio";


            //Inventarios 

            //DataTable 
            DataTable SqlDT2 = new DataTable();
            //Llenando datatable
            SqlDT2 = n_Inventario.ObtenerInventariosGlobales();
            //Asignando data table al checklist de inventario
            CKDListInventario.DataSource = SqlDT2;
            CKDListInventario.ValueMember = "ID";
            CKDListInventario.DisplayMember = "Inventario";



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

            //Obtener fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Verifica los controles si tienen data 

                if (TENombre.EditValue == "" || CBUbicacion.SelectedItem == null || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
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


                    DataRowView CBView = CBUbicacion.SelectedValue as DataRowView;

                    e_Salon.ubicacion = Convert.ToString(CBView["Ubicacion"]);

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
                        bool guardado = false;

                        int FilasAfectadas = 1;

                        #region  Guardando los servicios del Salon
                        //Verificacion si el checklist de servicios tiene algun items
                        if (CKDListServicios.Items.Count > 0)
                        {

                            //Foreach que guardara cada items seleccionado en la base de datos 
                            foreach (DataRowView rowView in CKDListServicios.CheckedItems)
                            {
                                //Completando la entidad de servicios 
                                e_Servicio.id_Salon = e_Salon.id_Salon;
                                e_Servicio.servicio = Convert.ToString(rowView["Servicio"]);

                                //Ejecutando el metodo 
                                FilasAfectadas = n_Servicio.AgregarServicio(e_Servicio);

                                //Verificacion de filas afectadas
                                if (FilasAfectadas == 0)
                                {
                                    guardado = false;

                                }
                                else
                                {
                                    guardado = true;
                                }

                            }


                        }




                        #endregion

                        #region Guardando los inventarios del salon  

                        //Verifiacion si hay algun elemento en el checklist de inventarios
                        if (CKDListInventario.Items.Count > 0)
                        {
                            //Guardando cada inventario seleccionado en la base de datos 
                            foreach (DataRowView rowView in CKDListInventario.CheckedItems)
                            {
                                //Completando la entidad de inventarios
                                e_Inventario.id_Salon = e_Salon.id_Salon;
                                e_Inventario.inventario = Convert.ToString(rowView["Inventario"]);

                                //Ejecutando el metodo de filas afectadas
                                FilasAfectadas = n_Inventario.AgregarInventario(e_Inventario);

                                //Verificacion
                                if (FilasAfectadas == 0)
                                {
                                    guardado = false;

                                }
                                else
                                {
                                    guardado = true;
                                }
                            }


                        }

                        //Mostrando mensajes  al usuario segun los resultados devueltos
                        if (FilasAfectadas == 0)
                        {
                            //Negativo
                            MessageBox.Show("Nose pudo guardar las informacion de servicios y inventarios del salon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //Positivo
                            MessageBox.Show("Salon guardado exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

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




        }





        #endregion

        #region Servicios 

        #region Eliminar Servicio Global 
        /// <summary>
        /// Evento Click sobre el boton eliminar la cual ejecutara una accion de eliminacion de un servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminarS_Click(object sender, EventArgs e)
        {
            //Variables    que recoge las filasafectadas
            int FilasAfectadas;

            if (CKDListServicios.SelectedItems.Count == 1)
            {

                //Recogien el ID del servicio
                int ID = Convert.ToInt32(CKDListServicios.SelectedValue);



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
                    MessageBox.Show("Ocurrio un error al eliminar el servicio", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se debe selecionar un servicio para ser eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


        #endregion

        #region Agregar Servicio Global
        /// <summary>
        /// Evento click sobre el  boton agregar en el cual se agrega un servicio a la base de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
            //Recogiendo las filas afectadas
            int FilasAfectadas = 0;

            if (TBServicio.Text != "")
            {

                FilasAfectadas = n_Servicio.InsertarServicioGlobal(TBServicio.Text);

                if (FilasAfectadas != 0)
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
        /// <summary>
        /// Evento click sobre el boton eliminar el cual ejecutara la accion de eliminar un inventario en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminarI_Click(object sender, EventArgs e)
        {
            //Recogiendo las filas afectadas
            int FilasAfectadas;

            if (CKDListInventario.SelectedItems.Count == 1)
            {


                int ID = Convert.ToInt32(CKDListInventario.SelectedValue);



                FilasAfectadas = n_Inventario.EliminarInventarioGlobal(ID);

                if (FilasAfectadas != 0)
                {

                    MessageBox.Show("El Inventario se elimino correctamente!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Inventarios 
                    DataTable SqlDT2 = new DataTable();
                    SqlDT2 = n_Inventario.ObtenerInventariosGlobales();

                    CKDListInventario.DataSource = SqlDT2;
                    CKDListInventario.ValueMember = "ID";
                    CKDListInventario.DisplayMember = "Inventario";
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar el servicio", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se debe selecionar un inventario para ser eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        #endregion

        #region Agregar Inventario Global 

        private void SBAgregarI_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            if (TBInventario.Text != "")
            {

                FilasAfectadas = n_Inventario.InsertarInventarioGlobal(TBInventario.Text);

                if (FilasAfectadas != 0)
                {
                    MessageBox.Show("El inventario se agrego correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Inventarios 
                    DataTable SqlDT2 = new DataTable();
                    SqlDT2 = n_Inventario.ObtenerInventariosGlobales();

                    CKDListInventario.DataSource = SqlDT2;
                    CKDListInventario.ValueMember = "ID";
                    CKDListInventario.DisplayMember = "Inventario";

                    //Limpiando el campo de inventario

                    TBInventario.Clear();

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Se debe completar el campo de inventario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




        #endregion

        #endregion

        #region Ubicaciones
        /// <summary>
        /// Metodo donde se maneja las uvicaciones Globales de los salones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBUbicaciones_Click(object sender, EventArgs e)
        {
            //Instanciando el formulario 

            UbicacionF Ubicacion = new UbicacionF();

            Ubicacion.ShowDialog();

            //Asignando las direcciones al combobox

            CBUbicacion.DataSource = n_salon.ObtenerUbicacionesGlobales();
            CBUbicacion.DisplayMember = "Ubicacion";


        }

        #endregion
    }
}