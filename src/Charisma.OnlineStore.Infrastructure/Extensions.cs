using Charisma.OnlineStore.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Charisma.OnlineStore.Infrastructure.EntityFramework;
namespace Charisma.OnlineStore.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);
            AddRepositories(services);
            return services;
        }

        private static IServiceCollection AddRepositories(IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes.AssignableToAny(typeof(IRepository)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
