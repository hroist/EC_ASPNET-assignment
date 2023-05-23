using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Entities;

namespace merketo.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
