using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Capas.Aplicacion
{
    public class Email
    {
        //<summary>
        //Clase que manipulara todo los concernientes con los emails en el sistema
        //</summary>


        #region Envio de un email
        public  void  enviarEmail(){
             
            //objeto email
        MailMessage email = new MailMessage();

            #region Propiedades del email

        email.To.Add(new MailAddress("Ezequielgarcia0925@gmail.com"));
        email.From = new MailAddress("soporteezequielgarcia@gmail.com");
        email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
        email.Body = "Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico.";
        email.IsBodyHtml = true;
        email.Priority = MailPriority.Normal;

            #endregion

            //Definir objeto SmtpClient

            SmtpClient smtp = new SmtpClient();

            #region Propiedades  del objeto Smtp 

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("soporteezequielgarcia@gmail.com", "soporte1234");

            #endregion 

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

           


        }

        #endregion

    }
}
