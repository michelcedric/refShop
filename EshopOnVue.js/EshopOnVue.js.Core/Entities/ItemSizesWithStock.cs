using System;

namespace EshopOnVue.js.Core.Entities
{
    public class ItemSizesWithStock
    {
        public Guid CatalogItemId { get; set; }
        public Guid SizeId { get; set; }
        public int? StockNumber { get; set; }

        public static ItemSizesWithStock Create(Guid catalogItemId, Guid sizeId, int? stockNumber)
        {
            return new ItemSizesWithStock
            {
                CatalogItemId = catalogItemId,
                SizeId = sizeId,
                StockNumber = stockNumber
            };
        }
    }
}
