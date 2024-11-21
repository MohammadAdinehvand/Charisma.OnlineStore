using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Repositories
{
    public interface IProductRepository:IRepository
    {
        Task<Product?> GetByIdAsync(long id);
        Task<IEnumerable<Product>> GetByIdAsync(List<long> ids);
    }
}
