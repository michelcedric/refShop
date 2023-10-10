using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnVue.js.Core.Entities
{
    public class CatalogItem : BaseEntity<Guid>
    {
        [Required]
        public string Name { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MemberPrice { get; private set; }

        public List<Size> Sizes { get; set; } = new();

        public List<ItemSizesWithStock> ItemSizesWithStocks { get; private set; } = new();

        [Required]
        public virtual string PictureImageName { get; private set; }

        public static CatalogItem Create(string name, string description, decimal price, decimal memberPrice, string pictureImageName)
        {
            return new CatalogItem
            {
                Id = Guid.NewGuid(),
                Description = description,
                Name = name,
                PictureImageName = pictureImageName,
                Price = price,
                MemberPrice = memberPrice,
            };
        }

        public void AssignSizeWithStock(Size size, int? stock)
        {
            Sizes.Add(size);
            ItemSizesWithStocks.Add(ItemSizesWithStock.Create(Id, size.Id, stock));
        }
    }
}
