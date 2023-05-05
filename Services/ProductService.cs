using merketo.Contexts;
using merketo.Models.Entities;
using merketo.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class ProductService
    {
        private readonly ProductContext _context;
        private readonly TagService _tagService;
        private readonly CategoryService _categoryService;

        public ProductService(ProductContext context, TagService tagService, CategoryService categoryService)
        {
            _context = context;
            _tagService = tagService;
            _categoryService = categoryService;
        }

        public async Task<ProductEntity> AddAsync(ProductAddViewModel productAddViewModel)
        {
            try
            {   
                ProductEntity productEntity = productAddViewModel;

                CategoryEntity categoryEntity = productAddViewModel;
                if (categoryEntity != null)
                {
                    categoryEntity = await _categoryService.CreateAsync(productAddViewModel);
                    productEntity.CategoryId = categoryEntity.Id;
                }

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return productEntity;
            } 
            catch 
            {
                return null!; 
            } 
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.Products.ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);

                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == item.CategoryId);
                if (categoryEntity != null)
                {
                    productModel.Category = categoryEntity.CategoryName;
                }

                var tags = await _tagService.GetProductTagsAsync(productModel);
                if (tags != null)
                {
                    productModel.Tags = tags;
                }
            }
            return products;
        }

        public async Task<IEnumerable<ProductModel>> GetByTagAsync(string tag)
        {
            var products = new List<ProductModel>();
            foreach(var item in await _context.ProductsTags.Where(x => x.Tag.TagName == tag).ToListAsync())
            {
                products.Add(await GetAsync(x => x.ArticleNumber == item.ArticleNumber));
            }

            return products;
        }

        public async Task<bool> ProductExists(Expression<Func<ProductEntity, bool>> predicate)
        {
            if (await _context.Products.AnyAsync(predicate))
                return true;

            return false;
        }

        public async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(predicate);
            return productEntity!;
        }

        public async Task<ProductModel> GetProductModelAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            try
            {
                var productEntity = await _context.Products.FirstOrDefaultAsync(predicate);
                if (productEntity != null)
                {
                    ProductModel productModel = productEntity;
                    var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == productEntity.CategoryId);
                    if (categoryEntity != null)
                    {
                        productModel.Category = categoryEntity.CategoryName;
                    }

                    var tags = await _tagService.GetProductTagsAsync(productModel);
                    if (tags != null)
                    {
                        productModel.Tags = tags;
                    }
                    return productModel!;
                }
                return null!;

            }
            catch { return null!; } 
        }
    }
}
