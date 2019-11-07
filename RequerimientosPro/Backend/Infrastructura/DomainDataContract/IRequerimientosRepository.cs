using Backend.Infrastructura.Entities;
using System.Collections.Generic;

namespace Backend.Infrastructura.DomainDataContract
{
    public interface IRequerimientosRepository
    {
        IEnumerable<Requerimiento> ObtenerRequerimientoPorTipoAsignacion(string tipoProyecto);
        List<Areas> ObtenerAreas();
        string ObtenerUltimoRequerimiento();

        List<TipoRequerimiento> ObtenerTiposRequerimientos();

        List<Procesos> ObtenerProcesos();

        List<PermisosDePU> ObtenerPermisosDePU();

        List<Programadores> ObtenerProgramadoresConId();

        string ObtenerUltimoIdDeRequerimiento();
        string ObtenerUltimoIdDeIndidencia();

        bool InsertarRequerimiento(Requerimientos requerimiento);
        bool InsertarIncidencia(IncidenciasProduccion incidencia);

        bool InsertarEquiposDeTrabajo(Programadores lider, List<Programadores> programadores);

        List<ProyectosPorProgramador> ObtenerProyectosPorIdProgramador(int id);
    }
}
