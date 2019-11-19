namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ObjetosDeTraslado")]
    public partial class ObjetosDeTraslado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ObjetosDeTraslado()
        {
            DatosHoja = new HashSet<DatosHoja>();
        }

        [Key]
        public int idObjetoTraslado { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreServidorOrigen { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreObjeto { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        [Required]
        [StringLength(200)]
        public string RutaOrigenObjeto { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreServidorDestino { get; set; }

        [Required]
        [StringLength(200)]
        public string RutaObjetoDestino { get; set; }

        [StringLength(50)]
        public string TipoDeObjeto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosHoja> DatosHoja { get; set; }
    }
}
