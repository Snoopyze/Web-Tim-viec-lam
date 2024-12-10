using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEnd.Controllers
{
    
    public class ChiTietViecLam : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://localhost:7208/api/ChiTietTuyenDungs";
        public ChiTietViecLam(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index(String id)
        {
            var jobdetails = await SearchJobsFromApi(id);

            ViewBag.jobdetails = jobdetails;
            return View(); // Truyền danh sách công việc vào View
        }
        private async Task<List<Dictionary<string, object>>> SearchJobsFromApi(string searchTerm)
        {
            // Gọi API với từ khóa tìm kiếm
            var response = await _httpClient.GetStringAsync($"{apiUrl}/{searchTerm}");
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response);
            return jobs;
        }
    }
}
