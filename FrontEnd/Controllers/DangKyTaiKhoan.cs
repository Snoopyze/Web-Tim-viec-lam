using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd.Controllers
{
    public class DangKyTaiKhoan : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> dangKyNhaTuyenDung(string email, string hoten, string matKhau, int gioiTinh,
            string soDienThoai, string CongTy, string tinh, string quan, string phuong)
        {
            string url = "https://localhost:7208/api/NhaTuyenDungs";

            List<NhaTuyenDung> nhaTDs = await GetUser<NhaTuyenDung>(url);
            foreach (var item in nhaTDs)
            {
                if (item.Email == email)
                {
                    TempData["errorDKi"] = "Email đã tồn tại";
                    return RedirectToAction("Index");
                }
            }
            int idCty;
            try
            {
                idCty = await ThemMoiCongTy(CongTy);
                TempData["idCTY"] = idCty;
            }
            catch (Exception ex)
            {
                TempData["errorDKi"] = $"Lỗi khi tạo công ty: {ex.Message}";
                return RedirectToAction("Index");
            }

            // Đăng ký nhà tuyển dụng
            var newNhaTuyenDung = new
            {
                email = email,
                soDienThoai = soDienThoai,
                matKhau = matKhau,
                anhHoSoUrl = "string",
                hoTen = hoten,
                gioiTinh = gioiTinh == 1,
                idCongTy = idCty
            };
            
            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(newNhaTuyenDung);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // dua base path vao config
                    string urlPost = "https://localhost:7208/api/NhaTuyenDungs";
                    var response = await client.PostAsync(urlPost, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successDKi"] = "Đăng ký thành công!";
                        return RedirectToAction("Index", "DangNhap");
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        TempData["errorDKi"] = $"Đăng ký thất bại: {error}";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorDKi"] = $"Lỗi hệ thống khi đăng ký: {ex.Message}";
                    return RedirectToAction("Index");
                }
            }
        }

        public async Task<IActionResult> DangKyUngVien(string hoVaTen, string email, string password)
        {
            string url = "https://localhost:7208/api/UngViens";

            List<UngVien> ungViens = await GetUser<UngVien>(url);
            foreach (var item in ungViens)
            {
                if (item.Email == email)
                {
                    TempData["errorDKi"] = "Email đã tồn tại";
                    return RedirectToAction("Index");
                }
            }
            var newUngVien = new
            {
                email = email,
                soDienThoai ="", 
                hoVaTen = hoVaTen,
                matKhau = password,
                anhHoSo = "",
                hoTen = hoVaTen

            };

            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(newUngVien);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // dua base path vao config
                    string urlPost = "https://localhost:7208/api/UngViens";
                    var response = await client.PostAsync(urlPost, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successDKi"] = "Đăng ký thành công!";
                        return RedirectToAction("Index", "DangNhap");
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        TempData["errorDKi"] = $"Đăng ký thất bại: {error}";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorDKi"] = $"Lỗi hệ thống khi đăng ký: {ex.Message}";
                    return RedirectToAction("Index");
                }
            }
        }
        public async Task<List<T>> GetUser<T>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string jsonResponse = await httpClient.GetStringAsync(url);

                    return JsonConvert.DeserializeObject<List<T>>(jsonResponse);
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

        public async Task<int> ThemMoiCongTy(string tenCongTy)
        {
            string urlPost = "https://localhost:7208/api/CongTies";

            var newCongTy = new
            {

                logoUrl = "string",
                tenCongTy = tenCongTy,
                maSoThue = "string",
                websiteUrl = "string",
                soLuongNguoiTheoDoi = "string",
                quyMoCongTy = "string",
                moTaCongTy = "string",
                email = "string"
            };

            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(newCongTy);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(urlPost, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var congTyResponse = JsonConvert.DeserializeObject<CongTy>(responseData);

                        if (congTyResponse?.IdCongTy != null)
                        {
                            return congTyResponse.IdCongTy;
                        }
                        else
                        {
                            throw new Exception("Phản hồi từ API thiếu thông tin IdCongTy.");
                        }
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Lỗi từ API: {error}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi hệ thống khi thêm công ty: {ex.Message}");
                }
            }
        }

       
    }
}