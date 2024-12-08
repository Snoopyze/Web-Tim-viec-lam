using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DangTin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
