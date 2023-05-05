using merketo.Contexts;
using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace merketo.Services
{
    public class CategoryService 
    {
        private readonly ProductContext _productContext;

        public CategoryService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<CategoryEntity> CreateAsync(ProductAddViewModel productViewModel)
        {
            CategoryEntity categoryEntity = productViewModel;
            if(categoryEntity != null) 
            {
                if(await CategoryExistsAsync(c => c.CategoryName == productViewModel.Category))
                    categoryEntity = await GetAsync(c => c.CategoryName == productViewModel.Category);

                else
                {
                    categoryEntity = new CategoryEntity()
                    {
                        CategoryName = productViewModel.Category
                    };
                    _productContext.Categories.Add(categoryEntity);
                    await _productContext.SaveChangesAsync();
                }

                return categoryEntity;

            }
            return null!;
        
        }

        public async Task<bool> CategoryExistsAsync(Expression<Func<CategoryEntity, bool>> predicate)
        {
            if (await _productContext.Categories.AnyAsync(predicate))
                return true;

            return false;
        }

        public async Task<CategoryEntity> GetAsync(Expression<Func<CategoryEntity, bool>> predicate)
        {
            try
            {
                return await _productContext.Categories.FirstOrDefaultAsync(predicate);
            }
            catch
            {
                return null!;
            }          
        }
    }
}
