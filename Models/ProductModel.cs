using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class ProductModel
{
    public Guid ArticleNumber { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public List<string>? Tags { get; set; } = new List<string>();

    public string Price { get; set; } = null!;

    public string? ImageUrl { get; set; }
}
