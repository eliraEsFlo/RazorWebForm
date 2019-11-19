namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosPorProyecto")]
    public partial class PermisosPorProyectoTable
    {
        [Key]
        public int idPermiso_Proyecto { get; set; }

        [Required]
        [StringLength(50)]
        public string idRequerimiento { get; set; }

        public int idPermisoPU { get; set; }

        public bool EstadoPermiso { get; set; }

        public virtual PermisosDePUTable PermisosDePU { get; set; }

        public virtual Requerimientos Requerimientos { get; set; }
    }
}
