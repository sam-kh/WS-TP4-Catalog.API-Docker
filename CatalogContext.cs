using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options){ }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>().HasData(
                  new CatalogItem { Id = 1, Name = "Pc Dell" , Description="PC Dell LATITUDE | E6230",
                                    Price = 50000, TypeId = 1},
                  new CatalogItem { Id = 2, Name = "Casquette Nike",Description="Casquette noire de la marque Nike",
                                    Price = 120, TypeId = 2 }
            );
            modelBuilder.Entity<CatalogType>().HasData(
                new CatalogType { Id = 1, Name = "Electronics" , Description = "Elecronics Items" },
                new CatalogType { Id = 2, Name = "Clothes", Description = "Elecronics Items" },
                new CatalogType { Id = 3, Name = "Other" , Description = "Divers Items"}
            );
        }
    }
}