using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ViecLamIT : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://localhost:7208/api/ChiTietTuyenDungs";
        private readonly string apiUrlNhomNghe = "https://localhost:7208/api/NhomNghes";
        private readonly string apiUrlNghe = "https://localhost:7208/api/Nghes";
        public ViecLamIT(HttpClient httpClient)
        {
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
            var nhomnghe= await GetNhomNgheFromApi();
            var nghe = await GetNgheFromApi();

            ViewBag.nhomnghe = nhomnghe;
            ViewBag.nghe = nghe;
            ViewBag.Jobs = jobs; // Truyền danh sách công việc vào ViewBag
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

        private async Task<List<Dictionary<string, object>>> GetJobsFromApi() // Phương thức bất đồng bộ
        {
            var response = await _httpClient.GetStringAsync(apiUrl); // Gọi API và đợi phản hồi
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return jobs; // Trả về danh sách công việc
        }

        private async Task<List<Dictionary<string, object>>> GetNhomNgheFromApi() // Phương thức bất đồng bộ
        {
            var response = await _httpClient.GetStringAsync(apiUrlNhomNghe); // Gọi API và đợi phản hồi
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return jobs; // Trả về danh sách công việc
        }

        private async Task<List<Dictionary<string, object>>> GetNgheFromApi() // Phương thức bất đồng bộ
        {
            var response = await _httpClient.GetStringAsync(apiUrlNghe); // Gọi API và đợi phản hồi
            var jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response); // Deserialize dữ liệu JSON
            return jobs; // Trả về danh sách công việc
        }
    }
}
