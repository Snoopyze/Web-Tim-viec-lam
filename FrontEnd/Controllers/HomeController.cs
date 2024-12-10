using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using FrontEnd.Models;
namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    { 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id = 1)  // Giả sử id là 1
        {
            var client = _httpClientFactory.CreateClient();

            // Lấy thông tin người dùng với id = 1 (hoặc bất kỳ ID nào bạn muốn)
            var response = await client.GetAsync($"https://localhost:7208/api/UngVien/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UngVien>(content);

                // Truyền thông tin người dùng vào TempData
                TempData["User"] = JsonConvert.SerializeObject(user);
            }

            return View();
        }
    }
}