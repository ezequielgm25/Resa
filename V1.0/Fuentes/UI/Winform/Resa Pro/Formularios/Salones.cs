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

        #region instancias -
        //Salones
        N_Salon n_Salon = new N_Salon();

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

        #region Constructor -

        /// <summary>
        ///  Contructor de la interfaz de salones la cual espera una entidad de usuario autentificado como parametro 
        /// </summary>
        /// <param name="e_UsuarioAU"></param>
        public Salones(E_Usuario e_UsuarioAU)
        {

            //Se inicializan los componentes  
            InitializeComponent();

            #region Precentando los salones en el datagrid principal 

            //se presentan los salones en el grid 
            GCSalones.DataSource = n_Salon.ObtenerSalones();



            #endregion

            //Asignando e_Usuario a la goblal instancia global de la clase 

            e_Usuario = e_UsuarioAU;


            #region Control de usuario -- Seguridad -- --Control de acceso--

            //Opciones de usuario 

            int Perfil_Usuario = n_Usuario.ObtenerPerfil(e_UsuarioAU.id_Usuario); //Se optiene el perfil del usuario 

            //Trabajando la opcion de Usuarios
            String Opcion = "Salones";  // -- - -Opcion 

            int ID_OSalones = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario); //Optiene el id de las opcion de salones de ese usuario 
            //Crear
            SBCrear.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Crear");
            //Actualizar
            SBActualizar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Actualizar");
            //Eliminar
            SBEliminar.Visible = n_Usuario.ObtenerFuncion(ID_OSalones, "Eliminar");

            #endregion


        }

        #endregion

        #region Crear Salon -

        /// <summary>
        ///  Evento click sobre el boton Crear el cual abrira una interfaz destinada a la creacion de un salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBCrear_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada del usuario a la funcion 

            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Instanciando una entidad 
                CrearSalonF C_Salon = new CrearSalonF();

                C_Salon.ShowDialog();

                #region Actualizando la data grid
                //Se actualiza el datasource del grid control de salones para mostrar los cambios  
                GCSalones.DataSource = n_Salon.ObtenerSalones();
                #endregion


            }
            //Se captura la excepcion encontrada al correr el codigo 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Crear", Convert.ToString(E));
            }
            //Agregando la auditoria al  usuario con los parametros correspondientes 
            finally
            {
                //Asignando los datos a  la auditoria  
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Crear";

                //Insertando la auditoria al Usuario correcpondiente

                n_Auditoria.InsertarAuditoria(e_Auditoria);

            }

        }
        #endregion

        #region Actualizar Salon -

        /// <summary>
        /// Evento Click sobre el boton Actualizar con el cual se dara apertura a un formulario extra con todas las caracteristicas de un  salon a actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizar_Click(object sender, EventArgs e)
        {

            //<summary>
            //Se creara una instancia de la clase de una entidad salon la cual sera enviada  a la interfaz de actualizacion 
            //</summary>

            //Obteniendo la fecha de entrada 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {
                //Llenando la entidad de salon 

                e_Salon.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                e_Salon.nombre = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));
                e_Salon.ubicacion = Convert.ToString(gridView1.GetFocusedRowCellValue("Ubicacion"));
                e_Salon.capacidad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Capacidad"));
                e_Salon.estado = Convert.ToString(gridView1.GetFocusedRowCellValue("Estado"));

                //Instanciado una nueva interfaz salon  a la cual se le enviara la entidad de salon

                if (e_Salon.id_Salon != 0)
                {

                    ActualizarSalon A_Salon = new ActualizarSalon(e_Salon);

                    A_Salon.ShowDialog();

                    //Actualizar el data source de el Grid control 

                    GCSalones.DataSource = n_Salon.ObtenerSalones();
                }
                else
                {
                    //mensaje No hay ningun salon seleccionado 

                    MessageBox.Show("No hay ningun salon seleccionado ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //Capturando la excepcion producidad al correr el codigo 
            catch (Exception E)
            {
                //Mostrando la excepcion al usuario
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Guardando el error en  El XMl de destinado  con los parametros correcpondientes 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Actualizar", Convert.ToString(E));
            }

            //Agregando la auditoria al  usuario con los parametros correspondientes 
            finally
            {
                //Asignando los datos a  la auditoria  
                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Actualizar";

                //Insertando la auditoria al Usuario correcpondiente

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }

        #endregion

        #region Eliminar  -

        /// <summary>
        ///  Evento Click del simple boton eliminar el cual se presentara un dialogo al usuario de eleccion para la eliminacion de un un salon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBEliminar_Click(object sender, EventArgs e)
        {

            //Obteniendo la fecha de entrada  para la auditoria de este usuario 
            String Fecha_Entrada = Convert.ToString(DateTime.Now);

            try
            {

                int FilasAfectadas = 0;

                //Recupera el ID del salon el cual va  
                e_Salon.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                if (e_Salon.id_Salon != 0)
                {

                    //Preguntar al usuario  si desea eliminarlo  "Este es el dialogo en el que se le preguntara al usuario la confirmacion de la eliminacion "
                    DialogResult dialogResult = MessageBox.Show("Desea eliminar el salon?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    //Si el dialogo result resulta  positivo 
                    if (dialogResult == DialogResult.Yes)
                    {




                        //Variables que recuperara las filas afectadas 
                        FilasAfectadas = n_Salon.EliminarSalon(e_Salon.id_Salon);

                        //Si no se afecto ninguna fila es por que hubo un error en el sistema  el cual se le presenta al usuario
                        if (FilasAfectadas != 1)
                        {
                            MessageBox.Show("Ocurrio un error al eliminar el salon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //De lo contrario se mostrara un mensaje con la informacion positiva de que se elimino el salon 
                        else
                        {
                            MessageBox.Show("El Salon se elimino Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GCSalones.DataSource = n_Salon.ObtenerSalones();

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

                    MessageBox.Show(" No hay ningun Salon a eliminar seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            //El catch capturara una excepcion en caso de que ocurra en el codigo ejecutado 
            catch (Exception E)
            {
                //Se le presenta la excepcion al usuario como un error  
                MessageBox.Show(Convert.ToString(E), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Se guarda un el error en el XML destinado a  esa funcion  que aceptara los siguientes paramatros 
                X_m.GuardarEnXMl(Fecha_Entrada, Convert.ToString(e_Usuario.id_Usuario), "Salones", "Eliminar", Convert.ToString(E));

            }

            //Finalmente se le agrega una auditoria al usuario completando todos los parametros correspondientes al usuario 
            finally
            {
                //Aqui se le asignan los parametros a la auditoria  

                e_Auditoria.id_Usuario = e_Usuario.id_Usuario;
                e_Auditoria.tipoUsuario = e_Usuario.rol;
                e_Auditoria.fecha_Entrada = Fecha_Entrada;
                e_Auditoria.fecha_Salida = Convert.ToString(DateTime.Now);
                e_Auditoria.opcion = "Salones";
                e_Auditoria.tipoOpcion = "Eliminar";

                //Insertando la auditoria

                n_Auditoria.InsertarAuditoria(e_Auditoria);
            }

        }

        #endregion

        #region Vista de salon -


        /// <summary>
        /// Evento doubleClick de la grid control  GCSalones "La cual se mostrara un Formulario con todas las caracteristicas de  ese salon"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCSalones_DoubleClick(object sender, EventArgs e)
        {
            // Se intancia un formulario en el cual se mostrara la informacion de un salon completa

            //Completando algunas de las caracteristicas a  mostrar  que son caracteristicas del salon 
            e_Salon.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            e_Salon.nombre = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));
            e_Salon.ubicacion = Convert.ToString(gridView1.GetFocusedRowCellValue("Ubicacion"));
            e_Salon.capacidad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Capacidad"));
            e_Salon.estado = Convert.ToString(gridView1.GetFocusedRowCellValue("Estado"));

            //Instanciando la interfaz 
            VerSalon v_Salon = new VerSalon(e_Salon);
            //Mostrando la  interfaz 
            v_Salon.ShowDialog();

        }

        #endregion

    }
}