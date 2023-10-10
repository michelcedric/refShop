using EshopOnVue.js.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>()
                .HasMany(e => e.Sizes)
                .WithMany(e => e.CatalogItems)
                .UsingEntity<ItemSizesWithStock>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
