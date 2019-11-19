namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProcesosPorProyecto")]
    public partial class ProcesosPorProyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcesosPorProyecto()
        {
            ActividadesPorProceso = new HashSet<ActividadesPorProcesoTable>();
        }

        [Key]
        public int idProceso_Proyecto { get; set; }

        public int idProyecto { get; set; }

        public int idProceso { get; set; }

        public bool EstadoProceso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActividadesPorProcesoTable> ActividadesPorProceso { get; set; }



        public virtual Proyectos Proyectos { get; set; }
    }
}
