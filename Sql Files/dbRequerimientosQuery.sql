
create table Usuarios
(
	idUsuario int primary key identity(1,1),
	NombreUsuario varchar(50) not null,
	PasswordUsuario varbinary(40) not null,
	Estado bit not null
);

create table Lideres
(
	idLiderProyecto int primary key identity(1,1),
	idUsuario int foreign key (idUsuario)
	references Usuarios(idUsuario) not null
);

create table EquipoDeTrabajo
(
	idEquipo_Trabajo int primary key identity(1,1),
	idLiderProyecto int foreign key (idLiderProyecto)
	references Lideres(idLiderProyecto) not null,
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
	idCredencial_Usuario int primary key identity(1,1),
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
/*
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
*/


create table Requerimientos
(
	idRequerimiento varchar(50) primary key ,
	NombreRequerimiento varchar(50) not null,
	RutaRequerimiento varchar(max) not null,
	idArea int foreign key (idArea)
	references Areas(idArea) not null,
	FechaAsignacion datetime not null,
	idEstadoRequerimiento int foreign key (idEstadoRequerimiento)
	references EstadosDeRequerimiento(idEstadoRequerimiento) null,
	Prioridad varchar(50) not null
);

create table Proyectos(
	idProyecto int primary key identity(1,1),
	idRequerimiento varchar(50) foreign key
	references Requerimientos(idRequerimiento) null,
	idTipoRequerimiento int foreign key (idTipoRequerimiento)  
	references TipoRequerimiento(idTipoRequerimiento) not null,
	idLiderProyecto int foreign key (idLiderProyecto)  
	references Lideres(idLiderProyecto) not null,
	idUsuario int foreign key (idUsuario)  
	references Usuarios(idUsuario) not null,
);

create table PermisosDePU
(
	idPermisoPU int primary key identity(1,1),
	NombrePermiso varchar(50) not null
);

create table Procesos(
	idProceso int primary key identity(1,1),
	NombreProceso varchar(50) not null
);

create table ProcesosPorProyecto
(
	idProceso_Proyecto int primary key identity(1,1),
	idProyecto int foreign key (idProyecto)
	references Proyectos(idProyecto) not null,
	idProceso int foreign key (idProceso)
	references Procesos(idProceso) not null,
	EstadoProceso bit not null
);

create table PermisosPorProyecto
(
	idPermiso_Proyecto int primary key identity(1,1),
	idRequerimiento varchar(50) foreign key (idRequerimiento)  
	references Requerimientos(idRequerimiento) not null,
	idPermisoPU int foreign key (idPermisoPU)  
	references PermisosDePU(idPermisoPU) not null,
	EstadoPermiso bit not null
);


create table HojasDeTrasladoDeProyectos
(
	idHojaDeTraslado int primary key identity(1,1),
	FechaCreacion datetime not null,
	idProyecto int foreign key (idProyecto)
	references Proyectos(idProyecto) not null
);

create table ObjetosDeTraslado
(
	idObjetoTraslado int primary key identity(1,1),
	NombreServidorOrigen varchar(50) not null,
	NombreObjeto varchar(50) not null,
	FechaCreacion datetime not null,
	FechaModificacion datetime not null,
	RutaOrigenObjeto varchar(200) not null,
	NombreServidorDestino varchar(50) not null,
	RutaObjetoDestino varchar(200) not null,
	TipoDeObjeto varchar(50)
);


create table DatosHoja
(
	idDatosHoja int primary key identity(1,1),
	idHojaDeTraslado int foreign key (idHojaDeTraslado)
	references HojasDeTrasladoDeProyectos(idHojaDeTraslado) not null,
	idObjetoTraslado int foreign key (idObjetoTraslado)
	references ObjetosDeTraslado(idObjetoTraslado) not null,
);



create table InformacionAdicional
(
	idInfoAdicional int primary key identity(1,1),
	RutaDercas varchar(200) not null,
	RutaPlanTrabajo varchar(200) not null
);


create table ActividadesPorProceso
(
	idActividadProceso int primary key identity(1,1),
	idProceso_Proyecto int foreign key (idProceso_Proyecto)
	references ProcesosPorProyecto(idProceso_Proyecto),
	idInfoAdicional int foreign key (idInfoAdicional)
	references InformacionAdicional(idInfoAdicional),
	FechaIncio datetime not null,
	FechaPromesa datetime not null,
	FechaEntrega datetime not null,
	EstadoActividadProceso bit not null
);


create table Notificaciones
(
	idNotificacion int primary key identity(1,1),
	Mensaje varchar(50) not null,
	FechaNotificacion datetime not null,

		idActividadProceso int foreign key (idActividadProceso)
	references ActividadesPorProceso(idActividadProceso)
);



