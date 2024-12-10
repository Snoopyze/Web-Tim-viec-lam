using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using FrontEnd.Models;
using System.Text;

namespace FrontEnd.Controllers
{
    public class DoiMatKhau : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DoiMatKhau(IHttpClientFactory httpClientFactory)
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
        public async Task<IActionResult> ChangePassword(int id , string currentPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.ErrorMessage = "Tất cả các trường mật khẩu đều phải được điền.";
                return View("Index");
            }
            if (newPassword != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu mới và xác nhận mật khẩu không khớp.";
                return View("Index");
            }

            var client = _httpClientFactory.CreateClient();

            // Gửi yêu cầu thay đổi mật khẩu tới API
            var changePasswordRequest = new
            {
                CurrentPassword = currentPassword,
                NewPassword = newPassword
            };
            var response2 = await client.GetAsync($"https://localhost:7208/api/UngViens/{id}");

            if (response2.IsSuccessStatusCode)
            {
                var content2 = await response2.Content.ReadAsStringAsync();
                var ungVien = JsonConvert.DeserializeObject<UngVien>(content2);

                // Kiểm tra mật khẩu cũ có khớp với mật khẩu trong hệ thống không
                if (ungVien != null && ungVien.MatKhau != currentPassword)
                {
                    ViewBag.ErrorMessage = "Mật khẩu cũ không đúng.";
                    return View("Index");
                }
            }

                var content = new StringContent(JsonConvert.SerializeObject(changePasswordRequest), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7208/api/UngViens/ChangePassword/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Đổi mật khẩu thành công!";
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Đổi mật khẩu thất bại. Vui lòng kiểm tra thông tin và thử lại.";
            return View("Index");
        }
    }
}
