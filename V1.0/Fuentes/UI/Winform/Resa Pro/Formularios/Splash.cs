using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Capas.Aplicacion;




namespace Resa_Pro
{
    public partial class Splash : Form
    {
        #region declaracion de variables de instancia 

        private Graphics Marco;

        private SolidBrush Pincel;

        private int Altura = 22, Ancho = 0;

        private int posicionX = 153, posicionY = 0;


        #endregion

        //<summary>
        //Se inicializaran todos los componentos en  el contructor principal donde se llamaran los metodos de cargar  el sistema que verifican la existencia de los recursos del sistema 
        //</summary>

        public Splash()
        {
            InitializeComponent();
            
          

            #region  Inicializando variables, objetos y llamadas 


            //Para dibujar en la pictureBox que seutilizara comoo progress bar 
            Marco = PBProgresiveB.CreateGraphics();

            //creando Asignando el color al pincel 

            Pincel = new SolidBrush(Color.Red);

            //Inicializando el Timer

            timerSplash.Start();

            //Llamando metodos para la verificacion  de los recursos del sistema y efectos 

            //Delegados  

            ThreadStart delegadoCargar = new ThreadStart(CargarSistema);

            ThreadStart delegadoTimerPB = new ThreadStart(timerSplash.Start);


            //Instancia de los hilos 

            Thread hilo = new Thread(delegadoCargar);

            Thread hiloTimer = new Thread(delegadoTimerPB);

            //Prioridades
            
            hilo.Priority = ThreadPriority.Lowest;

            hiloTimer.Priority = ThreadPriority.Lowest;

            //Hilos 

            
            hilo.Start();
            hiloTimer.Start();



            #endregion


        }

       

        #region  progressive  bar contralada con la clase Drawing

        //Timer que controla el dibujo de la progress bar del splash 
        private void timerSplash_Tick(object sender, EventArgs e)
        {

            
            if (posicionX > 0)
            {
                // -- Dibujando rectangulo --

                Marco.FillRectangle(Pincel, posicionX, posicionY, Ancho, Altura);

                posicionX = posicionX - 2;

                Ancho = Ancho + 4;

            }
            else
            {
                timerSplash.Stop();
                this.Close();
            }


        }

        #endregion

        #region Cargar Sistema (Se verifican todos los recursos y  emails pendientes)
        private void CargarSistema()
        {

            
            try {
                #region Instanciaciones a clases

                // Clase XMl
                XML_Manager manejadorXMl = new XML_Manager();
                // Clase conexion en  capa.Aplicacion
                ConexionAplicacion Conexion = new ConexionAplicacion();
                
                
                #endregion

                #region creaccion de hilos 

                //Delegados  

                ThreadStart delegadoVerificarXMLS = new ThreadStart(manejadorXMl.verificarArchivosXMLAplicacion);

                ThreadStart delegadoVerificarConexion = new ThreadStart(Conexion.PruebaConexion);

                //Instancia de los hilos 

                Thread hiloVerificadorXML = new Thread(delegadoVerificarXMLS);

                Thread hiloVerificarConexion = new Thread(delegadoVerificarConexion);
                //Propiedad

                hiloVerificadorXML.Priority = ThreadPriority.Normal;

                hiloVerificarConexion.Priority = ThreadPriority.Normal;

               
                //Hilos
           
                hiloVerificadorXML.Start();

                hiloVerificarConexion.Start();
                
                #endregion
            }
            catch (Exception e)
            {
                 //Mostrando mensaje de error

                MessageBox.Show("No se  pudo  cargar el sistema ERROR " + e.ToString());
            }
            
            

         
           





        }

        #endregion


      

    }
}
