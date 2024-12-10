using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ChiTietViecLam : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<IActionResult> Index(int idChiTietTuyenDung)
        {
            String url = $"https://localhost:7208/api/ChiTietTuyenDungs/{idChiTietTuyenDung}";
            TempData["url"] = url;
            ChiTietTuyenDung ctvl = await getChiTietViecLam(url);
            ViewBag.cttd = ctvl;
            String url2 = $"https://localhost:7208/api/CongTies/CongTy{ctvl.IdNhaTuyenDung}";
            CongTy cty = await getCongTy(url2);
            ViewBag.cty = cty;
            String url3 = $"https://localhost:7208/api/NhomNghes/ViTriChuyenMon/{ctvl.ViTriChuyenMon}";
            NhomNghe nhomNghe = await getNhomNghe(url3);
            ViewBag.nghe = nhomNghe;
            String url4 = $"https://localhost:7208/api/ChiTietTuyenDungs/Diadiemlamviec{ctvl.ChiTietDiaDiemLamViec}";
            String dch = await getDiaChi(url4);
            ViewBag.dchi = dch;

            return View();
        }

        public async Task<ChiTietTuyenDung> getChiTietViecLam(string url)
        {
            {
                try
                {
                    string jsonResponse = await _httpClient.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<ChiTietTuyenDung>(jsonResponse);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General error: {ex.Message}");
                    return null;
                }
            }
        }

        public async Task<CongTy> getCongTy(String url)
        {
                try
                {
                    string jsonResponse = await _httpClient.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<CongTy>(jsonResponse);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General error: {ex.Message}");
                    return null;
                }
        } 

        public async Task<NhomNghe> getNhomNghe(String url)
        {
            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<NhomNghe>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return null;
            }
        }

        public async Task<String> getDiaChi(String url)
        {
            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<String>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return null;
            }
        }


    }
}
