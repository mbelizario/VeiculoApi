using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Notificacoes;
using Repository.Context;
using Repository.Repository;
using Service;

namespace WebApi.Configuration
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<VeiculoDbContext>();
            services.AddScoped<INotificador, Notificador>();
            
            //services
            services.AddScoped<IMarcaService, MarcaService>();
            
            //repositories
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            return services;
        }
    }
}
