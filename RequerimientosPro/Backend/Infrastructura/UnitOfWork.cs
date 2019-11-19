using Backend.Infrastructura.ContextoDatos;
using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.Interfaces;
using Backend.Infrastructura.ProcedimientosAlmacenados;
using Backend.Infrastructura.Repositorios;
using Backend.Infrastructura.TableServices;
using Core.Entities;

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
        
         Repository<Usuarios> _clientes;
         public IRepository<Usuarios> Programadores
            {
             get { return _clientes ?? (_clientes = new Repository<Usuarios>(new ProgramadoresTable() )); }
         }

        Repository<IncidenciasProduccion> _incidencias;
        public IRepository<IncidenciasProduccion> Incidencias
        {
            get { return _incidencias ?? (_incidencias = new Repository<IncidenciasProduccion>(new IncidenciasTable())); }
        }

        Repository<LiderProyecto> _lideres;
        public IRepository<LiderProyecto> LideresProyecto
        {
            get { return _lideres ?? (_lideres = new Repository<LiderProyecto>(new LiderProyectoTable())); }
        }

        public IRepository<Areas> Areas => new Repository<Areas>(new AreasTable());

        public IRepository<Credenciales> Credenciales => new Repository<Credenciales>(new CredencialesTable());

        public IRepository<CredencialesUsuario> CredencialesUsuario => new Repository<CredencialesUsuario>(new CredencialesUsuarioTable());

        public IRepository<EquipoDeTrabajo> EquiposDeTrabajo => new Repository<EquipoDeTrabajo>(new EquipoDeTrabajoTable());

        public IRepository<EstadosDeRequerimiento> EstadosRequerimientos => new Repository<EstadosDeRequerimiento>(new EstadosDeRequerimientoTable());

        public IRepository<PermisosDePUTable> PermisosDePU => new Repository<PermisosDePUTable>(new PermisosPUTable());

        public IRepository<PermisosPorRequerimiento> PermisosPorRequerimiento => new Repository<PermisosPorRequerimiento>(new PermisosPorRequerimientoTable());

        public IRepository<Procesos> Procesos => new Repository<Procesos>(new ProcesosTable());

        public IRepository<ProcesosPorRequerimiento> ProcesosPorRequerimiento => new Repository<ProcesosPorRequerimiento>(null);

        
        public IStoredProcedureRepository ProcedimientoAlmacenados => new StoredProcedureRepository();
    }
}
