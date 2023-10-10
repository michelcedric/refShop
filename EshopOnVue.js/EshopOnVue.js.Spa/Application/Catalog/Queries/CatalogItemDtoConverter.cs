namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    public class CatalogItemDtoConverter
    {
        public static CatalogItemDto Convert(Core.Entities.CatalogItem catalogItem)
        {
            return new CatalogItemDto
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                PictureUri = $"static/products/{catalogItem.PictureImageName}",
                Price = catalogItem.Price,
                MemberPrice = catalogItem.MemberPrice
            };
        }
    }
}
