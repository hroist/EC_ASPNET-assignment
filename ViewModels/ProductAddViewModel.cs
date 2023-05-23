using merketo.Models.Entities;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductAddViewModel
{

    [Required(ErrorMessage = "You have to enter the name of the product")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;

    [Display(Name = "Product description")]
    public string? Description { get; set; }

    [Display(Name = "Category")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter the price of the product")]
    [Display(Name = "Price *")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "You have to add an image url for the product")]
    [Display(Name = "Product image url *")]
    public string ImageUrl { get; set; } = null!;

    public static implicit operator ProductEntity(ProductAddViewModel productAddViewModel)
    {
        return new ProductEntity
        {
            Name = productAddViewModel.Name,
            Description = productAddViewModel.Description,
            Price = productAddViewModel.Price,
            ImageUrl = productAddViewModel.ImageUrl,
        };
    }

    public static implicit operator CategoryEntity(ProductAddViewModel productAddViewModel)
    {
        return new CategoryEntity
        {
            CategoryName = productAddViewModel.Category
        };
    }
}
