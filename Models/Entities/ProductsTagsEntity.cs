using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace merketo.Models.Entities
{
    [PrimaryKey(nameof(ArticleNumber), nameof(TagId))]
    public class ProductsTagsEntity
    {
        public Guid ArticleNumber { get; set; }

        public ProductEntity Product { get; set; } = null!;

        public int TagId { get; set; }

        public TagEntity Tag { get; set; } = null!;


    }
}
