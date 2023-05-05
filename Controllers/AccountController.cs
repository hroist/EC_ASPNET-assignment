using merketo.Controllers;
using merketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserService userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {   

            if(ModelState.IsValid)
            {
                if (await _userService.UserExists(x => x.Email == registerViewModel.Email))
                {
                    ModelState.AddModelError("", "A user already exists with this e-mail address. Try loggin in.");
                } 
                else
                {

                    if (await _userService.RegisterAsync(registerViewModel)) { 
                       

                        if(User.IsInRole("SystemAdministrator"))
                           return RedirectToAction("Users", "Admin");
                        else
                           return RedirectToAction("Login", "Account");
                    }    
                    else
                        ModelState.AddModelError("", "Something went wrong when trying to create the account.");
                }
            }
            return View(registerViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) 
        {
            if (ModelState.IsValid)
            {
                if( await _userService.LoginAsync(loginViewModel)) 
                    return RedirectToAction("MyAccount", "Account");

                ModelState.AddModelError("", "The email and the password does not match.");
            }

            return View(loginViewModel);
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile( string? id )
        {
            ViewBag.Id = id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(MyAccountViewModel myAccountViewModel)
        {

            if (ModelState.IsValid)
            {
                if (await _userService.UpdateAsync(myAccountViewModel, null))
                {
                    if (User.IsInRole("SystemAdministrator"))
                        return RedirectToAction("Users", "Admin");
                    return RedirectToAction("MyAccount", "Account");
                }
                else
                    ModelState.AddModelError("", "Something went wrong when trying to update the profile.");              
            }

            return View(myAccountViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            if(_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return LocalRedirect("/");
        }
    }
}
