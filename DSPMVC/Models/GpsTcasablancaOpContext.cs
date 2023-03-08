using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DSPMVC.Models;

public partial class GpsTcasablancaOpContext : DbContext
{
    public GpsTcasablancaOpContext()
    {
    }

    public GpsTcasablancaOpContext(DbContextOptions<GpsTcasablancaOpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientesDispatcherOpc> ClientesDispatcherOpcs { get; set; }
    public virtual DbSet<DecToHexResult> DecToHexResult { get; set; }
    public virtual DbSet<DspClienteTipoResponse> DspClienteTipoResponse { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TCasablanca");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientesDispatcherOpc>(entity =>
        {
            entity.HasKey(e => e.CliCod).HasName("PK__CLIENTES__A6FFF1527CEE71A7");

            entity.ToTable("CLIENTES_DISPATCHER_OPC");

            entity.HasIndex(e => new { e.CliTipoClienteId, e.IdTipoZonaIt }, "INDEX_CLIENTES_DISPATCHER_OPC");

            entity.HasIndex(e => e.CliZonaRuta, "Ix_ZonaRuta_Alerta");

            entity.Property(e => e.CliCod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cli_Cod");
            entity.Property(e => e.AlertipId)
                .HasMaxLength(5)
                .HasColumnName("ALERTIP_ID");
            entity.Property(e => e.CliAlerTodos).HasColumnName("CLI_ALER_TODOS");
            entity.Property(e => e.CliBuzonesAlerta).HasColumnName("CLI_BUZONES_ALERTA");
            entity.Property(e => e.CliDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLI_DESCRIPCION");
            entity.Property(e => e.CliDetPermitido)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CLI_DET_PERMITIDO");
            entity.Property(e => e.CliDetencionMax).HasColumnName("CLI_DETENCION_MAX");
            entity.Property(e => e.CliDetencionMin).HasColumnName("CLI_DETENCION_MIN");
            entity.Property(e => e.CliEntraZona).HasColumnName("CLI_ENTRA_ZONA");
            entity.Property(e => e.CliExcesoVel).HasColumnName("CLI_EXCESO_VEL");
            entity.Property(e => e.CliInteres).HasColumnName("CLI_INTERES");
            entity.Property(e => e.CliMinAlerta)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CLI_MIN_ALERTA");
            entity.Property(e => e.CliMntsZonaCiega).HasColumnName("CLI_MNTS_ZONA_CIEGA");
            entity.Property(e => e.CliPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_password");
            entity.Property(e => e.CliRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_REGION");
            entity.Property(e => e.CliSector).HasColumnName("CLI_SECTOR");
            entity.Property(e => e.CliSobreestadia).HasColumnName("CLI_SOBREESTADIA");
            entity.Property(e => e.CliTicket).HasColumnName("CLI_TICKET");
            entity.Property(e => e.CliTipoClienteId).HasColumnName("CLI_TipoClienteId");
            entity.Property(e => e.CliZonaCiega).HasColumnName("CLI_ZONA_CIEGA");
            entity.Property(e => e.CliZonaDesacople).HasColumnName("CLI_ZONA_DESACOPLE");
            entity.Property(e => e.CliZonaRuta).HasColumnName("CLI_ZONA_RUTA");
            entity.Property(e => e.CliZonaSalida).HasColumnName("CLI_ZONA_SALIDA");
            entity.Property(e => e.CodTpRdCli)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("COD_TP_RD_CLI");
            entity.Property(e => e.IdTipoZonaIt).HasColumnName("ID_Tipo_ZonaIT");
        });
        modelBuilder.Entity<DecToHexResult>(entity =>
        {
            entity.Property(e => e.Valor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Valor");
        });

        modelBuilder.Entity<DspClienteTipoResponse>(entity =>
        {
            entity.Property(e => e.CliTipoClienteID)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_TipoClienteId");
            entity.Property(e => e.CliDescripcionTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_DescripcionTipo");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
