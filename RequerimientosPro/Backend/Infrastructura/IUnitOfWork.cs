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


        IRepository<Usuarios> Programadores { get; }
        IRepository<IncidenciasProduccion> Incidencias { get; }

        IRepository<LiderProyecto> LideresProyecto { get; }

        IRepository<PermisosDePU> PermisosDePU { get; }

        IRepository<PermisosPorRequerimiento> PermisosPorRequerimiento { get; }



        IRepository<ProcesosPorRequerimiento> ProcesosPorRequerimiento { get; }



    }
}
