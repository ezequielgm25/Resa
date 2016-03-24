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

using Capas.Infraestructura.Entidades;
using Capas.Negocio;

namespace Resa_Pro.Formularios
{
    public partial class CrearSalonF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //Interfaz que gestionara la creacion de un nuevo salon 
        //</Summary>

        #region Declaraciones

            //Entidad Salon
        N_Salon n_salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

           //Entidad Servicio
        E_Servicio e_Servicio = new E_Servicio();

        N_Servicio n_Servicio = new N_Servicio();

        //Entidad Inventario
        E_Inventario e_Inventario = new E_Inventario();

        N_Inventario n_Inventario = new N_Inventario();
         
        #endregion


        #region Constructor
        public CrearSalonF()
        {
            InitializeComponent();
           

            #region Desabilitando los botones de servicio y inventarios mientros no se agrege un salon 

            //Servicios
            SBAgregarS.Enabled = false;
            SBQuitarS.Enabled = false;
            TBDescripcionS.Enabled = false;
            TBNombreS.Enabled = false;
            //Inventarios
            SBAgregarI.Enabled = false;
            SBQuitarI.Enabled = false;
            TBNombreIV.Enabled = false;

            #endregion


            #region Agregando opciones al combobox de estado 

            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            
            #endregion


        }
        #endregion

        #region Crear Salon 
        private void SBCrearSalon_Click(object sender, EventArgs e)
        {


            if (TENombre.EditValue == "" || TEDireccion.EditValue == "" || TECapacidad.EditValue == "" || CBEstado.SelectedItem == null)
            {

                XtraMessageBox.Show("Todos los datos deben ser completados");

            }

            else
            {

                #region Asignando Datos a la entidad de salon 

                e_Salon.nombre = Convert.ToString(TENombre.EditValue);
                e_Salon.ubicacion = Convert.ToString(TEDireccion.EditValue);
                e_Salon.capacidad = Convert.ToInt32(TECapacidad.EditValue);
                e_Salon.estado = Convert.ToString(CBEstado.SelectedItem);

                #endregion


                e_Salon.id_Salon = n_salon.CrearSalon(e_Salon);

                if (e_Salon.id_Salon == null)
                {
                    XtraMessageBox.Show("Nose pudo guardar el salon");
                }
                else
                {

                    #region  Desactivar controles del grupo  de controles de la creacion de salon

                    TENombre.Enabled = false;
                    TEDireccion.Enabled = false;
                    TECapacidad.Enabled = false;
                    CBEstado.Enabled = false;
                    SBCrearSalon.Enabled = false;

                    #endregion

                    #region Se habilitan los controles de los grupos de servicios y inventarios 

                    //Servicios
                    SBAgregarS.Enabled = true;
                    SBQuitarS.Enabled = true;
                    TBDescripcionS.Enabled = true;
                    TBNombreS.Enabled = true;
                    //Inventarios
                    SBAgregarI.Enabled = true;
                    SBQuitarI.Enabled = true;
                    TBNombreIV.Enabled = true;


                    #endregion
                }

            }




        }

        #endregion

        #region Servicios

        #region Agregar Servicio 

        private void SBAgregarS_Click(object sender, EventArgs e)
        {

            int FilasAfectadas = 0;

            if( TBNombreS.Text =="" || TBDescripcionS.Text == "" )
            {
                XtraMessageBox.Show("Los campos de servicio y descripcion deben tener informacion");


            }
            else
            {
                #region Asignando los valores a la entidad de servicios

                e_Servicio.servicio = Convert.ToString(TBNombreS.Text);
                e_Servicio.descripcion = Convert.ToString(TBDescripcionS.Text);
                e_Servicio.id_Salon = e_Salon.id_Salon;

                #endregion

                #region Agregando el servicio al salon

                FilasAfectadas = n_Servicio.AgregarServicio(e_Servicio);

                if(FilasAfectadas == 0)
                {
                    XtraMessageBox.Show("Ocurrio un error al guardar los datos ");


                }
                else
                {


                    XtraMessageBox.Show(" El servicio se agrego correctamente ");

                    #region Obteniendo Servicios

                    GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

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

        #region QuitarServicio


        private void SBQuitarS_Click(object sender, EventArgs e)
        {

            int FilasAfectadas = 0;

            int ID_Servicio = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            //Ejecutar el metodo en la capa de negocio de eliminar el servicio

            FilasAfectadas = n_Servicio.EliminarServicio(ID_Servicio);

            if(FilasAfectadas != 1)
            {
                XtraMessageBox.Show("El servicio no fue eliminado ocurrio un error al eliminarlo");
            }
            else
            {
                XtraMessageBox.Show("El servicio Fue eliminado correctamente");

                //Actualizando el data source de la GRID Control 

                GCServicios.DataSource = n_Servicio.ObtenerServicios(e_Salon.id_Salon);

            }

            



        }

        #endregion

        #endregion

        #region Inventarios

        #region Agregar inventario

        private void SBAgregarI_Click(object sender, EventArgs e)
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

                e_Inventario.id_Salon = e_Salon.id_Salon;

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

            #region Quitar inventario

        private void SBQuitarI_Click(object sender, EventArgs e)
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

                GCInventarios.DataSource = n_Inventario.ObtenerInventarios(e_Salon.id_Salon);
               
            }
        }




        #endregion

        #endregion

        #endregion

    }
}