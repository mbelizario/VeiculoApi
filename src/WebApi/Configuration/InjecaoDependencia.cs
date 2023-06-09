using Core.Interfaces.Repositories;
using Core.Models;
using Repository.Context;
using Repository.Repository;

namespace WebApi.Configuration
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<VeiculoDbContext>();
            services.AddScoped<IBaseRepository<Entidade>, BaseRepository<Entidade>>();
            return services;
        }
    }
}
