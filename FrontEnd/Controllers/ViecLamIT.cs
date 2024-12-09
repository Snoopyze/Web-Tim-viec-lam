using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ViecLamIT : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://localhost:7208/api/ChiTietTuyenDungs";

        public ViecLamIT(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var jobs = await GetJobsFromApi();
            ViewBag.Jobs = jobs;
            return View();
        }

        private async Task<List<Dictionary<string, object>>> GetJobsFromApi() // Phương thức bất đồng bộ
        {
            var response = await _httpClient.GetStringAsync(apiUrl); // Gọi API và đợi phản hồi
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return jobs; // Trả về danh sách công việc
        }
    }
}
