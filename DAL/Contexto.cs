using System.Drawing;
using CarlosCustodio_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

    public DbSet<Prestamos> Prestamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }
    public DbSet<Cobros> Cobros { get; set; }
    public DbSet<CobrosDetalles> CobrosDetalles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cobros>()
			.HasOne(c => c.deudores)
			.WithMany()
			.HasForeignKey(c => c.deudorId)
			.OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CobrosDetalles>()
            .HasOne(cd => cd.cobro)
            .WithMany(c => c.cobroDetalles)
            .HasForeignKey(cd => cd.cobroId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CobrosDetalles>()
            .HasOne(cd => cd.prestamos)
            .WithMany()
            .HasForeignKey(cd => cd.prestamoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Deudores>().HasData(
			new Deudores
			{
				deudorId = 1,
				Nombres = "Carlos"
			},
			new Deudores
			{
				deudorId = 2,
				Nombres = "Maria"
			},
			new Deudores
			{
				deudorId = 3,
				Nombres = "Juancito"
			}
		);
        modelBuilder.Entity<Prestamos>().HasData(
         new Prestamos 
		 { 
			 prestamoId = 1, 
			 deudorId = 1, 
			 concepto = "Carro", 
			 monto = 5000m, balance = 3000m },

         new Prestamos 
		 { 
			 prestamoId = 2, 
			 deudorId = 2, 
			 concepto = "Carro", 
			 monto = 7000m, 
			 balance = 5000m }
		);

        modelBuilder.Entity<Cobros>().HasData(
         new Cobros 
		 { 
			 cobroId = 1, 
			 fecha = new DateTime(2024, 10, 11), 
			 deudorId = 1, monto = 2000m },

         new Cobros 
		 { 
			 cobroId = 2, 
			 fecha = new DateTime(2023, 10, 5), 
			 deudorId = 2, monto = 3000m }
		);

        modelBuilder.Entity<CobrosDetalles>().HasData(
			new CobrosDetalles
			{
				detalleId = 1,
				valorCobrado = 1000m
			},
			new CobrosDetalles
			{
				detalleId = 2,
                valorCobrado = 4000m
			}			
		); 

	}
}
