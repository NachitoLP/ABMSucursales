using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABMSucursales.Models;

public partial class AbmsucursalesContext : DbContext
{
    public AbmsucursalesContext()
    {
    }

    public AbmsucursalesContext(DbContextOptions<AbmsucursalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ResponsableSucursal> ResponsableSucursals { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("server=DESKTOP-9NLV2TR\\MSSQLSERVER10; database=ABMSucursales; integrated security=true; TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResponsableSucursal>(entity =>
        {
            entity.HasKey(e => e.IdResponsable).HasName("PK__Responsa__99B1C6CEE0B00BD1");

            entity.ToTable("ResponsableSucursal");

            entity.Property(e => e.IdResponsable)
                .ValueGeneratedNever()
                .HasColumnName("id_responsable");
            entity.Property(e => e.ApellidoResponsable)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido_responsable");
            entity.Property(e => e.CargoResponsable)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cargo_responsable");
            entity.Property(e => e.EmailResponsable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_responsable");
            entity.Property(e => e.HorarioAtencionApertura).HasColumnName("horario_atencion_apertura");
            entity.Property(e => e.HorarioAtencionClausura).HasColumnName("horario_atencion_clausura");
            entity.Property(e => e.NombreResponsable)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_responsable");
            entity.Property(e => e.TelefonoResponsable)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono_responsable");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__4C758013E7B98D50");

            entity.ToTable("Sucursal");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("id_sucursal");
            entity.Property(e => e.AreaSucursal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area_sucursal");
            entity.Property(e => e.DireccionSucursal)
                .HasColumnType("text")
                .HasColumnName("direccion_sucursal");
            entity.Property(e => e.EmailSucursal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_sucursal");
            entity.Property(e => e.HorarioAtencionApertura).HasColumnName("horario_atencion_apertura");
            entity.Property(e => e.HorarioAtencionClausura).HasColumnName("horario_atencion_clausura");
            entity.Property(e => e.IdResponsable).HasColumnName("id_responsable");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_sucursal");
            entity.Property(e => e.NumeroEmpleadosSucursal).HasColumnName("numero_empleados_sucursal");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.TelefonoSucursal)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono_sucursal");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("FK__Sucursal__id_res__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
