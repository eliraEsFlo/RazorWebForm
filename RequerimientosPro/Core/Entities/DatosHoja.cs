namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatosHoja")]
    public partial class DatosHoja
    {
        [Key]
        public int idDatosHoja { get; set; }

        public int idHojaDeTraslado { get; set; }

        public int idObjetoTraslado { get; set; }

        public virtual HojasDeTrasladoDeProyectos HojasDeTrasladoDeProyectos { get; set; }

        public virtual ObjetosDeTraslado ObjetosDeTraslado { get; set; }
    }
}
