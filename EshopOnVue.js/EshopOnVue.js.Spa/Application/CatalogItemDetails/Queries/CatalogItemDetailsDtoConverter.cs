namespace EshopOnVue.js.Spa.Application.CatalogItem.Queries
{
    public class CatalogItemDetailsDtoConverter
    {
        public static CatalogItemDetailsDto Convert(Core.Entities.CatalogItem catalogItem)
        {
            return new CatalogItemDetailsDto
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                PictureUri = $"static/products/{catalogItem.PictureImageName}",
                Price = catalogItem.Price,
                MemberPrice = catalogItem.MemberPrice,
                Sizes = catalogItem.Sizes.Select(s => new SizeDto
                {
                    Description = s.Description,
                    Id = s.Id,
                }).ToArray(),
            };
        }
    }
}
