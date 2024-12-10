using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
