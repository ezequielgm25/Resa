USE [master]
GO
/****** Object:  Database [ResaDB]    Script Date: 04/24/2016 22:58:48 ******/
CREATE DATABASE [ResaDB] ON  PRIMARY 
( NAME = N'ResaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ResaDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ResaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ResaDB_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ResaDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResaDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ResaDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ResaDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ResaDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ResaDB] SET ARITHABORT OFF
GO
ALTER DATABASE [ResaDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [ResaDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ResaDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ResaDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ResaDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ResaDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ResaDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ResaDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ResaDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ResaDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ResaDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [ResaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ResaDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ResaDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ResaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ResaDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ResaDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ResaDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ResaDB] SET  READ_WRITE
GO
ALTER DATABASE [ResaDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ResaDB] SET  MULTI_USER
GO
ALTER DATABASE [ResaDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ResaDB] SET DB_CHAINING OFF
GO
USE [ResaDB]
GO
/****** Object:  Table [dbo].[organizadoresGlobales]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizadoresGlobales](
	[ID_Organizador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](150) NOT NULL,
	[CorreoElectronico] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Organizador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiciosGlobales]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiciosGlobales](
	[ID_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Servicio] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Servicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salones]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salones](
	[ID_Salon] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Ubicacion] [nvarchar](100) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Estado] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Salon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventariosGlobales]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventariosGlobales](
	[ID_Inventario] [int] IDENTITY(1,1) NOT NULL,
	[Inventario] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Inventario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GruposUsuarios]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GruposUsuarios](
	[ID_GrupoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreGrupo] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_GrupoUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UbicacionesGlobales]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UbicacionesGlobales](
	[ID_Ubicacion] [int] IDENTITY(1,1) NOT NULL,
	[Ubicacion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Ubicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitudes]    Script Date: 04/24/2016 22:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitudes](
	[ID_Solicitud] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Aprobacion] [nvarchar](30) NOT NULL,
	[Usuario] [nvarchar](60) NULL,
	[FechaAprobacion] [smalldatetime] NULL,
	[ID_Salon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Solicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertarInventarioGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertarInventarioGlobal]
 @Inventario as Nvarchar(100)
 As 
BEGIN
   Insert Into InventariosGlobales
    (
        Inventario
    )
    Values
    (
        @Inventario
    )
    
 END
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[ID_Inventario] [int] IDENTITY(1,1) NOT NULL,
	[Inventario] [nvarchar](100) NOT NULL,
	[ID_Salon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Inventario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertarServicioGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertarServicioGlobal]
 @Servicio as Nvarchar(100)
 As 
BEGIN
   Insert Into ServiciosGlobales
    (
        Servicio
    )
    Values
    (
        @Servicio
    )
    
 END
GO
/****** Object:  StoredProcedure [dbo].[InsertarOrganizadorGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarOrganizadorGlobal]
  @Nombre        as      Nvarchar(100),
  @Descripcion   as      Nvarchar(150),
  @CorreoElectronico as  Nvarchar(100)
  
  AS
  BEGIN
   INSERT  INTO  organizadoresGlobales
   (
     Nombre,Descripcion,CorreoElectronico
   )
   VALUES
   (
     @Nombre , @Descripcion , @CorreoElectronico
   )
  END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerInventariosGlobales]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerInventariosGlobales]
AS
begin
Select ID_Inventario as 'ID',  Inventario from InventariosGlobales
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerOrganizadoresGlobales]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ObtenerOrganizadoresGlobales]
 AS 
 BEGIN
 Select ID_Organizador AS 'ID' ,Nombre , Descripcion ,CorreoElectronico as 'Correo' From organizadoresGlobales order by ID_Organizador Desc 
 END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerSalonesID_N]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerSalonesID_N]
AS
begin
Select ID_Salon As 'ID', Nombre FROM Salones where Estado = 'Activo'
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerSalones]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerSalones]
AS
begin
Select ID_Salon As 'ID', Nombre, Ubicacion, Capacidad, Estado FROM Salones
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarSalon]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarSalon]
@ID_Salon as Int 
 AS 
BEGIN
   delete from Salones Where Salones.ID_Salon = @ID_Salon
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarOrganizadorGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarOrganizadorGlobal]
  @ID_Organizador as int
  AS
  BEGIN
  DELETE FROM organizadoresGlobales
  Where ID_Organizador = @ID_Organizador
  END
GO
/****** Object:  StoredProcedure [dbo].[EliminarServicioGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EliminarServicioGlobal]
@ID_Servicio AS INT
AS
BEGIN
DELETE FROM ServiciosGlobales
WHERE ID_Servicio = @ID_Servicio
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUbicacionGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUbicacionGlobal]
@ID_Ubicacion as Int 
 AS 
BEGIN
   delete from UbicacionesGlobales Where ID_Ubicacion = @ID_Ubicacion
END
GO
/****** Object:  StoredProcedure [dbo].[CrearSalon]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearSalon]
  
  @Nombre    as nvarchar(100),
  @Ubicacion as nvarchar(100),
  @Capacidad as Int,
  @Estado    as nvarchar(100),
  @ID_Salon  as int output 
AS 
BEGIN
   Insert Into Salones
    (
        Nombre,Ubicacion,Capacidad,Estado
    )
    Values
    (
        @Nombre,@Ubicacion,@Capacidad,@Estado
    )
   
END 
Begin 
  set @ID_Salon = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarInventarioGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EliminarInventarioGlobal]
@ID_Inventario AS INT
AS
BEGIN
DELETE FROM InventariosGlobales
WHERE ID_Inventario = @ID_Inventario
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarUbicacionGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AgregarUbicacionGlobal]
 @Ubicacion as Nvarchar(100)
 As 
BEGIN
   Insert Into UbicacionesGlobales
    (
        Ubicacion
    )
    Values
    (
      @Ubicacion
    )
    
 END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarORganizadorGlobal]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ActualizarORganizadorGlobal]
  @ID_Organizador  as int, 
  @Nombre          as Nvarchar(100),
  @Descripcion     as Nvarchar(150),
  @CorreoElectronico as  Nvarchar(100)
AS 
  BEGIN
    Update organizadoresGlobales
    Set Nombre = @Nombre, Descripcion = @Descripcion , CorreoElectronico = @CorreoElectronico
    where ID_Organizador = @ID_Organizador  
  END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarSalon]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarSalon]  
  @ID_Salon   as Int,
  @Nombre     as nvarchar(100),
  @Ubicacion  as nvarchar(100),
  @Capacidad  as Int,
  @Estado     as nvarchar(100)
   AS 
BEGIN
   Update Salones  
    Set Nombre = @Nombre, Ubicacion = @Ubicacion, Capacidad = @Capacidad, Estado = @Estado
    where ID_Salon = @ID_Salon
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
	[ID_GrupoUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[ID_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Servicio] [nvarchar](100) NOT NULL,
	[ID_Salon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Servicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUbicacionesGlobales]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerUbicacionesGlobales] 
AS
begin
Select ID_Ubicacion As 'ID', Ubicacion FROM UbicacionesGlobales Order By Ubicacion DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerServiciosGlobales]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerServiciosGlobales]
AS
begin
Select ID_Servicio as 'ID',  Servicio from ServiciosGlobales
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerServicios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerServicios]
@ID_Salon as int
AS
begin
Select ID_Servicio AS 'ID', Servicio from Servicios where ID_Salon = @ID_Salon
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerSolicitud]
   @ID_Solicitud as int,
   @Fecha as SmallDateTime output,
   @Aprobacion as Nvarchar(30) output,
   @Usuario as nVarchar(60) output,
   @FechaAprobacion as SmallDateTime output,
   @ID_Salon as int output
   AS 
   BEGIN
    Select @Fecha = Fecha  , @Aprobacion = Aprobacion  ,  @Usuario = Usuario,   @FechaAprobacion = FechaAprobacion ,  @ID_Salon = ID_Salon  From Solicitudes Where ID_Solicitud = @ID_Solicitud
   END
GO
/****** Object:  StoredProcedure [dbo].[PorcentajeSolicitudesNoAprobadas]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PorcentajeSolicitudesNoAprobadas]
AS
BEGIN
Select Count(SO.ID_Solicitud) as 'Solitudes no aprobadas' from Salones as SA
inner join Solicitudes  AS SO on SO.ID_Salon = SA.ID_Salon  where SO.Aprobacion = 'No Aprobada'
END
GO
/****** Object:  StoredProcedure [dbo].[PorcentajeSolicitudesEfectuadas]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PorcentajeSolicitudesEfectuadas]
AS
BEGIN
Select Count(SO.ID_Solicitud) as 'Solitudes efectuadas' from Salones as SA
inner join Solicitudes  AS SO on SO.ID_Salon = SA.ID_Salon  where SO.Aprobacion = 'Efectuado'
END
GO
/****** Object:  StoredProcedure [dbo].[PorcentajeSolicitudesAprobada]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PorcentajeSolicitudesAprobada]
AS
BEGIN
Select Count(SO.ID_Solicitud) as 'Solitudes aprobadas' from Salones as SA
inner join Solicitudes  AS SO on SO.ID_Salon = SA.ID_Salon  where SO.Aprobacion = 'Aprobada'
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarRol]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarRol]
@NombreRol  as  Varchar(50),
@ID_GrupoUsuario as int,
@ID_Rol     as int
AS
BEGIN 
Update Roles
set NombreRol = @NombreRol ,ID_GrupoUsuario = @ID_GrupoUsuario where ID_Rol = @ID_Rol
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarServicio]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarServicio] 
 
 @Servicio as Nvarchar(100),
 @ID_Salon as int
 As 
BEGIN
   Insert Into Servicios
    (
        Servicio,ID_Salon
    )
    Values
    (
        @Servicio, @ID_Salon
    )
    
 END
GO
/****** Object:  StoredProcedure [dbo].[AgregarInventario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarInventario]
@Inventario Nvarchar(100),
@ID_Salon   int
  As 
BEGIN
   Insert Into Inventarios
    (
        Inventario, ID_Salon
    )
    Values
    (
        @Inventario, @ID_Salon
    )
    
 END
GO
/****** Object:  StoredProcedure [dbo].[EliminarInventario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarInventario]
@ID_Inventario AS INT
AS
BEGIN
DELETE FROM Inventarios
WHERE ID_Inventario = @ID_Inventario
END
GO
/****** Object:  StoredProcedure [dbo].[DesaprobarSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DesaprobarSolicitud]
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
/****** Object:  StoredProcedure [dbo].[CrearSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearSolicitud]
   @Fecha as NVarchar(30),
   @Aprobacion as Nvarchar(30),
   @Usuario as nvarchar(60),
   @FechaAprobacion as NVarchar(30),
   @ID_Salon as int,
   @ID_Solicitud as int output
 AS
 BEGIN
   DECLARE  @FechaDCreacionC as smallDateTime;
   set @FechaDCreacionC = CONVERT(smalldatetime, @Fecha, 1);
   DECLARE  @FechaAprobacionC as smallDateTime;
   set @FechaAprobacionC = CONVERT(smalldatetime, @FechaAprobacion, 1);
 END
BEGIN
   Insert Into Solicitudes 
    (
       Fecha,Aprobacion,Usuario,FechaAprobacion,ID_Salon
    )
    Values
    (
        @FechaDCreacionC,@Aprobacion,@Usuario,@FechaAprobacionC,@ID_Salon
    ) 
END 
BEGIN
  set @ID_Solicitud = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarSolicitud]
@ID_Solicitud as int
AS
BEGIN
   delete from Solicitudes Where Solicitudes.ID_Solicitud = @ID_Solicitud
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarServicioXS_ID]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EliminarServicioXS_ID]
@Servicio as Nvarchar(100),
@ID_Salon as int
AS 
BEGIN
DELETE FROM Servicios
WHERE ID_Salon = @ID_Salon and Servicio = @Servicio
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarServicio]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarServicio]
@ID_Servicio AS INT
AS
BEGIN
DELETE FROM Servicios
WHERE ID_Servicio = @ID_Servicio
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarInventarioXS_ID]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EliminarInventarioXS_ID]
@Inventario as Nvarchar(100),
@ID_Salon as int
AS 
BEGIN
DELETE FROM Inventarios
WHERE ID_Salon = @ID_Salon and Inventario = @Inventario
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarSolicitud]
   @ID_Solicitud as int,
   @Fecha as NVarchar(30),
   @Aprobacion as Nvarchar(30),
   @Usuario as nVarchar(60),
   @FechaAprobacion as NVarchar(30),
   @ID_Salon as int
   AS 
   BEGIN
   DECLARE  @FechaDCreacionC as smallDateTime;
   set @FechaDCreacionC = CONVERT(smalldatetime, @Fecha, 1);
   DECLARE  @FechaAprobacionC as smallDateTime;
   set @FechaAprobacionC = CONVERT(smalldatetime, @FechaAprobacion, 1);
 END
BEGIN
   Update Solicitudes 
    Set Fecha = @FechaDCreacionC, Aprobacion = @Aprobacion, Usuario = @Usuario ,  FechaAprobacion = @FechaAprobacionC, ID_Salon = @ID_Salon
    where ID_Solicitud = @ID_Solicitud  
END
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[ID_Evento] [int] IDENTITY(1,1) NOT NULL,
	[Titulo_Evento] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[Tipo] [nvarchar](100) NOT NULL,
	[Topico] [nvarchar](150) NOT NULL,
	[Tiempo_Inicio] [smalldatetime] NOT NULL,
	[Tiempo_Final] [smalldatetime] NOT NULL,
	[ID_Solicitud] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Evento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPorcentajeSolicitudesSalones]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ObtenerPorcentajeSolicitudesSalones]
AS
BEGIN
Select Count(SO.ID_Solicitud) as 'Solicitudes', SA.Nombre  as 'Salon' from Salones as SA
inner join Solicitudes  AS SO on SO.ID_Salon = SA.ID_Salon Group by SA.Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerInventarios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerInventarios]
@ID_Salon as int 
AS
begin
Select ID_Inventario as 'ID',Inventario from Inventarios where ID_Salon = @ID_Salon
end
GO
/****** Object:  StoredProcedure [dbo].[InsertarRol]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarRol]
 
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
/****** Object:  StoredProcedure [dbo].[AprobarSolicitud]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AprobarSolicitud] 
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
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaServicio]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarExistenciaServicio]
@Servicio Nvarchar(100),
@ID_Salon   int,
@Result As int Output
  As 
BEGIN
  Declare @ServicioCount as int;

END
BEGIN
 select @ServicioCount = count(Servicio) from Servicios where servicio = @servicio   and ID_Salon = @ID_Salon;
END
BEGIN
if(@ServicioCount = 1)
 
 Set @Result = 1;
 else 
 Set @Result = 0;

END
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaInventario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarExistenciaInventario]
@Inventario Nvarchar(100),
@ID_Salon   int,
@Result As int Output
  As 
BEGIN
  Declare @InventarioCount as int;

END
BEGIN
 select @InventarioCount = count(Inventario) from Inventarios where Inventario = @Inventario  and ID_Salon = @ID_Salon;
END
BEGIN
if(@InventarioCount = 1)
 
 Set @Result = 1;
 else 
 Set @Result = 0;

END
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](300) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[ID_Rol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[VerificarFechas]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarFechas] 
   @Tiempo_Inicio  as  Nvarchar(30),
   @Tiempo_Final   as  Nvarchar(30),
   @ID_Salon       as  int,
   @MSG as int  Output

  AS
  BEGIN
    DECLARE  @FechaInicioEvento as smallDateTime;
    set @FechaInicioEvento = CONVERT(smalldatetime, @Tiempo_Inicio, 1);
    DECLARE  @FechaFinalEvento as smallDateTime;
    set @FechaFinalEvento = CONVERT(smalldatetime, @Tiempo_Final, 1);
   
    DECLARE @C AS int;
    SET @C = 0;
   
  END
  
  BEGIN
    Select @C = count(Tiempo_Inicio) from Eventos 
    Inner join Solicitudes on Solicitudes.ID_Solicitud = Eventos.ID_Solicitud   
    Inner Join Salones  on Salones.ID_Salon = Solicitudes.ID_Salon where Salones.ID_Salon = @ID_Salon and @FechaInicioEvento <= Tiempo_Final and @FechaFinalEvento >= Tiempo_Inicio
  End 

  BEGIN
   if(@C > 0)
   set @MSG = 1;
   END
  BEGIN
   if(@C = 0 )
   set @MSG = 0;
  END
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarExistenciaUsuario]
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
/****** Object:  StoredProcedure [dbo].[IngresarUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarUsuario]
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
/****** Object:  StoredProcedure [dbo].[ObtenerInformacionCompletaUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ObtenerInformacionCompletaUsuario]
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
/****** Object:  StoredProcedure [dbo].[ObtenerEvento]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerEvento]
  @ID_Solicitud   as int,
  @ID_Evento      as  int output,
  @Titulo_Evento  as  Nvarchar(100) output,
  @Descripcion    as  Nvarchar(300) output,
  @Tipo           as  Nvarchar(100) output,
  @Topico         as  Nvarchar(150) output,
  @Tiempo_Inicio  as  smallDateTime output,
  @Tiempo_Final   as  smallDateTime output
  AS
  BEGIN
  Select @ID_Evento = ID_Evento ,  @Titulo_Evento = Titulo_Evento  , @Descripcion = Descripcion  , @Tipo = Tipo , @Topico = Topico , @Tiempo_Inicio = Tiempo_Inicio   , @Tiempo_Final = Tiempo_Final     from Eventos where ID_Solicitud = @ID_Solicitud
  END
GO
/****** Object:  StoredProcedure [dbo].[LoginUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[LoginUsuario]

    @Usuario AS nvarchar(50),
    @Pass AS nvarchar(50),
    @Result As int Output
 
As
BEGIN 
     
     DECLARE @PassWord as Varchar(4000);
     DECLARE @hash varchar(4000);
     SET @hash = HASHBYTES('SHA1', @Pass);  --Pass editada
     
     DECLARE @UserID as Int;--Declaracion de variable utilizada
     DECLARE @Estado as Nvarchar(15);
   
   

    BEGIN
     Select  @Estado = Estado from Usuarios Where Usuario = @Usuario
    END
 BEGIN
    
    
     IF(@Estado != '')
       BEGIN
    
       IF(@Estado = 'Activo')
         BEGIN
           Select  @passWord = Contraseña, @UserID = ID_Usuario From usuarios Where Usuario = @Usuario
       
       If (@hash = @PassWord)
         BEGIN
           Set @Result = @UserID;
         END
       If (@hash != @PassWord)
         BEGIN
           Set @Result = 0;
         END
         
         END  
            
       If(@Estado = 'Inactivo')
        BEGIN
          Set @Result = -1;
        END
        
     END
     Else
      BEGIN
       set @Result = -2;
       return;
      END
      
     END
   END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EliminarUsuario] 
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
/****** Object:  StoredProcedure [dbo].[ActualizarEvento]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarEvento]
  @ID_Evento      as  int,
  @Titulo_Evento  as  Nvarchar(100),
  @Descripcion    as  Nvarchar(300),
  @Tipo           as  Nvarchar(100),
  @Topico         as  Nvarchar(150),
  @Tiempo_Inicio  as  Nvarchar(30),
  @Tiempo_Final   as  Nvarchar(30)
  AS  
    BEGIN
   DECLARE  @FechaInicioEvento as smallDateTime;
   set @FechaInicioEvento = CONVERT(smalldatetime, @Tiempo_Inicio, 1);
   DECLARE  @FechaFinalEvento as smallDateTime;
   set @FechaFinalEvento = CONVERT(smalldatetime, @Tiempo_Final, 1);
  END
  BEGIN
    Update Eventos 
    Set Titulo_Evento = @Titulo_Evento, Descripcion = @Descripcion , Tipo = @Tipo, Topico = @Topico , Tiempo_Inicio = @FechaInicioEvento ,Tiempo_Final = @FechaFinalEvento
    where ID_Evento = @ID_Evento 
  END
GO
/****** Object:  StoredProcedure [dbo].[CrearEvento]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearEvento] 

  @Titulo_Evento  as  Nvarchar(100),
  @Descripcion    as  Nvarchar(300),
  @Tipo           as  Nvarchar(100),
  @Topico         as  Nvarchar(150),
  @Tiempo_Inicio  as  Nvarchar(30),
  @Tiempo_Final   as  Nvarchar(30),
  @ID_Solicitud Int,
  @ID_Evento Int Output
  
  AS
  BEGIN
   DECLARE  @FechaInicioEvento as smallDateTime;
   set @FechaInicioEvento = CONVERT(smalldatetime, @Tiempo_Inicio, 1);
   DECLARE  @FechaFinalEvento as smallDateTime;
   set @FechaFinalEvento = CONVERT(smalldatetime, @Tiempo_Final, 1);
  END
  BEGIN
   Insert Into Eventos
    (
      Titulo_Evento, Descripcion, Tipo, Topico, Tiempo_Inicio, Tiempo_Final, ID_Solicitud
    )
    Values
    (
        @Titulo_Evento, @Descripcion, @Tipo, @Topico, @FechaInicioEvento, @FechaFinalEvento, @ID_Solicitud
    )
   
  END
  
BEGIN
 set @ID_Evento = @@IDENTITY; 
END
GO
/****** Object:  Table [dbo].[Auditorias]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditorias](
	[ID_Auditoria] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[TipoUsuario] [nvarchar](100) NOT NULL,
	[Fecha_Entrada] [smalldatetime] NOT NULL,
	[Fecha_Salida] [smalldatetime] NOT NULL,
	[Opcion] [nvarchar](100) NOT NULL,
	[Tipo_Opcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Auditoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarUsuario]
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
/****** Object:  Table [dbo].[Perfiles]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[ID_Perfil] [int] IDENTITY(1,1) NOT NULL,
	[NombrePerfil] [varchar](50) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Perfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[organizadores]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizadores](
	[ID_Organizador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](150) NOT NULL,
	[CorreoElectronico] [nvarchar](100) NOT NULL,
	[ID_Evento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Organizador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarios]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuarios]
AS
begin
Select U.ID_Usuario as 'ID', U.Nombre + ' '+ U.Apellido as 'Nombre y apellido',U.Usuario as 'Usuario', R.NombreRol  as 'Rol', U.Estado from Usuarios as U 
Inner Join Roles as R on R.ID_Rol = U.ID_Rol;
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ObtenerUsuario] 
    
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
GO
/****** Object:  StoredProcedure [dbo].[ObtenerSolicitudes]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ObtenerSolicitudes]
AS
BEGIN 
 Update Solicitudes 
 Set Aprobacion = 'Efectuado' from Solicitudes
 inner join Eventos on eventos.ID_Solicitud = Solicitudes.ID_Solicitud where Eventos.Tiempo_Final < GETDATE() 
END

BEGIN
Select SO.ID_Solicitud ID,SO.Fecha Fecha, SO.Aprobacion Estado, SA.Nombre Salon, EV.Titulo_Evento Evento from Salones SA
Inner join Solicitudes SO on SO.ID_Salon = SA.ID_Salon
Inner Join Eventos EV on EV.ID_Solicitud = SO.ID_Solicitud
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarAuditoria]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarAuditoria]  
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
/****** Object:  Table [dbo].[Opciones]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Opciones](
	[ID_Opcion] [int] IDENTITY(1,1) NOT NULL,
	[Opcion] [varchar](50) NOT NULL,
	[ID_Perfil] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Opcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ActualizarPerfil]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ActualizarPerfil] 
@ID_Usuario as int,
@NombrePerfil as varchar(50)
as
BEGIN 
Update Perfiles
set NombrePerfil = @NombrePerfil where ID_Usuario = @ID_Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarOrganizador]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarOrganizador]
  @ID_Organizador  as int, 
  @Nombre          as Nvarchar(100),
  @Descripcion     as Nvarchar(150),
  @CorreoElectronico as  Nvarchar(100)
AS 
  BEGIN
    Update organizadores
    Set Nombre = @Nombre, Descripcion = @Descripcion , CorreoElectronico = @CorreoElectronico
    where ID_Organizador = @ID_Organizador  
  END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPerfil]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ObtenerPerfil]
@ID_Usuario  as int,
@ID_Perfil   as int output
As 
BEGIN
Select @ID_Perfil =  ID_Perfil  from Perfiles where ID_Usuario = @ID_Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerOrganizador]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ObtenerOrganizador]
  @ID_Evento   as int,
  @ID_Organizador  as int output, 
  @Nombre          as Nvarchar(100) output,
  @Descripcion     as Nvarchar(150) output,
  @CorreoElectronico as  Nvarchar(100) output
  As
  BEGIN
  select  @ID_Organizador = ID_Organizador ,  @Nombre = Nombre ,  @Descripcion = Descripcion ,  @CorreoElectronico = CorreoElectronico From Organizadores where ID_Evento = @ID_Evento 
  END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEventosDetalladosXID]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerEventosDetalladosXID]
@ID_Salon as int 
AS
BEGIN 
 Update Solicitudes 
 Set Aprobacion = 'Efectuado' from Solicitudes
 inner join Eventos on eventos.ID_Solicitud = Solicitudes.ID_Solicitud where Eventos.Tiempo_Final < GETDATE() 
END
BEGIN
Select EV.Titulo_Evento as 'Titulo'  , EV.Tipo  , EV.Topico , organizadores.Nombre as 'Organizador', Salones.Nombre  as 'Salon', EV.Tiempo_Inicio , EV.Tiempo_Final from Eventos as EV
Inner join organizadores on organizadores.ID_Evento = EV.ID_Evento
Inner join Solicitudes  on Solicitudes.ID_Solicitud = EV.ID_Solicitud
Inner join Salones on Salones.ID_Salon = Solicitudes.ID_Salon Where Solicitudes.Aprobacion = 'Aprobada' and Solicitudes.ID_Salon = @ID_Salon order by Tiempo_Inicio ASC
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEventosDetallados]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerEventosDetallados] 
AS
BEGIN 
 Update Solicitudes 
 Set Aprobacion = 'Efectuado' from Solicitudes
 inner join Eventos on eventos.ID_Solicitud = Solicitudes.ID_Solicitud where Eventos.Tiempo_Final < GETDATE() 
END
BEGIN
Select EV.Titulo_Evento as 'Titulo'  , EV.Tipo  , EV.Topico , organizadores.Nombre as 'Organizador', Salones.Nombre  as 'Salon', EV.Tiempo_Inicio , EV.Tiempo_Final from Eventos as EV
Inner join organizadores on organizadores.ID_Evento = EV.ID_Evento
Inner join Solicitudes  on Solicitudes.ID_Solicitud = EV.ID_Solicitud
Inner join Salones on Salones.ID_Salon = Solicitudes.ID_Salon Where Solicitudes.Aprobacion = 'Aprobada' order by Tiempo_Inicio ASC
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEventos]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ObtenerEventos]
AS
BEGIN 
 Update Solicitudes 
 Set Aprobacion = 'Efectuado' from Solicitudes
 inner join Eventos on eventos.ID_Solicitud = Solicitudes.ID_Solicitud where Eventos.Tiempo_Final < GETDATE() 
END
BEGIN
Select EV.ID_Evento as 'ID',  EV.Titulo_Evento as 'Titulo' , EV.Tipo as 'Tipo' , EV.Topico as 'Topico',EV.ID_Solicitud as 'Solicitud', organizadores.Nombre as 'Organizador', Salones.Nombre  as 'Salon'from Eventos as EV
Inner join organizadores on organizadores.ID_Evento = EV.ID_Evento
Inner join Solicitudes  on Solicitudes.ID_Solicitud = EV.ID_Solicitud
Inner join Salones on Salones.ID_Salon = Solicitudes.ID_Salon Where Solicitudes.Aprobacion = 'Aprobada'
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarOrganizador]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarOrganizador]
  @Nombre        as      Nvarchar(100),
  @Descripcion   as      Nvarchar(150),
  @CorreoElectronico as  Nvarchar(100),
  @ID_Evento        as   int,
  @ID_Organizador   as   Int output
  AS
  BEGIN
   INSERT  INTO Organizadores 
   (
     Nombre,Descripcion,CorreoElectronico,ID_Evento
   )
   VALUES
   (
     @Nombre , @Descripcion , @CorreoElectronico,@ID_Evento
   )
  END
  BEGIN
  Set @ID_Organizador = @@IDENTITY;
  END
GO
/****** Object:  StoredProcedure [dbo].[InsertarPerfil]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertarPerfil]
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
/****** Object:  Table [dbo].[Funciones]    Script Date: 04/24/2016 22:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funciones](
	[ID_Funcion] [int] IDENTITY(1,1) NOT NULL,
	[Funcion] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[ID_Opcion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Funcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertarOpcion]    Script Date: 04/24/2016 22:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertarOpcion]
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
/****** Object:  StoredProcedure [dbo].[ObtenerIDopcion]    Script Date: 04/24/2016 22:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtenerIDopcion] 
@Opcion as Varchar(50),
@ID_Perfil as int,
@ID_Opcion as int output
As 
BEGIN
Select @ID_Opcion = ID_Opcion from Opciones where Opcion = @Opcion and ID_Perfil = @ID_Perfil
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerFuncion]    Script Date: 04/24/2016 22:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ObtenerFuncion]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertarFuncion]    Script Date: 04/24/2016 22:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertarFuncion]
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
/****** Object:  StoredProcedure [dbo].[ActualizarFuncion]    Script Date: 04/24/2016 22:58:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ActualizarFuncion]
@ID_Opcion  as int,
@Funcion    as Varchar(50),
@Estado     as bit
as
BEGIN
update Funciones
set Estado = @Estado where ID_Opcion = @ID_Opcion and Funcion  = @Funcion
END
GO
/****** Object:  ForeignKey [FK__Solicitud__ID_Sa__2D27B809]    Script Date: 04/24/2016 22:58:50 ******/
ALTER TABLE [dbo].[Solicitudes]  WITH CHECK ADD FOREIGN KEY([ID_Salon])
REFERENCES [dbo].[Salones] ([ID_Salon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Inventari__ID_Sa__286302EC]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD FOREIGN KEY([ID_Salon])
REFERENCES [dbo].[Salones] ([ID_Salon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Roles__ID_GrupoU__0519C6AF]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([ID_GrupoUsuario])
REFERENCES [dbo].[GruposUsuarios] ([ID_GrupoUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Servicios__ID_Sa__239E4DCF]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([ID_Salon])
REFERENCES [dbo].[Salones] ([ID_Salon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Eventos__ID_Soli__31EC6D26]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD FOREIGN KEY([ID_Solicitud])
REFERENCES [dbo].[Solicitudes] ([ID_Solicitud])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Usuarios__ID_Rol__09DE7BCC]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Auditoria__ID_Us__3B75D760]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Auditorias]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Perfiles__ID_Usu__0EA330E9]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__organizad__ID_Ev__36B12243]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[organizadores]  WITH CHECK ADD FOREIGN KEY([ID_Evento])
REFERENCES [dbo].[Eventos] ([ID_Evento])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Opciones__ID_Per__1367E606]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Opciones]  WITH CHECK ADD FOREIGN KEY([ID_Perfil])
REFERENCES [dbo].[Perfiles] ([ID_Perfil])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  ForeignKey [FK__Funciones__ID_Op__182C9B23]    Script Date: 04/24/2016 22:58:51 ******/
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD FOREIGN KEY([ID_Opcion])
REFERENCES [dbo].[Opciones] ([ID_Opcion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO


