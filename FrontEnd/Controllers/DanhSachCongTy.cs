using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DanhSachCongTy : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
