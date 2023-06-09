using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class VeiculoDbContext : DbContext
    {
        public VeiculoDbContext(DbContextOptions<VeiculoDbContext> options) : base(options)
        {
        }

        //public DbSet<Aeronave> Aeronave { get; set; }
        //public DbSet<Automovel> Automovel { get; set; }
        //public DbSet<Marca> Marca { get; set; }
        //public DbSet<Modelo> Modelo { get; set; }
        //public DbSet<Reboque> Reboque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeiculoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
