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
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class ActualizarUsuario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Intrfaz donde se actualizara las caracteristicas de un usuario 
        //</Summary>

        #region Declaraciones 

        //Usuarios 
        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();


        #region Variables 
        private int ID_OSalones = 0;

        private int ID_OSolicitudes = 0;

        private int ID_OEventos = 0;

        private int ID_OUsuarios = 0;

        private int ID_OReportes = 0;


        #endregion



        #endregion


        #region Contructor
        /// <summary>
        /// Metodo Contructor de la interfaz  de actualizar un usuario 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        public ActualizarUsuario(int ID_Usuario)
        {
            InitializeComponent();

           


            //Asignando Las opciones a los controles de Estado y grupos de usuarios 

            //Estado de usuario 
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            //Grupos de usuario
            CBRol.Items.Add("Administrador");
            CBRol.Items.Add("Gestor");
            CBRol.Items.Add("Solicitante");

            #region asignando Los datos a los  controles 

            e_Usuario = n_Usuario.ObtenerInformacionDetallada(ID_Usuario);
            //
            e_Usuario.id_Usuario = ID_Usuario;
            //
            CBRol.Text = e_Usuario.rol;
            TBNombre.Text = e_Usuario.nombre;
            TBApellido.Text = e_Usuario.apellido;
            TBusuario.Text = e_Usuario.usuario;
            CBEstado.Text = e_Usuario.estado;

            #endregion


            #region Mostrando las Funciones del usuario 

            try
            {

            
                //Obteniendo el perfil del usuario
                int Perfil_Usuario = n_Usuario.ObtenerPerfil(ID_Usuario);

                //Obtener ID_Opcion 

                //Trabajando la opcion de Salones 
                String Opcion = "Salones";  // -- - -Opcion 

                 ID_OSalones = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

                //Crear 
                CBXSalonesC.Checked = n_Usuario.ObtenerFuncion(ID_OSalones, CBXSalonesC.Text);
                //Actualizar 
                CBXSalonesA.Checked = n_Usuario.ObtenerFuncion(ID_OSalones, CBXSalonesA.Text);
                //Eliminar
                CBXSalonesE.Checked = n_Usuario.ObtenerFuncion(ID_OSalones, CBXSalonesE.Text);

                //Trabajando la opcion de Solicitudes 
                Opcion = "Solicitudes";  // -- - -Opcion 

                ID_OSolicitudes = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

                //Crear
                CBXSolicitudesC.Checked = n_Usuario.ObtenerFuncion(ID_OSolicitudes, CBXSolicitudesC.Text);
                //Actualizar
                CBXSolicitudesA.Checked = n_Usuario.ObtenerFuncion(ID_OSolicitudes, CBXSolicitudesA.Text);
                //Eliminar
                CBXSolicitudesE.Checked = n_Usuario.ObtenerFuncion(ID_OSolicitudes, CBXSolicitudesE.Text);
                //Aprobar
                CBXSolicitudesAp.Checked = n_Usuario.ObtenerFuncion(ID_OSolicitudes, CBXSolicitudesAp.Text);

                //Trabajando la opcion de Eventos
                Opcion = "Eventos";  // -- - -Opcion

                 ID_OEventos = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

                //Crear 
                CBXEventosC.Checked = n_Usuario.ObtenerFuncion(ID_OEventos, CBXEventosC.Text);
                //Actualizar
                CBXEventosA.Checked = n_Usuario.ObtenerFuncion(ID_OEventos, CBXEventosA.Text);
                //Eliminar
                CBXEventosE.Checked = n_Usuario.ObtenerFuncion(ID_OEventos, CBXEventosE.Text);

                //Trabajando la opcion de Usuarios
                Opcion = "Usuarios";  // -- - -Opcion

                 ID_OUsuarios = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

                //Crear
                CBXUsuariosC.Checked = n_Usuario.ObtenerFuncion(ID_OUsuarios, CBXUsuariosC.Text);
                //Actualizar
                CBXUsuariosA.Checked = n_Usuario.ObtenerFuncion(ID_OUsuarios, CBXUsuariosA.Text);
                //Eliminar
                CBXUsuariosE.Checked = n_Usuario.ObtenerFuncion(ID_OUsuarios, CBXUsuariosE.Text);
                //Ver
                CBXUsuariosV.Checked = n_Usuario.ObtenerFuncion(ID_OUsuarios, CBXUsuariosV.Text);

                //Trabajando la opcion de Usuarios
                Opcion = "Reportes";  // -- - -Opcion

                ID_OReportes = n_Usuario.ObtenerIDOpcion(Opcion, Perfil_Usuario);

                //Generar
                CBXReportesG.Checked = n_Usuario.ObtenerFuncion(ID_OReportes, CBXReportesG.Text);
                //Imprimir
                CBXReportesI.Checked = n_Usuario.ObtenerFuncion(ID_OReportes, CBXReportesI.Text);



            }
            catch
            {
                MessageBox.Show("Ocurrio un error al recuperar la informacion del usuario de la base de datos");
            }
            #endregion

        }

        #endregion

        #region Actualizar  el usuario 

        private void SBActualizarU_Click(object sender, EventArgs e)
        {
            //Verificar Controles

            string perfil = "No Tiene Perfil";

            if (string.IsNullOrEmpty(CBRol.Text) || string.IsNullOrEmpty(TBNombre.Text) || string.IsNullOrEmpty(TBApellido.Text) || string.IsNullOrEmpty(CBEstado.Text))
            {

                MessageBox.Show(" El unico campo opcional a completar es la contraseña despues todos los otros deben estar completos");
            }

            else
            {
                // instanciando la clase y recibiendo el resultado 


                //Verificando la disponibilidad del otro usuario 

                int Resultado = 0;

                if (TBusuario.Text != e_Usuario.usuario)
                {
                    Resultado = n_Usuario.VerficarExistenciaUsuario(TBusuario.Text);

                  
                }

                if (Resultado > 0)
                {

                    MessageBox.Show(" El usuario: " + TBusuario.Text + "\n" + " Ya esta en uso");

                    //Limpiar el Textbox de usuario 

                    TBusuario.Focus();



                }
                else
                {
                    // insertar el Rol del nuevo usuario 

                    #region Asignando ID de grupo de usuario


                    int ID_GrupoUsuario = 0;
                    if (CBRol.Text == "Administrador")
                    {
                        ID_GrupoUsuario = 1;

                        perfil = "Administrador";
                    }
                    if (CBRol.Text == "Gestor")
                    {
                        ID_GrupoUsuario = 2;

                        perfil = "Gestionador";
                    }
                    if (CBRol.Text == "Solicitante")
                    {
                        ID_GrupoUsuario = 3;

                        perfil = "Solicitador";
                    }
                    #endregion

                    int FilasAfectadas = n_Usuario.ActualizarRol(CBRol.Text, ID_GrupoUsuario, e_Usuario.id_Rol);

                    if (FilasAfectadas != 0)
                    {
                        //Asignando data a la entidad 
                        e_Usuario.nombre = TBNombre.Text;
                        e_Usuario.apellido = TBApellido.Text;
                        e_Usuario.usuario = TBusuario.Text;
                        e_Usuario.contraseña = TBContra.Text;
                        e_Usuario.estado = CBEstado.Text;


                        FilasAfectadas = n_Usuario.ActualizarUsuario(e_Usuario);

                        if (FilasAfectadas != 0)
                        {

                            //Asignando las  Funciones que dispondra el usuario 


                            FilasAfectadas = n_Usuario.ActualizarPerfil(e_Usuario.id_Usuario, perfil);

                            bool Actualizado = false;

                            if (FilasAfectadas != 0)
                            {
                                //Asignar las opociones a ese perfil 

                                //Opcion de Salones a actualizar 

                                //Crear 
                                n_Usuario.ActualizarFuncion(ID_OSalones, CBXSalonesC.Text, CBXSalonesC.Checked);
                                //Actualizar
                                n_Usuario.ActualizarFuncion(ID_OSalones, CBXSalonesA.Text, CBXSalonesA.Checked);
                                //Eliminar
                                n_Usuario.ActualizarFuncion(ID_OSalones, CBXSalonesE.Text, CBXSalonesE.Checked);



                                //Opcion de Solicitudes a actualizar 

                                //Crear 
                                n_Usuario.ActualizarFuncion(ID_OSolicitudes, CBXSolicitudesC.Text, CBXSolicitudesC.Checked);
                                //Actualizar
                                n_Usuario.ActualizarFuncion(ID_OSolicitudes, CBXSolicitudesA.Text, CBXSolicitudesA.Checked);
                                //Eliminar
                                n_Usuario.ActualizarFuncion(ID_OSolicitudes, CBXSolicitudesE.Text, CBXSolicitudesE.Checked);
                                //Aprobar
                                n_Usuario.ActualizarFuncion(ID_OSolicitudes, CBXSolicitudesAp.Text, CBXSolicitudesAp.Checked);


                                //Opcion de Eventos a Actualizar

                                //Crear 
                                n_Usuario.ActualizarFuncion(ID_OEventos, CBXEventosC.Text, CBXEventosC.Checked);
                                //Actualizar
                                n_Usuario.ActualizarFuncion(ID_OEventos, CBXEventosA.Text, CBXEventosA.Checked);
                                //Eliminar
                                n_Usuario.ActualizarFuncion(ID_OEventos, CBXEventosE.Text, CBXEventosE.Checked);

                                //Opcion de Usuarios a actualizar

                                //Crear 
                                n_Usuario.ActualizarFuncion(ID_OUsuarios, CBXUsuariosC.Text, CBXUsuariosC.Checked);
                                //Actualizar
                                n_Usuario.ActualizarFuncion(ID_OUsuarios, CBXUsuariosA.Text, CBXUsuariosA.Checked);
                                //Eliminar
                                n_Usuario.ActualizarFuncion(ID_OUsuarios, CBXUsuariosE.Text, CBXUsuariosE.Checked);
                                //Ver
                                n_Usuario.ActualizarFuncion(ID_OUsuarios, CBXUsuariosV.Text, CBXUsuariosV.Checked);


                                //Opcion de Reportes a Actualizar

                                //Generar
                                n_Usuario.ActualizarFuncion(ID_OReportes, CBXReportesG.Text, CBXReportesG.Checked);
                                //Imprimir
                                n_Usuario.ActualizarFuncion(ID_OReportes, CBXReportesI.Text, CBXReportesI.Checked);

                                Actualizado = true;

                                if (Actualizado == false)
                                {
                                    MessageBox.Show("Ocurrio un errror al actualizar el usuario");
                                }
                                else
                                {
                                    MessageBox.Show("El usuario se actualizo correctamente");

                                    this.Close();
                                }



                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al actualizar el usuario");
                            }







                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al actualizar el usuario");
                        }



                    }
                    else
                    {

                        MessageBox.Show("Ocurrio un error al actualizar el usuario");
                    }



                }


            }
        }



        #endregion

        private void CBXSalonesC_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}