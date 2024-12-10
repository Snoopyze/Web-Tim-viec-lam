using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrontEnd.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FrontEnd.Controllers
{
    public class ChiTietCongTyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChiTietCongTyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Phương thức hiển thị trang chi tiết công ty
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Lấy thông tin chi tiết tuyển dụng
            var responseTuyenDung = await client.GetAsync($"https://localhost:7208/api/ChiTietTuyenDungs/{id}");
            List<ChiTietTuyenDung> chiTietTuyenDungs = new List<ChiTietTuyenDung>();

            if (responseTuyenDung.IsSuccessStatusCode)
            {
                var contentTuyenDung = await responseTuyenDung.Content.ReadAsStringAsync();
                chiTietTuyenDungs = JsonConvert.DeserializeObject<List<ChiTietTuyenDung>>(contentTuyenDung);
            }

            // Lấy thông tin công ty
            var responseCongTy = await client.GetAsync($"https://localhost:7208/api/CongTies/{id}");
            Company congTy = null;

            if (responseCongTy.IsSuccessStatusCode)
            {
                var contentCongTy = await responseCongTy.Content.ReadAsStringAsync();
                congTy = JsonConvert.DeserializeObject<Company>(contentCongTy);
            }

            // Lấy danh sách thành phố
            var responseCity = await client.GetAsync("https://localhost:7208/api/ThanhPhoes");
            List<City> cities = new List<City>();

            if (responseCity.IsSuccessStatusCode)
            {
                var contentCity = await responseCity.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(contentCity);
            }

            bool isFollowed = false;


            var responseIsFollowed = await client.GetAsync($"https://localhost:7208/api/TheoDoiCongTies/IsFollowed/1/{id}");
            if (responseIsFollowed.IsSuccessStatusCode)
            {
                isFollowed = JsonConvert.DeserializeObject<bool>(await responseIsFollowed.Content.ReadAsStringAsync());
            }


            // Tạo ViewModel
            var viewModel = new ChiTietCongTyViewModel
            {
                CongTy = congTy,
                ChiTietTuyenDungs = chiTietTuyenDungs,
                City = cities,
                IsFollow = isFollowed // Truyền trạng thái theo dõi vào ViewModel
            };

            return View(viewModel);
        }

        // API theo dõi công ty
        [HttpPost]
        public async Task<IActionResult> FollowCompany(int ungVienId, int congTyId)
        {
            var client = _httpClientFactory.CreateClient();

            // Gửi yêu cầu theo dõi công ty
            var response = await client.PostAsJsonAsync("https://localhost:7208/api/TheoDoiCongTies/FollowCompany", new { UngVienId = 1, CongTyId = congTyId });

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = congTyId });
            }

            return BadRequest("Failed to follow the company.");
        }

        // API hủy theo dõi công ty
        [HttpPost]
        public async Task<IActionResult> UnfollowCompany(int ungVienId, int congTyId)
        {
            var client = _httpClientFactory.CreateClient();
            ungVienId = 1;
            // Gửi yêu cầu hủy theo dõi công ty với ungVienId và congTyId
            var response = await client.DeleteAsync($"https://localhost:7208/api/TheoDoi/UnfollowCompany?UngVienId={ungVienId}&CongTyId={congTyId}");

            // Kiểm tra kết quả trả về từ API
            if (response.IsSuccessStatusCode)
            {
                // Nếu thành công, chuyển hướng về trang chi tiết công ty
                return RedirectToAction("Index", new { id = congTyId });
            }

            // Nếu không thành công, lấy chi tiết lỗi và trả về thông báo lỗi
            var errorResponse = await response.Content.ReadAsStringAsync();
            return BadRequest($"Failed to unfollow the company. Error: {errorResponse}");
        }
    }
}
