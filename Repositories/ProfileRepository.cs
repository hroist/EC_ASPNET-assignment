using merketo.Contexts;
using WebApp.Models.Entities;

namespace merketo.Repositories
{
    public class ProfileRepository : Repository<ProfileEntity>
    {
        public ProfileRepository(IdentityContext context) : base(context)
        {

        }
    }
}
