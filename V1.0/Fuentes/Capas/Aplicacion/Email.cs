using System;
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
            /// <summary>
            /// Metodo de envio de un correo electronico 
            /// </summary>
        public  void  enviarEmail( String Excepcion){
             
            //objeto email
        MailMessage email = new MailMessage();

            #region Propiedades del email
            //Instanciando la clase donde se manejan las opciones de XML
            XML_Manager XmlFile = new XML_Manager();


           

        email.To.Add(new MailAddress(XmlFile.BuscarElementoArchivoXMl("EmailFrom", "", "App-Config.xml")));
        email.From = new MailAddress(XmlFile.BuscarElementoArchivoXMl("EmailSubject", "","App-Config.xml"));
        email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
        email.Body = "Error " + Excepcion;
        email.IsBodyHtml = true;
        email.Priority = MailPriority.Normal;

            #endregion

            //Definir objeto SmtpClient

            SmtpClient smtp = new SmtpClient();

            #region Propiedades  del objeto Smtp 

            smtp.Host = XmlFile.BuscarElementoArchivoXMl("SMTP", "", "App-Config.xml");
            smtp.Port = Convert.ToInt32(XmlFile.BuscarElementoArchivoXMl("Port", "", "App-Config.xml"));
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(XmlFile.BuscarElementoArchivoXMl("HostServer", "", "App-Config.xml"), XmlFile.BuscarElementoArchivoXMl("PasswordServer", "", "App-Config.xml"));

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

        #region Envio de un email sindatos buscados del correo 
        /// <summary>
        /// Metodo de envio de un correo electronico 
        /// </summary>
        public void enviarEmailSinXMl(String Excepcion)
        {

            //objeto email
            MailMessage email = new MailMessage();

            #region Propiedades del email
            //Instanciando la clase donde se manejan las opciones de XML
            XML_Manager XmlFile = new XML_Manager();




            email.To.Add(new MailAddress("EzequielGarcia0925@gmail.com"));
            email.From = new MailAddress("soporteezequielgarcia@gmail.com");
            email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Body = "Error " + Excepcion;
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
            smtp.Credentials = new NetworkCredential("soporteezequielgarcia@gmail.com","soporte1234");

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
