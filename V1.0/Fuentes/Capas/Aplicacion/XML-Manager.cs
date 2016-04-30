using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;


namespace Capas.Aplicacion
{
    public class XML_Manager
    {

        //<summary>
        //Clase que manejara el el CRUD de los XML
        //</summary>
        
        #region     Verificación de los Archivos XML AppConfig y AppError Correspondientemente
        /// <summary>
        /// Verificación de los Archivos XML AppConfig y AppError Respectivamente
        /// </summary>
        public void verificarArchivosXMLAplicacion(){

            try {
                //Verificando la existencia de los archivos 
                if (Directory.Exists(directorioBaseAplicacion() + @"XML") == false)
                {

                    CrearDirectorio(directorioBaseAplicacion() + @"XML");
                }

                // comprovando si existe el archivo de configuracciones
                if (File.Exists(directorioBaseAplicacion() + @"XML\App-config.xml") == false)
                {

                    CrearXMl(@"App-config.xml");
                }
                // comprovando si existe el archivo de errores
                if (File.Exists(directorioBaseAplicacion() + @"XML\App-error.xml") == false)
                {

                    CrearXMl(@"App-Error.xml");
                }

               } catch ( DirectoryNotFoundException e)
               {
                
                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmailSinXMl(e.Message);
            }
             
            



        }

        #endregion 

        #region Creando el XMl  
        /// <summary>
        /// Metodo para Crear un Xml
        /// </summary>
        /// <param name="file"></param>
        public void CrearXMl(string file)
        {
            String FullXmlPath  = null;
         
            try {

                #region Creando App-Config
                ///<summary>
                ///Creando ell archivo  de configuraccion con su correspondiente estructura
                ///</Summary>

                if (file == "App-config.xml")
                {
                    file = @"XML\" + file; //Despues de la verificacion de archivos a crear se agrega el nombre del directorio

                    FullXmlPath = Path.Combine(directorioBaseAplicacion() + file);

                    //Se crear  la estructura
                   XDocument XML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),


                        new XElement("Configuraciones",

                            new XElement("Support",

                               new XElement("EmailFrom", "EzequielGarcia0925@gmail.com"),
                               new XElement("EmailSubject","soporteezequielgarcia@gmail.com"),
                               new XElement("Pop3"),
                               new XElement("SMTP", "smtp.gmail.com"),
                               new XElement("SSL"),
                               new XElement("Port", 587),
                               new XElement("EmailFormat"),
                               new XElement("HostServer", "soporteezequielgarcia@gmail.com"),
                               new XElement("PasswordServer", "soporte1234"),
                               new XElement("ContactInfo", "Ezequiel Garcia Vive en la victoria"),
                               new XElement("PhoneContact", "829-304-8492")),

                            new XElement("ConnectionString",

                              new XElement("SqlServer", "Data Source= Ezequiel; Initial Catalog = ResaDB; Integrated Security = true"))));

                    XML.Save(FullXmlPath); //Guardando el archivo
                }

                #endregion

                #region Creando App-Error

                ///<summary>
                ///Creando el archivo  de configuraccion con su correspondiente estructura
                ///</summary>
                ///
                if (file == "App-Error.xml")
                {
                    file = @"XML\" + file; //Despues de la verificacion de archivos a crear se agrega el nombre del directorio
                    
                     

                    FullXmlPath = Path.Combine(directorioBaseAplicacion() + file);

                    //Se crear  la estructura
                    XDocument XMLError = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),

                        new XElement("Errores",

                            new XElement("Error",
                                 new XElement("Fecha"),
                                 new XElement("ID_usuario"),
                                 new XElement("Opcion"),
                                 new XElement("TipoOpcion"),
                                 new XElement("Excepcion"))));

                    XMLError.Save(FullXmlPath); //Guardando El archivo
                }

                #endregion

               }
                catch(IOException IOE)
               {

                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmailSinXMl(IOE.Message);

            }

        }

        #endregion

        #region Creando Directorio de los XMl
        /// <summary>
        /// Metodo para la Creacion de un directorio 
        /// </summary>
        /// <param name="Folder"></param>
        private void CrearDirectorio(string Folder)
        {
            try {
                Directory.CreateDirectory(Folder);
                }
            catch (IOException EIO)
            {
                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmail(EIO.Message);
            }

        }


        #endregion

        #region buscarEnXml

        //<summary>
        //Metodo que buscara el contenido de un nodo hijo dentro de un XML 
        //</summary>
        /// <summary>
        /// Metodo que buscara un contenido de un nodo dentro de un archivo .XML
        /// </summary>
        /// <param name="ParameterNodo"></param>
        /// <param name="stringParameterAtributo"></param>
        /// <param name="stringParameterArchivoXML"></param>
        /// <returns></returns>
        public string BuscarElementoArchivoXMl(string ParameterNodo, string stringParameterAtributo, string stringParameterArchivoXML)
        {
            //Variables
            string Content = null;
            //Variables


            //Cargando el XML

            try {

                XmlNodeList xmlNodeList = default(XmlNodeList);

                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(directorioBaseAplicacion() + @"XML\" + stringParameterArchivoXML); // Cargando el documento

                xmlNodeList = xmlDocument.GetElementsByTagName(ParameterNodo);



                Content = string.IsNullOrEmpty(stringParameterAtributo) ? xmlNodeList[0].InnerText : xmlNodeList[0].Attributes[stringParameterAtributo].InnerText;

            }
            catch ( IOException IOE)
            {
               #region Manejo de errores en la busqueda del contenido del nodo
                //Enviando un email  a la cuenta de soporte la excepcion
                Email email = new Email();
                //Enviando
                email.enviarEmailSinXMl(IOE.Message);
                #endregion
                

            }

            return Content;
      

        }


        #endregion

        //Metodo para obtener la direccion del XMl 

        #region  obtener Direccion base
            /// <summary>
            /// Metodo para obtener la direccion basede un Directorio
            /// </summary>
            /// <returns></returns>
        public string directorioBaseAplicacion()
        {
            string stringDirectorioBase;//String directorio

            if (System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin") > 0)
            {
                //Directorio Base 
                stringDirectorioBase = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            }
            else {
                //Directorio release
                stringDirectorioBase = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            }

            return stringDirectorioBase;
        }

        #endregion

        #region Guardar En el XMl ERROR un error 

        /// <summary>
        /// Guardar en XMl  un error
        /// </summary>
        /// <param name="Fecha"></param>
        /// <param name="ID_Usuario"></param>
        /// <param name="opcion"></param>
        /// <param name="TipoOpcion"></param>
        /// <param name="excepcion"></param>
        public void GuardarEnXMl( string Fecha , string ID_Usuario , string opcion , string  TipoOpcion, string excepcion)
        {

            //Se resibe y se asignan los parametros esperados 
            XDocument miXML = XDocument.Load(directorioBaseAplicacion() + @"XML\App-Error.xml");
            miXML.Root.Add(
                new XElement("Error",
                    new XAttribute("Fecha", Fecha),
                    new XElement("ID_Usuario", ID_Usuario),
                    new XElement("Opcion", opcion),
                    new XElement("TipoOpcion", TipoOpcion),
                      new XElement("Excepcion", excepcion))
                    );
            miXML.Save(directorioBaseAplicacion() + @"XML\App-Error.xml");


        }


        #endregion

    }
}
