using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Text.RegularExpressions;

using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class ActualizarSolicitudesF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //interfaz donde se manejara la  Actualizacion de una solicitud 
        //</Summary>

        #region Declaraciones - 
        //Salones
        N_Salon n_Salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

        //Solicitudes
        N_Solicitud n_Solicitud = new N_Solicitud();

        E_Solicitud e_Solicitud = new E_Solicitud();
        //Eventos 
        E_Evento e_Evento = new E_Evento();

        N_Evento n_Evento = new N_Evento();
        //Organizadores
        E_Organizador e_Organizador = new E_Organizador();

        N_Organizador n_Organizador = new N_Organizador();

        #endregion

        #region Constructor -
        /// <summary>
        /// Contructor de la interfaz de actualizar solicitudes 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="Nombre_Salon"></param>
        public ActualizarSolicitudesF(int ID_Solicitud, String Nombre_Salon)
        {

            //Inicializar los componentes 
            InitializeComponent();


            #region Asignando Nombre al LBL Salon

            //Se asigna  el nombre del salon a la entidad 
            e_Salon.nombre = Nombre_Salon;

            //Se le asigna el nombre del salon seleccionado al label del nombre del salon 
            LBLNombreSalon.Text = e_Salon.nombre;

            #endregion 


            #region LLenando el datasource del grid control que precentara el Salon a eligir

            //llenando el datasource de los salones 
            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            #endregion

            #region  Asignando los datos a los controles 

            //Asignando la informacion a las Entidades

            //Obtener Solicitud 
            e_Solicitud = n_Solicitud.ObtenerSolicitud(ID_Solicitud);

            //Obtiene el evento
            e_Evento = n_Evento.ObtenerEvento(ID_Solicitud);

            //Obtener el organizador
            e_Organizador = n_Organizador.Obtenerorganizador(e_Evento.id_Evento);


            //Asignando la informacion a los controles 
            //Titulo evento
            TBTituloE.Text = e_Evento.titulo_Evento;
            //Tipo
            TBTipoE.Text = e_Evento.tipo;
            //Topico
            TBTopicoE.Text = e_Evento.topico;
            //Descripcion
            TBDescripcionE.Text = e_Evento.descripcion;

            //Tiempo 

            DateEditTInicio.DateTime = Convert.ToDateTime(e_Evento.tiempo_Inicio);
            DateEditTFinal.DateTime = Convert.ToDateTime(e_Evento.tiempo_Final);

            //Organizador 
            //nombre 
            TBNombreO.Text = e_Organizador.nombre;
            //Descripcion
            TBDescripcionO.Text = e_Organizador.descripcion;
            //Correo
            TBCorreoO.Text = e_Organizador.correoElectronico;



            #endregion



        }

        #endregion

        #region  Asignar al lbl de salon seleccionado -
        /// <summary>
        /// Evento click sobre el grid control de los salones  para cambiar  el Salon al cual se apunta con la Solicitud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCSalones_Click_1(object sender, EventArgs e)
        {


            #region Completando el label que indicara el registro seleccionado

            String Nombre_Salon = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));


            if (Nombre_Salon != "")
            {

                LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

                //Asignando ID  a la Entidad  de solicitud 

                e_Solicitud.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                //Verificando si se cambio el nombre del salon  y verificando las fechas 
                if (e_Salon.nombre != Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre")))
                {
                    VerificacionFechas();
                }

            }
            //De le contrario
            else
            {
                //Asignando  salon al Label de salon 
                MessageBox.Show("No hay Salones habilitados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            #endregion

            /* Verificacion de la Fecha para este salon */


        }

        #endregion

        #region Verificacion de Fechas Alternativas -
        /// <summary>
        /// Metodo que verificara alternativamente al evento Datechange si las fechas tienen algun error
        /// </summary>
        public void VerificacionFechas()
        {
            //Declaracion de dos variables Datetimes
            DateTime FechaInicial;
            DateTime FechaFinal;
            //*---------------------------------*//

            //Verificacion si los dos DateTimes tienen informacion 
            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {
                    //Asignacion de los valores 
                    FechaInicial = DateEditTInicio.DateTime;
                    //----//
                    FechaFinal = DateEditTFinal.DateTime;

                    //Comparando las fechas en busca de alguna discordancia

                    if (FechaInicial >= FechaFinal)
                    {

                        //Mensaje de informacion de discordancia en las fechas
                        MessageBox.Show("Hay discordancia en las fechas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Eliminando la informacion
                        DateEditTFinal.Text = "";
                        //Asignando el focus al DateEdit
                        DateEditTFinal.Focus();
                    }

                    //De lo contrario 
                    else
                    {
                        //Variable que recogera el resultado
                        int Resultado;

                        //variable que se le asigna la data del grid view 
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));


                        //Desicion de verficacion 
                        if (ID_Salon != 0)
                        {
                            //VErifica si el ID cambio para verificar si la fecha esta disponible en el salon
                            if (e_Salon.nombre != Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre")) || DateEditTInicio.DateTime != Convert.ToDateTime(e_Evento.tiempo_Inicio) || DateEditTFinal.DateTime != Convert.ToDateTime(e_Evento.tiempo_Final))
                            {

                                Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                                if (Resultado == 1)
                                {
                                    MessageBox.Show("El Tiempo Seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    DateEditTInicio.Text = "";
                                    DateEditTFinal.Text = "";

                                }
                                else
                                {
                                }

                            }
                        }
                    
                    }

                }


            }

        }




        #endregion

        #region Validacion de las Fechas -
        /// <summary>
        /// Evento EditValueChange donde se revisara si las fechas concuerdan o hay algun error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateEditTInicio_EditValueChanged(object sender, EventArgs e)
        {
            // Verificar Si la data del Grid control

            //Declaraccion de las variables 
            DateTime FechaInicial;
            DateTime FechaFinal;
            //------//

            //Verificacion de que los DateEdit contengandatos 
            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {

                    //Asignando los datos 
                    FechaInicial = DateEditTInicio.DateTime;
                    FechaFinal = DateEditTFinal.DateTime;

                    //Condicion de verificacion de discordancia en las fechas o algo por el estilo
                    if (FechaInicial >= FechaFinal)
                    {

                        MessageBox.Show("Hay discordancia en las fechas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Eliminando el text 
                        DateEditTFinal.Text = "";
                        //Dandole el focus al DateEditTFinal
                        DateEditTFinal.Focus();
                    }
                    else
                    {

                        //VErifica si el ID cambio para verificar si la fecha esta disponible en el salon
                        if (e_Salon.nombre != Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre")) || DateEditTInicio.DateTime != Convert.ToDateTime(e_Evento.tiempo_Inicio) || DateEditTFinal.DateTime != Convert.ToDateTime(e_Evento.tiempo_Final))
                        {

                            //Variable que recogera el resultado 
                            int Resultado;
                            //Variable salon que verificara los resultados 
                            int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                            //Verificacion 
                            if (ID_Salon != 0)
                            {

                                Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                                if (Resultado == 1)
                                {
                                    MessageBox.Show("El Tiempo Seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //Limpiando los dateTipes
                                    DateEditTInicio.Text = "";
                                    DateEditTFinal.Text = "";

                                }
                                else
                                {
                                    //No hacer nada
                                }

                            }
                     
                        }

                    }

                }


            }


        }


        //Validacion de la fecha Final 
        /// <summary>
        /// Evento EditValueChange donde se revisara si las fechas concuerdan o hay algun error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateEditTFinal_EditValueChanged(object sender, EventArgs e)
        {

            // Verificar Si la data del Grid control

            //Variables a las cuales se lees asignara las fechas 
            DateTime FechaInicial;
            DateTime FechaFinal;
            // -- - //

            //Verificacion de  que los DateEdit Contengan Data 
            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {
                    //Asignando las fechas a los DateEdits
                    FechaInicial = DateEditTInicio.DateTime;
                    FechaFinal = DateEditTFinal.DateTime;

                    //Verificacion si hay discordancia en las fechas 
                    if (FechaInicial >= FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Eliminando el text en el DateEdit 

                        DateEditTFinal.Text = "";
                        // Dandole el enfoque al DateEdit 
                        DateEditTFinal.Focus();

                    }
                    else
                    {
                        if (e_Salon.nombre != Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre")) || DateEditTInicio.DateTime != Convert.ToDateTime(e_Evento.tiempo_Inicio) || DateEditTFinal.DateTime != Convert.ToDateTime(e_Evento.tiempo_Final))
                        {
                            //Variable que se le asignara el resultado
                            int Resultado;
                            //Variable que resivira el ID  de la fila seleccionada en el grid view 
                            int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                            if (ID_Salon != 0)
                            {
                                //Verificacion de las fechas
                                Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);
                                //verificando el resultado

                                if (Resultado == 1)
                                {
                                    //Mensaje de informacion de que la fecha no esta disponible 
                                    MessageBox.Show("El Tiempo Seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //Limpiando los DateEdit 
                                    DateEditTInicio.Text = "";
                                    DateEditTFinal.Text = "";

                                }
                                else
                                {

                                }


                            }
                           
                        }
                    }

                }


            }



        }



        #endregion

        #region Actualizar Solicitud -
        /// <summary>
        /// Evento click sobre el boton actualizar  en el cual se gestionara la funcion de actualizar una solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizar_Click(object sender, EventArgs e)
        {


            //<Summary>
            //Se  Actualiza  una solicitud con todas las caracteristicas correspondientes a la misma 
            //</Summary>

            //Variables

            int FilasAfectadas = 0;


            //Verificacion de las Fechas si no estan en usos 

            VerificacionFechas();

            //Verificacion de  los Controles que se esten debidamente llenos

            if (string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || string.IsNullOrEmpty(TBNombreO.Text) || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text) || VEmail(TBCorreoO.Text) != true)
            {

                if (TBCorreoO.Text != "" && VEmail(TBCorreoO.Text) != true)
                {

                    //Mensaje de informacion de los campos no estan completos o debidamente llenos
                    MessageBox.Show("El correo esta mal escrito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    //Mensaje de informacion de los campos no estan completos o debidamente llenos
                    MessageBox.Show("Todos los campos deben contener Informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            //De lo contrario 
            else
            {


                //Asignando los datos  a la entida de solicitud 

                e_Solicitud.fecha = Convert.ToString(DateTime.Now);



                //Actualizando  la solicitud
                FilasAfectadas = n_Solicitud.ActualizarSolicitud(e_Solicitud);

                //Verificando  las filas afectadas
                if (FilasAfectadas == 0)
                {
                    //mensaje de error
                    MessageBox.Show("Ocurrio un error al actualizar la solicitud ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //De lo contrario 
                else
                {
                    //Asignando los datos a la entidad de Evento

                    //Tiempo
                    //Inicio
                    DateTime Fechainicial = DateEditTInicio.DateTime;
                    //Final
                    DateTime FechaFinal = DateEditTFinal.DateTime;
                    //-----------------------------------//

                    //Titulo Evento
                    e_Evento.titulo_Evento = TBTituloE.Text;
                    //Tipo
                    e_Evento.tipo = TBTipoE.Text;
                    //Topico
                    e_Evento.topico = TBTopicoE.Text;
                    //Descripcion
                    e_Evento.descripcion = TBDescripcionE.Text;
                    //Tiempo inicio
                    e_Evento.tiempo_Inicio = Convert.ToString(Fechainicial);
                    //Tiempo Final 
                    e_Evento.tiempo_Final = Convert.ToString(FechaFinal);


                    //Actualizando la Solicitud 

                    FilasAfectadas = n_Evento.ActualizarEvento(e_Evento);

                    //Verificando  
                    if (FilasAfectadas == 0)
                    {
                        //Mensaje de error
                        MessageBox.Show("Ocurrio un error al actualizar la solicitud ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //De lo contrario 
                    else
                    {
                        //Asignando los datos a la entidad de Evento
                        e_Organizador.nombre = TBNombreO.Text;
                        //Descripcion
                        e_Organizador.descripcion = TBDescripcionO.Text;
                        //Correo Electronico 
                        e_Organizador.correoElectronico = TBCorreoO.Text;

                        //Guardando la solicitud y esperando el Id 

                        FilasAfectadas = n_Organizador.ActualizarOrganizador(e_Organizador);

                        //Verificacion 
                        if (FilasAfectadas == 0)
                        {
                            //Mensaje de error 
                            MessageBox.Show("Ocurrio un error al actualizar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        //De lo contrario 
                        else
                        {

                            MessageBox.Show("La solicitud se Actualizo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }


                    }

                }


            }



        }

        #endregion

        #region Verificacion de Email -
        /// <summary>
        /// Metodo que verifica el email acepta un string como parametro 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool VEmail(String Email)
        {
            //Variable que contendra la expresion de validacion del email  
            String expresion;
            //Asignando la expresion de validacion 
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            //Varificando 
            if (Regex.IsMatch(Email, expresion))
            {
                //Desicion 
                if (Regex.Replace(Email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion 

    }
}