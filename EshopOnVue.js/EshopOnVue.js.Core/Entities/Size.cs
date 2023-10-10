using System;
using System.Collections.Generic;

namespace EshopOnVue.js.Core.Entities
{
    public class Size : BaseEntity<Guid>
    {
        public string Description { get; private set; }

        public List<CatalogItem> CatalogItems { get; private set; } = new();

        public static Size Create(string description)
        {
            return new Size
            {
                Id = Guid.NewGuid(),
                Description = description,
            };
        }
    }
}
