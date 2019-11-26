--Usuarios
go
create proc usp_InsertarUsuario
(@nombreUsuario varchar(40),
@passwordUsuario varchar(40))
as
begin
	
	declare @user varchar(20)= (select  NombreUsuario from Usuarios 
							where NombreUsuario = @nombreUsuario);

	if(@user is null)
	begin
		declare @encrypt varbinary(200) ;
		select @encrypt = EncryptByPassPhrase('key', @passwordUsuario);
		declare @isActive bit = 1;

		insert into Usuarios(NombreUsuario, PasswordUsuario, Estado) 
		values (@nombreUsuario, @encrypt,@isActive);
			select (cast( 1 as bit)) as isOk;
	end
		 
else
	begin
		select cast(0 as bit) as isOk
	end
end

exec usp_InsertarUsuario 'jorge', '1234'


go
 create proc usp_ObtenerUsuarios
 as
	select idUsuario, NombreUsuario, Estado from Usuarios;

go
create proc InsertarPermisoUsuario
(
@Descripcion nvarchar(50)
)
as

declare @user varchar(20)= (select  DescripcionCredencial from Credenciales where DescripcionCredencial = @Descripcion);

if(@user is null)
	begin
		insert into Credenciales(DescripcionCredencial)
			 values (@Descripcion);
		select (cast( 1 as bit)) as existe;
	end
		 
else
	begin
		select cast(0 as bit) as existe
	end


go
create PROC usp_ValidarUsuario
( @userName VARCHAR(50),
	@password VARCHAR(50)
)

AS
begin
	
	declare @user varchar(50) = (
		
	select NombreUsuario 
			from Usuarios
				where convert(varchar(100),DecryptByPassPhrase('key', PasswordUsuario )) = @password
					and NombreUsuario = @userName
	
	);
	
	if(@user is null)
		begin
			select cast(0 as bit) as isOk
			return;
		end

		select cast(1 as bit) as isOk;

end

exec usp_InsertarUsuario 'mauri', '123'
go
create proc usp_ObtenerCredencialUsuario( @idUsuario int)
as
	begin
		select 
		u.idUsuario,
		u.NombreUsuario ,
		u.Estado,
		c.DescripcionCredencial

		from Usuarios as u
		join CredencialesUsuario as cred
		on cred.idUsuario = u.idUsuario
		join Credenciales as c
		on c.idCredencial = cred.idCredencial

		where u.idUsuario = @idUsuario
	end


go
--Requerimientos
go
create proc usp_ObtenerProgramadoresEnRequerimiento
(@idRequerimiento varchar(40)
)
as
begin
		declare @idLid varchar(50) = ( select 
											li.idLiderProyecto
										from Requerimientos as re
										join LiderProyecto as li
										on re.idLiderProyecto = li.idLiderProyecto
										join Usuarios as u
										on li.idUsuario = u.idUsuario
										where re.idRequerimiento = '0/2019' )

		select 
			e.idUsuario,
			(select NombreUsuario from Usuarios 
				where idUsuario = e.idUsuario ) as Programador
			from EquipoDeTrabajo as e
			where e.idLiderProyecto = @idLid;

end


go
create proc usp_InsertarRequerimiento
(
	@idRequerimiento varchar(50),
	@nombreRequerimiento  varchar(50), 
	@rutaRequerimiento  varchar(max),
	@idUsuario int,
	@idArea int,
	@idTipoRequerimiento int,
	@idEstadoRequerimiento int,
	@prioridad varchar(50)
)
as
begin
		insert into Requerimientos
	(
		idRequerimiento,
		NombreRequerimiento, 
		RutaRequerimiento,
		idUsuario,
		idArea,
		idTipoRequerimiento,
		FechaAsignacion,
		idEstadoRequerimiento,
		Prioridad
	)
		values 
		(
			@idRequerimiento,
			@nombreRequerimiento,
			@rutaRequerimiento,
			@idUsuario,
			@idArea,
			@idTipoRequerimiento,
			GETDATE(),
			@idEstadoRequerimiento,
			@prioridad
			
		)

end


exec usp_InsertarRequerimiento '01-2019',
'Formatos byte','c:/data',
null,1,1,1,'Alta'

go

go
create proc usp_ObtenerRequerimientos
as
	select * from Requerimientos;

go

