using merketo.ViewModels;

namespace merketo.Services
{
    public class CollectionService
    {

        public CollectionViewModel GetCollection(string tag, string? title)
        {
            return new CollectionViewModel()
            {
                Title = title,
                Tag = tag
            };
        }
    }
}
