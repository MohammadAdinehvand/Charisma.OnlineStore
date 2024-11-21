using Charisma.OnlineStore.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DataBaseConfig.Charisma_OnlineStore_DataBase);
            services.AddDbContext<OnlineStoreContext>(ctx => ctx.UseSqlServer(connectionString));
            services.SeedData();
            return services;
        }
    }
}
