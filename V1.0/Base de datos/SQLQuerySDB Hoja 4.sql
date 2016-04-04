/* Transact SQL   */

Use ResaDB;

CREATE PROCEDURE AprobarSolicitud 
@ID_Solicitud as int,
@Usuario      as Nvarchar(60),
@FechaAprobacion as NVarchar(30)
   AS 
   BEGIN
   DECLARE  @FechaAprobacionC as smallDateTime;
   set @FechaAprobacionC = CONVERT(smalldatetime, @FechaAprobacion, 1);
   END
BEGIN
   Update Solicitudes 
    Set Aprobacion = 'Aprobada', Usuario = @Usuario,FechaAprobacion = @FechaAprobacionC where ID_Solicitud = @ID_Solicitud  
END
GO
/* Eliminar Procedure */
drop procedure AprobarSolicitud

/*DEsaprobar*/
CREATE PROCEDURE DesaprobarSolicitud
@ID_Solicitud as int,
@Usuario      as Nvarchar(60),
@FechaAprobacion as NVarchar(30)
   AS 
   BEGIN
   DECLARE  @FechaAprobacionC as smallDateTime;
   set @FechaAprobacionC = CONVERT(smalldatetime, @FechaAprobacion, 1);
   END
BEGIN
   Update Solicitudes 
    Set Aprobacion = 'No Aprobada', Usuario = @Usuario,FechaAprobacion = @FechaAprobacionC where ID_Solicitud = @ID_Solicitud  
END
GO
/* Drop Procedure  */

drop procedure DesaprobarSolicitud


/************************************************* Opciones de usuario sus funciones  ***************************************/
use ResaDB
CREATE PROCEDURE ObtenerUsuarios
AS
begin
Select U.ID_Usuario as 'ID', U.Nombre + ' '+ U.Apellido as 'Nombre y apellido',U.Usuario as 'Usuario', R.NombreRol  as 'Rol', U.Estado from Usuarios as U 
Inner Join Roles as R on R.ID_Rol = U.ID_Rol;
end
Go

/**/

/* Crear un nuevo rol al sistema */

CREATE PROCEDURE VerificarExistenciaUsuario
@Usuario as nVarchar(50),
@Result   as int output 
AS
BEGIN 
Set @Result = 0;
END
BEGIN
Select @Result = Count(Usuario) from Usuarios where Usuario = @Usuario
END
BEGIN
Return;
END
GO

/* Insertar Rol y devolver el ID */

CREATE procedure InsertarRol
 
@NombreRol  as  Varchar(50),
@ID_GrupoUsuario as int,
@ID_Rol     as int output
AS
BEGIN
   Insert Into Roles
    (
       NombreRol,ID_GrupoUsuario
    )
    Values
    (
        @NombreRol,@ID_GrupoUsuario 
        
      
    )
    set @ID_Rol = @@IDENTITY;
END
GO

select * from Roles

drop procedure InsertarRol


/* Inertar Perfil y devolver el ID */

Create Procedure InsertarPerfil
@NombrePerfil  as  Varchar(50),
@ID_Usuario as int,
@ID_Perfil     as int output
AS
BEGIN
   Insert Into Perfiles
    (
       NombrePerfil,ID_Usuario
    )
    Values
    (
        @NombrePerfil,@ID_Usuario 
        
      
    )
    set @ID_Perfil = @@IDENTITY;
END
GO

Drop procedure InsertarPerfil

/*insertar opcion*/

Create Procedure InsertarOpcion
@Opcion as varchar(50),
@ID_Perfil as int,
@ID_Opcion  as int output
AS
BEGIN
   Insert Into Opciones
    (
       Opcion,ID_Perfil
    )
    Values
    (
        @Opcion,@ID_Perfil 
        
      
    )
    set @ID_Opcion = @@IDENTITY;
END
GO

/*Insertar Funcion */ 
Create Procedure InsertarFuncion
@Funcion as varchar(50),
@Estado  as Bit,
@ID_Opcion  as int
AS
BEGIN
   Insert Into Funciones
    (
       Funcion,Estado,ID_Opcion
    )
    Values
    (
        @Funcion,@Estado,@ID_Opcion 
        
      
    )
   
END
GO

/* - - - - - -*/
use ResaDB
Select * from Funciones

Create Procedure ObtenerInformacionCompletaUsuario
@ID_Usuario as int ,
@Rol      as varchar(50)  output,
@Nombre   as nVarchar(50) output,
@Apellido as nVarchar(50) output,
@Usuario  as nvarchar(50) output,
@ID_ROl   as int          output,
@Estado   as nvarchar(50) output
AS
BEGIN
Select @Rol = R.NombreRol, @Nombre = U.Nombre , @Apellido = U.Apellido , @Usuario = U.Usuario , @Estado = U.Estado , @ID_ROl = U.ID_Rol from Usuarios as U
inner join  Roles as R on R.ID_Rol = U.ID_Rol  where ID_Usuario = @ID_Usuario
END
GO

/* */

--Drop procedure ObtenerInformacionCompletaUsuario

CREATE Procedure ObtenerPerfil
@ID_Usuario  as int,
@ID_Perfil   as int output
As 
BEGIN
Select @ID_Perfil =  ID_Perfil  from Perfiles where ID_Usuario = @ID_Usuario
END
GO

Declare @ID_Usuario as int;
Declare @ID_Perfil as int;
execute ObtenerPerfil  8 , @ID_Perfil = @ID_Perfil output

