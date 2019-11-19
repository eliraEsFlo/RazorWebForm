using Core.Entities;

namespace ServiciosAplicacion.Services.LoginService
{
    public interface ILoginService
    {
        string Login(Usuarios usuario);
    }
    public class LoginServiceImp : ILoginService
    {
        IServicioAtenticacion<Usuarios> _servicioAtenticacion;

        public LoginServiceImp()
        {
            _servicioAtenticacion = new ServicioAtenticacion();
        }

        public string Login(Usuarios usuario)
        {
   
            bool noSeEncontroElUsuario = _servicioAtenticacion.ValidarUsuario(usuario) == false;

            if (noSeEncontroElUsuario)
            {
                return "no";
                
            }
            return "ok";
        }
    }
}