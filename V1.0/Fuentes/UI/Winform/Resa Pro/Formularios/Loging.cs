using System;
using System.Windows.Forms;
//Usings del sistema 
using Capas.Infraestructura.Entidades;
using Capas.Negocio;
using Capas.Aplicacion;



namespace Resa_Pro.Formularios
{
    public partial class Loging : Form
    {
        //<summary>
        //Codigo del formulario donde se solicitara el inicio de sesion
        //</summary>

        #region Variables 

        private int ID_Usuario;

        #endregion

        #region Instancias

        //Instancia de la capa de Entidades
        E_Autentificacion E_Autentificacion;
        //Instancia de la capa de negocios
        N_Autentificacion N_Autentificaicon;


        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de el formulario de Loging 
        /// </summary>
        public Loging()
        {
            //Inicializando los compenentes 
            InitializeComponent();

            //Inicializando las instancias 

            E_Autentificacion = new E_Autentificacion();

            N_Autentificaicon = new N_Autentificacion();

            //Inicializando variables 


        }

        //Segundo constructor
        public Loging(Form form)
        {

            //Se cierra el formulario pasado como parametro
            form.Close();

            //Inicializacion de los componentes 
            InitializeComponent();

            //Inicializando las instancias 

            E_Autentificacion = new E_Autentificacion();

            N_Autentificaicon = new N_Autentificacion();

            //Inicializando variables 
        }

        #endregion

        #region Cancelar
        /// <summary>
        /// Metodo donde se cancela el ingreso al sistema y se cierra la aplicacion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrando la aplicacion 
            Application.Exit();


        }

        #endregion

        #region Iniciar Sesion
        /// <summary>
        /// Evento click sobre el boton "Iniciar sesion" en el cual se maneja la autentificacion del usuario en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Verificando que los  campos esten completos 
            if (TbUsuario.Text != "" && TbPass.Text != "")
            {
                //Insertando los datos a la entidad

                E_Autentificacion.usuario = TbUsuario.Text;
                E_Autentificacion.contraseña = TbPass.Text;


                //llamando el metodo en la capa de negocio
                try
                {
                    ID_Usuario = N_Autentificaicon.VerificarUsuario(E_Autentificacion); // Se obtiene el ID del usuario que se autentifico en el sistema
                }
                catch (Exception EX)
                {
                    //Mostrando mensaje de error

                    MessageBox.Show("No se pudo un autentificar el usuario " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //Enviando un email  a la cuenta de soporte la excepcion
                    Email email = new Email();
                    //Enviando
                    email.enviarEmail(EX.Message);


                }
                if (ID_Usuario == -1 || ID_Usuario == -2)
                {

                    if (ID_Usuario == -1)
                    {
                        MessageBox.Show("Lo sentimos pero el usuario esta inactivo", "Mensaje de autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (ID_Usuario == -2)
                    {
                        MessageBox.Show("El usuario no existe ", "Mensaje de autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }


                else
                {
                    if (ID_Usuario != 0)
                    {

                        //<summary>
                        // Enviando el ID_Al Formulario mainSCreen para que obtenga la informacion del usuario
                        //</summary>

                        MainScreen Pantallaprincipal = new MainScreen(ID_Usuario); // Instanciando la interfaz de pantalla principal

                        this.Hide();  //Ocultando la interfaz de login 

                        Pantallaprincipal.ShowDialog();

                        this.Close();




                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Mensaje de autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        //Dandole el focus a los controles 

                        TbPass.Focus(); //Dandole el Focus a el TB de pass


                    }
                }

            }
            else
            {
                MessageBox.Show("Los campos de contraseña y usuario  deben estar llenos", "Mensaje de autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        #endregion

    }

}