create proc usp_ObtenerRequerimientosPorAsignacion
(
@tipoDeProyecto varchar(40)
)
as

begin

	if @tipoDeProyecto = 'Individual'
	begin
		select 
		req.idRequerimiento,
		req.NombreRequerimiento,
		req.RutaRequerimiento,
		area.NombreArea,
		reqTipo.idTipoRequerimiento,
		req.FechaAsignacion,
		estado.NombreEstado,
		req.Prioridad,
		usuario.NombreUsuario as Programador
		 from Requerimientos as req
		 join Areas as area
		 on req.idArea = area.idArea
		 join TipoDeRequerimiento as reqTipo
		 on reqTipo.idTipoRequerimiento = req.idTipoRequerimiento
		 join EstadosDeRequerimiento as estado
		 on req.idEstadoRequerimiento = estado.idEstadoRequerimiento
		 join Usuarios as usuario
		 on req.idUsuario = usuario.idUsuario;
	end

	if @tipoDeProyecto = 'Equipo'
	begin
		select 
		req.idRequerimiento,
		req.NombreRequerimiento,
		req.RutaRequerimiento,
		area.NombreArea,
		reqTipo.NombreTipoRequerimiento,
		req.FechaAsignacion,
		estado.NombreEstado,
		req.Prioridad,
		usuario.NombreUsuario as LiderDeProyecto
		 from Requerimientos as req
		 join Areas as area
		 on req.idArea = area.idArea
		 join TipoDeRequerimiento as reqTipo
		 on reqTipo.idTipoRequerimiento = req.idTipoRequerimiento
		 join EstadosDeRequerimiento as estado
		 on req.idEstadoRequerimiento = estado.idEstadoRequerimiento
		 join Lideres as lider
		 on req.id = lider.idLiderProyecto
		 join Usuarios as usuario
		 on lider.idUsuario = usuario.idUsuario;
	end
	
end

--

go
create proc usp_ObtenerRequerimientosPorProgramador
as
begin
	select  requerimiento.NombreRequerimiento, 
		requerimiento.idRequerimiento,
		requerimiento.FechaAsignacion,
		usuario.NombreUsuario as ProgramadorEncargado
	from Requerimientos as requerimiento 
		join Usuarios as usuario
		on requerimiento.idUsuario = usuario.idUsuario
end

go

create proc usp_ObtenerNoProgramadoresPorRequerimiento
as
begin
		declare @LiderProyect table (idLiderProyecto int, idUsuario int, noIntegrantes int);

		insert into @LiderProyect
		select 
				equipo.idLiderProyecto,
				lider.idUsuario,
				count(equipo.idUsuario) as NumeroIntegrantes
				
			from EquipoDeTrabajo as equipo
			join LiderProyecto as lider 
			on  equipo.idLiderProyecto = lider.idLiderProyecto
			group by equipo.idLiderProyecto, lider.idUsuario;
		--insertando en la tabla para compara datos
		select  lid.idLiderProyecto,
				usuario.NombreUsuario, 
				lid.idUsuario,
				lid.noIntegrantes as ProgramadoresEnEquipo

				from @LiderProyect as lid
				join Usuarios as usuario
				on lid.idUsuario = usuario.idUsuario;
		

end

go
--Procesos
create proc usp_ObtenerProcesos
as
	select * from Procesos;


go
create proc usp_InsertarProcesosPorRequerimientos
(
	@idProcesos int,
	@estadoProceso bit
)
as
begin
	insert into ProcesosPorProyecto
	(
		idProceso,
		EstadoProceso
	)
	values
	(
		@idProcesos,
		@estadoProceso
	)
end

go
create proc usp_InsertarProcesoPorProyecto
(@idProyecto int, @idProces int)
as
	insert into ProcesosPorProyecto(idProyecto,idProceso,EstadoProceso)
		values(@idProyecto, @idProces, 0);

go
create proc usp_ActualizarEstadoProcesoPorRequerimiento
(@idProceso int, @estado bit)
as
	update ProcesosPorProyecto
		set EstadoProceso = @estado
		where idProceso = @idProceso


go


go
--Permisos de IPS
create proc usp_ObtenerPermisosDeIPS
as
	select * from PermisosDePU;


go
create proc usp_InsertarPermisoDeIPS
(@nombre varchar(40))
as
	insert into  PermisosDePU(NombrePermiso) 
		values(@nombre);

