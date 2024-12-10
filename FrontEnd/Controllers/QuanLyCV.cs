using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class QuanLyCV : Controller
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient qua constructor
        public QuanLyCV(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int idUngVien = 1)
        {
            List<HoSoCV> cvList = new List<HoSoCV>();

            // URL của API (thay đổi tùy vào cấu hình API của bạn)
            string apiUrl = $"https://localhost:7208/api/HoSoCvs/GetDsHoSo/{idUngVien}";

            // Gọi API
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Chuyển dữ liệu JSON sang đối tượng
                string responseData = await response.Content.ReadAsStringAsync();
                cvList = JsonConvert.DeserializeObject<List<HoSoCV>>(responseData);
            }
            else
            {
                // Thêm xử lý lỗi nếu cần
                ViewBag.Error = "Không thể lấy dữ liệu từ API.";
            }

            // Truyền dữ liệu tới View
            return View(cvList);
        }
    }

    // Model cho HoSoCV
    public class HoSoCV
    {
        public int Id_CV { get; set; }
        public string TenCV { get; set; }
        public string FileURL { get; set; }
        public string TenFile { get; set; }
        public string LoaiCV { get; set; }
        public string LanCapNhapCuoiCung { get; set; }
        public int Id_UngVien { get; set; }
    }
}
