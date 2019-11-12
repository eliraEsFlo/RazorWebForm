GO
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


--
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

--
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

--Llamar a tablas
go 
create proc usp_ObtenerRequerimientos
as
select * from Requerimientos;

go
create proc usp_ObtenerEquipoDeTrabajo
as
select * from EquipoDeTrabajo;

go
create proc usp_ObtenerCredenciales
as
select * from Credenciales;

go 
create proc usp_ObtenerCredencialesUsuario
as
select * from CredencialesUsuario;

go
create proc usp_ObtenerPermisosPorRequerimiento
as
select * from PermisosPorRequerimiento;

go
create proc usp_ObtenerProcesosPorRequerimiento
as
select * from ProcesosPorRequerimiento;

go
create proc usp_ObtenerTipoRequerimiento
as
select * from TipoRequerimiento;

--
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
create proc usp_ObtenerIncidencias
as
	select * from IncidenciasProduccion;

go
create proc usp_InsertarEquiposDeTrabajo
(
	@idLiderProyecto int ,
	@idUsuario int
)
as
	insert into EquipoDeTrabajo(idLiderProyecto, idUsuario) values(@idLiderProyecto,@idUsuario);

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
create proc usp_InsertarLiderProyecto(@idUsuario int)
as
	insert into LiderProyecto(idUsuario) values(@idUsuario);


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
		select (select '01'+ '/' + @year) as idRequerimiento
	end

	else
		begin
		declare @ul varchar(40) = (select  SUBSTRING(@ultimoId,0, charindex('/',@ultimoId, 0)) );
		set @ul += 1;
		declare @nuevoNumeroId varchar(20) =  RIGHT(CAST(@ul AS VARCHAR(3)), 3)

		select @nuevoNumeroId+'/'+@year as idRequerimiento;
		end
end


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
		select (select 'SR' + '001'+ '-' + @year) as NuevoId
	end

	else
	begin
		declare	@noIncidencia varchar(40) =   SUBSTRING(@ultimoId,3, len(@ultimoId)-7);
		set @noIncidencia += 1;
		declare @nuevoNumeroId varchar(20) =  RIGHT('00' + CAST(@noIncidencia AS VARCHAR(3)), 3)

		select 'SR'+@nuevoNumeroId+'-'+@year as idIncidenciaProduccion;
	end

	 
end



go
create proc usp_ObtenerProgramadoresConId
as
select idUsuario, NombreUsuario from Usuarios;


--
go
create proc usp_ObtenerAreas
as
select * from Areas;

--
go
create proc usp_ObtenerTiposRequerimiento
as
select  * from TipoRequerimiento;

--

go
create proc usp_ObtenerProcesos
as
	select * from Procesos;
go
create proc usp_GuardarProcesosPorRequerimientos
(
	@idRequerimiento varchar(50),
	@idProcesos int,
	@estadoProceso bit
)
as
begin
	insert into ProcesosPorRequerimiento
	(
		idRequerimiento,
		idProceso,
		EstadoProceso
	)
	values
	(
		@idRequerimiento,
		@idProcesos,
		@estadoProceso
	)
end

go
--Crear un pnanel para poder agregar nuevos permisos
--O eliminar permisos
create proc usp_ObtenerPermisosDePU
as
	select * from PermisosDePU;
go
create proc usp_ObtenerEstadosDeRequerimiento
as
select * from EstadosDeRequerimiento;
--

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
		reqTipo.NombreTipoRequerimiento,
		req.FechaAsignacion,
		estado.NombreEstado,
		req.Prioridad,
		usuario.NombreUsuario as Programador
		 from Requerimientos as req
		 join Areas as area
		 on req.idArea = area.idArea
		 join TipoRequerimiento as reqTipo
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
		 join TipoRequerimiento as reqTipo
		 on reqTipo.idTipoRequerimiento = req.idTipoRequerimiento
		 join EstadosDeRequerimiento as estado
		 on req.idEstadoRequerimiento = estado.idEstadoRequerimiento
		 join LiderProyecto as lider
		 on req.idLiderProyecto = lider.idLiderProyecto
		 join Usuarios as usuario
		 on lider.idUsuario = usuario.idUsuario;
	end
	
end

--
go
create proc usp_InsertarRequerimiento
(
	@idRequerimiento varchar(50),
	@nombreRequerimiento  varchar(50), 
	@rutaRequerimiento  varchar(max),
	@idArea int,
	@idTipoRequerimiento int,
	@idEstadoRequerimiento int,
	@prioridad varchar(50),
	@idUsuario int ,
	@idLiderProyecto int
)
as
begin
	insert into Requerimientos
	(
		idRequerimiento,
		NombreRequerimiento, 
		RutaRequerimiento,
		idArea,
		idTipoRequerimiento,
		FechaAsignacion,
		idEstadoRequerimiento,
		Prioridad,
		idUsuario,
		idLiderProyecto
	)
		values 
		(
			@idRequerimiento,
			@nombreRequerimiento,
			@rutaRequerimiento,
			@idArea,
			@idTipoRequerimiento,
			GETDATE(),
			@idEstadoRequerimiento,
			@prioridad,
			@idUsuario,
			@idLiderProyecto
		)

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

--
create proc usp_ObtenerEquipos
as
begin
	declare @nombreLider varchar(40) = (select usuario.NombreUsuario 
				 from LiderProyecto as lider 
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

--
create proc usp_ObtenerNoProgramadoresPorRequerimiento
as
begin

		--tabla temp para sacar los datos a comparar
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
