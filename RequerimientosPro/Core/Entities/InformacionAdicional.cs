namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformacionAdicional")]
    public partial class InformacionAdicional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InformacionAdicional()
        {
            ActividadesPorProceso = new HashSet<ActividadesPorProceso>();
        }

        [Key]
        public int idInfoAdicional { get; set; }

        [Required]
        [StringLength(200)]
        public string RutaDercas { get; set; }

        [Required]
        [StringLength(200)]
        public string RutaPlanTrabajo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActividadesPorProceso> ActividadesPorProceso { get; set; }
    }
}
