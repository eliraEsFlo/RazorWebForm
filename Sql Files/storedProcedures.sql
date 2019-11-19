 go
 create proc usp_ObtenerUsuarios
 as
 select idUsuario,NombreUsuario, PasswordUsuario from usuarios



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
		select (select '01'+ '/' + @year) as IdNuevo
	end

	else
	begin
		declare	@noReque varchar(40) =   SUBSTRING(@ultimoId,1, len(@ultimoId)-5);
		set @noReque += 1;
		declare @nuevoNumeroId varchar(20) =  RIGHT('00' + CAST(@noReque AS VARCHAR(3)), 3)

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
create proc usp_ObtenerRequerimientosPorEquipo
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

select * from Requerimientos

--
