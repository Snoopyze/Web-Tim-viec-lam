using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrontEnd.Models;
using System.Text;
namespace FrontEnd.Controllers
{
    public class CaiDatThongTinCaNhan : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CaiDatThongTinCaNhan(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id = 1)  // Giả sử id là 1
        {
            var client = _httpClientFactory.CreateClient();

            // Lấy thông tin người dùng với id = 1 (hoặc bất kỳ ID nào bạn muốn)
            var response = await client.GetAsync($"https://localhost:7208/api/UngViens/{id}");
            UngVien ungVien = new UngVien();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ungVien = JsonConvert.DeserializeObject<UngVien>(content);

                return View(ungVien);

            }
            return View(ungVien);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInfo(int id, string fullName, string phone)
        {
            var client = _httpClientFactory.CreateClient();
            var response2 = await client.GetAsync($"https://localhost:7208/api/UngViens/{id}");
            UngVien ungVien = new UngVien();
            if (response2.IsSuccessStatusCode)
            {
                var content2 = await response2.Content.ReadAsStringAsync();
                ungVien = JsonConvert.DeserializeObject<UngVien>(content2);
            }
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                ViewBag.Error = "Tên đầy đủ và số điện thoại không được để trống.";
                return View("Index", ungVien);
            }

            // Tạo đối tượng để gửi lên API
            var updateRequest = new
            {
                HoTen = fullName,
                SoDienThoai = phone
            };

            var content = new StringContent(JsonConvert.SerializeObject(updateRequest), Encoding.UTF8, "application/json");

            // Gửi yêu cầu PUT để cập nhật thông tin cá nhân
            var response = await client.PutAsync($"https://localhost:7208/api/UngViens/UpdateUserInfo/{id}", content);
           
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Cập nhật thông tin cá nhân thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Cập nhật thông tin cá nhân thất bại. Vui lòng kiểm tra lại.";
                return View("Index", ungVien);
            }
        }
    }

}