go
--Otro
CREATE PROC usp_ObtenerObjetosDeSql
as
SELECT 
		name
		, MODIFY_DATE, 
         CASE TYPE 
		 WHEN 'V' THEN 'UVW' 
		 WHEN 'U' THEN 'TBL' 
		 WHEN 'P' THEN  'USP'
		 WHEN 'TT' THEN 'TBL-TYPES' 
		 WHEN 'IFN' THEN 'UFN' 
		 WHEN 'FN' THEN 'UFN' 

		 ELSE TYPE 
		 END AS TIPO_OBJETO
FROM SYS.OBJECTS
WHERE  MODIFY_DATE >= '2019-06-07 10:26:24.143' AND type IN ('U', 'P','TT','IF','FN') and name not like 'sp%'
ORDER BY name ,MODIFY_DATE


go
create proc usp_ObtenerPermisosPuRequeridos
(@idRequerimiento varchar(50))
as
begin
	select permiso.idPermisoPU,
				permiso.NombrePermiso
		 from Requerimientos as req
		join PermisosPorRequerimiento as pxReq
		on req.idRequerimiento = pxReq.idRequerimiento
		join PermisosDePU as permiso
		on pxReq.idPermisoPU = permiso.idPermisoPU
		where pxReq.idRequerimiento = @idRequerimiento
end

--falta agregar el procedimiento para almacenar los procesos desde el checkboxlist
select req.NombreRequerimiento,
		proceso.NombreProceso
	from Requerimientos as req
	join ProcesosPorRequerimiento as procXReq
	on req.idRequerimiento = procXReq.idRequerimiento
	join Procesos as proceso
	on procXReq.idProceso = proceso.idProceso
	where req.idRequerimiento = '01/2019'



go
create proc usp_
as
begin
	select	distinct
		e.idUsuario,
		u.NombreUsuario,
		r.NombreRequerimiento,
		e.idLiderProyecto as lider,
		(select top 1 NombreUsuario from Usuarios where idUsuario = e.idLiderProyecto) as Lide
	from EquipoDeTrabajo as e 
		join Requerimientos as r
		on e.idLiderProyecto = r.idLiderProyecto
		join Usuarios u
		on e.idUsuario = u.idUsuario
		where (select top 1 NombreUsuario from Usuarios where idUsuario = e.idLiderProyecto) <> u.NombreUsuario;

end







go
--Equipos de trabajo

create proc usp_ObtenerEquipos
as
	begin
	declare @nombreLider varchar(40) = (select usuario.NombreUsuario 
				 from Lideres as lider 
				join Usuarios as usuario
				on lider.idUsuario = usuario.idUsuario);
	 select 
			(select @nombreLider) as NombreLider,
			lider.idLiderProyecto,
			usuario.NombreUsuario  as Programador,
			usuario.idUsuario
		from EquipoDeTrabajo as equipo 
			join Usuarios as usuario
			on equipo.idUsuario = usuario.idUsuario
			join LiderProyecto as lider 
			on lider.idLiderProyecto = equipo.idLiderProyecto 
end

go
create proc usp_ObtenerEquipoDeTrabajo
as
	select * from EquipoDeTrabajo;

go
create proc usp_InsertarEquipoDeTrabajo
(@idLiderProyecto int, @idUsuario int)
as
	insert into EquipoDeTrabajo(idLiderProyecto,idUsuario) values(@idLiderProyecto,@idUsuario);

go
--Credenciales
create proc usp_ObtenerCredenciales
as
select * from Credenciales;

go 
create proc usp_ObtenerCredencialesUsuario
as
	select * from CredencialesUsuario;

go
create proc usp_InsertarCredencialUsuario
(@idCredencial int, @idUsuario int)
as
	insert into CredencialesUsuario(idCredencial,idUsuario) values(@idCredencial,@idUsuario);

go
create proc usp_InsertarCredencial(@descripcion varchar(100))
as
	insert into Credenciales(DescripcionCredencial) values (@descripcion)


go
--Permisos por proyecto
create proc usp_ObtenerPermisosPorProyecto
as
select * from PermisosPorProyecto;

go
create proc usp_InsertarPermisoPorProyecto
(@idRequerimiento varchar(40),
@idPermisoPU int,
@estado bit)
as
	insert into PermisosPorProyecto(idRequerimiento,idPermisoPU,EstadoPermiso)
		 values (@idRequerimiento, @idPermisoPU, @estado);


