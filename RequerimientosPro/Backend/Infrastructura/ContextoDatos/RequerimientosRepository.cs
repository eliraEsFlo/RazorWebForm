using Backend.Infrastructura.DomainDataContract;
using Backend.Infrastructura.Entities;
using Backend.Infrastructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Backend.Infrastructura.ContextoDatos
{
    public class RequerimientosRepository : IRequerimientosRepository
    {
        public RequerimientosRepository()
        {
        }

        public string ObtenerUltimoRequerimiento()
        {
            string idRequerimiento = "";
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerUltimoIdDeRequerimiento", instance.GetConnection());
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    idRequerimiento = reader["IdRequerimiento"].ToString();
                }
            }
            return idRequerimiento;
        }


        public IEnumerable<Requerimientos> ObtenerRequerimientoPorTipoAsignacion(string tipoProyecto)
        {
            List<Requerimientos> requerimientos = new List<Requerimientos>();
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerRequerimientosPorAsignacion", instance.GetConnection());    
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@tipoDeProyecto", SqlDbType.VarChar, 40).Value = tipoProyecto;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    requerimientos.Add(new Requerimientos()
                    {
                        idRequerimiento = reader["idRequerimiento"].ToString(),
                        NombreRequerimiento = reader["NombreRequerimiento"].ToString()
                    });
                }
            }

            return requerimientos;
        }


  

        public List<TipoRequerimiento> ObtenerTiposRequerimientos()
        {
            List<TipoRequerimiento> tipoRequerimientos = new List<TipoRequerimiento>();

            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerTiposRequerimiento",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tipoRequerimientos.Add
                    (
                        new TipoRequerimiento()
                        {
                            idTipoRequerimiento = (int)reader["idTipoRequerimiento"],
                            NombreTipoRequerimiento = reader["NombreTipoRequerimiento"].ToString()
                        }
                    );
                }
            }
            return tipoRequerimientos;
        }

        public List<Procesos> ObtenerProcesos()
        {
           
            List<Procesos> procesosPorRequerimiento = new List<Procesos>();

            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerProcesos",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    procesosPorRequerimiento.Add
                    (
                        new Procesos()
                        {
                            idProceso = (int)reader["idProceso"],
                            NombreProceso = reader["NombreProceso"].ToString()
                        }
                    );
                }
            }
            return procesosPorRequerimiento;
        }

        public List<PermisosDePU> ObtenerPermisosDePU()
        {
            
            List<PermisosDePU> permisosDePU = new List<PermisosDePU>();

            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerPermisosDePU",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    permisosDePU.Add
                    (
                        new PermisosDePU()
                        {
                            idPermisoPU = (int)reader["idPermisoPU"],
                            NombrePermiso = reader["NombrePermiso"].ToString()
                        }
                    );
                }
            }
            return permisosDePU;
        }

        public List<Programadores> ObtenerProgramadoresConId()
        {

            List<Programadores> usuariosConId = new List<Programadores>();

            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerProgramadoresConId",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuariosConId.Add
                    (
                        new Programadores()
                        {
                             idUsuario = (int)reader["idUsuario"],
                            NombreUsuario = reader["NombreUsuario"].ToString()
                        }
                    );
                }
            }
            return usuariosConId;

        }

        public List<Areas> ObtenerAreas()
        {
            List<Areas> areas = new List<Areas>();
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerAreas",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    areas.Add
                    (
                        new Areas()
                        {
                            idArea = (int)reader["IdArea"],
                            NombreArea = reader["NombreArea"].ToString()
                        }
                    ); ;
                }
            }
            return areas;
        }

        public string ObtenerUltimoIdDeRequerimiento()
        {
            string idRequerimiento = "";
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerUltimoIdDeRequerimiento",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idRequerimiento = reader["idRequerimiento"].ToString();
                }
            }
            return idRequerimiento;
        }

        public string ObtenerUltimoIdDeIndidencia()
        {
            string idIncidencia = "";
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_ObtenerUltimoIdDeIncidencia",
                    instance.GetConnection());

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idIncidencia = reader["NuevoId"].ToString();
                }
            }
            return idIncidencia;
        }
    }
}
