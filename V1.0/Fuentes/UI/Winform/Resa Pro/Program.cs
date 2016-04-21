using System;
using System.Windows.Forms;

namespace Resa_Pro
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Corriendo el Splash

            Application.Run(new Splash());

            //<summary>
            //Cuando se cierre  el splash se abrira la ventana de loging
            //</summary>

            //Al cerrarse el splash se empieza a correr el formulario de  Logeo
            Application.Run(new Formularios.Loging());
          
              

        }
    }
}
