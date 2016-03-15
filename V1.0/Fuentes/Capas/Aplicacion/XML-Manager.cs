using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Threading;

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
                
               }
             
            



        }

        #endregion 


        #region Creando el XMl  
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
                               new XElement("EmailSubject", "Contactandote desde la aplicacion de reservacion"),
                               new XElement("Pop3"),
                               new XElement("SMTP"),
                               new XElement("SSL"),
                               new XElement("Port"),
                               new XElement("EmailFormat"),
                               new XElement("HostServer"),
                               new XElement("PasswordServer"),
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

               }

        }

        #endregion

        #region Creando Directorio de los XMl
        private void CrearDirectorio(string Folder)
        {
            try {
                Directory.CreateDirectory(Folder);
                }
            catch (IOException EIO)
            {

            }

        }


        #endregion



        #region buscarEnXml

        //<summary>
        //Metodo que buscara el contenido de un nodo hijo dentro de un XML 
        //</summary>

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

                xmlNodeList = xmlDocument.GetElementsByTagName("SqlServer");



                Content = string.IsNullOrEmpty(stringParameterAtributo) ? xmlNodeList[0].InnerText : xmlNodeList[0].Attributes[stringParameterAtributo].InnerText;

            }
            catch ( IOException IOE)
            {
                #region Manejo de errores en la busqueda del contenido del nodo

                #endregion

              
            }

            return Content;
      

        }


        #endregion

        //Metodo para obtener la direccion del XMl 

        #region  obtener Direccion base
        public static string directorioBaseAplicacion()
        {
            string stringDirectorioBase;
            if (System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin") > 0)
            {

                stringDirectorioBase = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            }
            else {

                stringDirectorioBase = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            }

            return stringDirectorioBase;
        }

        #endregion
    }
}