go
create proc usp_ObtenerProcesosPorProyecto
as
	select * from ProcesosPorProyecto;

go

--Tipo de requerimiento
create proc usp_ObtenerTipoRequerimiento
as 
select * from TipoDeRequerimiento;

go
create proc usp_InsertarTipoDeRequerimiento
(@nombreTipo varchar(40))
as
	insert into TipoDeRequerimiento(NombreTipoRequerimiento)
		values(@nombreTipo);


--Proyectos por programador

go
create proc usp_ObtenerProyectosPorIdProgramador
(@idUsuario int)
as
begin
	select  requerimiento.NombreRequerimiento, 
		requerimiento.idRequerimiento,
		requerimiento.FechaAsignacion,
		(select  NombreEstado from EstadosDeRequerimiento where idEstadoRequerimiento = requerimiento.idEstadoRequerimiento) as Estado
		from Requerimientos as requerimiento 
		join Usuarios as usuario
		on requerimiento.idUsuario = usuario.idUsuario
		where usuario.idUsuario =  @idUsuario

		union 

		select  requerimiento.NombreRequerimiento, 
		requerimiento.idRequerimiento,
		requerimiento.FechaAsignacion,
		(select  NombreEstado from EstadosDeRequerimiento where idEstadoRequerimiento = requerimiento.idEstadoRequerimiento) as Estado
		from Requerimientos as requerimiento 
		join EquipoDeTrabajo as e
		on requerimiento.idLiderProyecto = e.idLiderProyecto
		join Usuarios as u
		on  e.idUsuario = u.idUsuario
		where u.idUsuario = @idUsuario

end

go
--Hojas de traslado
create proc usp_Obtener
as


go
--Incidencias
create proc usp_ObtenerIncidencias
as
	select * from IncidenciasProduccion;


go
create proc usp_InsertarIncidencia
(
	@idIncidenciaProduccion varchar(40),
	@nombreIncidencia varchar(60),
	@DescripcionIncidencia varchar(200),
	@idUsuario int
)
as
	insert into IncidenciasProduccion(idIncidenciaProduccion,
				NombreIncidencia,
				DescripcionIncidencia,
				FechaDeEmision ,
				idUsuario) 
	values(@idIncidenciaProduccion,@nombreIncidencia,@DescripcionIncidencia,GETDATE(),@idUsuario);




go
create proc usp_ObtenerLiderProyecto
as
	select l.idLiderProyecto,u.NombreUsuario from LiderProyecto l
	join Usuarios u on u.idUsuario = l.idUsuario;


go
go
create proc usp_ObtenerUltimoIdDeIncidencia
as
begin
	declare  @year varchar(40) = YEAR(getdate());
	declare @ultimoId varchar(40) =  (SELECT TOP 1 idIncidenciaProduccion
										 FROM IncidenciasProduccion 
											ORDER BY idIncidenciaProduccion DESC);

	if @ultimoId is null
	begin
		select (select 'SR' + '001'+ '-' + @year) as idIncidenciaProduccion
	end

	else
	begin
		declare	@noIncidencia varchar(40) =   SUBSTRING(@ultimoId,3, len(@ultimoId)-7);
		set @noIncidencia += 1;
		declare @nuevoNumeroId varchar(20) =  RIGHT('00' + CAST(@noIncidencia AS VARCHAR(3)), 3)

		select 'SR'+@nuevoNumeroId+'-'+@year as idIncidenciaProduccion;
	end

	 
end



--Areas



go
create proc GuardarPermisosPorRequerimiento
(
	@idRequerimiento varchar(40),
	@idPermisoPU int, 
	@estado bit
)
as
insert into PermisosPorRequerimiento(idRequerimiento,idPermisoPU, EstadoProceso) 
values(@idRequerimiento,@idPermisoPU,@estado)





