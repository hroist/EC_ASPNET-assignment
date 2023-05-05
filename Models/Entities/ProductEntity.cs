using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApp.Models.Entities
{   
    public class ProductEntity
    {
        [Key]
        public Guid ArticleNumber { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

        [Column(TypeName = "money(18,2)")]
        public decimal Price { get; set; } 

        public string? ImageUrl { get; set; }

        public ICollection<ProductsTagsEntity> ProductsTags { get; set; } = new HashSet<ProductsTagsEntity>();


        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price.ToString("0.00"),
                ImageUrl = entity.ImageUrl
            };
        }

        public static implicit operator CategoryEntity(ProductEntity entity)
        {
            return new CategoryEntity
            {
                Id = entity.CategoryId,
                CategoryName = entity.Category.CategoryName

            };
        }
    }
}
