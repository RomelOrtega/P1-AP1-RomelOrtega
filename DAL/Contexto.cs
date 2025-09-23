using Microsoft.EntityFrameworkCore;
using P1_AP_RomelOrtega.Models;

namespace P1_AP1_RomelOrtega.DAL;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Registro> Registros { get; set; }
    }

