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
        private bool Autentificacion;

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

            Autentificacion = false;

        }
        #endregion

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            Application.Exit();


        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {

            //Insertando los datos a la entidad
             
            E_Autentificacion.usuario = TbUsuario.Text;
            E_Autentificacion.contraseña = TbPass.Text;


            //llamando el metodo en la capa de negocio

            Autentificacion = N_Autentificaicon.VerificarUsuario(E_Autentificacion);
            
            if(Autentificacion == true)
            {

                MainScreen Pantallaprincipal = new MainScreen();

                Pantallaprincipal.Show();

                

               
            }
            else
            {

                MessageBox.Show("Usuario o pass incorrectos");
            }

        }
    }
}
