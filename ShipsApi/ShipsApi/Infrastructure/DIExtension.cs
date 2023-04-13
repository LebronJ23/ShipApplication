using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipsApi.Application.Interfaces;

namespace ShipsApi.Infrastructure
{
    public static class DIExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ShipsConnection"];
            services.AddDbContext<ShipsDbContext>(opts =>
            {
                opts.UseSqlServer(connectionString);
                opts.EnableSensitiveDataLogging(true);
            });
            services.AddScoped<IShipsDbContext>(provider => provider.GetService<ShipsDbContext>());
            return services;
        }
    }
}
