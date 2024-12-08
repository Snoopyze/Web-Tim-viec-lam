using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MauCV : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
