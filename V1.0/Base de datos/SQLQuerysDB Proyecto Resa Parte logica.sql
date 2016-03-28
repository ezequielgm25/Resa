Use ResaDB;

/*Drop database ResaDB;*/


/* Creando las tablas y procedimientos de la parte logica del sistema */

/* Tabla de salones*/

Create Table Salones
(
  ID_Salon        Int not null Identity(1,1),
  Nombre          Nvarchar(100) not null,
  Ubicacion       Nvarchar(100) not null,
  Capacidad       Int not null,
  Estado          Nvarchar(100) not null,
  Primary key(ID_Salon)
  
  )
  
  Go
  
    /* Tabla de Servicios */
  
  Create Table Servicios
(
  ID_Servicio     Int not null Identity(1,1),
  Servicio        Nvarchar(100) not null,
  Descripcion     Nvarchar(250) not null,
  ID_Salon        int not null,
  Primary key(ID_Servicio),
  Foreign key(ID_Salon) REFERENCES Salones(ID_Salon)
  On delete cascade
  On update cascade,
  )
  
  Go
  
  /* Tabla de inventarios */
  
    Create Table Inventarios
(
  ID_Inventario     Int not null Identity(1,1),
  Inventario        Nvarchar(100) not null,
  ID_Salon        int not null,
  Primary key(ID_Inventario),
  Foreign key(ID_Salon) REFERENCES Salones(ID_Salon)
  On delete cascade
  On update cascade,
  
  )
  
  Go
  
  
  /* Tabla de solicitudes */
  
  Create Table Solicitudes
  (
   ID_Solicitud    Int not null Identity(1,1),
   Fecha           SmallDateTime not null,
   Aprobacion      Nvarchar(30) not null,
   Usuario         Nvarchar(60),
   FechaAprobacion SmallDateTime,
   ID_Salon        int not null,
   primary Key(ID_Solicitud),
   Foreign key(ID_Salon) REFERENCES Salones(ID_Salon)
   On delete cascade
   On update cascade,
  
  )
  
  Go
 
 
 
  /* Tabla de Eventos*/
  
      Create Table Eventos
(
  ID_Evento       Int not null Identity(1,1),
  Titulo_Evento   Nvarchar(100) not null,
  Descripcion     Nvarchar(300) not null,
  Tipo            Nvarchar(100) not null,
  Topico          Nvarchar(150) not null,
  Tiempo_Inicio   SmallDateTime not null,
  Tiempo_Final    SmallDateTime not null,
  ID_Solicitud        int not null,
  Primary key(ID_Evento),
  Foreign key(ID_Solicitud) REFERENCES Solicitudes(ID_Solicitud)
  On delete cascade
  On update cascade,
  
  )
  
  Go
    
    /* Tabla de Organizadores*/
    
    Create Table organizadores
(
  ID_Organizador      Int not null Identity(1,1),
  Nombre              Nvarchar(100) not null,
  Descripcion         Nvarchar(150) not null,
  CorreoElectronico   Nvarchar(100) not null,
  ID_Evento           int not null,
  Primary key(ID_Organizador),
  Foreign key(ID_Evento) REFERENCES Eventos(ID_Evento)
  On delete cascade
  On update cascade,
  
  )
  
  Go
  
  /* Tabla de auditorias */
  
   Create Table Auditorias
(
  ID_Auditoria    Int not null Identity(1,1),
  ID_Usuario      Int not null,
  TipoUsuario     Nvarchar(100) not null,
  Fecha_Entrada   SmallDateTime not null,
  Fecha_Salida    SmallDateTime not null,
  Opcion          Nvarchar(100) not null,
  Tipo_Opcion     Nvarchar(100) not null,
  Primary key(ID_Auditoria),
  Foreign key(ID_Usuario) REFERENCES Usuarios(ID_Usuario)
  On delete cascade
  On update cascade,
  
  )
  
  Go
  
  
  /* Seccion de trabajo con la parte logica Stored Procedure ETC... */
  
  /* Salones parte logica */
  
  Select IV.Inventario From Salones AS S 
  Left Join Inventarios as IV on IV.ID_Salon = S.ID_Salon 
  Where S.ID_Salon = 1 ;  
  
  /*  Crear Salon  */       /* - - - - - - - - - - - - - - - - - */
  
  CREATE PROCEDURE CrearSalon
  
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

/* Eliminar Stored Procedure */

Drop procedure CrearSalon

/* Prueba Stored procedure */
Declare @ID_Salon as int;

execute CrearSalon 'La cuevikkta','En higuey ',200,'activo',@ID_Salon = @ID_Salon OUTPUT
   
   Select @ID_Salon as 'ID'
   
   
Select * from Salones

/* Eliminar Salon */     /* - - - - - - - - - - - - - - - - - */

CREATE PROCEDURE EliminarSalon
@ID_Salon as Int 
 AS 
BEGIN
   delete from Salones Where Salones.ID_Salon = @ID_Salon
END
 GO

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - */ 
execute EliminarSalon 1   /* prueba de eliiminacion  */


/* Actualizar salon */     /* - - - - - - - - - - - - - - - - - */

CREATE PROCEDURE ActualizarSalon  
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

/* Eliminando procedure */ 
Drop procedure ActualizarSalon
/* Probando el stored procedure*/

Execute ActualizarSalon 5 ,'salonsote el escondidote','donde tu abuela',200,'loco'

/* ------------------------------------------------------------------------------ */

/* Obtener un salon */    /* - - - - - - - - - - - - - - - - - */

