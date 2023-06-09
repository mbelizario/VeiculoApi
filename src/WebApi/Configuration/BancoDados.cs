using Core.Constants;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace WebApi.Configuration
{
    public static class BancoDados
    {
        public static IServiceCollection ConfigurarDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VeiculoDbContext>(options =>
                                            options.UseSqlServer(configuration.GetConnectionString(ConnectionString.Padrao)));
            return services;
        }
    }
}
