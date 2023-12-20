using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprint16.Models;
using Sprint16.Service;
using System.Diagnostics;
using System.Security.Claims;

namespace Sprint16.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "admin, user, buyer")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //var statusCode = HttpContext.Response.StatusCode;
            //if (statusCode == 403) // Forbidden
            //{
            //    return RedirectToAction("Login", "Account"); 
            //}

            return View();
        }
    }
}
