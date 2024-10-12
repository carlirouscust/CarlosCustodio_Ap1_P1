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

		modelBuilder.Entity<CobrosDetalles>().HasData(
			new CobrosDetalles
			{
				detalleId = 1,
				cobroId = 0,
				prestamoId = 0,
				valorCobrado = 1000m
			},
			new CobrosDetalles
			{
				detalleId = 2,
                cobroId = 0,
                prestamoId = 0,
                valorCobrado = 4000m
			},
			new CobrosDetalles
			{
				detalleId = 3,
                cobroId = 0,
                prestamoId = 0,
                valorCobrado = 1123m
			}
		); 

	}
}
