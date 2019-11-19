namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Requerimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requerimientos()
        {
            PermisosPorProyecto = new HashSet<PermisosPorProyecto>();
            Proyectos = new HashSet<Proyectos>();
        }


        public int idUsuario { get; set; }
        public int idTipoRequerimiento { get; set; }

        [Key]
        [StringLength(50)]
        public string idRequerimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreRequerimiento { get; set; }

        [Required]
        public string RutaRequerimiento { get; set; }

        public int idArea { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public int? idEstadoRequerimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Prioridad { get; set; }

        public virtual Areas Areas { get; set; }

        public virtual EstadosDeRequerimiento EstadosDeRequerimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermisosPorProyecto> PermisosPorProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyectos> Proyectos { get; set; }
    }
}
