namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NotificacionesTable
    {
        [Key]
        public int idNotificacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Mensaje { get; set; }

        public DateTime FechaNotificacion { get; set; }

        public int? idActividadProceso { get; set; }

        public virtual ActividadesPorProcesoTable ActividadesPorProceso { get; set; }
    }
}
