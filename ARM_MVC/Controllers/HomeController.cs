using ARM_MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ARM_MVC.Controllers
{
    //[Authorize(Roles ="Administration")]
    
    //[Authorize(Users= "DESKTOP-UROO8T1\\MPhil")]
    //https://stackoverflow.com/questions/60105635/create-role-based-authorization-with-windows-authentication
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles ="BasicUser")]
        public IActionResult Index()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles ="SuperUser")]
        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}