using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.Models;

namespace Romanny_HernandezAP1_P1.DAL;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }
        public DbSet<EntradasHuacales> EntradasHuacales { get; set; }

    }


