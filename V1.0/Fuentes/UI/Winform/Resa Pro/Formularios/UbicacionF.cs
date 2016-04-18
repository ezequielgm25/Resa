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
    public partial class UbicacionF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //<Summary>
        //Interfaz que gestionara la creacion de un nuevo salon 
        //</Summary>

        #region Declaraciones -

        //Entidad Salon
        N_Salon n_salon = new N_Salon();

        E_Salon e_Salon = new E_Salon();

        #endregion

        #region Contructor
        public UbicacionF()
        {
            //Inicializando  los componenentes 
            InitializeComponent();

            //Llenando el DataGrid de ubicaciones 

            GCUbicaciones.DataSource = n_salon.ObtenerUbicacionesGlobales();
           


        }


        #endregion

        #region Agregar Ubicacion 
        private void SBAgregarU_Click(object sender, EventArgs e)
        {
            if(TBUbicacion.Text == "")
            {
                //Mostrando  Mensaje de recomendacion al usuario 
                MessageBox.Show("El campo ubicacion debe estar completo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int Resultado;
                Resultado = n_salon.AgregarUbicacionGlobal(TBUbicacion.Text);

                if(Resultado == 1)
                {
                    MessageBox.Show("La ubicacion se guardo con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualizando el dataSource en el Grid control

                    GCUbicaciones.DataSource = n_salon.ObtenerUbicacionesGlobales();

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar la ubicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        #endregion

        #region Quitar Ubicacion
        private void SBEliminarU_Click(object sender, EventArgs e)
        {
            int FilasAfectadas;
             int ID_Ubicacion = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
             
               
            if (ID_Ubicacion != 0)
            {

                //Preguntar al usuario  si desea eliminarlo  "Este es el dialogo en el que se le preguntara al usuario la confirmacion de la eliminacion "
                DialogResult dialogResult = MessageBox.Show("Desea eliminar la ubicacion?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                //Si el dialogo result resulta  positivo 
                if (dialogResult == DialogResult.Yes)
                {


                    //Variables que recuperara las filas afectadas 
                    FilasAfectadas = n_salon.EliminarUbicacionGlobal(ID_Ubicacion);

                    //Si no se afecto ninguna fila es por que hubo un error en el sistema  el cual se le presenta al usuario
                    if (FilasAfectadas != 1)
                    {
                        MessageBox.Show("Ocurrio un error al eliminar la ubicacionF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //De lo contrario se mostrara un mensaje con la informacion positiva de que se elimino el salon 
                    else
                    {
                        MessageBox.Show("La solicitud se elimino Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GCUbicaciones.DataSource = n_salon.ObtenerUbicacionesGlobales();

                    }

                }
                //Si la iteracion con el dialogo result fue negativa  "No se hara nada "
                else if (dialogResult == DialogResult.No)
                {
                    //No se hace nada 
                }

            }

            else
            {
                //mensaje  de que el Grid view esta vacio 

                MessageBox.Show(" No hay ninguna ubicacion a eliminar seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        #endregion


    }
}