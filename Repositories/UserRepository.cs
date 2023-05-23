using merketo.Contexts;
using WebApp.Models.Identity;

namespace merketo.Repositories;

public class UserRepository : Repository<AppUser>
{
    protected UserRepository(IdentityContext context) : base(context)
    {

    }
}
