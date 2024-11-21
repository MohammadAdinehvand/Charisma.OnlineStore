using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Repositories
{
    public interface IProfitRepository : IRepository
    {
        Task<Profit?> GetActiveProfitAsync();
    }
}
