using System;
using Capas.Infraestructura.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Capas.Data
{
    public class D_Usuario : Conexion
    {
        //<Summary>
        //Clase que se encargara  de gestionar el usuario enn la capa de datos 
        //</Summary>

        #region Instancias
        //Instancias de la entida usuario 
        E_Usuario e_usuario = new E_Usuario();
        //Conexion 
        private Conexion conexion;
        #endregion

        #region  Variables

        private String StoredProcedure;

        private int FilasAfectadas = 0;


        #endregion

        #region Contructor
        /// <summary>
        /// Constructor de la clase en la capa Data 
        /// </summary>
        public D_Usuario()
        {
            //Instancia de la conexion
            conexion = new Conexion();
        }

        #endregion

        #region Obtener Usuario 
        /// <summary>
        /// Metodo Obtener Usuario -- Recoge el ID y devuelve sus propiedades 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public E_Usuario ObtenerUsuario(int ID_Usuario)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerUsuario";

            //Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();
            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametro
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;


            //Variable devuelta nombre
            SqlParameter Nombre = new SqlParameter("@Nombre", SqlDbType.VarChar, 50);
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

        #region obtner usuarios +
        /// <summary>
        /// Metodo En el cual se obtienen los usuarios guardados en la base de datos -- Retornando un DataTable -- 
        /// </summary>
        /// <returns></returns>
        public DataTable ObteneruSuarios()
        {
            //Stored procedure 
            StoredProcedure = "ObtenerUsuarios";

            //Sql Command
            SqlCommand comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            //Tipo de commando
            comando.CommandType = CommandType.StoredProcedure;

            //Sql Adapter
            SqlDataAdapter DataAD = new SqlDataAdapter(comando);

            //DataTable 
            DataTable DataT = new DataTable();

            //Limpiando el mismo 
            DataT.Clear();

            //Llenandolo 
            DataAD.Fill(DataT);

            //Returnando el DATATABLE 
            return DataT;
        }


        #endregion

        #region Verificar Existencia de usuario +
        /// <summary>
        /// Metodo que verifica la existencia del usuario en la base de datos  Espera el   -- usuario --
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int VerificarExistenciaDeUsuario(String Usuario)
        {
            //Stored procedure
            StoredProcedure = "VerificarExistenciaUsuario";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros 
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = Usuario;


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

        #region Insertar Rol +
        /// <summary>
        /// Metodo que inserta un rol al usuario 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="ID_GrupoUsuario"></param>
        /// <returns></returns>
        public int InsertarRol(String Rol, int ID_GrupoUsuario)
        {
            //Stored procedure 
            StoredProcedure = "InsertarRol";

            //Sql Commando 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de commando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
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

        #region Insertar Usuario +
        /// <summary>
        /// Metondo donde se inserta un usuario en la base de datos 
        /// </summary>
        /// <param name="e_U"></param>
        /// <returns></returns>
        public int InsertarUsuario(E_Usuario e_U)
        {
            //Stored procedure 
            StoredProcedure = "IngresarUsuario";

          

            //SQL Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de commando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            //Nombre
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = e_U.nombre;
            //Apellido
            Comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 50).Value = e_U.apellido;
            //Usuario
            Comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = e_U.usuario;
            //Pass
            Comando.Parameters.Add("@Pass", SqlDbType.NVarChar, 300).Value = e_U.contraseña;
            //Estado
            Comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = e_U.estado;
            //ID Rol
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

        #region Insertar  Perfil +
        /// <summary>
        /// Insertar Perfil a un usuario
        /// </summary>
        /// <param name="Perfil"></param>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public int InsertarPerfil(string Perfil, int ID_Usuario)
        {
            //Stored procedure 
            StoredProcedure = "InsertarPerfil";

            //Sql Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Commando Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
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

        #region Insertar opcion +
        /// <summary>
        /// Metodo donde se inserta una Opcion que un usuario tendra activa 
        /// </summary>
        /// <param name="Opcion"></param>
        /// <param name="ID_Perfil"></param>
        /// <returns></returns>
        public int InsertarOpcion(String Opcion, int ID_Perfil)
        {
            //Stored procedure
            StoredProcedure = "InsertarOpcion";

            //Sql Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros 
            //Opcion 
            Comando.Parameters.Add("@Opcion", SqlDbType.VarChar, 50).Value = Opcion;
            //ID perfil
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

        #region Insertar Funcion +


        /// <summary>
        /// Metodo donde se le asignan las funciones dentro de una opcion a un usuario 
        /// </summary>
        /// <param name="Funcion"></param>
        /// <param name="Estado"></param>
        /// <param name="ID_Opcion"></param>
        /// <returns></returns>
        public int InsertarFuncion(String Funcion, bool Estado, int ID_Opcion)
        {

            //Stored procedure
            StoredProcedure = "InsertarFuncion";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Commando Type 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
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

        #region Obtener Informacion detallada de usuario +
        /// <summary>
        /// Metodo que obtiene informacion detallada de un usuario -- Atravez de su Id -- y devuelve una entidad
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public E_Usuario ObtenerInformacionDetallada(int ID_Usuario)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerInformacionCompletaUsuario";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de commando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
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

        #region Obtener Perfil + 
        /// <summary>
        /// Metodo donde se optiene el perfil de un usuario 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public int obtenerPerfil(int ID_Usuario)
        {
            //Stored procedure 
            StoredProcedure = "ObtenerPerfil";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;

            //Variable devuelta ID_Perfil 
            SqlParameter ID_Perfil = new SqlParameter("@ID_Perfil", SqlDbType.Int);
            ID_Perfil.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(ID_Perfil);



            //Se ejecuta el  Query y se asignan las filas afectas
            FilasAfectadas = Comando.ExecuteNonQuery();

            //Asigna el resultado devuelto por el stored procedure


            int ID = Convert.ToInt16(Comando.Parameters["@ID_Perfil"].Value);


            //Cerrando la conexion 
            conexion.Desconectar();

            //Devolviendo el resultado 
            return ID;
        }


        #endregion

        #region Obtener ID_Opcion +
        /// <summary>
        /// Metodo donde se optiene el ID que enlaza una opcion con el usuario 
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="ID_Perfil"></param>
        /// <returns></returns>
        public int ObtenerID_Opcion(String opcion, int ID_Perfil)
        {

            //Stored procedure
            StoredProcedure = "ObtenerIDopcion ";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
            Comando.Parameters.Add("@Opcion", SqlDbType.VarChar, 50).Value = opcion;
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

        #region Obtener Funcion +
        /// <summary>
        /// Metodo para optener el Id de una funcion que esta asignada a un usuario X
        /// </summary>
        /// <param name="ID_Opcion"></param>
        /// <param name="Funcion"></param>
        /// <returns></returns>
        public Boolean ObtenerFuncion(int ID_Opcion, string Funcion)
        {

            //Stored procedure
            StoredProcedure = "ObtenerFuncion";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Command Type
            Comando.CommandType = CommandType.StoredProcedure;
            //Parametros
            Comando.Parameters.Add("@ID_Opcion", SqlDbType.Int).Value = ID_Opcion;

            Comando.Parameters.Add("@Funcion", SqlDbType.VarChar, 50).Value = Funcion;

            //Variable devuelta Estado 
            SqlParameter Estado = new SqlParameter("@Estado", SqlDbType.Bit);
            Estado.Direction = ParameterDirection.Output;
            Comando.Parameters.Add(Estado);

            //Variable devuelta Estado 
            SqlParameter Result = new SqlParameter("@Result", SqlDbType.NVarChar, 20);
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

        #region Actualizar Rol +
        /// <summary>
        /// Metodo en el cual  se actualiza un rol del usuario en el sistema 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="ID_GrupoUsuario"></param>
        /// <param name="ID_Rol"></param>
        /// <returns></returns>
        public int ActualizarRol(string Rol, int ID_GrupoUsuario, int ID_Rol)
        {
            //Stored procedure 
            StoredProcedure = "ActualizarRol";

            //Sql Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //parametros 
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

        #region Actualizar usuario +
        /// <summary>
        /// Metodo en el cual  se actualizara las caracteristicas de un usuario -- se espera la entidad de un usuario--
        /// </summary>
        /// <param name="e_usuario"></param>
        /// <returns></returns>
        public int ActualizarUsuario(E_Usuario e_usuario)
        {
            //Stored procedure
            StoredProcedure = "ActualizarUsuario";

          

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros 
            Comando.Parameters.Add("@ID_USuario", SqlDbType.Int).Value = e_usuario.id_Usuario;
            Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = e_usuario.nombre;
            Comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 50).Value = e_usuario.apellido;
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

        #region Actualizar Perfil +
        /// <summary>
        /// Metodo donde se actualiza el perfil de un usuario en el sistema 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <param name="Perfil"></param>
        /// <returns></returns>
        public int ActualizarPerfil(int ID_Usuario, string Perfil)
        {
            //Stored procedure 
            StoredProcedure = "ActualizarPerfil";


            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
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

        #region  Actualizar Funcion +
        /// <summary>
        /// Metodo donde se actualiza el estado de una funcion para un usuario X
        /// </summary>
        /// <param name="ID_Opcion"></param>
        /// <param name="Funcion"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public int ActualizarFuncion(int ID_Opcion, String Funcion, bool Estado)
        {
            //Stored procedure
            StoredProcedure = "ActualizarFuncion";

            //Command
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de commando
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
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

        #region Eliminar Usuario +
        /// <summary>
        /// Eliminar usuario 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <returns></returns>
        public int EliminarUsuario(int ID_Usuario)
        {
            //Stored procedure eliminar usuario 
            StoredProcedure = "EliminarUsuario";

            //SQL Command 
            SqlCommand Comando = new SqlCommand(StoredProcedure, conexion.resaconexion);

            // Conectar a la base de datos

            conexion.Conectar();

            //Tipo de comando 
            Comando.CommandType = CommandType.StoredProcedure;

            //Parametros
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
