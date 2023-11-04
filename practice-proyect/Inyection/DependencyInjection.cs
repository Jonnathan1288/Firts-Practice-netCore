using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;
using practice_proyect.Repository;

namespace practice_proyect.Inyection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //ADD REPOSITORYS
            services.AddScoped<IParentRepository, ParentRepository>();

            //ADD SERVICES

            //GET CONNECTION
            services.AddDbContext<FirstContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));

            });

            return services;
        }
    }
}
