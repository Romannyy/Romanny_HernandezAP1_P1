using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.Models;

namespace Romanny_HernandezAP1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    public DbSet<EntradaDetalle> EntradasDetalle { get; set; }
    public DbSet<TipoHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TipoHuacales>().HasData(
            new TipoHuacales { TipoId = 1, Descripcion = "Rojo", Existencia = 0 },
            new TipoHuacales { TipoId = 2, Descripcion = "Verde", Existencia = 0 }
        );
    }
}