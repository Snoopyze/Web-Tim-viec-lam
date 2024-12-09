using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://localhost:7208/api/ChiTietTuyenDungs";
        private readonly string apiUrlCitTy = "https://localhost:7208/api/ThanhPhoes";

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index() // Sử dụng Task<IActionResult> và async
        {
            var jobs = await GetJobsFromApi(); // Sử dụng await để đợi kết quả từ API
            var cities = await GetCitiesFromApi();
            ViewBag.Jobs = jobs; // Truyền danh sách công việc vào ViewBag
            ViewBag.CiTies = cities;


            return View(); // Trả về dữ liệu jobs cho view
        }

        private async Task<List<Dictionary<string, object>>> GetCitiesFromApi()
        {
            var response = await _httpClient.GetStringAsync(apiUrlCitTy); // Gọi API và đợi phản hồi
            var cities = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return cities;
        }

        private async Task<List<Dictionary<string, object>>> GetJobsFromApi() // Phương thức bất đồng bộ
        {
            var response = await _httpClient.GetStringAsync(apiUrl); // Gọi API và đợi phản hồi
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return jobs; // Trả về danh sách công việc
        }

        public IActionResult Privacy()
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
