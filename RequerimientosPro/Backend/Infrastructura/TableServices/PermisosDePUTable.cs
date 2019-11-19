namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosDePU")]
    public partial class PermisosDePUTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermisosDePUTable()
        {
            PermisosPorProyecto = new HashSet<PermisosPorProyectoTable>();
        }

        [Key]
        public int idPermisoPU { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePermiso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermisosPorProyectoTable> PermisosPorProyecto { get; set; }
    }
}
