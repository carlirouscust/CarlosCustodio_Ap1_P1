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
			}
		);

		modelBuilder.Entity<Prestamos>().HasData(
			new Prestamos
			{
				prestamoId = 1,
				deudorId = 1,
				concepto = "Casa",
				monto = 5000,
				balance = 3000
			}			
		);
		modelBuilder.Entity<Cobros>().HasData(
				new Cobros
				{
					cobroId = 1,
					fecha = new DateTime(2024, 10, 11),
					deudorId = 1,
					monto = 2000
				}
			);

		modelBuilder.Entity<CobrosDetalles>().HasData(
			new CobrosDetalles
			{
				detalleId = 1,
				cobroId = 1,
				prestamoId = 1,
				valorCobrado = 1000
			}
		);
	}
}
