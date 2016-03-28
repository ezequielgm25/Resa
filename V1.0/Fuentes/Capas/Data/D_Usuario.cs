using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capas.Infraestructura.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Capas.Data
{
    public class D_Usuario:Conexion
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias

        E_Usuario e_usuario = new E_Usuario();

        private Conexion conexion;
        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;

        
        #endregion

        #region Contructor

        public D_Usuario()
        {
            conexion = new Conexion();
        }

        #endregion


        #region Obtener Usuario 
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {

            StoredProcedure = "ObtenerUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;


            //Variable devuelta nombre
            SqlParameter Nombre = new SqlParameter("@Nombre", SqlDbType.VarChar,50);
            Nombre.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Nombre);
            //Variable devuelta Apellido
            SqlParameter Apellido = new SqlParameter("@Apellido", SqlDbType.VarChar, 50);
            Apellido.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Apellido);
            //Variable devuelta Rol
            SqlParameter Rol = new SqlParameter("@Rol", SqlDbType.VarChar, 50);
            Rol.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Rol);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            e_usuario.nombre = Convert.ToString(Comando.Parameters["@Nombre"].Value);
            e_usuario.apellido = Convert.ToString(Comando.Parameters["@Apellido"].Value);
            e_usuario.rol = Convert.ToString(Comando.Parameters["@Rol"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
        
            return e_usuario;
        }

        #endregion

        #region obtner usuarios 

        public DataTable ObteneruSuarios()
        {
            StoredProcedure = "ObtenerUsuarios";

            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            DataTable DataT = new DataTable();

            DataT.Clear();

            DataAD.Fill(DataT);

            return DataT;
        }


        #endregion


        #region Verificar Existencia de usuario 

        public int VerificarExistenciaDeUsuario(String Usuario)
        {
            StoredProcedure = "VerificarExistenciaUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar,50).Value = Usuario;


            //Variable devuelta nombre
            SqlParameter Result = new SqlParameter("@Result", SqlDbType.Int);
            Result.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Result);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int Resultado = Convert.ToInt32(Comando.Parameters["@Result"].Value);
           

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return Resultado;




        }

        #endregion


        #region Insertar Rol
        public int InsertarRol(String Rol , int ID_GrupoUsuario )
        {
            StoredProcedure = "InsertarRol";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@NombreRol", SqlDbType.VarChar, 50).Value = Rol;
            Comando.Parameters.Add("@ID_GrupoUsuario", SqlDbType.Int).Value = ID_GrupoUsuario;


            //Variable devuelta nombre
            SqlParameter ID_Rol = new SqlParameter("@ID_Rol", SqlDbType.Int);
            ID_Rol.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Rol);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int ID = Convert.ToInt32(Comando.Parameters["@ID_Rol"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;

        }


        #endregion


        #region Insertar Usuario
        public int InsertarUsuario(E_Usuario e_U)
        {
            StoredProcedure = "IngresarUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = e_U.nombre;
            Comando.Parameters.Add("@Apellido", SqlDbType.NVarChar , 50).Value = e_U.apellido;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = e_U.usuario;
            Comando.Parameters.Add("@Pass", SqlDbType.NVarChar, 300).Value = e_U.contraseña;
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = e_U.estado;
            Comando.Parameters.Add("@ID_Rol", SqlDbType.Int).Value = e_U.id_Rol;

            //Variable devuelta nombre
            SqlParameter ID_Usuario = new SqlParameter("@ID_Usuario", SqlDbType.Int);
            ID_Usuario.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Usuario);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int ID = Convert.ToInt32(Comando.Parameters["@ID_Usuario"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;

        }

        #endregion

        #region Insertar  Perfil 
        public int InsertarPerfil(string Perfil, int ID_Usuario)
        {
            StoredProcedure = "InsertarPerfil";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@NombrePerfil", SqlDbType.VarChar, 50).Value = Perfil;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;
          

            //Variable devuelta nombre
            SqlParameter ID_Perfil = new SqlParameter("@ID_Perfil", SqlDbType.Int);
            ID_Perfil.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Perfil);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int ID = Convert.ToInt32(Comando.Parameters["@ID_Perfil"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;

        }


        #endregion


        #region Insertar opcion 

        public int InsertarOpcion(String Opcion , int ID_Perfil)
        {
            StoredProcedure = "InsertarOpcion";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Opcion", SqlDbType.VarChar, 50).Value = Opcion;
            Comando.Parameters.Add("@ID_Perfil", SqlDbType.Int).Value = ID_Perfil;


            //Variable devuelta nombre
            SqlParameter ID_Opcion = new SqlParameter("@ID_Opcion", SqlDbType.Int);
            ID_Opcion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Opcion);


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int ID = Convert.ToInt32(Comando.Parameters["@ID_Opcion"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;
        }

        #endregion

        #region Insertar Funcion 
        public int InsertarFuncion(String Funcion, bool Estado, int ID_Opcion)
        {

            StoredProcedure = "InsertarFuncion";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Funcion", SqlDbType.VarChar, 50).Value = Funcion;
            Comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            Comando.Parameters.Add("@ID_Opcion", SqlDbType.Int).Value = ID_Opcion;


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure

            int ID = Convert.ToInt32(Comando.Parameters["@ID_Opcion"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

           



            return FilasAfectadas;
        }

        #endregion


        #region Obtener Informacion detallada de usuario 
        public E_Usuario ObtenerInformacionDetallada(int ID_Usuario)
        {

            StoredProcedure = "ObtenerInformacionCompletaUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;

            //Variable devuelta Rol
            SqlParameter Rol = new SqlParameter("@Rol", SqlDbType.NVarChar, 50);
            Rol.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Rol);

            //Variable devuelta nombre
            SqlParameter Nombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 50);
            Nombre.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Nombre);

            //Variable devuelta Apellido
            SqlParameter Apellido = new SqlParameter("@Apellido", SqlDbType.NVarChar, 50);
            Apellido.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Apellido);

            //Variable devuelta Usuario
            SqlParameter Usuario = new SqlParameter("@Usuario", SqlDbType.NVarChar, 50);
            Usuario.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Usuario);

            //Variable devuelta Usuario
            SqlParameter Estado = new SqlParameter("@Estado", SqlDbType.NVarChar, 50);
            Estado.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Estado);

            //Variable devuelta ID_ROl
            SqlParameter ID_ROl = new SqlParameter("@ID_Rol", SqlDbType.Int);
            ID_ROl.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_ROl);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            e_usuario.rol = Convert.ToString(Comando.Parameters["@Rol"].Value);
            e_usuario.nombre = Convert.ToString(Comando.Parameters["@Nombre"].Value);
            e_usuario.apellido = Convert.ToString(Comando.Parameters["@Apellido"].Value);
            e_usuario.usuario = Convert.ToString(Comando.Parameters["@Usuario"].Value);
            e_usuario.estado = Convert.ToString(Comando.Parameters["@Estado"].Value);
            e_usuario.id_Rol = Convert.ToInt32(Comando.Parameters["@ID_Rol"].Value);

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

          



            return e_usuario;
        }



        #endregion


        #region ObtenerPerfil 
        public  int obtenerPerfil(int ID_Usuario)
        {
            StoredProcedure = "ObtenerPerfil";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;

            //Variable devuelta ID_Perfil 
            SqlParameter ID_Perfil = new SqlParameter("@ID_Perfil", SqlDbType.Int);
            ID_Perfil.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Perfil);



            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            int ID =Convert.ToInt16( Comando.Parameters["@ID_Perfil"].Value);
          

            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 





            return ID;


        }


        #endregion


        #region Obtener ID_Opcion

        public int ObtenerID_Opcion(String opcion , int ID_Perfil)
        {
        
            StoredProcedure = "ObtenerIDopcion ";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Opcion", SqlDbType.VarChar , 50).Value = opcion;

            Comando.Parameters.Add("@ID_Perfil", SqlDbType.Int).Value = ID_Perfil;

            //Variable devuelta Estado 
            SqlParameter ID_Opcion = new SqlParameter("@ID_Opcion", SqlDbType.Int);
            ID_Opcion.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Opcion);



            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            int ID = Convert.ToInt32(Comando.Parameters["@ID_Opcion"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 

            return ID;
        }

        #endregion

        #region Obtener Funcion
        public Boolean ObtenerFuncion(int ID_Opcion, string Funcion)
        {
       

                StoredProcedure = "ObtenerFuncion";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ID_Opcion", SqlDbType.Int).Value = ID_Opcion;

            Comando.Parameters.Add("@Funcion", SqlDbType.VarChar, 50).Value = Funcion;

            //Variable devuelta Estado 
            SqlParameter Estado = new SqlParameter("@Estado", SqlDbType.Bit);
            Estado.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Estado);

            //Variable devuelta Estado 
            SqlParameter Result = new SqlParameter("@Result", SqlDbType.NVarChar,20);
            Result.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Result);

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            Boolean statu = Convert.ToBoolean(Comando.Parameters["@Result"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 





            return statu;

        }



        #endregion


        #region Actualizar Rol 
        public int ActualizarRol(string Rol , int ID_GrupoUsuario, int ID_Rol)
        {
            StoredProcedure = "ActualizarRol";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.Add("@NombreRol", SqlDbType.VarChar, 50).Value = Rol;
            Comando.Parameters.Add("@ID_GrupoUsuario", SqlDbType.Int).Value = ID_GrupoUsuario;
            Comando.Parameters.Add("@ID_Rol", SqlDbType.Int).Value = ID_Rol;




            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 





            return FilasAfectadas;



        }



        #endregion



        #region Actualizar usuario 
        public int ActualizarUsuario(E_Usuario e_usuario)
        {
            StoredProcedure = "ActualizarUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.Add("@ID_USuario", SqlDbType.Int).Value = e_usuario.id_Usuario;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar,50).Value = e_usuario.nombre;
            Comando.Parameters.Add("@Apellido", SqlDbType.NVarChar,50).Value = e_usuario.apellido;
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = e_usuario.usuario;
            Comando.Parameters.Add("@Pass", SqlDbType.NVarChar, 300).Value = e_usuario.contraseña;
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = e_usuario.estado;

            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;


        }


        #endregion



        #region Actualizar Perfil 
        public int ActualizarPerfil( int ID_Usuario, string Perfil)
        {
            StoredProcedure = "ActualizarPerfil";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;
            Comando.Parameters.Add("@NombrePerfil", SqlDbType.VarChar, 50).Value = Perfil;


            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;
        }


        #endregion


        #region  Actualizar Funcion 
        public int ActualizarFuncion(int ID_Opcion , String Funcion, bool Estado)
        {
            StoredProcedure = "ActualizarFuncion";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.Add("@ID_Opcion", SqlDbType.Int).Value = ID_Opcion;
            Comando.Parameters.Add("@Funcion", SqlDbType.VarChar, 50).Value = Funcion;
            Comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;



            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;


        }


        #endregion


        #region Eliminar Usuario 
        public int EliminarUsuario(int ID_Usuario)
        {

            StoredProcedure = "EliminarUsuario";

            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;




            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 


            return FilasAfectadas;




        }



        #endregion


    }
}
