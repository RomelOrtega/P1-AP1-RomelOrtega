using Microsoft.EntityFrameworkCore;
using P1_AP1_RomelOrtega.Models;

namespace P1_AP1_RomelOrtega.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradaHuacales> EntradaHuacales { get; set; }
    public DbSet<EntradasHuacalesDetalle> EntradasHuacalesDetalle { get; set; }
    public DbSet<TiposHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TiposHuacales>().HasData(
            new List<TiposHuacales>()
            {
                new()
                {
                    IdTipo = 1,
                    Descripcion = "Huacal Verde, Tamaño Pequeño",
                    Existencia = 10,
                },
                new()
                {
                    IdTipo = 2,
                    Descripcion = "Huacal Verde, Tamaño Mediano",
                    Existencia = 10,
                },
                new()
                {
                    IdTipo = 3,
                    Descripcion = "Huacal Verde, Tamaño Grande",
                    Existencia = 10,
                },
                new()
                {
                    IdTipo = 4,
                    Descripcion = "Huacal Rojo, Tamaño Pequeño",
                    Existencia = 10,
                },
                new()
                {
                    IdTipo = 5,
                    Descripcion = "Huacal Rojo, Tamaño Mediano",
                    Existencia = 10,
                },
                new()
                {
                    IdTipo = 6,
                    Descripcion = "Huacal Rojo, Tamaño Grande",
                    Existencia = 10,
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}

