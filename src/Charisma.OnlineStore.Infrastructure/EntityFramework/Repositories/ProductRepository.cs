
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using Charisma.OnlineStore.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<Product> _products => _onlineStoreContext.Products;
        private readonly OnlineStoreContext _onlineStoreContext;
        public ProductRepository(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _onlineStoreContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetByIdAsync(List<long> ids)
        {
            try
            {

            return await _onlineStoreContext.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
            }
            catch (Exception ex) 
            {

                throw;
            }
        }
    }
}
