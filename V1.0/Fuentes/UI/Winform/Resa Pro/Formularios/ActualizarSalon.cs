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

        #region Instancias
            //Salon
        E_Salon et_Salon = new E_Salon();
        N_Salon n_Salon = new N_Salon();

        //Servicio
        E_Servicio e_Servicio = new E_Servicio();
        N_Servicio n_Servicio = new N_Servicio();

        //Inventario 
        E_Inventario e_Inventario = new E_Inventario();
        N_Inventario n_Inventario = new N_Inventario();

     
        


        #region Constructor 
        public ActualizarSalon(E_Salon e_Salon)
        {
            
            InitializeComponent();

            //<Summary>
            //Se asignaran los valores a los  a los controles correspondientes en la interfaz
            //</Summary>

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

            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");

            #endregion

            #region Asignando la opcion de la entidad 

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

            GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

            #endregion

            #region Inventarios
            GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);
            #endregion

            #endregion


        }
        #endregion

        #region Actualizar  Salon
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<Summary>
            //Actualizar  Caracteristicas principales de un salon
            //</Summary>

            //Asignando coleccion de  datos a la entidad 

            //----------//
            int FilasAfectadas = 0;

            if (TENombreS.EditValue == "" || TEDireccion.EditValue == "" || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
            {

                XtraMessageBox.Show("Todos los datos deben ser completados");

            }

            else
            {

                #region Asignando Datos a la entidad de salon 

                et_Salon.nombre = Convert.ToString(TENombreS.EditValue);
                et_Salon.ubicacion = Convert.ToString(TEDireccion.EditValue);
                et_Salon.capacidad = Convert.ToInt32(TECapacidad.EditValue);
                et_Salon.estado = Convert.ToString(CBEstado.SelectedItem);

                #endregion


                FilasAfectadas = n_Salon.ActualizarSalon(et_Salon);

                if (FilasAfectadas != 1 )
                {
                    XtraMessageBox.Show("Nose pudo guardar el salon");
                }
                else
                {

                    XtraMessageBox.Show("Salon actualizado satisffactoriamente");
         

                }

            }





        }



        #endregion

        #region Servicios 

        #region Agregar Servicio
        private void SBAgregarS_Click(object sender, EventArgs e)
        {

            int FilasAfectadas = 0;

            if (TBNombreS.Text == "" || TBDescripcionS.Text == "")
            {
                XtraMessageBox.Show("Los campos de servicio y descripcion deben tener informacion");


            }
            else
            {
                #region Asignando los valores a la entidad de servicios

                e_Servicio.servicio = Convert.ToString(TBNombreS.Text);
                e_Servicio.descripcion = Convert.ToString(TBDescripcionS.Text);
                e_Servicio.id_Salon = et_Salon.id_Salon;

                #endregion

                #region Agregando el servicio al salon

                FilasAfectadas = n_Servicio.AgregarServicio(e_Servicio);

                if (FilasAfectadas == 0)
                {
                    XtraMessageBox.Show("Ocurrio un error al guardar los datos ");


                }
                else
                {


                    XtraMessageBox.Show(" El servicio se agrego correctamente ");

                    #region Obteniendo Servicios

                    GCServicios.DataSource = n_Servicio.ObtenerServicios(et_Salon.id_Salon);

                    #endregion

                    #region Limpiando los controles 

                    TBNombreS.Clear();
                    TBDescripcionS.Clear();
                    #endregion 



                }

                #endregion



            }
        }

        #endregion

        #region Quitar Servicio
        private void SBQuitarS_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            int ID_Servicio = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            //Ejecutar el metodo en la capa de negocio de eliminar el servicio

            FilasAfectadas = n_Servicio.EliminarServicio(ID_Servicio);

            if (FilasAfectadas != 1)
            {
                XtraMessageBox.Show("El servicio no fue eliminado ocurrio un error al eliminarlo");
            }
            else
            {
                XtraMessageBox.Show("El servicio Fue eliminado correctamente");

                //Actualizando el data source de la GRID Control 

                GCServicios.DataSource = n_Servicio.ObtenerServicios(et_Salon.id_Salon);

            }
        }

        #endregion

        #endregion

        #region Inventarios

        #region Agregar Inventario
        private void SBAgregarIV_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            if (TBNombreIV.Text == "")
            {

                XtraMessageBox.Show("El Campo de inventario esta vacio");

            }
            else
            {
                #region Asignando los valores a la entidad de inventarios

                e_Inventario.inventario = Convert.ToString(TBNombreIV.Text);

                e_Inventario.id_Salon = et_Salon.id_Salon;

                #endregion

                #region Agregando el inventario al salon

                FilasAfectadas = n_Inventario.AgregarInventario(e_Inventario);

                if (FilasAfectadas == 0)
                {
                    XtraMessageBox.Show("Ocurrio un error al guardar los datos ");


                }
                else
                {


                    XtraMessageBox.Show(" El inventario se agrego correctamente ");

                    #region Obteniendo inventarios

                    GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Inventario.id_Salon);

                    #endregion

                    #region Limpiando los controles 

                    TBNombreIV.Clear();

                    #endregion



                }

            }
        }

        #endregion


        #endregion

        #region Quitar Inventario
        private void SBQuitarIV_Click(object sender, EventArgs e)
        {
            int FilasAfectadas = 0;

            int ID_Inventario = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ID"));

            //Ejecutar el metodo en la capa de negocio de eliminar el servicio

            FilasAfectadas = n_Inventario.EliminarInventario(ID_Inventario);

            if (FilasAfectadas != 1)
            {
                XtraMessageBox.Show("El inventario no fue eliminado ocurrio un error al eliminarlo");
            }
            else
            {
                XtraMessageBox.Show("El inventario Fue eliminado correctamente");

                //Actualizando el data source de la GRID Control 

                GCInventarios.DataSource = n_Inventario.ObtenerInventarios(et_Salon.id_Salon);

            }
        }
        #endregion

        #endregion

        #endregion

    }
}