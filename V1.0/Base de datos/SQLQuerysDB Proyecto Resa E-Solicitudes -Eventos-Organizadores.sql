
use resaDB;
/* En este Query se trabajara la parte logica de las Entidades de solicitudes */

/* manejando la parte logica de almacenamiento de las Solicitudes */

/* Stored procedure CrearSolicitud*/

CREATE PROCEDURE CrearSolicitud
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
/* Eliminar Stored Procedure */

--Drop procedure CrearSolicitud 

/* Prueb Stored procedure  1 */
Declare @ID_Solicitud as int;

execute CrearSolicitud  '03/24/16 1:00 PM', false, 1, '03/24/16 1:00 PM', 1,@ID_Solicitud = @ID_Solicitud OUTPUT

Select @ID_Solicitud as 'ID'

/* Consulta */
Select * from Solicitudes;

/* Prueba Stored procedure stored procedure 2 */
/*Declare @ID_Solicitud as int;
declare @FechaInicio as smalldateTime;

set @FechaInicio =    CONVERT(smalldatetime, '03/24/16 1:00 PM', 1);

execute CrearSolicitud  @FechaInicio, false, 1, @FechaInicio, 1,@ID_Solicitud = @ID_Solicitud OUTPUT
   
   Select @ID_Solicitud as 'ID'
   
   /*Sintacis Utilizada para convertir*/ 
      CONVERT(datetime, '2006-04-25T15:50:59.997', 126)
   /* Sintacis utilizada para casturar*/
   CAST ( expression AS data_type )   
      
     
  /** Conculta **/*/

/* select    CAST(Fecha AS datetime) AS 'datetime2' from Solicitudes */


/* Finalizacion del  stored procedure */

/* Stored procedure obtener todas las solicitudes */

Create procedure ObtenerSolicitudes
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
/* Eliminando El stored procedure */
--drop procedure ObtenerSolicitudes;
use resaDB

/*  Prueba del stored Procedure */
create table #data(ID_Solicitud Int,Fecha SmallDateTime,Aprobacion Nvarchar(30) ,Nombre Nvarchar(100),Titulo_Evento Nvarchar(100))

insert into #data exec dbo.ObtenerSolicitudes
select ID_Solicitud as 'ID', Fecha as 'Fecha', Aprobacion as 'Estado', Nombre as 'Salon',Titulo_Evento as 'Evento' from #data
go
/* Eliminando la tabla #Data*/
Drop Table #data

/* Actualizar Solicitud */
CREATE PROCEDURE ActualizarSolicitud
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

/* Stored procedure a eliminar */
--drop procedure ActualizarSolicitudes;

/* probando el stored procedure */

execute ActualizarSolicitudes 4,'03/24/16 1:00 PM','Desaprobado','Julio','03/24/16 1:00 PM',1

Select * from solicitudes;


/* Stored proocedure Eliminar una solicitud */

CREATE procedure EliminarSolicitud
@ID_Solicitud as int
AS
BEGIN
   delete from Solicitudes Where Solicitudes.ID_Solicitud = @ID_Solicitud
END
GO
/* Eliminando Stored procedure */
--drop procedure EliminarSolicitud 

/* probando El stored procedure */

Execute EliminarSolicitud 25

/* */
Select * from solicitudes

/* Eventos  Logica de  los eventos  */ 
CREATE PROCEDURE CrearEvento 

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

/* Truenqueando  las tablas*/

Select  * from Solicitudes 
Select * From Eventos
Select * from organizadores

/* Eliminar procedure de eventos */
--Drop procedure CrearEvento

/*Probando El store procedure */


Declare  @ID_Evento  Int;

execute CrearEvento  'La Loquera del pais','To los maldito loco','Loco','La basura','03/24/16 1:00 PM','03/24/16 1:00 PM',4, @ID_Evento = @ID_Evento output

Select @ID_Evento  as 'ID'


Select * from Eventos

Select * from solicitudes

Select * from organizadores
 
/* Soluccionando verificacion de las fechas  para la no repeticion */

   Select EV.Tiempo_Inicio From Salones as SA 
   Inner join Solicitudes as SO on SO.ID_Salon  = SA.ID_Salon
   Inner Join Eventos  as EV  on EV.ID_Solicitud  =  SO.ID_Solicitud
   Where  
     
     Set @Explorador = 01;
     
     ELSE
     
     /* Paginas Tomadas como referencia */
     https://social.msdn.microsoft.com/Forums/es-ES/240342d5-b8f6-4a91-9570-dce08723fc2f/manejo-de-fechas-de-sql-server-2005?forum=sqlserveres
     
     
     /* Actualizar  un evento */ 
     
 /*Verificacion de las fechas de */
 
 CREATE PROCEDURE VerificarFechas 
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
  /* - - - - */
  --drop procedure VerificarFechas
  
  select * from Eventos
  
  
 /* Actualizar un evento hora*/ 
     
CREATE PROCEDURE ActualizarEvento
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
  go
  
  /* Eliminar el  stored procedure */
  
  --Drop procedure ActualizarEvento
  
  /* Probando el procedure*/
  
  Select * from solicitudes
  execute ActualizarEvento 5,'La Loquera del pais','To los maldito loco','Loco','La basura','03/24/16 1:00 PM','03/24/16 1:00 PM'
  
  select * from eventos
  
  /* Obtener Eventos */
  
CREATE Procedure ObtenerEventos
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

/* Eliminando Stored procedure */
use ResaDB
--Drop procedure ObtenerEventos
/*  - ---  - - - -- - - - -- - - */

/********************************************/

CREATE PROCEDURE ObtenerEventosDetallados 
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
/**/

Select * from Eventos
/*Eliminando Stored procedure */ 
--Drop procedure ObtenerEventosDetallados

CREATE PROCEDURE ObtenerEventosDetalladosXID
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
/* Eliminar Stored procedure */

--Drop Procedure  ObtenerEventosDetalladosXID



/* Stored procedures de los organizadores*/

/* Insertar un organizador */

CREATE PROCEDURE InsertarOrganizador
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
 
  
  
  
  /* Eliminar Stored Procedure */
  
  --drop Procedure InsertarOrganizador;
  
  /* Prueba */
  DECLARE @ID_Organizador as int;
  
  Execute InsertarOrganizador  'Leonel Fernandez','Presidente de la','tuLeo.com',1,@ID_Organizador = @ID_Organizador output
   
  Select @ID_Organizador as 'ID'
   /* - - - - - - - - */
   select * from Eventos;
   Select * from organizadores
  
  /* Uctualizar un organizador */
  
  CREATE PROCEDURE ActualizarOrganizador
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
  /* Delete procedure*/
  --drop procedure ActualizarOrganizador;
  /* prueba */
  
    Execute ActualizarOrganizador  2,'Leonel Fernandez','Presidente de la','tuLeo.com'
    
    Select * from organizadores
    
    
    /*Logistica  para la Actualizacion  de las Entidades Eventos, Solicitudes y organizadores */
    
    use ResaDB
   /*Obtener Solicitudes*/
   
  CREATE PROCEDURE ObtenerSolicitud
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
   /* */ 
   --Drop procedure ObtenerSolicitud
   select * from Solicitudes
   select * from Salones
   
   /* Obtener Evento */
   CREATE PROCEDURE ObtenerEvento
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
  Go
  /*  - - - - - - */
  
  --drop procedure ObtenerEvento;
  
  
  
  /* Obtener Organizador */
  CREATE Procedure ObtenerOrganizador
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
  
  /* - - - */ 
  --drop procedure ObtenerOrganizador;