using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.Interfaces;
using Backend.Infrastructura.ProcedimientosAlmacenados;
using Backend.Infrastructura.TableServices;
using Core.Entities;

namespace Backend.Infrastructura
{
    public interface IUnitOfWork
    {
        IStoredProcedureRepository ProcedimientoAlmacenados { get; }
         IRequerimientosRepository Requerimientos { get; }

        IRepository<Areas> Areas { get; }
        IRepository<Credenciales> Credenciales { get; }

        IRepository<CredencialesUsuario> CredencialesUsuario { get; }

        IRepository<EquipoDeTrabajo> EquiposDeTrabajo { get; }

        IRepository<EstadosDeRequerimiento> EstadosRequerimientos { get; }

        IRepository<Usuarios> Programadores { get; }
        IRepository<IncidenciasProduccion> Incidencias { get; }

        IRepository<LiderProyecto> LideresProyecto { get; }

        IRepository<PermisosDePUTable> PermisosDePU { get; }

        IRepository<PermisosPorRequerimiento> PermisosPorRequerimiento { get; }



        IRepository<ProcesosPorRequerimiento> ProcesosPorRequerimiento { get; }



    }
}
