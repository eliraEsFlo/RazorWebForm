using Backend.Infrastructura.ProcedimientosAlmacenados;
using Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace ServiciosAplicacion.Services.LoginService
{
    public interface IServicioAtenticacion<T> where T : class
    {
       bool ValidarUsuario(T usuario);
    }
    public class ServicioAtenticacion : IServicioAtenticacion<Usuarios>
    {
        IStoredProcWritter<Usuarios> _usp;

        public ServicioAtenticacion()
        {
            _usp = new UserStoredProcedure();
        }
        public bool ValidarUsuario(Usuarios usuario)
        {
            List<Usuarios> u = GetUserIfExist(usuario);

           if(u == null)
                return false;

            bool userExist =  u.FirstOrDefault() != null ? true: false;

            return userExist;
        }

        public List<Usuarios> GetUserIfExist(Usuarios usuario) {
            List<Usuarios> usuarioBuscado = _usp.CallStoredProcedure(usuario);
            return usuarioBuscado;
        } 
    }
}