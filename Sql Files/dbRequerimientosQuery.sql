drop database AtencionRequerimientoDb;
CREATE DATABASE AtencionRequerimientosDb; 

create table Usuarios(
	idUsuario int primary key identity(1,1),
	NombreUsuario varchar(50) not null,
	PasswordUsuario varbinary(40) not null,
	Estado bit not null
);

create table Credenciales(
	idCredencial int primary key identity(1,1),
	DescripcionCredencial varchar(50) not null
);


create table CredencialesUsurio(
	idCredencialUsuario int primary key identity(1,1),
	idCredencial int foreign key (idCredencial)
	references Credenciales(idCredencial)
);


create table Areas(
	idArea int primary key identity(1,1),
	NombreArea varchar(40) not null
);


--Cruce entre tod tablas
create table Requerimientos(
	idRequerimiento varchar(50) primary key ,
	NombreRequerimiento varchar(50) not null,
	RutaRequerimiento varchar(max) not null,
	idArea int foreign key (idArea)
	references Areas(idArea) not null,
	TipoRequerimiento varchar(50) not null,
	FechaAsignacion datetime not null,
	EstadoRequerimiento varchar(50) not null,
	Prioridad varchar(50) not null,
	idUsuario int null

);


create table Permisos(
	idPermiso int primary key identity(1,1),
	NombrePermiso varchar(50) not null
);

create table PermisosPorRequerimiento(
	idPermisoPorRequerimiento int primary key identity(1,1),
	idRequerimiento varchar(50) foreign key (idRequerimiento)  
	references Requerimientos(idRequerimiento) not null,
	idPermiso int foreign key (idPermiso)  
	references Permisos(idPermiso) not null,
	EstadoProceso bit not null
);


create table Procesos(
	idProceso int primary key identity(1,1),
	NombreProceso varchar(50) not null
);

create table ProcesosPorRequerimiento(
	idProcesoPorRequerimiento int primary key identity(1,1),
	idRequerimiento varchar(50) foreign key (idRequerimiento)  
	references Requerimientos(idRequerimiento) not null,
	idProceso int foreign key (idProceso)  
	references Procesos(idProceso) not null,
	EstadoProceso bit not null
);



create table ControlObjetos(
	idControlObjetos int primary key identity(1,1),
	FuenteReferencia varchar(50) not null,
	NombreFuente varchar(50) not null,
	TipoObjeto varchar(50) not null,
	NombreObjeto varchar(100) not null,
	AccionObjeto varchar(100) not null,
	DescripcionObjeto varchar(200) not null

);

create table Proyectos(
	idProyecto int primary key identity(1,1),
	NombreProyecto varchar(50) not null,
	EstadoProyecto bit not null,
	idDiagramaConexion int null,
	idControlObjetos int null
);

create table RequerimientoProyecto(
	idRequerimientoProyecto int primary key identity(1,1),
	idProyecto int foreign key (idProyecto)
	references Proyectos(idProyecto) not null,
	idRequerimiento varchar(50) foreign key (idRequerimiento)
	references Requerimientos(idRequerimiento) not null,
);
--fin de cruce


