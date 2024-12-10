using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrontEnd.Models;
using System.Net.Http;

namespace FrontEnd.Controllers
{
    public class DanhSachCongTy : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient httpClient;
        public DanhSachCongTy(IHttpClientFactory httpClientFactory, HttpClient _httpClient)
        {
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClient;


        }

        public async Task<IActionResult> Index(String search)
        {
            

            var client = _httpClientFactory.CreateClient();

            // Lấy danh sách công ty
            var response = await client.GetAsync("https://localhost:7208/api/Congties"); // URL API chính xác
            List<Company> allCompanies = new List<Company>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                allCompanies = JsonConvert.DeserializeObject<List<Company>>(content);
            }

            // Lấy danh sách công ty đã theo dõi của một ứng viên (giả sử ungVienId là 1)
            var ungVienId = 1; // Có thể thay đổi id ứng viên theo nhu cầu
            var responseFollowed = await client.GetAsync($"https://localhost:7208/api/CongTies/GetDsCongTy/{ungVienId}"); // URL API lấy danh sách công ty đã theo dõi
            List<Company> followedCompanies = new List<Company>();

            if (responseFollowed.IsSuccessStatusCode)
            {
                var contentFollowed = await responseFollowed.Content.ReadAsStringAsync();
                followedCompanies = JsonConvert.DeserializeObject<List<Company>>(contentFollowed);
            }



            List<Company> jobs = new List<Company>();
            if (!string.IsNullOrEmpty(search)) // Kiểm tra nếu có từ khóa tìm kiếm
            {
                jobs = await SearchJobsFromApi(search); // Gọi API tìm kiếm
            }
            else { 
                jobs = await GetJobsFromApi(); // Lấy toàn bộ công việc nếu không có từ khóa
            }
            ViewBag.Jobs = jobs;
            // Tạo ViewModel để chứa cả hai danh sách
            var viewModel = new CompanyViewModel
            {
                AllCompanies = allCompanies,
                FollowedCompanies = followedCompanies,
                SearchCompanies = jobs
            };
            return View(viewModel); // Trả về View và truyền ViewModel
        }
        private async Task<List<Company>> SearchJobsFromApi(string searchTerm)
        {
            // Gọi API với từ khóa tìm kiếm
            var response = await httpClient.GetStringAsync($"https://localhost:7208/api/CongTies/GetDsCongTyBySearch/{searchTerm}");
            var jobs = JsonConvert.DeserializeObject<List<Company>>(response);
            return jobs;
        }
        private async Task<List<Company>> GetJobsFromApi()
        {
            // Gọi API với từ khóa tìm kiếm
            var response = await httpClient.GetStringAsync($"https://localhost:7208/api/Congties");
            var jobs = JsonConvert.DeserializeObject<List<Company>>(response);
            return jobs;
        }
    }

    public class CompanyViewModel
    {
        public List<Company> AllCompanies { get; set; } // Danh sách công ty
        public List<Company> FollowedCompanies { get; set; } // Danh sách công ty đã theo dõi

        public List<Company> SearchCompanies { get; set; }
    }
}
