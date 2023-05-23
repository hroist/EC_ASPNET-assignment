using WebApp.ViewModels;

namespace WebApp.Services;

public class ShowcaseService
{
    private ShowcaseViewModel showcase = new()
    {
        Ingress = "WELCOME TO BMERKETO SHOP",
        Title = "Exclusive Chair Gold Selection",
        LinkContent = "SHOP NOW",
        LinkUrl = "/products",
        ImageUrl = "https://images.unsplash.com/photo-1529139574466-a303027c1d8b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8ZmFzaGlvbnxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
    };

    public ShowcaseViewModel GetShowcase() 
    {
        return showcase; 
    }
}
