
create table Usuarios
(
	idUsuario int primary key identity(1,1),
	NombreUsuario varchar(50) not null,
	PasswordUsuario varbinary(40) not null,
	Estado bit not null
);

create table LiderProyecto
(
	idLiderProyecto int primary key identity(1,1),
	idUsuario int  null
);

create table EquipoDeTrabajo
(
	idEquipo_Trabajo int primary key identity(1,1),
	idLiderProyecto int foreign key (idLiderProyecto)
	references LiderProyecto(idLiderProyecto) not null,
	idUsuario int foreign key (idUsuario)
	references Usuarios(idUsuario) not null
);


create table Credenciales
(
	idCredencial int primary key identity(1,1),
	DescripcionCredencial varchar(50) not null
);


create table CredencialesUsuario
(
	idCredencial_Usuario int primary key(idCredencial,idUsuario) identity(1,1),
	idCredencial int foreign key (idCredencial)
	references Credenciales(idCredencial) not null,
	idUsuario int foreign key (idUsuario)
	references Usuarios(idUsuario) not null
);


create table Areas
(
	idArea int primary key identity(1,1),
	NombreArea varchar(40) not null
);


create table TipoRequerimiento
(
	idTipoRequerimiento int primary key identity(1,1),
	NombreTipoRequerimiento varchar(40) not null
);


create table EstadosDeRequerimiento
(
	idEstadoRequerimiento int primary key identity(1,1),
	NombreEstado varchar(40) not null
);


create table IncidenciasProduccion
(
	idIncidenciaProduccion varchar(40) primary key ,
	NombreIncidencia varchar(60) not null,
	DescripcionIncidencia varchar(200) not null,
	FechaDeEmision datetime not null,
	idUsuario int foreign key (idUsuario)
	references Usuarios(idUsuario) not null
);



--Cruce entre tod tablas
create table Requerimientos
(
	idRequerimiento varchar(50) primary key ,
	NombreRequerimiento varchar(50) not null,
	RutaRequerimiento varchar(max) not null,
	idArea int foreign key (idArea)
	references Areas(idArea) not null,
	idTipoRequerimiento int foreign key (idTipoRequerimiento) 
	references TipoRequerimiento(idTipoRequerimiento) not null,
	FechaAsignacion datetime not null,
	idEstadoRequerimiento int foreign key (idEstadoRequerimiento)
	references EstadosDeRequerimiento(idEstadoRequerimiento) null,
	Prioridad varchar(50) not null,
	idUsuario int null,
	idLiderProyecto int null

);


create table PermisosDePU
(
	idPermisoPU int primary key identity(1,1),
	NombrePermiso varchar(50) not null
);

create table PermisosPorRequerimiento
(
	idPermiso_Req int primary key (idRequerimiento,idPermisoPU) identity(1,1),
	idRequerimiento varchar(50) foreign key (idRequerimiento)  
	references Requerimientos(idRequerimiento) not null,
	idPermisoPU int foreign key (idPermisoPU)  
	references PermisosDePU(idPermisoPU) not null,
	EstadoProceso bit not null
);


create table Procesos(
	idProceso int primary key identity(1,1),
	NombreProceso varchar(50) not null
);

create table ProcesosPorRequerimiento(
	idProcesos_Req int primary key(idRequerimiento,idProceso) identity(1,1),
	idRequerimiento varchar(50) foreign key (idRequerimiento)  
	references Requerimientos(idRequerimiento) not null,
	idProceso int foreign key (idProceso)  
	references Procesos(idProceso) not null,
	EstadoProceso bit not null
);

--fin de cruce


