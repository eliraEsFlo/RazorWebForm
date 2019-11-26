using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.ProcedimientosAlmacenados.Command;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Infrastructura.ContextoDatos
{
    public class RequerimientosRepository : IRequerimientosRepository
    {
        public RequerimientosRepository()
        {
            _storedProceduresService = new SqlStoredProcedureServiceManager();
        }

        public string ObtenerUltimoRequerimiento()
        {
            string idRequerimiento = "";

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerUltimoIdDeRequerimiento")
                .Build();

            idRequerimiento = _storedProceduresService
                                    .GetAnyDataByCommand<string>(cmd)
                                          .First();
            SQLConfiguration.Close();
            return idRequerimiento;
        }


        public IEnumerable<Requerimiento> ObtenerRequerimientoPorTipoAsignacion(string tipoProyecto)
        {
            List<Requerimiento> requerimientos = new List<Requerimiento>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerRequerimientosPorAsignacion")
                .WithParameter<string>("", tipoProyecto)
                .Build();

            requerimientos = _storedProceduresService.GetAnyDataByCommand<Requerimiento>(cmd);
            SQLConfiguration.Close();
            return requerimientos;
        }


        public List<TipoRequerimiento> ObtenerTiposRequerimientos()
        {
            List<TipoRequerimiento> tipoRequerimientos = new List<TipoRequerimiento>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerTipoRequerimiento")
                .Build();

            tipoRequerimientos = _storedProceduresService.GetAnyDataByCommand<TipoRequerimiento>(cmd);
            SQLConfiguration.Close();
            return tipoRequerimientos;
        }

        public List<Procesos> ObtenerProcesos()
        {
            _storedProceduresService = new SqlStoredProcedureServiceManager();

            List<Procesos> procesosPorRequerimiento = new List<Procesos>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerProcesos")
                .Build();
            procesosPorRequerimiento = _storedProceduresService.GetAnyDataByCommand<Procesos>(cmd);

            return procesosPorRequerimiento;
        }

        public List<PermisosDePU> ObtenerPermisosDePU()
        {

            List<PermisosDePU> permisosDePU = new List<PermisosDePU>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerPermisosDeIPS")
                .Build();
            permisosDePU = _storedProceduresService.GetAnyDataByCommand<PermisosDePU>(cmd);
            SQLConfiguration.Close();
            return permisosDePU;
        }

        public List<Usuarios> ObtenerProgramadoresConId()
        {

            List<Usuarios> usuariosConId = new List<Usuarios>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerUsuarios")
                .Build();

            usuariosConId = _storedProceduresService.GetAnyDataByCommand<Usuarios>(cmd);
            SQLConfiguration.Close();
            return usuariosConId;

        }

        public List<Areas> ObtenerAreas()
        {
            List<Areas> areas = new List<Areas>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerAreas")
                .Build();
            areas = _storedProceduresService.GetAnyDataByCommand<Areas>(cmd);

            SQLConfiguration.Close();

            return areas;
        }

        public String ObtenerUltimoIdDeRequerimiento()
        {
            string idRequerimiento;
            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerUltimoIdDeRequerimiento")
                .Build();
            idRequerimiento = _storedProceduresService.GetAnyDataByCommand<Requerimientos>(cmd)
                .FirstOrDefault().idRequerimiento;

            SQLConfiguration.Close();
            return idRequerimiento;
        }

        public string ObtenerUltimoIdDeIndidencia()
        {
            string idIncidencia = "";

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerUltimoIdDeIncidencia")
                .Build();

            idIncidencia = _storedProceduresService.GetAnyDataByCommand<IncidenciasProduccion>(cmd)
                                    .LastOrDefault().idIncidenciaProduccion;
            return idIncidencia;
        }

        public bool InsertarRequerimiento(Requerimientos requerimiento)
        {

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_InsertarRequerimiento")
                .WithParameter<string>("idRequerimiento", requerimiento.idRequerimiento)
                .WithParameter<string>("nombreRequerimiento", requerimiento.NombreRequerimiento)
                .WithParameter<string>("rutaRequerimiento", requerimiento.RutaRequerimiento)
                .WithParameter<int>("idArea", requerimiento.idArea)
                .WithParameter<string>("prioridad", requerimiento.Prioridad)
                .WithParameter<int?>("idUsuario", requerimiento.idUsuario)
                .Build();

            bool queryIsOk = cmd.Excecute() == 1 ? true : false;

            if (queryIsOk)
            {
                foreach (var permiso in requerimiento.PermisosPorProyecto)
                {
                          new CommandSender.Builder()
                            .SetProcedureName("GuardarPermisosPorRequerimiento")
                            .WithParameter<string>("idRequerimiento", requerimiento.idRequerimiento)
                            .WithParameter<int>("idPermisoPU", permiso.idPermisoPU)
                            .WithParameter<bool>("estado", permiso.EstadoPermiso)
                            .Build()
                            .Excecute();

                }
                SQLConfiguration.Close();
                return true;
            }
            SQLConfiguration.Close();
            return false;

        }


        public bool InsertarIncidencia(IncidenciasProduccion incidencia)
        {
            bool queryIsOk =  new CommandSender.Builder()
                .SetProcedureName("usp_InsertarIncidencia")
                .WithParameter<string>("idIncidenciaProduccion",incidencia.idIncidenciaProduccion)
                .WithParameter<string>("nombreIncidencia",incidencia.NombreIncidencia)
                .WithParameter<string>("DescripcionIncidencia",incidencia.DescripcionIncidencia)
                .WithParameter<int>("idUsuario",incidencia.idUsuario)
                .Build()
                .Excecute() == 1 ? true : false;

            SQLConfiguration.Close();
            return queryIsOk;
        }

        public int ExecuteComman()
        {
            return new CommandSender.Builder()
                .SetProcedureName("usp_InsertarEquiposDeTrabajo")
                .Build()
                .Excecute();
        }


        public bool InsertarEquiposDeTrabajo(int idLider, List<Usuarios> programadoresDelEquipo)
        {
            bool isQueryOk = false;
            programadoresDelEquipo.ForEach( p => {

               isQueryOk = new CommandSender.Builder()
                    .SetProcedureName("usp_InsertarEquiposDeTrabajo")
                    .WithParameter<int>("idLiderProyecto", idLider)
                    .WithParameter<int>("idUsuario", p.idUsuario)
                    .Build()
                    .Excecute() == 1 ? true : false;
            });

            SQLConfiguration.Close();
            return isQueryOk;

        }

        public List<EstadosDeRequerimiento> ObtenerEstadoRequerimiento()
        {
            List<EstadosDeRequerimiento> estados = new List<EstadosDeRequerimiento>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerEstadosDeRequerimiento")
                .Build();

            estados = _storedProceduresService.GetAnyDataByCommand<EstadosDeRequerimiento>(cmd);
            SQLConfiguration.Close();
            return estados;
        }


        public List<ProyectosPorProgramador> ObtenerProyectosPorIdProgramador(int id)
        {
            List<ProyectosPorProgramador> proyectos = new List<ProyectosPorProgramador>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerProyectosPorIdProgramador")
                .WithParameter<int>("idUsuario",id)
                .Build();

            proyectos = _storedProceduresService.GetAnyDataByCommand<ProyectosPorProgramador>(cmd);
            SQLConfiguration.Close();
            return proyectos;

        }

        

        public CommandSender CreateCommandWithoutParams(string proc) => new CommandSender.Builder()
                .SetProcedureName(proc)
                .Build();

        SqlStoredProcedureServiceManager _storedProceduresService;
        public List<Requerimientos> GetAll()
        {
            _storedProceduresService = new SqlStoredProcedureServiceManager();
            List<Requerimientos> requerimientos = new List<Requerimientos>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("ObtenerRequrimientos")
                .Build();

            requerimientos = _storedProceduresService.GetAnyDataByCommand<Requerimientos>(cmd);

            SQLConfiguration.Close();
            return requerimientos;
        }

        public List<Usuarios> ObtenerProgramdoresEnRequerimiento(string idRequerimiento)
        {
            _storedProceduresService = new SqlStoredProcedureServiceManager();

            CommandSender cmd = new CommandSender.Builder()
                                     .SetProcedureName("usp_ObtenerProgramadoresEnRequerimiento")
                                        .Build();
            List<Usuarios> proyectos = _storedProceduresService
                .GetAnyDataByCommand<Usuarios>(cmd);
            return proyectos;
        }

        public List<PermisosDePU> ObtenerPermisosPuRequeridos(string idRequerimiento)
        {
            List<PermisosDePU> proyectos = new List<PermisosDePU>();

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerPermisosPuRequeridos")
                .WithParameter<string>("idRequerimiento", idRequerimiento)
                .Build();

            proyectos = _storedProceduresService.GetAnyDataByCommand<PermisosDePU>(cmd);
                SQLConfiguration.Close();
        
            return proyectos;
        }
    }

}