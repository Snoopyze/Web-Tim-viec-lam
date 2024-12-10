using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ViecLamDaUngTuyen : Controller
    {
        public async Task<IActionResult> Index()
        {
            var idUngVien = HttpContext.Session.GetInt32("Id");
            string url = $"https://localhost:7208/api/HoSoDaNops/UngVien/{idUngVien}";

            List<ApplyJobs> list = await GetApplyJobs(url);
            ViewBag.listApplyJobs = list;
            return View();
        }

        public async Task<List<ApplyJobs>> GetApplyJobs(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string jsonResponse = await httpClient.GetStringAsync(url);
                    Console.WriteLine("JSON Response: " + jsonResponse); // Debug JSON trả về

                    // Deserialize JSON thành List<ApplyJobs>
                    var applyJobs = JsonConvert.DeserializeObject<List<ApplyJobs>>(jsonResponse);

                    Console.WriteLine("Số lượng công việc: " + applyJobs?.Count);
                    return applyJobs;
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
    }
}
