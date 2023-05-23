using WebApp.Models.Entities;

namespace merketo.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }

    public string TagName { get; set; } = null!;

    public ICollection<ProductsTagsEntity> ProductsTags { get; set; } = new HashSet<ProductsTagsEntity>();
}
