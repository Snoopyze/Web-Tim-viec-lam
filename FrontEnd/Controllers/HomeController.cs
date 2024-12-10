using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName; 
            return View();
        }

  

    }


}
