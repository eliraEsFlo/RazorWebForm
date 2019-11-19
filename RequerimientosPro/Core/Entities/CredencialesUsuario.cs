namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CredencialesUsuario")]
    public partial class CredencialesUsuario
    {
        [Key]
        public int idCredencial_Usuario { get; set; }

        public int idCredencial { get; set; }

        public int idUsuario { get; set; }

        public virtual Credenciales Credenciales { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
