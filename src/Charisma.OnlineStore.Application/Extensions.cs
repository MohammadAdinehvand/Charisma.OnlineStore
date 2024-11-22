using Charisma.OnlineStore.Abstractions.Specification;
using Charisma.OnlineStore.Domain.DomainServices;
using Charisma.OnlineStore.Domain.Factories;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Rules.PricingRule;
using Charisma.OnlineStore.Domain.Specifications;
using Charisma.OnlineStore.Domain.Specifications.OrderSpecification;
using FluentValidation;
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
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });

            services.AddValidatorsFromAssembly(assembly);



            services.AddScoped<IOrderSpecification, MinimumOrderAmountSpecification>();
            services.AddScoped<IOrderSpecification, OrderTimeSpecification>();

            services.AddScoped<IOrderFactory,OrderFactory>();

       
            services.AddScoped<IOrderPicingVisitor, ProfitMarginVisitor>();
            services.AddScoped<IOrderPicingVisitor, DiscountVisitor>();
            services.AddScoped<IPricingService, PricingService>();


            return services;

        }
    }
}