go
create proc usp_ObtenerUltimoIdDeRequerimiento
as
begin
	declare  @year varchar(40) = YEAR(getdate());
	declare @ultimoId varchar(40) =  (SELECT TOP 1 idRequerimiento
										 FROM Requerimientos 
											ORDER BY idRequerimiento DESC);

	if @ultimoId is null
	begin
		select (select '01'+ '-' + @year) as idRequerimiento
	end

	else
		begin
		declare @ul varchar(40) = (select  SUBSTRING(@ultimoId,0, charindex('-',@ultimoId, 0)) );
		set @ul += 1;
		declare @nuevoNumeroId varchar(20) =  RIGHT(CAST(@ul AS VARCHAR(3)), 3)

		select @nuevoNumeroId+'-'+@year as idRequerimiento;
		end
end

go

--Informacion Adicional
go
create proc usp_ObtenerInfoAdicional
as
	select * from InformacionAdicional;

go
create proc usp_InsertarInfoAdicional
(@rutaDercas varchar(100), @rutaPlan varchar(100))
as
	insert into InformacionAdicional(RutaDercas, RutaPlanTrabajo)
	values (@rutaDercas, @rutaPlan);

go
--Lideres
create proc usp_ObtenerLideres
as
	select * from Lideres;

go
create proc usp_InsertarLider
(@idLider int)
as
	insert into Lideres(idUsuario) values(@idLider)

go
--Notificaciones
create proc usp_ObtenerNotifacaciones
as
	select * from Notificaciones;

go
create proc usp_InsertarNotificacion
(@mensaje varchar(100), @fechaNotificacion datetime, @idActividad int)
as
	insert into Notificaciones(Mensaje,FechaNotificacion, idActividadProceso)
		values(@mensaje, @fechaNotificacion, @idActividad);



go
--Actividades por proceso
create proc usp_ObtenerActividadesPorProceso
as
	select * from ActividadesPorProceso;

go
create proc usp_InsertarActividadPorProceso
( @idProcesoProyecto int, @idInfoAdicional int, @fechaPromesa datetime, @fechaEntrega datetime, @estadoActividad bit )
as
	insert into ActividadesPorProceso(idProceso_Proyecto, idInfoAdicional, FechaIncio, FechaPromesa, FechaEntrega, EstadoActividadProceso)
		values(@idProcesoProyecto, @idInfoAdicional, GETDATE(),
		@fechaPromesa, @fechaEntrega, @estadoActividad
				);



go
--Areas

create proc usp_ObtenerAreas
as
select * from Areas;

go
--Estados de requerimiento

create proc usp_ObtenerEstadosDeRequerimiento
as
select * from EstadosDeRequerimiento;

go



create proc usp_InsertarAreas
(@nombre varchar(20))
as
	insert into Areas(NombreArea) values(@nombre);

go
--Datos hoja de traslado
create proc usp_ObtenerDatosDeHojaDeTraslado
as
	select * from DatosHoja;

go
create proc usp_InsertarDatosHoja
(@idHoja int, @idObjeto int)
as
	insert into DatosHoja(idHojaDeTraslado,idObjetoTraslado) 
		values(@idHoja, @idObjeto)

go
create proc usp_ObtenerHojasDeTrasladoDeProyectos
as
	select * from HojasDeTrasladoDeProyectos;

go
create proc usp_InsertarHojaDeTrasladoDeProyectos
(@fechaCreacion datetime, @idProyecto int)
as
	insert into  HojasDeTrasladoDeProyectos(FechaCreacion, idProyecto)
		values(@fechaCreacion,@idProyecto);

go
create proc usp_ObtenerObjetoTraslado
as
	select * from ObjetosDeTraslado;


go
--Proyectos
create proc usp_ObtenerProyectos
as
	select * from Proyectos;

go
create proc usp_InsertarProyecto
(@idRequerimiento varchar(50), @idLider int, @idUsuario int null)
as
	insert into Proyectos(idRequerimiento,idLiderProyecto,idUsuario)
		values(@idRequerimiento, @idLider, @idUsuario)


go
create proc usp_ObtenerProyectosEnEquipoDeProgramador
(@idUsuario int)
as

	select	
		proyecto.idRequerimiento,
		requerimiento.NombreRequerimiento,
		requerimiento.RutaRequerimiento
		from Proyectos as proyecto
		join  EquipoDeTrabajo as equipo
		on equipo.idLiderProyecto = proyecto.idLiderProyecto

		join Requerimientos as requerimiento
		on requerimiento.idRequerimiento = proyecto.idRequerimiento

		join Usuarios as usuario
		on usuario.idUsuario = equipo.idUsuario

		where equipo.idUsuario = @idUsuario