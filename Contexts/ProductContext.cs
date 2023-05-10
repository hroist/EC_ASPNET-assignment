using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace merketo.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<ProductsTagsEntity> ProductsTags { get; set; }

    }
}
