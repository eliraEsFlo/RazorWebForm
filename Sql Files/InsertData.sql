insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('jorge', HASHBYTES('sha1','123'),1);
insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) values ('mauricio', HASHBYTES('sha1','123'),1);

insert into Areas(NombreArea) values('Cobros');

insert into Permisos(NombrePermiso) values('Carpetas');
insert into Permisos(NombrePermiso) values('Frontend');
insert into Permisos(NombrePermiso) values('Backend');
insert into Permisos(NombrePermiso) values('Usuarios');
insert into Permisos(NombrePermiso) values('Maquina');
insert into Permisos(NombrePermiso) values('ActiveDirectory');
insert into Permisos(NombrePermiso) values('Mail Service');
insert into Permisos(NombrePermiso) values('FTP');
insert into Permisos(NombrePermiso) values('Certificados');

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

insert into Requerimientos(idRequerimiento,
	NombreRequerimiento, 
	RutaRequerimiento,
	idArea,
	TipoRequerimiento,
	FechaAsignacion,
	EstadoRequerimiento,
	Prioridad,
	idUsuario) values('87/2019','Formatos byte', 'C:\Users\Ariel\Deezloader Music\Requerimiento.pdf',
				1,'Incidencia', GETDATE(), 'Sin empezar', 'Alta', 1);


insert into PermisosPorRequerimiento(idRequerimiento, idPermiso, EstadoProceso) values('87/2019',4,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermiso, EstadoProceso) values('87/2019',5,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermiso, EstadoProceso) values('87/2019',7,1);
insert into PermisosPorRequerimiento(idRequerimiento, idPermiso, EstadoProceso) values('87/2019',8,1);

insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('87/2019',4,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('87/2019',5,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('87/2019',7,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('87/2019',8,1);
insert into ProcesosPorRequerimiento(idRequerimiento, idProceso, EstadoProceso) values('87/2019',11,1);