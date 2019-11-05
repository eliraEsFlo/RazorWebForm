insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('odin', HASHBYTES('sha1','123'),1);
insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('mauricio', HASHBYTES('sha1','123'),1);
insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('eber', HASHBYTES('sha1','123'),1);
insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('mago', HASHBYTES('sha1','123'),1);
insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('jorge', HASHBYTES('sha1','123'),1);

select * from Usuarios;

insert into Credenciales(DescripcionCredencial) values('admin');
insert into Credenciales(DescripcionCredencial) values('usuario');

--admin
insert into CredencialesUsuario(idCredencial, idUsuario) values(1,5);
insert into CredencialesUsuario(idCredencial, idUsuario) values(2,1);
insert into CredencialesUsuario(idCredencial, idUsuario) values(2,2);

insert into Areas(NombreArea) values('Banca empresas');
insert into Areas(NombreArea) values('Banca persoas');
insert into Areas(NombreArea) values('Microfinanzas');
insert into Areas(NombreArea) values('Produccion');

insert into EstadosDeRequerimiento(NombreEstado) values('Sin empezar');
insert into  EstadosDeRequerimiento(NombreEstado) values('En proceso');
insert into  EstadosDeRequerimiento(NombreEstado) values('Cerficicacion');
insert into  EstadosDeRequerimiento(NombreEstado) values('Terminado');

insert into TipoRequerimiento(NombreTipoRequerimiento) values('Incidencia');
insert into  TipoRequerimiento(NombreTipoRequerimiento) values('Proyecto Estrategico');
insert into  TipoRequerimiento(NombreTipoRequerimiento) values('Proyecto no estrategico');


insert into PermisosDePU(NombrePermiso) values('Carpetas');
insert into PermisosDePU(NombrePermiso) values('Frontend');
insert into PermisosDePU(NombrePermiso) values('Backend');
insert into PermisosDePU(NombrePermiso) values('Usuarios');
insert into PermisosDePU(NombrePermiso) values('Maquina');
insert into PermisosDePU(NombrePermiso) values('ActiveDirectory');
insert into PermisosDePU(NombrePermiso) values('Mail Service');
insert into PermisosDePU(NombrePermiso) values('FTP');
insert into PermisosDePU(NombrePermiso) values('Certificados');

insert into Procesos(NombreProceso) values('Dercas');
insert into Procesos(NombreProceso) values('Plan de trabajo');
insert into Procesos(NombreProceso) values('Hoja de objetos');
insert into Procesos(NombreProceso) values('Gestionar permisos PU');
insert into Procesos(NombreProceso) values('Diagrama de conexion');
insert into Procesos(NombreProceso) values('Pruebas tecnicas');
insert into Procesos(NombreProceso) values('Certificaciones');
insert into Procesos(NombreProceso) values('Hoja de traslado');
insert into Procesos(NombreProceso) values('Reunion con usuarios');
insert into Procesos(NombreProceso) values('Documentacion tecnica');
insert into Procesos(NombreProceso) values('Instalaciones');




insert into LiderProyecto(idUsuario) values(1);

insert into EquipoDeTrabajo(idLiderProyecto, idUsuario) values(1,1);
insert into EquipoDeTrabajo(idLiderProyecto, idUsuario) values(1,2);


insert into Requerimientos(
	idRequerimiento,
	NombreRequerimiento, 
	RutaRequerimiento,
	idArea,
	idTipoRequerimiento,
	FechaAsignacion,
	idEstadoRequerimiento,
	Prioridad,
	idUsuario,
	idLiderProyecto) values('01/2019','Formatos byte', 'C:\Users\Ariel\Deezloader Music\Requerimiento.pdf',
				1,1, GETDATE(), 1, 'Alta', 1,null);
				
insert into Requerimientos(
	idRequerimiento,
	NombreRequerimiento, 
	RutaRequerimiento,
	idArea,
	idTipoRequerimiento,
	FechaAsignacion,
	idEstadoRequerimiento,
	Prioridad,
	idUsuario,
	idLiderProyecto) values('02/2019','BALCAM', 'C:\Users\Ariel\Deezloader Music\Requerimiento2.pdf',
				1,2, GETDATE(), 1, 'Alta', null,1);

insert into PermisosPorRequerimiento(idRequerimiento, idPermisoPU, EstadoProceso) values('01/2019',1,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermisoPU, EstadoProceso) values('01/2019',2,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermisoPU, EstadoProceso) values('01/2019',3,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermisoPU, EstadoProceso) values('01/2019',4,1);

insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('01/2019',1,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('01/2019',2,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('01/2019',3,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('01/2019',4,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('01/2019',5,1);


