namespace Backend.Infrastructura.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AttReqDataContext : DbContext
    {
        public AttReqDataContext()
            : base("name=AttReqDataContext")
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Credenciales> Credenciales { get; set; }
        public virtual DbSet<CredencialesUsuario> CredencialesUsuario { get; set; }
        public virtual DbSet<EquipoDeTrabajo> EquipoDeTrabajo { get; set; }
        public virtual DbSet<EstadosDeRequerimiento> EstadosDeRequerimiento { get; set; }
        public virtual DbSet<IncidenciasProduccion> IncidenciasProduccion { get; set; }
        public virtual DbSet<LiderProyecto> LiderProyecto { get; set; }
        public virtual DbSet<PermisosDePU> PermisosDePU { get; set; }
        public virtual DbSet<PermisosPorRequerimiento> PermisosPorRequerimiento { get; set; }
        public virtual DbSet<Procesos> Procesos { get; set; }
        public virtual DbSet<ProcesosPorRequerimiento> ProcesosPorRequerimiento { get; set; }
        public virtual DbSet<Requerimientos> Requerimientos { get; set; }
        public virtual DbSet<TipoRequerimiento> TipoRequerimiento { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>()
                .Property(e => e.NombreArea)
                .IsUnicode(false);

            modelBuilder.Entity<Areas>()
                .HasMany(e => e.Requerimientos)
                .WithRequired(e => e.Areas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Credenciales>()
                .Property(e => e.DescripcionCredencial)
                .IsUnicode(false);

            modelBuilder.Entity<Credenciales>()
                .HasMany(e => e.CredencialesUsuario)
                .WithRequired(e => e.Credenciales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosDeRequerimiento>()
                .Property(e => e.NombreEstado)
                .IsUnicode(false);

            modelBuilder.Entity<IncidenciasProduccion>()
                .Property(e => e.idIncidenciaProduccion)
                .IsUnicode(false);

            modelBuilder.Entity<IncidenciasProduccion>()
                .Property(e => e.NombreIncidencia)
                .IsUnicode(false);

            modelBuilder.Entity<IncidenciasProduccion>()
                .Property(e => e.DescripcionIncidencia)
                .IsUnicode(false);

            modelBuilder.Entity<LiderProyecto>()
                .HasMany(e => e.EquipoDeTrabajo)
                .WithRequired(e => e.LiderProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermisosDePU>()
                .Property(e => e.NombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<PermisosDePU>()
                .HasMany(e => e.PermisosPorRequerimiento)
                .WithRequired(e => e.PermisosDePU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermisosPorRequerimiento>()
                .Property(e => e.idRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Procesos>()
                .Property(e => e.NombreProceso)
                .IsUnicode(false);

            modelBuilder.Entity<Procesos>()
                .HasMany(e => e.ProcesosPorRequerimiento)
                .WithRequired(e => e.Procesos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcesosPorRequerimiento>()
                .Property(e => e.idRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Requerimientos>()
                .Property(e => e.idRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Requerimientos>()
                .Property(e => e.NombreRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Requerimientos>()
                .Property(e => e.RutaRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Requerimientos>()
                .Property(e => e.Prioridad)
                .IsUnicode(false);

            modelBuilder.Entity<Requerimientos>()
                .HasMany(e => e.PermisosPorRequerimiento)
                .WithRequired(e => e.Requerimientos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requerimientos>()
                .HasMany(e => e.ProcesosPorRequerimiento)
                .WithRequired(e => e.Requerimientos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoRequerimiento>()
                .Property(e => e.NombreTipoRequerimiento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoRequerimiento>()
                .HasMany(e => e.Requerimientos)
                .WithRequired(e => e.TipoRequerimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.CredencialesUsuario)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.EquipoDeTrabajo)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.IncidenciasProduccion)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
