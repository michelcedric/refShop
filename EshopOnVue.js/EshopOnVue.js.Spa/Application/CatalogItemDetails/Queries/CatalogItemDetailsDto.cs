namespace EshopOnVue.js.Spa.Application.CatalogItem.Queries
{
    /// <summary>
    /// Represent an element form the catalog
    /// </summary>
    public record CatalogItemDetailsDto
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Path without domain of the item's picture
        /// </summary>
        public string PictureUri { get; set; } = null!;

        /// <summary>
        /// The price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The price reserved for member only
        /// </summary>
        public decimal MemberPrice { get; set; }

        public SizeDto[] Sizes { get; set; }
    }

    public record SizeDto
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
