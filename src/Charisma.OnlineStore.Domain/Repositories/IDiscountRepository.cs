using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Repositories
{
    public interface IDiscountRepository : IRepository
    {
        Task<Discount?> GetActiveDiscountAsync();
    }
}
