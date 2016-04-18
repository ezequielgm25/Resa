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
    public partial class CrearEvento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        // Interfaz que manejara la creacion de una nuevo evento 
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
        //Usuarios
        N_Usuario n_Usuario = new N_Usuario();

        E_Usuario e_UsuarioAU = new E_Usuario();

        #endregion

        #region Contructor 

        public CrearEvento(E_Usuario e_Usuario)
        {
            InitializeComponent();

            //Asignando entidad 

            e_UsuarioAU = e_Usuario;


            #region LLenando el datasource del grid control que precentara el Salon a eligir

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            #endregion

            #region Completando el lable que indicara el registro seleccionado

            LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

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

        #region Validacion de fechas 


        private void DateEditTInicio_EditValueChanged_1(object sender, EventArgs e)
        {
            DateTime FechaInicial;
            DateTime FechaFinal;


            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {


                    FechaInicial = DateEditTInicio.DateTime;
                    FechaFinal = DateEditTFinal.DateTime;

                    if (FechaInicial >= FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text ="";
                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                        if (Resultado == 1)
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso");

                            //Limpiando los dateTipes
                            DateEditTInicio.Text = "";
                            DateEditTFinal.Text ="";

                        }
                        else
                        {

                        }

                    }

                }


            }

        }

        //Validacion de la fecha Final 

        private void DateEditTFinal_EditValueChanged(object sender, EventArgs e)
        {
            DateTime FechaInicial;
            DateTime FechaFinal;


            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {

                    FechaInicial = DateEditTInicio.DateTime;
                    FechaFinal = DateEditTFinal.DateTime;

                    if (FechaInicial >= FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text = "";

                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                        if (Resultado == 1)
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso ");

                            DateEditTInicio.Text = "";
                            DateEditTFinal.Text =  "";

                        }
                        else
                        {

                        }

                    }

                }


            }
        }



        #endregion

        #region  Asignar al lbl de salon seleccionado

        private void GCSalones_Click(object sender, EventArgs e)
        {

            #region Completando el label que indicara el registro seleccionado

            LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));


            #endregion

            /* Verificacion de la Fecha para este salon */
            VerificacionFechas();

        }

        #endregion

        #region Verificacion de Fechas Alternativas 

        public void VerificacionFechas()
        {
            DateTime FechaInicial;
            DateTime FechaFinal;


            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {

                    FechaInicial = DateEditTInicio.DateTime;
                    FechaFinal = DateEditTFinal.DateTime;

                    if (FechaInicial >= FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text = "";

                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                        if (Resultado == 1)
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso ");

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


        #endregion

        #region Crear Evento 

        private void SBGuardar_Click(object sender, EventArgs e)
        {
            //<Summary>
            //Se guardara un evento el cual sera parte del programa de un salon
            //</Summary>

            //Verificacion de las Fechas si no estan en usos 

            VerificacionFechas();

            //Verificacion de  los Controles que eseten debidamente llenos



            if (string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || CBOrganizador.SelectedItem == null  || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text))
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
                e_Solicitud.usuario = e_UsuarioAU.nombre;
                e_Solicitud.aprobacion = "Aprobada";
                e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);
                e_Solicitud.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                //Guardando la solicitud y esperando el Id 
                e_Solicitud.id_Solicitud = n_Solicitud.CrearSolicitud(e_Solicitud);

                if (e_Solicitud.id_Solicitud == 0)
                {
                    MessageBox.Show("Ocurrio un error al guardar la solicitud ");
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
                    e_Evento.id_Solicitud = e_Solicitud.id_Solicitud;



                    //Guardando la solicitud y esperando el Id 
                    e_Evento.id_Evento = n_Evento.CrearEvento(e_Evento);
                    if (e_Solicitud.id_Solicitud == 0)
                    {
                        MessageBox.Show("Ocurrio un error al guardar la solicitud ");
                    }
                    else
                    {
                        //Asignando los datos a la entidad de Evento
                       
                        e_Organizador.id_Evento = e_Evento.id_Evento;

                        //Guardando la solicitud y esperando el Id 

                        e_Organizador.id_Organizador = n_Organizador.insertarOrganizador(e_Organizador);
                        if (e_Solicitud.id_Solicitud == 0)
                        {
                            MessageBox.Show("Ocurrio un error al guardar el evento ");
                        }
                        else
                        {
                            MessageBox.Show("El evento se guardo correctamente");

                            this.Close();
                        }


                    }

                }


            }

        }


        #endregion

        #region  Asignar al lbl de salon seleccionado
        private void GCSalones_Click_1(object sender, EventArgs e)
        {


            #region Completando el label que indicara el registro seleccionado

            LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));


            #endregion

            /* Verificacion de la Fecha para este salon */
            VerificacionFechas();


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

        #region Evento al cambiar los valores en el combobox 
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