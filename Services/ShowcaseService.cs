using WebApp.ViewModels;

namespace WebApp.Services
{
    public class ShowcaseService
    {
        private ShowcaseViewModel showcase = new()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair Gold Selection",
            LinkContent = "SHOP NOW",
            LinkUrl = "/products",
            ImageUrl = "images/625x647.svg"
        };

        public ShowcaseViewModel GetShowcase() 
        {
            return showcase; 
        }
    }
}