Create Procedure obtenerSalon
 @ID_Salon as int,
 @Nombre     as nvarchar(100) output,
 @Ubicacion  as nvarchar(50)  output,
 @Capacidad  as Int  output,
 @Estado     as nvarchar(100) output
 AS
 
 Begin
 
  Select @Nombre = nombre, @Ubicacion = Ubicacion , @Capacidad = Capacidad , @Estado = Estado from Salones
  Where ID_Salon = @ID_Salon
 
 END
 
 Begin 
 
    return 
  
 End
 
 GO
 
 /* Eliminando EL StoredProcedure */          
 Drop Procedure obtenerSalon
 
 /* Probando Obtener Salon */ 
 
 /************ Ejecuntando Stored procedure de prueba ********************/

  /** Variable  que recibira la salida **/
 

 DECLARE @Nombre     as nvarchar(100);
 DECLARE @Ubicacion  as nvarchar(50);  
 DECLARE @Capacidad  as Int;
 DECLARE @Estado     as nvarchar(100); 
    /* Se ejecuta  el store procedure  */
 Execute ObtenerSalon 5,@Nombre = @Nombre OUTPUT , @Ubicacion = @Ubicacion OUTPUT , @Capacidad = @Capacidad OUTPUT, @Estado = @Estado output

 Select @Nombre      AS 'Nombre'
 Select @Ubicacion   AS 'Ubicacion'
 Select @Capacidad   As 'Capacidad'
 Select @Estado      As 'Estado'
 go
/************************************************************************/ 

/************** Obtener Salones  ***********************************/   /* - - - - - - - - - - - - - - - - - */
 
Create Procedure ObtenerSalones
AS
begin
Select ID_Salon As 'ID', Nombre, Ubicacion, Capacidad, Estado FROM Salones
end
Go

use resaDB
/* Eliminar el stored procedure*/
drop procedure ObtenerSalones

/*  Prueba del stored Procedure */
create table #data(ID_Salon Int, Nombre NVarchar(100),Ubicacion Nvarchar(100),Capacidad Int, Estado Nvarchar(100))

insert into #data exec dbo.ObtenerSalones
select * from #data
go
/* Eliminando la tabla #Data*/
Drop Table #data

/* Obtener Id y nombre de Salones */
CREATE PROCEDURE ObtenerSalonesID_N
AS
begin
Select ID_Salon As 'ID', Nombre FROM Salones
end
Go
/* ***************************************************************/
Drop procedure ObtenerSalonesID_N

/************ Agregar Servicio **************/     /* - - - - - - - - - - - - - - - - - */
              
CREATE PROCEDURE AgregarServicio 
 
 @Servicio as Nvarchar(100),
 @Descripcion as Nvarchar(250),
 @ID_Salon as int
 As 
BEGIN
   Insert Into Servicios
    (
        Servicio,Descripcion,ID_Salon
    )
    Values
    (
        @Servicio, @Descripcion, @ID_Salon
    )
    
 END
 GO 
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
/*Probando */
Drop procedure AgregarServicio
/*****/
execute AgregarServicio 'hjhjh','Bailarines profecionales',5

select * from Salones

select * from Servicios
/*********************************************************/
/* Stored procedure Eliminar Servicio */   /* - - - - - - - - - - - - - - - - - */
CREATE PROCEDURE EliminarServicio
@ID_Servicio AS INT
AS
BEGIN
DELETE FROM Servicios
WHERE ID_Servicio = @ID_Servicio
END
GO

/* Elminar procedure*/
Drop Procedure EliminarServicio
/* * * * * * * Prueba * * * * * * * * * * * */
EXECUTE EliminarServicio 17

Select * from Servicios
/************* Obtener Servicios ***********/

/* Obtener Servicios */  /* - - - - - - - - - - - - - - - - - */

Create Procedure ObtenerServicios
@ID_Salon as int
AS
begin
Select ID_Servicio AS 'ID', Servicio, Descripcion from Servicios where ID_Salon = @ID_Salon
end
Go

/* Eliminar procedure */
Drop Procedure ObtenerServicios
/* Prueba*/
create table #data( servicio NVarchar(100),Descripcion Nvarchar(250) )

insert into #data exec dbo.ObtenerServicios 5
select * from #data
go

Select * from Servicios


/* Eliminando Tabla */
Drop Table #data



/* Inventarios   */    /* - - - - - - - - - - - - - - - - - */

CREATE PROCEDURE AgregarInventario
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
 
 /* Eliminando Procedure */
 
 Drop procedure AgregarInventario
 
 /* Prueba */
 Execute AgregarInventario 'Aire Acondicionado',5
 
 select * from salones
 
 select * from Inventarios
 
 /* Eliminar Inventario */   /* - - - - - - - - - - - - - - - - - */
 
 /* Stored procedure Eliminar Inventario*/
CREATE PROCEDURE EliminarInventario
@ID_Inventario AS INT
AS
BEGIN
DELETE FROM Inventarios
WHERE ID_Inventario = @ID_Inventario
END
GO
/* Elminar procedure*/
Drop Procedure EliminarInventario
/* * * * * * * Prueba * * * * * * * * * * * */
EXECUTE EliminarInventario 9

Select * from Inventarios

/* Obtener Inventarios */   /* - - - - - - - - - - - - - - - - - */

Create Procedure ObtenerInventarios
@ID_Salon as int 
AS
begin
Select ID_Inventario as 'ID',Inventario from Inventarios where ID_Salon = @ID_Salon
end
Go
/* Eliminando Procedure */
drop procedure ObtenerInventarios
/*   */
Select * from Inventarios


/* Prueba*/
create table #data( Inventario NVarchar(100))

insert into #data exec dbo.ObtenerInventarios 5
select * from #data
go
/* Eliminando Tabla */
Drop Table #data


