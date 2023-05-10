using merketo.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace merketo.Services
{
    public class CollectionService
    {

        public CollectionViewModel GetCollection(string tag, string? title, int amount, string? categories)
        {
            return new CollectionViewModel()
            {
                Title = title,
                Categories = categories,
                Tag = tag,
                Amount = amount

            };
        }
    }
}
