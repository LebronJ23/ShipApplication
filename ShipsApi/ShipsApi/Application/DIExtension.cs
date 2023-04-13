using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShipsApi.Application.Common.Behaviours;
using System.Reflection;

namespace ShipsApi.Application
{
    public static class DIExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(opts =>
            {
                opts.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
