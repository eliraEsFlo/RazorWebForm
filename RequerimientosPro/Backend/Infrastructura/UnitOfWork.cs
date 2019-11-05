using Backend.Infrastructura.ContextoDatos;
using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.Entities;
using Backend.Infrastructura.Interfaces;
using Backend.Infrastructura.Repositorios;

namespace Backend.Infrastructura
{

    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork()
        {

        }

        RequerimientosRepository _requerimientos;
        public IRequerimientosRepository Requerimientos
        {
            get { return _requerimientos ?? (_requerimientos = new RequerimientosRepository(  )); }
        }
        /*
     Repository<Cliente> _clientes;
     public IRepository<Cliente> Clientes
     {
         get { return _clientes ?? (_clientes = new Repository<Cliente>(new ClientesTable() )); }
     }

     Repository<Cuenta> _cuentas;
     public IRepository<Cuenta> Cuentas
     {
         get { return _cuentas ?? (_cuentas = new Repository<Cuenta>(new CuentasTable() )); }
     }


     Repository<Empleado> _empleados;
     public IRepository<Empleado> Empleados
     {
         get { return _empleados ?? (_empleados = new Repository<Empleado>(new EmpleadosTable())); }
     }


     Repository<Permiso> _permisos;
     public IRepository<Permiso> Permisos
     {
         get { return _permisos ?? (_permisos = new Repository<Permiso>(new PermisosTable())); }
     }

     Repository<Transaccion> _transacciones;
     public IRepository<Transaccion> Transacciones
     {
         get { return _transacciones ?? (_transacciones = new Repository<Transaccion>(new TransaccionTable())); }
     }

     Repository<Usuario> _usuarios;
     public IRepository<Usuario> Usuarios
     {
         get { return _usuarios ?? (_usuarios = new Repository<Usuario>(new UsuariosTable())); }
     }

     Repository<UsuarioPermiso> _usuariosPermisos;
     public IRepository<UsuarioPermiso> UsuariosPermisos
     {
         get { return _usuariosPermisos ?? (_usuariosPermisos = new Repository<UsuarioPermiso>(new UsuariosPermisoTable())); }
     }

     */
    }
}
