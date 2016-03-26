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

using Capas.Infraestructura.Entidades;
using Capas.Negocio;

namespace Resa_Pro.Formularios
{
    public partial class AgregarSolicitud : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        //<Summary>
        // Interfaz que manejara la creacion de una nueva solicitud 
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

        #region Constructor
        public AgregarSolicitud()
        {
            InitializeComponent();

            #region LLenando el datasource del grid control que precentara el Salon a eligir

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            #endregion

            #region Completando el lable que indicara el registro seleccionado

            LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

            #endregion

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


        #region Guardar Solicitud 
        private void SBGuardar_Click(object sender, EventArgs e)
        {


            //<Summary>
            //Se guardar una solicitud con todas las caracteristicas correspondientes a la misma 
            //</Summary>

            //Verificacion de las Fechas si no estan en usos 

            VerificacionFechas();

            //Verificacion de  los Controles que eseten debidamente llenos



            if(string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || string.IsNullOrEmpty(TBNombreO.Text) || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text))
            {

                MessageBox.Show("Todos los campos Deben Contener Informacion");
                

            }
            else
            {
             
                 
                //Asignando los datos  a la entida de solicitud 

                e_Solicitud.fecha = Convert.ToString(DateTime.Now);
                e_Solicitud.usuario = "----";
                e_Solicitud.aprobacion = "No aprobada";
                e_Solicitud.fechaAprobacion = Convert.ToString(DateTime.Now);
                e_Solicitud.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                     //Guardando la solicitud y esperando el Id 
                    e_Solicitud.id_Solicitud = n_Solicitud.CrearSolicitud(e_Solicitud);
                  
                 if( e_Solicitud.id_Solicitud == 0)
                {
                    MessageBox.Show("Ocurrio un error al guardar la solicitud ");
                }
                else
                {
                    //Asignando los datos a la entidad de Evento

                    DateTime Fechainicial = DateEditTInicio.DateTime;
                    DateTime FechaFinal = DateEditTFinal.DateTime;
                   
                    e_Evento.titulo_Evento = TBTituloE.Text;
                    e_Evento.tipo    = TBTipoE.Text;
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
                        e_Organizador.nombre = TBNombreO.Text;
                        e_Organizador.descripcion = TBDescripcionO.Text;
                        e_Organizador.correoElectronico = TBCorreoO.Text;
                        e_Organizador.id_Evento = e_Evento.id_Evento;

                        //Guardando la solicitud y esperando el Id 

                        e_Organizador.id_Organizador = n_Organizador.insertarOrganizador(e_Organizador);
                        if (e_Solicitud.id_Solicitud == 0)
                        {
                            MessageBox.Show("Ocurrio un error al guardar la solicitud ");
                        }
                        else
                        {
                            MessageBox.Show("La solicitud se guardo correctamente");

                            this.Close();
                        }


                    }

                }


            }









        }

        #endregion

        #region Validacion de fechas 
        private void DateEditTInicio_EditValueChanged(object sender, EventArgs e)
        {
            DateTime FechaInicial;
            DateTime FechaFinal;


            if (!string.IsNullOrEmpty(DateEditTInicio.Text))
            {
                if (!string.IsNullOrEmpty(DateEditTFinal.Text))
                {


                    FechaInicial = DateEditTInicio.DateTime ;
                    FechaFinal = DateEditTFinal.DateTime;

                    if (FechaInicial > FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text = null;
                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                        if (Resultado== 1)
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso");

                            //Limpiando los dateTipes
                            DateEditTInicio.ResetText();
                            DateEditTFinal.ResetText();

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

                    if (FechaInicial > FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text = null;

                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas( DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);
                        
                        if (Resultado == 1 )
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso ");

                            DateEditTInicio.ResetText();
                            DateEditTFinal.ResetText();

                        }
                        else
                        {

                        }

                    }

                }


            }
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

                    if (FechaInicial > FechaFinal)
                    {
                        MessageBox.Show("Hay discordancia en las fechas");

                        DateEditTFinal.Text = null;

                    }
                    else
                    {
                        int Resultado;
                        int ID_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                        Resultado = n_Evento.VerificarFechas(DateEditTInicio.DateTime, DateEditTFinal.DateTime, ID_Salon);

                        if (Resultado == 1)
                        {
                            MessageBox.Show("El Tiempo Seleccionado ya esta en uso ");

                            DateEditTInicio.ResetText();
                            DateEditTFinal.ResetText();

                        }
                        else
                        {

                        }

                    }

                }


            }

        }

        #endregion
    }
}