﻿namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    /// <summary>
    /// Represent an element form the catalog
    /// </summary>
    public record CatalogItemDto
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
    }
}
