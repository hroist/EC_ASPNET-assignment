using merketo.Contexts;
using merketo.Repositories;
using merketo.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace merketo.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _profileRepo;

        public ProfileService(ProfileRepository profileRepo)
        {
            _profileRepo = profileRepo;
        }

        public async Task<ProfileEntity> CreateAsync(RegisterViewModel registerViewModel, AppUser appUser)
        {
            ProfileEntity profileEntity = registerViewModel;
            if (profileEntity != null)
            {
                profileEntity.UserId = appUser.Id;
                return await _profileRepo.AddAsync(profileEntity);
            }
            return null!;
        }

        public async Task<ProfileEntity> GetAsync(string userId)
        {
            return await _profileRepo.GetAsync(x => x.UserId == userId);
        }

        public async Task<bool> UpdateAsync(ProfileEntity profileEntity)
        {
            if(await _profileRepo.UpdateAsync(profileEntity) != null)
            {
                return true;
            } else { return false; }
        }
    }
}
