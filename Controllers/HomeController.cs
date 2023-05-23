﻿using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        
        var viewModel = new HomeIndexViewModel();

        return View();
    }
}
