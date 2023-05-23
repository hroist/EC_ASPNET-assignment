using merketo.Contexts;
using merketo.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.ViewModels;

namespace merketo.Services;

public class TagService
{

    private readonly ProductContext _productContext;

    public TagService(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public List<SelectListItem> GetTags()
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in _productContext.Tags)
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName,                    
            });
        }

        return tags;
    }

    public List<SelectListItem> GetTags(string[] selectedTags)
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in _productContext.Tags)
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName,
                Selected = selectedTags.Contains(tag.Id.ToString())
            });
        }

        return tags;
    }

    public async Task<List<string>> GetProductTagsAsync(ProductModel productModel)
    {
        try
        {
            List<string> tagList = new();
            var productTags = await _productContext.ProductsTags.Where(x => x.ArticleNumber == productModel.ArticleNumber).ToListAsync();
            foreach (var _tag in productTags)
            {
                var t = await _productContext.Tags.FirstOrDefaultAsync(x => x.Id == _tag.TagId);
                if (t != null)
                {
                    tagList.Add(t.TagName);
                }

            }

            return tagList;
        }
        catch
        {
            return null!;
        }
    }

    public async Task AddTagsAsync(ProductEntity productEntity, string[] tags)
    {
        foreach(var tag in tags)
        {
            _productContext.Add(new ProductsTagsEntity
            {
                ArticleNumber = productEntity.ArticleNumber,
                TagId = int.Parse(tag)
            });
            await _productContext.SaveChangesAsync();
        }
    }

}
