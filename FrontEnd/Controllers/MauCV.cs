using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class MauCV : Controller
    {
        public async Task<IActionResult> Index()
        {
   
        return View();
        }
    }
}
