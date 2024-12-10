using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace FrontEnd.Controllers
{
    public class QuanLyCV_NhaTD : Controller
    {
        private readonly HttpClient _httpClient;

        public QuanLyCV_NhaTD(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var apiUrl = "https://localhost:7208/api/HoSoCvs/GetDSHoSoDaNop";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                   
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var danhSachHoSo = JsonConvert.DeserializeObject<List<HoSoViewModel>>(jsonData);

                    return View(danhSachHoSo);
                }
                else
                {
                    ViewBag.Error = "Không thể lấy dữ liệu từ API.";
                    return View(new List<HoSoViewModel>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Lỗi: {ex.Message}";
                return View(new List<HoSoViewModel>());
            }
        }
    }

    public class HoSoViewModel
    {
        public int id_HoSoDaNop { get; set; }
        public string? AnhHoSo { get; set; }
        public string? HoTen { get; set; }
        public string? Email { get; set; }
        public string? SDT { get; set; }
        public DateTime ThoiGianNop { get; set; }
        public string? TrangThai { get; set; }
        
    }

}