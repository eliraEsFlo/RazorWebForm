select PermisoUsuarioId, UsuarioId, permiso.Descripcion as DescripcionPermiso,
  permiso.PermisoId
from Permisos_Usuario permisoUs
join Permisos permiso on  permisoUs.PermisoId = permiso.PermisoId 