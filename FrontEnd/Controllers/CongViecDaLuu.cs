using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;

namespace FrontEnd.Controllers
{
    public class CongViecDaLuu : Controller
    {
        public async Task<IActionResult> Index()
        {
            var idUngVien = HttpContext.Session.GetInt32("Id");
            string url = $"https://localhost:7208/api/LuuTinTuyenDungs/ungvien/{idUngVien}/congty";
            //string url = $"https://localhost:7208/api/LuuTinTuyenDungs/ungvien/1/congty";

            List<SaveJobs> list = await GetSaveJobs(url);
            ViewBag.list = list;
            return View();
        }

        public async Task<List<SaveJobs>> GetSaveJobs(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string jsonResponse = await httpClient.GetStringAsync(url);
                    Console.WriteLine("JSON Response: " + jsonResponse); // Debug JSON trả về

                    // Deserialize JSON thành List<SaveJobs>
                    var saveJobs = JsonConvert.DeserializeObject<List<SaveJobs>>(jsonResponse);

                    Console.WriteLine("Số lượng công việc: " + saveJobs?.Count);
                    return saveJobs;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Lỗi gọi API: {ex.Message}");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khác: {ex.Message}");
                    return null;
                }
            }
        }
        public async Task<IActionResult> BoLuu(int idLuuTin)
        {
            {
                using (HttpClient httpClient = new HttpClient())
                    try
                {
                    string apiUrl = $"https://localhost:7208/api/LuuTinTuyenDungs/{idLuuTin}";

                    HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "Xóa tin tuyển dụng thành công!";
                        return RedirectToAction("Index"); // Thay "Index" bằng tên action phù hợp
                    }
                    else
                    {
                        TempData["ErrorMessage"] = $"Xóa thất bại! Lỗi: {response.ReasonPhrase}";
                    }
                }
                catch (HttpRequestException ex)
                {
                    TempData["ErrorMessage"] = $"Lỗi khi gửi yêu cầu: {ex.Message}";
                }

                return RedirectToAction("Index");
            }
        }
    }
    }
