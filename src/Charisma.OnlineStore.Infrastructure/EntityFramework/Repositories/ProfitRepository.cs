using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
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
    public class ProfitRepository : IProfitRepository
    {
        private DbSet<Profit>  _profits => _onlineStoreContext.Profits;
        private readonly OnlineStoreContext _onlineStoreContext;

        public ProfitRepository(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext= onlineStoreContext;
        }
        public async Task<Profit?> GetActiveProfitAsync()
        {
            return await _onlineStoreContext.Profits.FirstOrDefaultAsync(x => x.Active);
        }
    }
}
