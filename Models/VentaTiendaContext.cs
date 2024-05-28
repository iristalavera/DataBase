using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReporteVentas.Models;

public partial class VentaTiendaContext : DbContext
{
    public VentaTiendaContext()
    {
    }

    public VentaTiendaContext(DbContextOptions<VentaTiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-76Q05EV\\TALAVERA;DataBase=VentaTienda;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente)
                .HasName("PK_IdCliente")
                .IsClustered(false);

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumCedula)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("numCedula");
            entity.Property(e => e.Telefono)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<CodigoPostal>(entity =>
        {
            entity.HasKey(e => e.IdCodigo)
                .HasName("PK_IdCodigo")
                .IsClustered(false);

            entity.ToTable("CodigoPostal");

            entity.Property(e => e.IdCodigo).HasColumnName("idCodigo");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Localidad)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("localidad");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CodigoPostals)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCliente3");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto)
                .HasName("PK_IdProducto")
                .IsClustered(false);

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Marca)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Talla)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("talla");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor)
                .HasName("PK_IdProveedor")
                .IsClustered(false);

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.IdCodigo).HasColumnName("idCodigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCodigoNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCodigoPostal4");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta)
                .HasName("PK_IdVenta")
                .IsClustered(false);

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("forma_pago");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCliente1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProducto2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
