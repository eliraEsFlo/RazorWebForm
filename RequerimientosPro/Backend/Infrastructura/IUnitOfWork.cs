using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.Entities;
using Backend.Infrastructura.Interfaces;

namespace Backend.Infrastructura
{
    public interface IUnitOfWork
    {

         IRequerimientosRepository Requerimientos { get; }
        /*eta clase me ayudara a administradar todos los repositorios que esten implemtados en los servidios que 
         llaman a las procedimientos almacenados y este será injectado para poder administrar la estructura de datos.*/
        /*
        IRepository<Agencia> Agencias { get; }
        IRepository<Cliente> Clientes { get; }
        IRepository<Cuenta> Cuentas { get; }
        IRepository<Empleado> Empleados { get; }
        IRepository<Permiso> Permisos { get; }
        IRepository<Transaccion> Transacciones { get; }
        IRepository<Usuario> Usuarios { get; }
        IRepository<UsuarioPermiso> UsuariosPermisos { get; }
        */
    }
}
