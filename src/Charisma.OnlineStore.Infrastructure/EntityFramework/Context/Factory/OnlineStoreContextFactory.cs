using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Context.Factory
{
    internal class OnlineStoreContextFactory : IDesignTimeDbContextFactory<OnlineStoreContext>
    {
        public OnlineStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnlineStoreContext>();
            optionsBuilder.UseSqlServer("data Source =192.168.57.51;Initial Catalog=Charisma_OnlineStore;User ID=sa;Password=Pdn@Admin;MultipleActiveResultSets=true;TrustServerCertificate=True");
            var dbContext = new OnlineStoreContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}
