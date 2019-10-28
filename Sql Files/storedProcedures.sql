go
create PROC usp_ValidarUsuario
( @userName VARCHAR(50),
	@password VARCHAR(50)
)
AS
begin
SELECT CASE WHEN NombreUsuario = @userName and 
		PasswordUsuario = HASHBYTES('sha1', @password) THEN  cast(1 as bit)
		ELSE   cast(0 as bit) end as TieneAcceso
	
FROM Usuarios;
end

