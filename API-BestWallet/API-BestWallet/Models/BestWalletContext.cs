using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_BestWallet.Models;

public partial class BestWalletContext : DbContext
{
    public BestWalletContext()
    {
    }

    public BestWalletContext(DbContextOptions<BestWalletContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Moneda> Monedas { get; set; }

    public virtual DbSet<ResumenSaldo> ResumenSaldos { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Transaccion> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=WENDER;Initial Catalog=BestWallet;Integrated Security=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta);

            entity.Property(e => e.IdCuenta).HasColumnName("id_Cuenta");
            entity.Property(e => e.Cvu).HasColumnName("CVU");
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAlta");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("fechaBaja");
            entity.Property(e => e.IdMoneda).HasColumnName("id_Moneda");
            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuentas_Monedas");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuentas_Usuarios");
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK_Moneda");

            entity.Property(e => e.IdMoneda).HasColumnName("id_Moneda");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResumenSaldo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ResumenSaldo");

            entity.Property(e => e.Cvu).HasColumnName("CVU");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Moneda)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion);

            entity.ToTable("TipoTransaccion");

            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreTipoTransaccion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion);

            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("id_TipoTransaccion");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacciones_Cuentas");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdTipoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacciones_TipoTransaccion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAlta");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("fechaBaja");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fechaNac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
