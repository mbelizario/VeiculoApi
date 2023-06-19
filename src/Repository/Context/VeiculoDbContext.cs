using Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository.Context
{
    public class VeiculoDbContext : DbContext
    {
        public VeiculoDbContext(DbContextOptions<VeiculoDbContext> options) : base(options)
        {
        }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeiculoDbContext).Assembly);
            modelBuilder.Entity<Entidade>().HasQueryFilter(f => !f.Excluido);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            TratarDados();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            TratarDados();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            TratarDados();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            TratarDados();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public void TratarDados()
        {
            var registros = ChangeTracker.Entries();
            foreach (var registro in registros)
            {
                if (registro.Entity is Entidade)
                {
                    switch (registro.State)
                    {
                        case EntityState.Deleted:
                            registro.ConfigurarRemocaoLogica();
                            break;
                        case EntityState.Added:
                            registro.ConfigurarNovoRegistro();
                            break;
                    }
                }
            }
        }

    }
}
