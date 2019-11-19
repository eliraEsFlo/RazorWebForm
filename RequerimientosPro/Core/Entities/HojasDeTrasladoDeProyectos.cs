namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HojasDeTrasladoDeProyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HojasDeTrasladoDeProyectos()
        {
            DatosHoja = new HashSet<DatosHoja>();
        }

        [Key]
        public int idHojaDeTraslado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int idProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosHoja> DatosHoja { get; set; }

        public virtual Proyectos Proyectos { get; set; }
    }
}
