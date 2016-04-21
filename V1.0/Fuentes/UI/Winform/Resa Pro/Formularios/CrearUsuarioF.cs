using System;
using System.Windows.Forms;

//Usings del sistema 
using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class CrearUsuarioF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz donde se creara un nuevo Usuario
        //</Summary>

        #region Declaraciones 
        //Usuario 

        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_Usuario = new E_Usuario();

        #endregion

        #region Contructor 

        /// <summary>
        /// Constructor de la interfaz donde se creara un usuario
        /// </summary>
        public CrearUsuarioF()
        {
            //Inicializando los componentes 
            InitializeComponent();


            //Asignando Las opciones a los controles de Estado y grupos de usuarios 

            //Estado de usuario 
            CBEstado.Items.Add("Activo");
            CBEstado.Items.Add("Inactivo");
            //Grupos de usuario
            CBRol.Items.Add("Administrador");
            CBRol.Items.Add("Gestor");
            CBRol.Items.Add("Solicitante");



        }

        #endregion

        #region Crear Usuario 
        /// <summary>
        /// Evento click en el boton crear donde se gestiona la creacion de un usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBCrearU_Click(object sender, EventArgs e)
        {
            //Verificar Controles

            //String que recogera el perfil 
            string perfil = "No Tiene Perfil";

            if (string.IsNullOrEmpty(CBRol.Text) || string.IsNullOrEmpty(TBNombre.Text) || string.IsNullOrEmpty(TBApellido.Text) || string.IsNullOrEmpty(TBContra.Text) || string.IsNullOrEmpty(CBEstado.Text))
            {

                MessageBox.Show(" Toda la informacion del usuario debe estar completa","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                // instanciando la clase y recibiendo el resultado 

                int Resultado = n_Usuario.VerficarExistenciaUsuario(TBusuario.Text);

                if (Resultado > 0)
                {
                    MessageBox.Show(" El usuario: " + TBusuario.Text + "\n" + " Ya esta en uso","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                    int ID_Rol = n_Usuario.InsertarRol(CBRol.Text, ID_GrupoUsuario);

                    if (ID_Rol !=  0)
                    {
                        //Asignando data a la entidad 
                        e_Usuario.nombre = TBNombre.Text;
                        e_Usuario.apellido = TBApellido.Text;
                        e_Usuario.usuario = TBusuario.Text;
                        e_Usuario.contraseña = TBContra.Text;
                        e_Usuario.estado = CBEstado.Text;
                        e_Usuario.id_Rol = ID_Rol;

                        e_Usuario.id_Usuario = n_Usuario.InsertarUsuario(e_Usuario);

                        if (e_Usuario.id_Usuario != 0)
                        {

                            //Asignando las  Funciones que dispondra el usuario 


                            int ID_Perfil = n_Usuario.InsertarPerfil(perfil, e_Usuario.id_Usuario);

                            bool Guardado = false;

                            if (ID_Perfil != 0)
                            {
                                //Asignar las opociones a ese perfil 

                                //Opcion de Salones 
                                string Opcion = "Salones";

                                int ID_OSalones= n_Usuario.InsertarOpcion(Opcion, ID_Perfil);


                                if(ID_OSalones != 0)
                               {
                                    //Crear 
                                    n_Usuario.InsertarFuncion(CBXSalonesC.Text, CBXSalonesC.Checked, ID_OSalones);
                                    //Actualizar
                                    n_Usuario.InsertarFuncion(CBXSalonesA.Text, CBXSalonesA.Checked, ID_OSalones);
                                    //Eliminar
                                    n_Usuario.InsertarFuncion(CBXSalonesE.Text, CBXSalonesE.Checked, ID_OSalones);




                                   


                                }
                                else
                                {
                                    Guardado = false;
                                }

                                //Opcion de Solicitudes
                                Opcion = "Solicitudes";

                                int ID_OSolicitudes = n_Usuario.InsertarOpcion(Opcion, ID_Perfil);

                                if (ID_OSolicitudes != 0)
                                {
                                    //Crear 
                                    n_Usuario.InsertarFuncion(CBXSolicitudesC.Text, CBXSolicitudesC.Checked, ID_OSolicitudes);
                                    //Actualizar
                                    n_Usuario.InsertarFuncion(CBXSolicitudesA.Text, CBXSolicitudesA.Checked, ID_OSolicitudes);
                                    //Eliminar
                                    n_Usuario.InsertarFuncion(CBXSolicitudesE.Text, CBXSolicitudesE.Checked, ID_OSolicitudes);
                                    //Aprobar
                                    n_Usuario.InsertarFuncion(CBXSolicitudesAp.Text, CBXSolicitudesAp.Checked, ID_OSolicitudes);


                                }
                                else
                                {
                                    Guardado = false;
                                }

                                //Opcion de eventos
                                Opcion = "Eventos";

                                int ID_OEventos = n_Usuario.InsertarOpcion(Opcion, ID_Perfil);

                                if (ID_OEventos != 0)
                                {
                                    //Crear 
                                    n_Usuario.InsertarFuncion(CBXEventosC.Text, CBXEventosC.Checked, ID_OEventos);
                                    //Actualizar
                                    n_Usuario.InsertarFuncion(CBXEventosA.Text, CBXEventosA.Checked, ID_OEventos);
                                    //Eliminar
                                    n_Usuario.InsertarFuncion(CBXEventosE.Text, CBXEventosE.Checked, ID_OEventos);
                                 

                                }
                                else
                                {
                                    Guardado = false;


                                }

                                

                                //Opcion de usuarios
                                Opcion = "Usuarios";

                                int ID_OUsuarios = n_Usuario.InsertarOpcion(Opcion, ID_Perfil);

                                if (ID_OUsuarios != 0)
                                {
                                    //Crear 
                                    n_Usuario.InsertarFuncion(CBXUsuariosC.Text, CBXUsuariosC.Checked, ID_OUsuarios);
                                    //Actualizar
                                    n_Usuario.InsertarFuncion(CBXUsuariosA.Text, CBXUsuariosA.Checked, ID_OUsuarios);
                                    //Eliminar
                                    n_Usuario.InsertarFuncion(CBXUsuariosE.Text, CBXUsuariosE.Checked,ID_OUsuarios);
                                    //Ver
                                    n_Usuario.InsertarFuncion(CBXUsuariosV.Text, CBXUsuariosV.Checked, ID_OUsuarios);


                                }
                                else
                                {
                                    Guardado = false;
                                }

                                //Opcion de  Reportes
                                Opcion = "Reportes";

                                int ID_OReportes= n_Usuario.InsertarOpcion(Opcion, ID_Perfil);

                                if (ID_OReportes != 0)
                                {
                                    //Generar
                                    n_Usuario.InsertarFuncion(CBXReportesG.Text, CBXReportesG.Checked, ID_OReportes);
                                    //Imprimir
                                    n_Usuario.InsertarFuncion(CBXReportesI.Text, CBXReportesI.Checked, ID_OReportes);

                                    Guardado = true;

                                }
                                else
                                {
                                    Guardado = false;
                                }


                                if(Guardado == false)
                                {
                                    MessageBox.Show("Ocurrio un error al guardar el usuario","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("El usuario se guardo correctamente","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                }



                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al crear el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }







                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un errror al crear el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                    }
                    else
                    {

                        MessageBox.Show("Ocurrio un errror al crear el usuario","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }


            }


        }

        #endregion
        
    }
}