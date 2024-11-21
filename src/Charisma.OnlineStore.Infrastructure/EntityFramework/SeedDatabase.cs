using Charisma.OnlineStore.Domain.Models.BuyerAggregate;
using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
using Charisma.OnlineStore.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework
{
    public static class SeedDatabase
    {
        public static void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<OnlineStoreContext>();
                dbContext.Database.Migrate();

                if (!dbContext.Products.Any())
                {
                    dbContext.Products.Add(new Product("Laptop", 10000000, ProductType.FRAGILE));
                    dbContext.Discounts.Add(new Discount("Discount1", DiscountType.FIXED, 10000, true));
                    dbContext.Profits.Add(new Profit("Profit1", 10000, true));
                    dbContext.Buyers.Add(new Buyer("Mohammad", "Adineh", "09109100911"));

                    dbContext.SaveChanges();
                }

            }





        }
    }
}
