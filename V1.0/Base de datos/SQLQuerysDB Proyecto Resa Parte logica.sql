Use ResaDB;
Drop database ResaDB;
use HR
/* Creando las tablas y procedimientos de la parte logica del sistema */

/* Tabla de salones*/

Create Table Salones
(
  ID_Salon        Int not null Identity(1,1),
  Nombre          Nvarchar(100) not null,
  Direccion       Nvarchar(100) not null,
  Capacidad       Int 
  Primary key(ID_Salon)
  
  )
  
  Go
  
  /* Tabla de solicitudes */
  
  Create Table Solicitudes
  (
   ID_Solicitud    Int not null Identity(1,1),
   Fecha           SmallDateTime not null,
   Aprobacion      bit not null,
   Usuario         nvarchar(60),
   FechaAprobacion SmallDateTime,
   ID_Salon        int not null,
   primary Key(ID_Solicitud),
   Foreign key(ID_Salon) REFERENCES Salones(ID_Salon)
   On delete cascade
   On update cascade,
  
  )
  
  Go
  
  /* Tabla de Servicios */
  
  Create Table Servicios
(
  ID_Servicio     Int not null Identity(1,1),
  Servicio        Nvarchar(100) not null,
  Descripcion     Nvarchar(100) not null,
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
  Descripcion       Nvarchar(100) not null,
  ID_Salon        int not null,
  Primary key(ID_Inventario),
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
  Descripcion     Nvarchar(100) not null,
  Tipo            Nvarchar(50) not null,
  Topico          Nvarchar(100) not null,
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
  Descripcion         Nvarchar(100) not null,
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
  
  
  
  
