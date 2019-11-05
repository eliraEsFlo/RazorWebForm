using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixingWebFormsMVC.Models
{
    public class Requerimiento
    {
        public String IdRequerimiento { get; set; }
        public String NombreRequerimiento { get; set; }
        public String RutaRequerimiento { get; set; }
        public int IdArea { get; set; }
        public String TipoRequerimiento { get; set; }
        public String EstadoRequerimiento { get; set; }
        public String Prioridad { get; set; }

        public class Builder
        {
            private readonly Requerimiento _requerimiento;
            public Builder()
            {
                _requerimiento = new Requerimiento();
            }

            public Builder ConIdRequerimiento(String id) { _requerimiento.IdRequerimiento = id; return this; }
            public Builder ConNombreRequerimiento(String nombre) { _requerimiento.NombreRequerimiento = nombre; return this; }

            public Requerimiento Build() => _requerimiento;
        }
    }
}