using Backend.Infrastructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.DomainDataContract
{
    public interface IRequerimientosRepository
    {
        IEnumerable<Requerimientos> ObtenerRequerimientoPorTipoAsignacion(string tipoProyecto);
        List<Areas> ObtenerAreas();
        string ObtenerUltimoRequerimiento();

        List<TipoRequerimiento> ObtenerTiposRequerimientos();

        List<Procesos> ObtenerProcesos();

        List<PermisosDePU> ObtenerPermisosDePU();

        List<Programadores> ObtenerProgramadoresConId();

        string ObtenerUltimoIdDeRequerimiento();
        string ObtenerUltimoIdDeIndidencia();
    }
}
