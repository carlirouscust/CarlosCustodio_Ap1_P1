using CarlosCustodio_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

    public DbSet<Prestamos> Prestamos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Deudores>().HasData(new List<Deudores>();
        {
            //new Prestamos(){ }
        }
    }
}
