using ServiciosAplicacion.Services.LoginService;

namespace ServiciosAplicacion.Services
{
    public interface IGlobalServices
    {
        ILoginService ServicioDeAutenticacion { get; }
    }
    public class GlobalServices : IGlobalServices
    {
       
        public ILoginService ServicioDeAutenticacion { get; }

        public GlobalServices()
        {
            ServicioDeAutenticacion = new LoginServiceImp();
        }

    }
}