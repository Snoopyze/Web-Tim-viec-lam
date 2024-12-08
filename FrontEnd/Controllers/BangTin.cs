using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class BangTin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
