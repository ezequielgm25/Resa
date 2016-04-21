using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//Usings capas del sistema
using Capas.Infraestructura.Entidades;
using Capas.Negocio;

namespace Resa_Pro.Formularios
{
    public partial class AgregarSolicitud : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        //<Summary>
        // Interfaz que manejara la creacion de una nueva solicitud 
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
        //Usuario
        E_Usuario e_UsuarioAU = new E_Usuario();



        #endregion

        #region Constructor -
        /// <summary>
        /// Contructor de la clase agregar solicitud la cual espera una entidad de usuario 
        /// </summary>
        /// <param name="e_Usuario"></param>
        public AgregarSolicitud(E_Usuario e_Usuario)
        {

            //Asignando la entidad usuario  a la entidad global para ser utilizada desde todos los fragmentos del codigo 
            e_UsuarioAU = e_Usuario;

            //Inicializando los componentes 
            InitializeComponent();

            #region LLenando el datasource del grid control que precentara el Salon a eligir

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            #endregion

            #region Completando el label que indicara el registro seleccionado

            LBLNombreSalon.Text = "No seleccionado.";

            #endregion

            #region llenando el ComboBox de organizadores 

            CBOrganizador.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();
            CBOrganizador.ValueMember = "ID";
            CBOrganizador.DisplayMember = "Nombre";

            //Deseleccionando el items predeterminado 
            CBOrganizador.SelectedValue = -2;
            TBCorreoO.Text = "";
            TBDescripcionO.Text = "";




            #endregion

        }

        #endregion

        #region  Asignar al lbl de salon seleccionado -
        /// <summary>
        /// Evento click sobre el grid view de salones en el cual se le cambiara el text al lbl de salones que apunta la solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCSalones_Click(object sender, EventArgs e)
        {

            #region Completando el label que indicara el registro seleccionado
            //Variable a la cuall se le asignara la data seleccionada en la grid view 
            string NombreSalon = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

            //Verificacion de la variable 
            if (NombreSalon == "")
            {
                //Asignando  salon al Label de salon 
                MessageBox.Show("No hay Salones habilitados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //De lo contrario 
            else
            {
                //Asignando el dato seleccionado en la grid view 
                LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));


                /* Verificacion de la Fecha para este salon */
                VerificacionFechas();
            }

            #endregion


        }

        #endregion

        #region Guardar Solicitud -
        /// <summary>
        /// Evento click sobre el boton guardar en el  cual se gestionara el guardado de un solicitud 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBGuardar_Click(object sender, EventArgs e)
        {


            //<Summary>
            //Se guardar una solicitud con todas las caracteristicas correspondientes a la misma 
            //</Summary>

            //Verificacion de las Fechas si no estan en usos 

            VerificacionFechas();

            //Verificacion de  los Controles que esten debidamente llenos
            if (string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || CBOrganizador.SelectedItem == null || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text) || Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")) == 0 || VEmail(TBCorreoO.Text) != true || LBLNombreSalon.Text == "No seleccionado.")
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

                //Asignando los datos  a la entidad de solicitud 

                e_Solicitud.fecha = Convert.ToString(DateTime.Now);
                e_Solicitud.usuario = "No aprobada";
                e_Solicitud.aprobacion = "No aprobada";
                e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);
                e_Solicitud.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                //Guardando la solicitud y esperando el Id 
                e_Solicitud.id_Solicitud = n_Solicitud.CrearSolicitud(e_Solicitud);

