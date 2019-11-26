exec usp_InsertarUsuario 'mauri','123'
exec usp_InsertarUsuario 'jorge','123'
exec usp_InsertarUsuario 'mago','123'

exec usp_InsertarCredencial  'Admin'
exec usp_InsertarCredencial 'Programador'

exec usp_InsertarCredencialUsuario 1,1
exec usp_InsertarCredencialUsuario 2,2
exec usp_InsertarCredencialUsuario 2,3
go

exec usp_InsertarAreas 'Banca Personas' 
exec usp_InsertarAreas 'Banca Empresas' 
exec usp_InsertarAreas 'Microfinanzas' 
exec usp_InsertarAreas 'Produccion' 

exec usp_InsertarLider 2
exec usp_InsertarLider 3

exec usp_InsertarEquipoDeTrabajo 1,1
exec usp_InsertarEquipoDeTrabajo 1,2
exec usp_InsertarEquipoDeTrabajo 1,3

exec usp_InsertarEquipoDeTrabajo 2,1
exec usp_InsertarEquipoDeTrabajo 2,2
exec usp_InsertarEquipoDeTrabajo 2,3

exec usp_InsertarTipoDeRequerimiento 'Incidencia'
exec usp_InsertarTipoDeRequerimiento 'Proyecto Estrategico'
exec usp_InsertarTipoDeRequerimiento 'Proyecto No Estrategico'




insert into PermisosDePU(NombrePermiso) values('Carpetas');
insert into PermisosDePU(NombrePermiso) values('Frontend');
insert into PermisosDePU(NombrePermiso) values('Backend');
insert into PermisosDePU(NombrePermiso) values('Usuarios');
insert into PermisosDePU(NombrePermiso) values('Maquina');
insert into PermisosDePU(NombrePermiso) values('ActiveDirectory');
insert into PermisosDePU(NombrePermiso) values('Mail Service');
insert into PermisosDePU(NombrePermiso) values('FTP');
insert into PermisosDePU(NombrePermiso) values('Certificados');

insert into Procesos(NombreProceso) values('Analisis');
insert into Procesos(NombreProceso) values('Dercas y plan de trabajo');
insert into Procesos(NombreProceso) values('Desarrollo');
insert into Procesos(NombreProceso) values('Entrega a IPS');
insert into Procesos(NombreProceso) values('Produccion');


insert into EstadosDeRequerimiento(NombreEstado) values('Proceso');

insert into EstadosDeRequerimiento(NombreEstado) values('Certificacion');

insert into EstadosDeRequerimiento(NombreEstado) values('Terminado');

exec usp_InsertarRequerimiento  '02-2019','Cerd', 'C:\\', null,1, 2,3,'Alta'

exec usp_InsertarProyecto '01-2019',1,null

ALTER TABLE Proyectos ALTER COLUMN idLiderProyecto int NULL;

--admin
insert into CredencialesUsuario(idCredencial, idUsuario) values(1,5);

insert into Areas(NombreArea) values('Banca Empresas');
insert into Areas(NombreArea) values('Banca Personas');
insert into Areas(NombreArea) values('Microfinanzas');
insert into Areas(NombreArea) values('Produccion');

insert into EstadosDeRequerimiento(NombreEstado) values('Sin empezar');
insert into  EstadosDeRequerimiento(NombreEstado) values('En proceso');
insert into  EstadosDeRequerimiento(NombreEstado) values('Cerficicacion');
insert into  EstadosDeRequerimiento(NombreEstado) values('Terminado');

insert into TipoDeRequerimiento(NombreTipoRequerimiento) values('Incidencia');
insert into  TipoDeRequerimiento(NombreTipoRequerimiento) values('Proyecto Estrategico');
insert into  TipoDeRequerimiento(NombreTipoRequerimiento) values('Proyecto no Estrategico');






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
				