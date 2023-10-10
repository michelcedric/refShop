using EshopOnVue.js.Core.Entities;
using EshopOnVue.js.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class CatalogItemsRepository : EfRepository<CatalogItem, Guid, EshopContext>, ICatalogItemRepository
    {
        private readonly EshopContext _dbContext;

        public CatalogItemsRepository(EshopContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// <see cref="ICatalogItemRepository.GetPrice(Guid)"/>
        /// </summary>
        /// <param name="catalogItemId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<decimal?> GetPrice(Guid catalogItemId, CancellationToken cancellationToken)
        {
            try
            {
                var price = await _dbSet.Where(c => c.Id == catalogItemId)
                    .Select(s => s.Price).FirstAsync(cancellationToken);

                return price;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }     
        public async Task<CatalogItem?> GetItemWithSize(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.CatalogItems
                .Include(c => c.Sizes)
                .Include(c => c.ItemSizesWithStocks)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
