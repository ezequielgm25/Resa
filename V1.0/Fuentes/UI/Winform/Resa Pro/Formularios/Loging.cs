using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capas.Infraestructura.Entidades;
using Capas.Negocio;




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
        public Loging()
        {
            InitializeComponent();

            //Inicializando las instancias 

            E_Autentificacion = new E_Autentificacion();

            N_Autentificaicon = new N_Autentificacion();

            //Inicializando variables 


        }

        public Loging(Form form)
        {

            form.Close();

            InitializeComponent();

            //Inicializando las instancias 

            E_Autentificacion = new E_Autentificacion();

            N_Autentificaicon = new N_Autentificacion();

            //Inicializando variables 
        }

        #endregion

        #region Cancelar
        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            Application.Exit();


        }

        #endregion

        #region Iniciar Sesion
        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {

                //Insertando los datos a la entidad

                E_Autentificacion.usuario = TbUsuario.Text;
                E_Autentificacion.contraseña = TbPass.Text;


                //llamando el metodo en la capa de negocio

                ID_Usuario = N_Autentificaicon.VerificarUsuario(E_Autentificacion); // Se obtiene el ID del usuario que se autentifico en el sistema

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
                #endregion

          

        }

    }

}
