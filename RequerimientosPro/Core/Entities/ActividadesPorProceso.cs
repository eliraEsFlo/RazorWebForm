namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActividadesPorProceso")]
    public partial class ActividadesPorProceso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActividadesPorProceso()
        {
            Notificaciones = new HashSet<Notificaciones>();
        }

        [Key]
        public int idActividadProceso { get; set; }

        public int? idProceso_Proyecto { get; set; }

        public int? idInfoAdicional { get; set; }

        public DateTime FechaIncio { get; set; }

        public DateTime FechaPromesa { get; set; }

        public DateTime FechaEntrega { get; set; }

        public bool EstadoActividadProceso { get; set; }

        public virtual InformacionAdicional InformacionAdicional { get; set; }

        public virtual ProcesosPorProyecto ProcesosPorProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificaciones> Notificaciones { get; set; }
    }
}
