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

/* Ejemplo de trigger en select para marcar el esta de una solicitud como pasado */
