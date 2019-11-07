using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class RequerimientoViewModel
    {
        public string idRequerimiento { get; set; }


        public string NombreRequerimiento { get; set; }


        public string NombreArea { get; set; }

        public string NombreTipoRequerimiento { get; set; }

        public DateTime FechaAsignacion { get; set; }
        public string NombreEstado { get; set; }


        public string Prioridad { get; set; }

        public string NombreLider { get; set; }
    }
}