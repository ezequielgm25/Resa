using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//Usings del sistema
using Capas.Negocio;
using Capas.Infraestructura.Entidades;


namespace Resa_Pro.Formularios
{
    public partial class ActualizarEvento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz donde se actualizara un evento 
        //</Summary>

        #region Declaraciones
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

        #region Contructor 
        /// <summary>
        /// Constructor de  la interfaz de actualizar un evento 
        /// </summary>
        /// <param name="ID_Solicitud"></param>
        /// <param name="Nombre_Salon"></param>
        public ActualizarEvento(int ID_Solicitud, String Nombre_Salon)
        {
            //Inicializando los componentes 
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
            string NombreOR = e_Organizador.nombre;

            // Asignando el datasource al combobox 
            CBOrganizador.DataSource = n_Organizador.ObtenerOrganizadoresGlobales();
            CBOrganizador.ValueMember = "ID";
            CBOrganizador.DisplayMember = "Nombre";



            int N = 0;
            //Asignando al combo box de ubicaciones la ubicacion seleccionada anteriormente
            foreach (DataRowView rowView in CBOrganizador.Items)
            {
                //Completando la entidad de servicios 

                if (NombreOR == Convert.ToString(rowView["Nombre"]))
                {

                    CBOrganizador.SelectedItem = CBOrganizador.Items[N];

                }

                N++;
            }




            #endregion


        }



        #endregion

        #region  Asignar al lbl de salon seleccionado
        /// <summary>
        /// Evento en el grid control de salones donde se contrala  el salon al cual se aunta el evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCSalones_Click(object sender, EventArgs e)
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

        #region Verificacion de Fechas Alternativas 
        /// <summary>
        /// Metodo donde se verifican las fechas alternativamente 
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

        #region  validacion de las fechas para no repeticion en los salones
        /// <summary>
        /// Validacion de las fechas  en el DateEdit de fecha de inicio
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
                                    MessageBox.Show("El Tiempo seleccionado ya esta en uso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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



        //DataEdit Fechca Final 
        /// <summary>
        /// Verificacion de las fechas del Date Edit  de fecha final 
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

        #region Actualizar Evento
        /// <summary>
        /// Evento click en el boton actualizar  donde se gestiona la funcion de actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBActualizar_Click(object sender, EventArgs e)
        {
            //<Summary>
            //Se Actualiza  un Evento  con todas  sus caracteristicas correspondientes a la misma 
            //</Summary>

            //Variables

            int FilasAfectadas = 0;


            //Verificacion de las Fechas si no estan en usos 

            VerificacionFechas();

            //Verificacion de  los Controles que se esten debidamente llenos



            if (string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || CBOrganizador.SelectedItem == null || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text))
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
            else
            {


                //Asignando los datos  a la entida de solicitud 

                e_Solicitud.fecha = Convert.ToString(DateTime.Now);
                e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);

                //Actualizando  la solicitud
                FilasAfectadas = n_Solicitud.ActualizarSolicitud(e_Solicitud);

                if (FilasAfectadas == 0)
                {
                    MessageBox.Show("Ocurrio un error al actualizar el evento ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Asignando los datos a la entidad de Evento

                    DateTime Fechainicial = DateEditTInicio.DateTime;
                    DateTime FechaFinal = DateEditTFinal.DateTime;

                    e_Evento.titulo_Evento = TBTituloE.Text;
                    e_Evento.tipo = TBTipoE.Text;
                    e_Evento.topico = TBTopicoE.Text;
                    e_Evento.descripcion = TBDescripcionE.Text;
                    e_Evento.tiempo_Inicio = Convert.ToString(Fechainicial);
                    e_Evento.tiempo_Final = Convert.ToString(FechaFinal);


                    //Actualizando la Solicitud 

                    FilasAfectadas = n_Evento.ActualizarEvento(e_Evento);

                    if (FilasAfectadas == 0)
                    {
                        MessageBox.Show("Ocurrio un error al actualizar el evento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Asignando los datos a la entidad de Evento
                      
                        
                        //Guardando la solicitud y esperando el Id 

                        FilasAfectadas = n_Organizador.ActualizarOrganizador(e_Organizador);

                        if (FilasAfectadas == 0)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar el evento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El evento  se actualizo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        #region Evento de cambio de valor en el combobox de organizador
        /// <summary>
        /// Evento cambop de valor en el ComboBox 
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

        #region Organizadores 
        /// <summary>
        /// Metodo donde se controla la iteracion con la interfaz de organizadores
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

      
    }
}
