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
using Capas.Aplicacion;

namespace Resa_Pro.Formularios
{
    public partial class Salones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<summary>
        // Interfaz de  los salones en la cual se gestionaran los mismos 
        //</summary>

        #region instancias
            //Salones
        N_Salon n_Salon =  new N_Salon();

        E_Salon e_Salon = new E_Salon();
        //Usuarios 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();

        //Auditorias 

        N_Auditoria n_Auditoria = new N_Auditoria();

        E_Auditoria e_Auditoria = new E_Auditoria();

        //Xml manager 
        XML_Manager X_m = new XML_Manager();


        #endregion

        #region Constructor


        public Salones(E_Usuario e_UsuarioAU)
        {
            InitializeComponent();

            #region Precentando los salonees en el datagrid principal 

            GCSalones.DataSource = n_Salon.ObtenerSalones();



            #endregion

            //Asignando e_Usuario   a la goblal

            e_Usuario = e_UsuarioAU;


            #region Control de usuario

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario);

            //Trabajando la opcion de Usuarios
            String Opcion = "Salones";  // -- - -Opcion

            int ID_OSalones = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);
            //Crear
            SBCrear.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Crear");
            //Actualizar
            SBActualizar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Actualizar");
            //Eliminar
            SBEliminar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Eliminar");

            #endregion


        }

        #endregion

        #region Crear Salon
        private void SBCrear_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try {

                CrearSalonF C_Salon = new CrearSalonF();

                C_Salon.ShowDialog();

                #region Actualizando la data grid 
                GCSalones.DataSource = n_Salon.ObtenerSalones();
                #endregion

               
            }
            catch(Exception E)
            {
                MessageBox.Show(Convert.ToString(E));

                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Crear", Convert.ToString(E));
            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Crear";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);

               

            }

        }
        #endregion

        #region Actualizar Salon

        
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<Summary>
            //Se creara una instancia de la clase salon la cual sera enviada  a la interfaz de actualizacion 
            //</Summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try {
                //Llenando la entidad de salon 

                e_Salon.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                e_Salon.nombre = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));
                e_Salon.ubicacion = Convert.ToString(gridView1.GetFocusedRowCellValue("Ubicacion"));
                e_Salon.capacidad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Capacidad"));
                e_Salon.estado = Convert.ToString(gridView1.GetFocusedRowCellValue("Estado"));

                //Instanciado una nueva interfaz salon  a la cual se le enviara la entidad de salon

                ActualizarSalon A_Salon = new ActualizarSalon(e_Salon);

                A_Salon.ShowDialog();

                //Actualizar el data source de el Grid control 

                GCSalones.DataSource = n_Salon.ObtenerSalones();
            }
            catch (Exception E)
            {
                MessageBox.Show(Convert.ToString(E));

                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Actualizar", Convert.ToString(E));
            }


            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Actualizar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }
            
        }

        #endregion

        #region Eliminar
        private void SBEliminar_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try {

                int FilasAfectadas = 0;

                //Preguntar al usuario  si desea eliminarlo

                DialogResult dialogResult = MessageBox.Show("Desea eliminar el salon?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    //Recupera el ID del salon el cual va  
                    e_Salon.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                    FilasAfectadas = n_Salon.EliminarSalon(e_Salon.id_Salon);

                    if (FilasAfectadas != 1)
                    {
                        MessageBox.Show("Ocurrio un error al eliminar el salon");
                    }
                    else
                    {
                        MessageBox.Show("El Salon se elimino Correctamente");

                        GCSalones.DataSource = n_Salon.ObtenerSalones();

                    }

                }
                else if (dialogResult == DialogResult.No)
                {

                }


            }
            catch(Exception E)
            {

                MessageBox.Show(Convert.ToString(E));

                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Eliminar", Convert.ToString(E));

            }

            finally
            {
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Eliminar";

                //insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }

        #endregion

        #region Vista de salon 
        private void GCSalones_DoubleClick(object sender, EventArgs e)
        {
            // Se intancia un formulario en el cual se mostrara la informacion de un salon completa

            e_Salon.id_Salon  = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            e_Salon.nombre    = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));
            e_Salon.ubicacion = Convert.ToString(gridView1.GetFocusedRowCellValue("Ubicacion"));
            e_Salon.capacidad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Capacidad"));
            e_Salon.estado    = Convert.ToString(gridView1.GetFocusedRowCellValue("Estado"));

            VerSalon v_Salon = new VerSalon(e_Salon);

            v_Salon.ShowDialog();

        }

        #endregion

    }
}