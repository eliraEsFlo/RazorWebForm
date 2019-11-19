namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyectos()
        {
            HojasDeTrasladoDeProyectos = new HashSet<HojasDeTrasladoDeProyectosTable>();
            ProcesosPorProyecto = new HashSet<ProcesosPorProyecto>();
        }

        [Key]
        public int idProyecto { get; set; }

        [StringLength(50)]
        public string idRequerimiento { get; set; }

        public int idTipoRequerimiento { get; set; }

        public int idLiderProyecto { get; set; }

        public int idUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HojasDeTrasladoDeProyectosTable> HojasDeTrasladoDeProyectos { get; set; }

        public virtual LideresTable Lideres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcesosPorProyecto> ProcesosPorProyecto { get; set; }

        public virtual Requerimientos Requerimientos { get; set; }

        public virtual TipoRequerimiento TipoRequerimiento { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
