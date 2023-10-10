using EshopOnVue.js.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class CatalogItemSeed
    {
        public static void Seed(EshopContext context)
        {
            if (!context.CatalogItems.Any())
            {
                context.CatalogItems.AddRange(
                    GetCatalogItems());

                context.SaveChanges();
            }
        }

        public static IEnumerable<CatalogItem> GetCatalogItems()
        {
            var mSize = Size.Create("M");
            var lSize = Size.Create("L");
            var xlSize = Size.Create("XL");


            var item1 = CatalogItem.Create(".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M, 19.5M, "1.png");
            item1.AssignSizeWithStock(mSize, null);
            item1.AssignSizeWithStock(lSize, null);
            item1.AssignSizeWithStock(xlSize, null);

            return new CatalogItem[]
            {
                item1,
                CatalogItem.Create("NET Black & White Mug","NET Black & White Mug",19.5M,8.50M,"2.png"),
                CatalogItem.Create("Prism White T-Shirt","Prism White T-Shirt",19.5M,12,"3.png"),
                CatalogItem.Create(".NET Foundation Sweatshirt",".NET Foundation Sweatshirt",19.5M,12,"4.png"),
                CatalogItem.Create("Roslyn Red Sheet","Roslyn Red Sheet",19.5M,8.5M,"5.png")

            };
        }
    }
}
