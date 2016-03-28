Create Database ResaDB;

Use ResaDB;

/* Creando Tabla Grupo de usuarios */

Create Table GruposUsuarios
(
  ID_GrupoUsuario Int not null Identity(1,1),
  NombreGrupo     NVarchar(50) not null,
  Descripcion     NVarchar(100),
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
  Nombre      NVarchar(50) not null,
  Apellido    NVarchar(50),
  Usuario     NVarchar(50) not null,
  Contraseña  NVarchar(300) not null,
  Estado      NVarchar(50) not null,
  ID_Rol      int not null,
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
  ID_Usuario   Int not null,
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
 ID_Perfil int not null,
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
  ID_Opcion  int  not null,
  Primary Key(ID_Funcion),
  Foreign Key(ID_Opcion) REFERENCES Opciones(ID_Opcion)
   On delete cascade
   On update cascade,
)
GO


/********** Probando Base de datos nivel de seguridad *****************************/

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
  @Nombre   as nvarchar(50),
  @Apellido as nvarchar(50),
  @Usuario  as nvarchar(50),
  @Pass     as nvarchar(300),
  @Estado   as nvarchar(50),
  @ID_Rol   as int,
  @ID_Usuario as int output
AS 
BEGIN
    DECLARE @hash varchar(4000);
    SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
End

BEGIN
   Insert Into Usuarios
    (
        Nombre,Apellido,Usuario,Contraseña,Estado,ID_Rol
    )
    Values
    (
        @Nombre,@Apellido,@Usuario,@hash,@Estado,@ID_Rol
        
      
    )
END
BEGIN
Set @ID_Usuario= @@IDENTITY; 

END
GO
/*********  Eliminando Stored Procedure *************/
Drop procedure IngresarUsuario
/* *--- Fin ---* */

/* Ejecutando el Store Proceedure */
   /* Prueba */
Execute IngresarUsuario 'Juan','Ramirez','JuanRM','1234','Activo',3
select *  from usuarios
use ResaDB
select * from usuarios
/* Loging Usuario  */ 

----------------------------------------------------------------------------`
Create Procedure LoginUsuario

    @Usuario AS nvarchar(50),
    @Pass AS nvarchar(50),
    @Result As int Output
    
As
     DECLARE @PassWord as Varchar(4000);
     DECLARE @hash varchar(4000);
     SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
     
     DECLARE @UserID as Int;--Declaracion de variable utilizada
     
Begin
    Select  @passWord = Contraseña, @UserID = ID_Usuario From usuarios Where Usuario = @Usuario
End
 
Begin
    If @hash = @PassWord
         
          Set @Result = @UserID
    
    Else
        Set @Result = 0
End
 
Go
-------------------------------------------------------------------------------------------

/*********  Eliminando Stored Procedure *************/
----------------------------------------------------
Drop procedure LoginUsuario
-----------------------------------------------------
/************ Ejecuntando Stored procedure de prueba ********************/

  /** Variable  que recibira la salida **/
 Declare @resultadoSalida  as int  
    /* Se ejecuta  el store procedure diciendole que la variable dentro del procedore sera instanciada desde fuera como resultado salida */
 Execute LoginUsuario 'JuanRM','1234',@result = @resultadoSalida OUTPUT

 Select @resultadoSalida as 'resultado'
 go

---------------------------------------------------------------------

/* Stored procedure    Obtener usuario */

Create procedure ObtenerUsuario 
    
    @ID_Usuario AS Int,         
    @Nombre     AS varchar(50)  output,
    @Apellido   AS varchar(50)  output,
    @Rol        AS Varchar(50)  output
       
 AS 
     
 Begin
  Select  @Nombre = Nombre , @Apellido = Apellido , @Rol = R.NombreRol from Usuarios as U
  inner join Roles as R on U.ID_Rol = R.ID_Rol
  where  ID_Usuario =  @ID_Usuario 
 
 End 
 
 Begin 
 
    return 
  
 End
 
 Go
 
 /*******************************************************************************************/
----------------------------------------------------
Drop procedure ObtenerUsuario   /*Para eliminar el storedprocedure*/
-----------------------------------------------------
/************ Ejecuntando Stored procedure de prueba ********************/

  /** Variable  que recibira la salida **/
 

 Declare @Name        AS varchar(50);
 Declare @LastName    AS varchar(50);
 Declare @Rol         As varchar(50);
 
    /* Se ejecuta  el store procedure  */
 Execute ObtenerUsuario 1,@Nombre = @Name OUTPUT , @Apellido = @LastName OUTPUT , @Rol = @Rol OUTPUT

 Select @Name       AS 'Nombre'
 Select @LastName   AS 'Apellido'
 Select @Rol        As 'Rol'
 go
/************************************************************************/ 