using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace oriflameFinal.Models
{
    public partial class oriflameContext : IdentityDbContext
    {
        public oriflameContext()
        {
        }

        public oriflameContext(DbContextOptions<oriflameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //              optionsBuilder.UseSqlServer("server=localhost;database=oriflame; User ID=sa; Password= T3lk0av8");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .HasColumnName("descripcion")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerified)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email_verified");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remember_token");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength();

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdPuesto)
                    .HasConstraintName("personas_FK");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.ToTable("puestos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .HasColumnName("descripcion")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdJerarquia).HasColumnName("id_jerarquia");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("puestos_FK_dept");

                entity.HasOne(d => d.IdJerarquiaNavigation)
                    .WithMany(p => p.InverseIdJerarquiaNavigation)
                    .HasForeignKey(d => d.IdJerarquia)
                    .HasConstraintName("puestos_FK");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<IdentityUserLogin<string>>();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
