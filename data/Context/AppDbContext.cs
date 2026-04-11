using Microsoft.EntityFrameworkCore;
using PruebaTecnica.data.Models;
using PruebaTecnica.data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<VehiculoVendidoDto> VehiculosVendidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacion Vehiculo -> Marca
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Marca)
                .WithMany(m => m.Vehiculos)
                .HasForeignKey(v => v.MarcaId);

            // Relacion Venta -> Vehiculo
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Vehiculo)
                .WithMany(vh => vh.Ventas)
                .HasForeignKey(v => v.VehiculoId);

            // Relacion Venta -> Vendedor
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Vendedor)
                .WithMany(ve => ve.Ventas)
                .HasForeignKey(v => v.VendedorId);

            // Precision del campo Precio
            modelBuilder.Entity<Venta>()
                .Property(v => v.Precio)
                .HasColumnType("decimal(18,2)");

            // DTO del stored procedure
            modelBuilder.Entity<VehiculoVendidoDto>().HasNoKey();
        }
    }
}
