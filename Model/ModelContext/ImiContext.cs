namespace Model.ModelContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImiContext : DbContext
    {
        public ImiContext()
            : base("name=ImiContext1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<actividad> actividad { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<direccion_negocio> direccion_negocio { get; set; }
        public virtual DbSet<formatos> formatos { get; set; }
        public virtual DbSet<Mes_Pago> Mes_Pago { get; set; }
        public virtual DbSet<meses> meses { get; set; }
        public virtual DbSet<negocio> negocio { get; set; }
        public virtual DbSet<pagos> pagos { get; set; }
        public virtual DbSet<tributos> tributos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<actividad>()
                .Property(e => e.actividad1)
                .IsUnicode(false);

            modelBuilder.Entity<actividad>()
                .HasMany(e => e.negocio)
                .WithRequired(e => e.actividad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRoles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.negocio)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_cont_negocio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<direccion_negocio>()
                .Property(e => e.zona)
                .IsUnicode(false);

            modelBuilder.Entity<direccion_negocio>()
                .HasMany(e => e.negocio)
                .WithRequired(e => e.direccion_negocio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<formatos>()
                .Property(e => e.nombre_f)
                .IsUnicode(false);

            modelBuilder.Entity<formatos>()
                .HasMany(e => e.pagos)
                .WithRequired(e => e.formatos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<meses>()
                .Property(e => e.Mes)
                .IsUnicode(false);

            modelBuilder.Entity<meses>()
                .HasMany(e => e.Mes_Pago)
                .WithRequired(e => e.meses)
                .HasForeignKey(e => e.id_mes_pago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<negocio>()
                .Property(e => e.nombre_n)
                .IsUnicode(false);

            modelBuilder.Entity<negocio>()
                .HasMany(e => e.pagos)
                .WithRequired(e => e.negocio)
                .HasForeignKey(e => e.id_negocio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pagos>()
                .Property(e => e.concepto)
                .IsUnicode(false);

            modelBuilder.Entity<pagos>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<pagos>()
                .Property(e => e.tipo_pago)
                .IsUnicode(false);

            modelBuilder.Entity<pagos>()
                .HasMany(e => e.Mes_Pago)
                .WithRequired(e => e.pagos)
                .HasForeignKey(e => e.id_pago_mes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tributos>()
                .Property(e => e.nombre_t)
                .IsUnicode(false);

            modelBuilder.Entity<tributos>()
                .Property(e => e.codigo_t)
                .IsUnicode(false);

            modelBuilder.Entity<tributos>()
                .HasMany(e => e.pagos)
                .WithRequired(e => e.tributos)
                .WillCascadeOnDelete(false);
        }
    }
}
