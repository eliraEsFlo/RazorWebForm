using MixingWebFormsMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MixingWebFormsMVC.Handlers
{
    /// <summary>
    /// Descripción breve de GetProjectsHandlers
    /// </summary>
    public class GetProjectsHandlers : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hola a todos");
            
            string stringConnection = "string";
            List<Requerimiento> requerimientos;


            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerRequerimientos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Requerimiento req = new Requerimiento.Builder()
                                             .ConIdRequerimiento(reader["idRequerimiento"].ToString())
                                             .ConNombreRequerimiento(reader["NombreRequerimiento"].ToString())
                                             .Build();
                }
            }

            List<Requerimiento> reqs = new List<Requerimiento>();

            JavaScriptSerializer js = new JavaScriptSerializer();
            var data =  js.Serialize(reqs);

            context.Response.Write(data);
        
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}