                //Comprobando los datos 
                if (e_Solicitud.id_Solicitud == 0)
                {
                    //Mensaje de error
                    MessageBox.Show("Ocurrio un error al guardar la solicitud", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Asignando los datos a la entidad de Evento

                    //Tiempos//
                    DateTime Fechainicial = DateEditTInicio.DateTime;
                    DateTime FechaFinal = DateEditTFinal.DateTime;
                    //Tiempos//

                    // --- Otros --- //
                    e_Evento.titulo_Evento = TBTituloE.Text;
                    //Tipo
                    e_Evento.tipo = TBTipoE.Text;
                    //Topico
                    e_Evento.topico = TBTopicoE.Text;
                    //Descripcion
                    e_Evento.descripcion = TBDescripcionE.Text;
                    //Tiempo de inicio
                    e_Evento.tiempo_Inicio = Convert.ToString(Fechainicial);
                    //Tiempo de finalizacion
                    e_Evento.tiempo_Final = Convert.ToString(FechaFinal);
                    //Id  de la  Solicitud
                    e_Evento.id_Solicitud = e_Solicitud.id_Solicitud;



                    //Guardando la solicitud y esperando el Id 
                    e_Evento.id_Evento = n_Evento.CrearEvento(e_Evento);


                    if (e_Evento.id_Evento == 0)
                    {
                        MessageBox.Show("Ocurrio un error al guardar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //De lo contrario 
                    else
                    {
                        //Asignando los datos a la entidad de organizador Solo el Id por que ya anteriormente son asignados 


                        e_Organizador.id_Evento = e_Evento.id_Evento;

                        //Guardando la solicitud y esperando el Id 

                        e_Organizador.id_Organizador = n_Organizador.insertarOrganizador(e_Organizador);

                        //Verificando los datos
                        if (e_Solicitud.id_Solicitud == 0)
                        {
                            //Mensaje de error
                            MessageBox.Show("Ocurrio un error al guardar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //De lo contrario 
                        else
                        {
                            //Mensaje positivo se guardo correctamente

                            MessageBox.Show("La solicitud se guardo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }


                    }

                }


            }









        }

        #endregion

        #region Validacion de fechas -
        /// <summary>
        /// Evento EditValueChange donde se revisara si las fechas concuerdan o hay algun error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateEditTInicio_EditValueChanged(object sender, EventArgs e)
        {
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

                            }

                        }
                        else
                        {
                            //Mensaje de error 
                            MessageBox.Show("No se ha seleccionado un salon para verificar las fechas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                MessageBox.Show("El Tiempo seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Limpiando los DateEdit 
                                DateEditTInicio.Text = "";
                                DateEditTFinal.Text = "";

                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            //Mensaje de error
                            MessageBox.Show("No hay un salon seleccionado al cual se pueda verificar las fechas ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }

                }


            }
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

                            Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                            if (Resultado == 1)
                            {
                                MessageBox.Show("El Tiempo seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                DateEditTInicio.Text = "";
                                DateEditTFinal.Text = "";

                            }
                            else
                            {
                                //No hacer Nada
                            }

                        }
                        else
                        {
                            //Mensaje de informacion de que no hay salon selecciondo 

                            MessageBox.Show("No hay salon seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region Organizadores 
        /// <summary>
        /// Evento click en el boton organizadores donde se trabaja EL CRUD de los mismos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBOrganizador_Click(object sender, EventArgs e)
        {
            //Instanciando la interfaz de organizadores

            OrganizadoresF OrganizadorFrm = new OrganizadoresF();

            OrganizadorFrm.ShowDialog();

            // Asignando el datasource nuevamente al combobox


            CBOrganizador.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();
            CBOrganizador.ValueMember = "ID";
            CBOrganizador.DisplayMember = "Nombre";



        }

        #endregion

        #region Cambio en el valor del ComboBox 
        /// <summary>
        /// Evento del combobox de organizadores donde se cambian los valores de los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBOrganizador_SelectedValueChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(NombreOrganizador);

            int C = 0;
            //Asignando al combo box de ubicaciones la ubicacion seleccionada anteriormente
            foreach (DataRowView rowView in CBOrganizador.Items)
            {
                //Completando la entidad de servicios 

                if (C == CBOrganizador.SelectedIndex)
                {


                    TBDescripcionO.Text = Convert.ToString(rowView["Descripcion"]);

                    TBCorreoO.Text = Convert.ToString(rowView["Correo"]);
                    //Completando la Entidad 

                    e_Organizador.nombre = Convert.ToString(rowView["Nombre"]);
                    e_Organizador.descripcion = Convert.ToString(rowView["Descripcion"]);
                    e_Organizador.correoElectronico = Convert.ToString(rowView["Correo"]);


                }

                C++;
            }
        }






        #endregion

    }
}