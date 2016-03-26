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
using Capas.Negocio;
using Capas.Infraestructura.Entidades;

namespace Resa_Pro.Formularios
{
    public partial class ActualizarSolicitudesF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //interfaz donde se manejara la  Actualizacion de una solicitud 
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
        public ActualizarSolicitudesF(int ID_Solicitud, String Nombre_Salon)
        {
            InitializeComponent();

            #region Asignando Nombre al LBL Salon
            e_Salon.nombre = Nombre_Salon;
            LBLNombreSalon.Text = e_Salon.nombre;

            #endregion 


            #region LLenando el datasource del grid control que precentara el Salon a eligir

            GCSalones.DataSource = n_Salon.ObtenerID_NombreDeSalones();

            #endregion

            #region  Asignando los datos a los controles 

            //Asignando la informacion a las Entidades 
            e_Solicitud = n_Solicitud.ObtenerSolicitud(ID_Solicitud);
            e_Evento = n_Evento.ObtenerEvento(ID_Solicitud);
            e_Organizador = n_Organizador.Obtenerorganizador(e_Evento.id_Evento);


            //Asignando la informacion a los controles 

            TBTituloE.Text = e_Evento.titulo_Evento;
            TBTipoE.Text = e_Evento.tipo;
            TBTopicoE.Text = e_Evento.topico;
            TBDescripcionE.Text = e_Evento.descripcion;

            //Tiempo 

            DateEditTInicio.DateTime = Convert.ToDateTime(e_Evento.tiempo_Inicio);
            DateEditTFinal.DateTime = Convert.ToDateTime(e_Evento.tiempo_Final);

            //Organizador 

            TBNombreO.Text = e_Organizador.nombre;
            TBDescripcionO.Text = e_Organizador.descripcion;
            TBCorreoO.Text = e_Organizador.correoElectronico;



            #endregion



        }

        #endregion

        #region  Asignar al lbl de salon seleccionado

        private void GCSalones_Click_1(object sender, EventArgs e)
        {


            #region Completando el label que indicara el registro seleccionado

            LBLNombreSalon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre"));

            //Asignando ID  a la Entidad  de solicitud 

            e_Solicitud.id_Salon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

            #endregion

            /* Verificacion de la Fecha para este salon */

            if (e_Salon.nombre != Convert.ToString(gridView1.GetFocusedRowCellValue("Nombre")))
            {
                VerificacionFechas();
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


        #region Validacion de las Fechas 
        private void DateEditTInicio_EditValueChanged(object sender, EventArgs e)
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

        #region Actualizar Solicitud 
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



            if (string.IsNullOrEmpty(TBTituloE.Text) || string.IsNullOrEmpty(TBTipoE.Text) || string.IsNullOrEmpty(TBTopicoE.Text) || string.IsNullOrEmpty(TBDescripcionE.Text) || string.IsNullOrEmpty(DateEditTInicio.Text) || string.IsNullOrEmpty(DateEditTFinal.Text) || string.IsNullOrEmpty(TBNombreO.Text) || string.IsNullOrEmpty(TBDescripcionO.Text) || string.IsNullOrEmpty(TBCorreoO.Text))
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
             
                //Actualizando  la solicitud
                    FilasAfectadas = n_Solicitud.ActualizarSolicitud(e_Solicitud);

                if (FilasAfectadas == 0)
                {
                    MessageBox.Show("Ocurrio un error al Actualizar la solicitud ");
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
                        MessageBox.Show("Ocurrio un error al Actualizar la solicitud ");
                    }
                    else
                    {
                        //Asignando los datos a la entidad de Evento
                        e_Organizador.nombre = TBNombreO.Text;
                        e_Organizador.descripcion = TBDescripcionO.Text;
                        e_Organizador.correoElectronico = TBCorreoO.Text;
                        
                        //Guardando la solicitud y esperando el Id 

                        FilasAfectadas= n_Organizador.ActualizarOrganizador(e_Organizador);

                        if (FilasAfectadas == 0)
                        {
                            MessageBox.Show("Ocurrio un error al Actualizar la solicitud ");
                        }
                        else
                        {
                            MessageBox.Show("La solicitud se Actualizo correctamente");

                            this.Close();
                        }


                    }

                }


            }



        }

        #endregion
    }
}