Select @ID_Perfil as 'ID';

select * from Perfiles

Drop Procedure ObtenerPerfil
/* - - - - - - - - - - - - - - - - - - - - - - -*/

CREATE procedure ObtenerIDopcion 
@Opcion as Varchar(50),
@ID_Perfil as int,
@ID_Opcion as int output
As 
BEGIN
Select @ID_Opcion = ID_Opcion from Opciones where Opcion = @Opcion and ID_Perfil = @ID_Perfil
END
GO
/* - - - - - - - - - - */

DECLARE @ID_Opcion as int;

Execute ObtenerIDOpcion 'Salones',2,@ID_Opcion = @ID_Opcion output

select @ID_Opcion


--drop procedure ObtenerIDopcion
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
CREATE Procedure ObtenerFuncion
@ID_Opcion  as int,
@Funcion    as Varchar(50),
@Estado     as bit output,
@Result     as nVarchar(20) output
AS
BEGIN
Select @Estado = Estado from Funciones where ID_Opcion = @ID_Opcion and Funcion = @Funcion 
END 
BEGIN
  if(@Estado = 1)
  Set @Result = 'True';
  Else
  Set @Result = 'False';
   
END
Go

/*-- - - - - - - */

--Drop procedure ObtenerFuncion
Use ResaDB

Select * from Funciones

/* Actualizar Rol */

CREATE Procedure ActualizarRol
@NombreRol  as  Varchar(50),
@ID_GrupoUsuario as int,
@ID_Rol     as int
AS
BEGIN 
Update Roles
set NombreRol = @NombreRol ,ID_GrupoUsuario = @ID_GrupoUsuario where ID_Rol = @ID_Rol
END
GO

/*Actualizar Ussuario */

CREATE Procedure ActualizarUsuario
  @ID_Usuario as int,
  @Nombre   as nvarchar(50),
  @Apellido as nvarchar(50),
  @Usuario  as nvarchar(50),
  @Pass     as nvarchar(300),
  @Estado   as nvarchar(50)
AS 

if(@Pass !='')

BEGIN
    DECLARE @hash varchar(4000);
    SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada


Update Usuarios
set Nombre = @Nombre , Apellido = @Apellido , Usuario = @Usuario , Contraseña = @hash , Estado = @Estado where ID_Usuario = @ID_Usuario
END

Else
BEGIN
 Update Usuarios
set Nombre = @Nombre , Apellido = @Apellido , Usuario = @Usuario , Estado = @Estado where ID_Usuario = @ID_Usuario
END
GO

/* Actualizar Perfil */ 

Create Procedure ActualizarPerfil 
@ID_Usuario as int,
@NombrePerfil as varchar(50)
as
BEGIN 
Update Perfiles
set NombrePerfil = @NombrePerfil where ID_Usuario = @ID_Usuario
END
GO
/**/

/* Actualizar Funcion  */

Create Procedure ActualizarFuncion
@ID_Opcion  as int,
@Funcion    as Varchar(50),
@Estado     as bit
as
BEGIN
update Funciones
set Estado = @Estado where ID_Opcion = @ID_Opcion and Funcion  = @Funcion
END
GO

--drop Procedure ActualizarFuncion

 --Eliminar un usuario 
 Create Procedure EliminarUsuario 
 @ID_Usuario as int
 AS
 BEGIN
 Declare @ID_Rol  as int;
 Select  @ID_Rol = R.ID_ROl From Usuarios 
 inner join Roles as R on Usuarios.ID_Rol = R.ID_Rol  Where Usuarios.ID_Usuario = @ID_Usuario
 END
 BEGIN
 Delete from Roles where ID_Rol = @ID_Rol
 END
 GO
/* - - - -Probando - - - - - - */

--Drop procedure EliminarUsuario

Execute EliminarUsuario 20

Select * from usuarios 
Select * from Perfiles
Select * from Opciones
Select * from Roles
Select * from GruposUsuarios


/* Insertar Auditoria */ 
use ResaDB
CREATE PROCEDURE InsertarAuditoria  
  @ID_Usuario    as  Int,
  @TipoUsuario   as  Nvarchar(100),
  @Fecha_Entrada as  Nvarchar(30),
  @Fecha_Salida  as  NVarchar(30),
  @Opcion        as  Nvarchar(100),
  @Tipo_Opcion   as  Nvarchar(100)
 AS
 BEGIN
   DECLARE  @Fecha_EntradaC as smallDateTime;
   set @Fecha_EntradaC = CONVERT(smalldatetime, @Fecha_Entrada, 1);
   DECLARE  @Fecha_SalidaC as smallDateTime;
   set @Fecha_SalidaC = CONVERT(smalldatetime, @Fecha_Salida, 1);
 END
BEGIN
   Insert Into Auditorias
    (
       ID_Usuario,TipoUsuario,Fecha_Entrada,Fecha_Salida,Opcion,Tipo_Opcion
    )
    Values
    (
        @ID_Usuario,@TipoUsuario,@Fecha_EntradaC,@Fecha_SalidaC,@Opcion,@Tipo_Opcion
    ) 
END 
GO

/*-----*/
--drop procedure InsertarAuditoria

use ResaDB

select * from usuarios 

Select * from Auditorias


//Pruebas 

use ResaDB

select * from  salones
select * from solicitudes

Select * from eventos
Select * from organizadores