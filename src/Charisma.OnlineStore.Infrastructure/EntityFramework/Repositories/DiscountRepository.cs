using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using Charisma.OnlineStore.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private DbSet<Discount> _discount => _onlineStoreContext.Discounts;
        private readonly OnlineStoreContext _onlineStoreContext;

        public DiscountRepository(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext= onlineStoreContext;
        }
        public async Task<Discount?> GetActiveDiscountAsync()
        {
            return await _onlineStoreContext.Discounts.FirstOrDefaultAsync(x => x.Active);
        }
    }
}
