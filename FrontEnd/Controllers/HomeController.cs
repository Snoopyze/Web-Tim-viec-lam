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
        public async Task<IActionResult> Index(string search) // Thêm tham số search
        {
            List<Dictionary<string, object>> jobs;

            if (!string.IsNullOrEmpty(search)) // Kiểm tra nếu có từ khóa tìm kiếm
            {
                jobs = await SearchJobsFromApi(search); // Gọi API tìm kiếm
            }
            else
            {
                jobs = await GetJobsFromApi(); // Lấy toàn bộ công việc nếu không có từ khóa
            }

            var cities = await GetCitiesFromApi(); // Lấy danh sách thành phố
            ViewBag.Jobs = jobs; // Truyền danh sách công việc vào ViewBag
            ViewBag.CiTies = cities; // Truyền danh sách thành phố vào ViewBag
            ViewBag.Search = search; // Truyền từ khóa tìm kiếm vào ViewBag

            return View(); // Trả về dữ liệu cho view
        }


        private async Task<List<Dictionary<string, object>>> SearchJobsFromApi(string searchTerm)
        {
            // Gọi API với từ khóa tìm kiếm
            var response = await _httpClient.GetStringAsync($"{apiUrl}/{searchTerm}");
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response);
            return jobs;
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
