using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.Run(new Splash());
            
            //<summary>
            //Cuando se cierre  el splash se abrira la ventana de loging
            //</summary>

             Application.Run(new Formularios.Loging());
            //<summary>
            //Cuando El usuario se autentifique se cerrara el loging y se abrira la pantalla principal
            //</summary>

           // Application.Run(new Formularios.MainScreen());

        }
    }
}
