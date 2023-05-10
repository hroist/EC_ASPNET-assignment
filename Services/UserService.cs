using merketo.Contexts;
using merketo.Repositories;
using merketo.Services;
using merketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ProfileService _profileService;

        public UserService(UserManager<AppUser> userManager, ProfileService profileService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _profileService = profileService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UserExists(Expression<Func<AppUser, bool>> predicate)
        {
            if (await _userManager.Users.AnyAsync(predicate))
                return true;

            return false;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                AppUser appUser = registerViewModel;
                var role = _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == "User").Result;
                var roleName = "User";

                if(role == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                    
                }

                var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, roleName);

                    ProfileEntity profileEntity = registerViewModel;
                    if (profileEntity != null)
                    {
                        await _profileService.CreateAsync(registerViewModel, appUser);
                    }
                }
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(MyAccountViewModel myAccountViewModel, string? Id)
        {
            try
            {
                AppUser user;

                if(Id != null)
                {
                    user = await _userManager.FindByIdAsync(Id);
                } 
                else
                {
                    user = await _userManager.FindByEmailAsync(myAccountViewModel.Email);
                }
                                
                if(user != null) 
                    { 
                    user.FirstName = myAccountViewModel.FirstName;
                    user.LastName = myAccountViewModel.LastName;
                    user.PhoneNumber = myAccountViewModel.PhoneNumber;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await UpdateRoleAsync(myAccountViewModel, user);
                        ProfileEntity profileEntity = await _profileService.GetAsync(user.Id);
                        if (profileEntity != null)
                        {
                            profileEntity.StreetName = myAccountViewModel.StreetName;
                            profileEntity.PostalCode = myAccountViewModel.PostalCode;
                            profileEntity.City = myAccountViewModel.City;
                            profileEntity.CompanyName = myAccountViewModel.CompanyName;
                            await _profileService.UpdateAsync(profileEntity);
                        }
                    }
                        return true;
                } 
                    return false;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }


        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            } 
            catch
            {
                return null!;
            }
        }

        public async Task<AppUser> GetAsync(string email)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
                
                if(user != null)
                {
                    return user;
                }
                else { return null!; }
                
            }
            catch
            {
                return null!;
            }
        }

        public async Task<AppUser> GetByIdAsync(string Id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id);

                if (user != null)
                {
                    return user;
                }
                else { return null!; }

            }
            catch
            {
                return null!;
            }
        }

        public async Task UpdateRoleAsync(MyAccountViewModel myAccountViewModel, AppUser user)
        {
            if(myAccountViewModel.RoleName != null)
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                await _userManager.AddToRoleAsync(user, myAccountViewModel.RoleName);
            }
            
        }
    }
}
