using Charisma.OnlineStore.Abstractions.Specification;
using Charisma.OnlineStore.Domain.DomainServices;
using Charisma.OnlineStore.Domain.Factories;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Specifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly =Assembly.GetExecutingAssembly();

            //   services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });

            //   services.AddValidatorsFromAssembly(assembly);
            services.AddScoped<IOrderFactory>(x =>
            {
                IEnumerable<ISpecification<Order>> specifications= new List<ISpecification<Order>>() 
                {
                    { new MinimumOrderAmountSpecification() },
                    { new OrderTimeSpecification() },
                };         
                return new OrderFactory(specifications);
            });

            services.AddScoped<IPricingService, PricingService>();
            return services;

        }
    }
}
