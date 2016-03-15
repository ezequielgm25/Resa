
Create Database ResaDB;

Use ResaDB;

/* Creando Tabla Grupo de usuarios */

Create Table GruposUsuarios
(
  ID_GrupoUsuario Int not null Identity(1,1),
  NombreGrupo     Varchar(50) not null,
  Primary Key(ID_GrupoUsuario) 

)

Go

/* Creando Tabla Roles */

Create Table Roles 
(
  ID_Rol          Int not null Identity(1,1),
  NombreRol       Varchar(50) not null,
  ID_GrupoUsuario Int not null,
  Primary key(ID_Rol),
  Foreign key(ID_GrupoUsuario) REFERENCES GruposUsuarios(ID_GrupoUsuario)
  On delete cascade
  on update cascade,
  )
  Go
/* Creando Tabla Usuarios */

Create Table Usuarios 
(
  ID_Usuario Int not null Identity(1,1),
  Nombre      Varchar(50) not null,
  Apellido    Varchar(50),
  Usuario     Varchar(50) not null,
  Contraseña  Varchar(300) not null,
  ID_Rol      int,
  Primary Key(ID_Usuario),
  Foreign Key(ID_Rol) REFERENCES Roles(ID_Rol)
  On delete cascade
  on update cascade,
)
Go
/* Creando Tabla Perfiles */

Create  table Perfiles
(
  ID_Perfil    Int not null Identity(1,1),
  NombrePerfil Varchar(50) not null,
  ID_Usuario   Int,
  Primary key(ID_perfil),
  Foreign Key(ID_Usuario) REFERENCES Usuarios(ID_Usuario)
  On delete cascade
  on update cascade,
  
)
Go

/* Creando Tabla Opciones */

Create Table Opciones 
(
 ID_Opcion int not null Identity(1,1),
 Opcion    Varchar(50) not null, 
 Estado    Bit not null,
 ID_Perfil int
 Primary Key(ID_Opcion),
 Foreign Key(ID_Perfil) REFERENCES Perfiles(ID_Perfil) 
 On delete cascade
 on update cascade,
 
 )
  GO
  
  /* Creando Tabla Funciones */

Create Table Funciones 
(
  ID_Funcion Int not null Identity(1,1),
  Funcion    Varchar(50) not null,
  Estado     Bit not null, 
  ID_Opcion  int ,
  Primary Key(ID_Funcion),
  Foreign Key(ID_Opcion) REFERENCES Opciones(ID_Opcion)
   On delete cascade
   On update cascade,
)
GO


/********** Probando Base de datos nivel de seguridad *****************************/

use ResaDB
Select Nombre,Apellido ,NombreRol , NombrePerfil , Opcion , NombreGrupo from GruposUsuarios As ad 
inner join Roles On ad.ID_GrupoUsuario = Roles.ID_GrupoUsuario 
inner join usuarios on usuarios.ID_Rol = Roles.ID_Rol
inner join Perfiles on Perfiles.ID_Usuario = usuarios.ID_Usuario
right join Opciones on  Opciones.ID_Perfil = Perfiles.ID_Perfil 

/*********************** Query Prueba de  la base de datos ************************************/

Select Nombre,Apellido,NombrePerfil from Usuarios As ad 
inner join Perfiles On Perfiles.ID_Usuario = ad.ID_Usuario 


/************** Encriptaccion  En la base de datos ****************************************/

/* Store procedure de encriptacion con hash sha1 */

CREATE PROCEDURE IngresarUsuario
  @Nombre  as nvarchar(50),
  @Apellido as nvarchar(50),
  @Usuario as nvarchar(50),
  @Pass as nvarchar(300),
  @ID_Rol as int
AS 
BEGIN
    DECLARE @hash varchar(4000);
    SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
End

BEGIN
   Insert Into Usuarios
    (
        Nombre,Apellido,Usuario,Contraseña,ID_Rol
    )
    Values
    (
        @Nombre,@Apellido,@Usuario,@hash,@ID_Rol
        
      
    )
END
GO
/*********  Eliminando Stored Procedure *************/
Drop procedure IngresarUsuario
/* *--- Fin ---* */

/* Ejecutando el Store Proceedure */
   /* Prueba */
Execute IngresarUsuario 'Jose','Merchol','JM','1234',2

select * from usuarios
/* Loging Usuario  */ 

Create Procedure LoginUsuario
    @Usuario AS nvarchar(50),
    @Pass AS nvarchar(50),
    @Result AS bit Output
As
     DECLARE @PassWord as Varchar(4000);
     DECLARE @hash varchar(4000);
     SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
Begin
    Select @passWord = Contraseña From usuarios Where Usuario = @Usuario
End
 
Begin
    If @hash = @PassWord
        Set @Result = 1
    Else
        Set @Result = 0
End
 
Go

/*********  Eliminando Stored Procedure *************/
Drop procedure LoginUsuario

/************ Ejecuntando Stored procedure de prueba ********************/

  /** Variable  que recibira la salida **/
 Declare @resultadoSalida  as Bit 
    /* Se ejecuta  el store procedure diciendole que la variable dentro del procedore sera instanciada desde fuera como resultado salida */
 Execute LoginUsuario 'Ezequiel','1234',@result = @resultadoSalida OUTPUT

 Select @resultadoSalida as 'resultado'
 go

/*  Actualizando el tipo de dato de la colimna contrase */
 Alter table usuarios
 alter column  Contraseña nvarchar(300) not null


/* Stored procedure    Obtener usuario */

Create procedure ObtenerUsuario 
    @Usuario    AS varchar(50),
    @Pass       AS varchar(50),
    @ID_Usuario AS Int          output,
    @Nombre     AS varchar(50)  output,
    @Apellido   AS varchar(50)  output,
    @ID_ROl     AS int          output
    
 AS 
     Declare @ID_UsuarioS AS Int;
     Declare @NombreS As Varchar(50);
     Declare @ApellidoS AS Varchar(50);
     Declare @Id_RolS AS int;
     
     DECLARE @hash varchar(4000);
     SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
 
 Begin
  
 Select  @ID_UsuarioS = ID_Usuario , @NombreS = Nombre , @ApellidoS = Apellido , @ID_ROlS = ID_Rol from Usuarios 
 where usuario = @Usuario  and  Contraseña = @hash
 
 End 
 
 Begin 
 
  Set @ID_Usuario = @ID_UsuarioS;
  Set @Nombre = @NombreS;
  Set @Apellido = @ApellidoS;
  Set @ID_ROl = @Id_RolS;
  
 End
 
 Go
--------------------- 
Drop procedure ObtenerUsuario
/************ Ejecuntando Stored procedure de prueba ********************/

  /** Variable  que recibira la salida **/
 Declare @ID_User AS int;
 Declare @Name      AS varchar(50);
 Declare @LastName    AS varchar(50);
 Declare @ID_R    AS Int;
 
    /* Se ejecuta  el store procedure  */
 Execute ObtenerUsuario 'jm','1234',@ID_Usuario = @ID_User OUTPUT , @Nombre = @Name OUTPUT , @Apellido = @LastName OUTPUT , @ID_Rol = @ID_R OUTPUT  

 Select @ID_User AS 'ID'
 Select @Name     AS 'Nombre'
 Select @LastName   AS 'Apellido'
 Select @ID_R   AS 'ID_Rol'
 go

select * From usuarios 