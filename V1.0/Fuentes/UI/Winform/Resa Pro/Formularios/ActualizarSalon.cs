using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Capas.Negocio;

//Usings del sistema
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

            //Asignando las direcciones al combobox

            CBUbicacion.DataSource = n_Salon.ObtenerUbicacionesGlobales();
            CBUbicacion.DisplayMember = "Ubicacion";


            //Parte de controles de un salon 

            TENombreS.EditValue = e_Salon.nombre;


            int C = 0;
            //Asignando al combo box de ubicaciones la ubicacion seleccionada anteriormente
            foreach (DataRowView rowView in CBUbicacion.Items)
            {
                //Completando la entidad de servicios 

                if (e_Salon.ubicacion == Convert.ToString(rowView["Ubicacion"]))
                {

                    CBUbicacion.SelectedItem = CBUbicacion.Items[C];
                }

                C++;
            }


            TECapacidad.EditValue = e_Salon.capacidad;

            #region Agregando opciones al combobox de estado 

            //Se agregan las opciones al comboBox 

            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");

            #endregion

            #region Asignando la opcion de la entidad al comboBox 

            if (e_Salon.estado == "Activo")
            {
                CBEstado.SelectedIndex = CBEstado.Items.IndexOf("Activo");
            }
            if (e_Salon.estado == "Inactivo")
            {
                CBEstado.SelectedIndex = CBEstado.Items.IndexOf("Inactivo");
            }

            #endregion

            #endregion

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

            #region Seleccionando los inventarios y  servicios que tenga el  salon

            #region Servicios

            int FilasAfectadas = 0;
            int n = 0;
            int Resultado = 0;

            //Verificacion si el checklist de servicios tiene algun items
            if (CKDListServicios.Items.Count > 0)
            {


                List<int> IndexesLista = new List<int>();

                //Foreach que guardara cada items seleccionado en la base de datos 
                foreach (DataRowView rowView in CKDListServicios.Items)
                {
                    //Completando la entidad de servicios 
                    e_Servicio.id_Salon = e_Salon.id_Salon;
                    e_Servicio.servicio = Convert.ToString(rowView["Servicio"]);

                    //Ejecutando el metodo 
                    Resultado = n_Servicio.VerificarExistenciaDeServicio(e_Servicio);

                   
                    if (Resultado != 0)
                    {
                        IndexesLista.Add(n);
                    }

                    n++;
                }

                //Foreach Para marcar los servicios 
                n = 0;
                foreach (int indexes in IndexesLista)
                {

                    CKDListServicios.SetItemCheckState(IndexesLista[n], CheckState.Checked);

                    n++;
                }


            }


            #endregion

            #region Inventarios

            //Verificacion si el checklist de Inventarios tiene algun items
            if (CKDListInventario.Items.Count > 0)
            {

                n = 0;
                Resultado = 0;

                List<int> IndexesLista = new List<int>();

                //Foreach que guardara cada items seleccionado en la base de datos 
                foreach (DataRowView rowView in CKDListInventario.Items)
                {
                    //Completando la entidad de Inventarios
                    e_Inventario.id_Salon = e_Salon.id_Salon;
                    e_Inventario.inventario = Convert.ToString(rowView["Inventario"]);

                    //Ejecutando el metodo 
                    Resultado = n_Inventario.VerificarExistenciaDeInventario(e_Inventario);


                    if (Resultado != 0)
                    {
                        IndexesLista.Add(n);
                    }

                    n++;
                }

                //Foreach Para marcar los servicios 
                n = 0;
                foreach (int indexes in IndexesLista)
                {

                    CKDListInventario.SetItemCheckState(IndexesLista[n], CheckState.Checked);

                    n++;
                }


            }
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
            if (TENombreS.EditValue == "" || CBUbicacion.SelectedItem == null || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
            {
                //Mensaje de informacion de que los controles deben estar debidadmente completados 
                MessageBox.Show("Todos los datos deben ser completados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            // De lo contrario 
            else
            {

                #region Asignando Datos a la entidad de salon 

                // Se asigan los datos a la entidad de salones 

                et_Salon.nombre = Convert.ToString(TENombreS.EditValue);


                DataRowView CBView = CBUbicacion.SelectedValue as DataRowView;

                et_Salon.ubicacion = Convert.ToString(CBView["Ubicacion"]);

                et_Salon.capacidad = Convert.ToInt32(TECapacidad.EditValue);
                et_Salon.estado = Convert.ToString(CBEstado.SelectedItem);

                #endregion

                //  Se ejecuta la actualizacion del salon 
                FilasAfectadas = n_Salon.ActualizarSalon(et_Salon);




                //Se verifica las filas afectadas 
                if (FilasAfectadas != 1)
                {

                    //Mensaje de error en la actualizacion 
                    MessageBox.Show("Nose pudo guardar el salon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    #region Actualizando los Servicios y inventarios del Salon 

                    #region Servicios

                    try
                    {

                        CheckState Estado;
                        int ID;
                        int n = 0;
                        int Resultado = 0;

                        //Verificacion si el checklist de servicios tiene algun items
                        if (CKDListServicios.Items.Count > 0)
                        {
                            //Foreach que guardara cada items seleccionado en la base de datos 
                            foreach (DataRowView rowView in CKDListServicios.Items)
                            {
                                //Completando la entidad de servicios 
                                e_Servicio.id_Salon = et_Salon.id_Salon;
                                e_Servicio.servicio = Convert.ToString(rowView["Servicio"]);

                                Estado = CKDListServicios.GetItemCheckState(n);

                                if (Estado == CheckState.Unchecked)
                                {

                                    

                                    Resultado = n_Servicio.VerificarExistenciaDeServicio(e_Servicio);



                                    if (Resultado != 0)
                                    {
                                        n_Servicio.EliminarSercvicioXS_ID(e_Servicio);
                                    }

                                }
                                else
                                {

                                    Resultado = n_Servicio.VerificarExistenciaDeServicio(e_Servicio);

                                    if (Resultado != 0)
                                    {
                                        //No hacer nada //
                                    }
                                    else
                                    {
                                        n_Servicio.AgregarServicio(e_Servicio);

                                    }

                                }


                                //Ejecutando el metodo 



                                n++;
                            }



                        }


                        #endregion

                        #region Inventarios 


                        ID = 0;
                        n = 0;
                        Resultado = 0;

                        //Verificacion si el checklist de servicios tiene algun items
                        if (CKDListInventario.Items.Count > 0)
                        {
                            //Foreach que guardara cada items seleccionado en la base de datos 
                            foreach (DataRowView rowView in CKDListInventario.Items)
                            {
                                //Completando la entidad de Inventario
                                e_Inventario.id_Salon = et_Salon.id_Salon;
                                e_Inventario.inventario = Convert.ToString(rowView["Inventario"]);

                                Estado = CKDListInventario.GetItemCheckState(n);

                                if (Estado == CheckState.Unchecked)
                                {

                                    

                                    Resultado = n_Inventario.VerificarExistenciaDeInventario(e_Inventario);



                                    if (Resultado != 0)
                                    {
                                        n_Inventario.EliminarInventarioXS_ID(e_Inventario);
                                    }

                                }
                                else
                                {
                                    
                                    Resultado = n_Inventario.VerificarExistenciaDeInventario(e_Inventario);

                                    if (Resultado != 0)
                                    {
                                        //No hacer nada //
                                    }
                                    else
                                    {
                                        n_Inventario.AgregarInventario(e_Inventario);

                                    }

                                }


                                //Ejecutando el metodo 



                                n++;
                            }



                        }

                        #endregion


                        #endregion

                        //Mensaje Positivo 
                        MessageBox.Show("Salon actualizado satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message);
                    }

                }

            }





        }






        #endregion

        #region Servicios 

        #region Agregar Servicio Global
        /// <summary>
        /// Evento click sobre el boton agregar el cual ejecutara una accion de agregar un servicio a la base de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarS_Click(object sender, EventArgs e)
        {
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

        #region Eliminar Servicio Global 
        /// <summary>
        /// Evento click sobre el boton quitar el cual eliminar un servicio de la base  de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBQuitarS_Click(object sender, EventArgs e)
        {
            int FilasAfectadas;

            if (CKDListServicios.SelectedItems.Count == 1)
            {


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
                MessageBox.Show("Se debe seleccionar un servicio para ser eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        #endregion

        #endregion

        #region Inventario 


        #region Agregar inventario Global
        /// <summary>
        /// Evento click Sobre el boton agregar en el cual se gestionara la accion de agregar un inventario al sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAgregarIV_Click(object sender, EventArgs e)
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

        #region Eliminar Inventario Global
        /// <summary>
        /// Evento click sobre el boton quitar el cual eliminara un inventario de la base de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBQuitarIV_Click(object sender, EventArgs e)
        {
            //Variable que recogera las filas afectadas 
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

        #endregion

        #region Ubicacion
        /// <summary>
        /// Metodo donde se manejan la session de ubicaciones globales de los salones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBUbicaciones_Click(object sender, EventArgs e)
        {
            //Instanciando el formulario 

            UbicacionF Ubicacion = new UbicacionF();

            Ubicacion.ShowDialog();

            //Asignando las direcciones al combobox

            CBUbicacion.DataSource = n_Salon.ObtenerUbicacionesGlobales();
            CBUbicacion.DisplayMember = "Ubicacion";
        }

        #endregion

    }
}