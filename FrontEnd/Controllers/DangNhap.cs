
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace FrontEnd.Controllers
{
    public class DangNhap : Controller

    {

        public async Task<IActionResult> Index(String email, String matKhau, String userType)
        {
            var check = true; 
            if (email != null)
            {
                HttpContext.Session.SetString("email", email);
            }
            if (userType == "recruiter")
            {
                string urlNTD = "https://localhost:7208/api/NhaTuyenDungs"; // URL của API
                List<NhaTuyenDung> nhaTDs = await GetUngCuVien<NhaTuyenDung>(urlNTD);
                foreach(var item in nhaTDs)
                {
                    if(email == item.Email && matKhau == item.MatKhau)
                    {
                        HttpContext.Session.SetString("UserName", item.HoTen);
                        HttpContext.Session.SetInt32("Id", item.IdNhaTuyenDung);
                        HttpContext.Session.SetString("Email", item.Email);

                        return RedirectToAction("Index", "BangTin");
                    }
                    else
                    {
                        check = false;
                    }
                }
                
            }
            if (userType == "candidate")
            {
                string urlUCV = "https://localhost:7208/api/UngViens"; // URL của API
                List<UngVien> ungViens = await GetUngCuVien<UngVien>(urlUCV);
                foreach (var item in ungViens)
                {
                    if (email == item.Email && matKhau == item.MatKhau)
                    {
                        check = true;
                        HttpContext.Session.SetString("UserName", item.HoTen);
                        HttpContext.Session.SetString("Email", item.Email);
                        HttpContext.Session.SetInt32("Id", item.IdUngVien);
                        return RedirectToAction("Index", "Home");
                    }else
                    {
                        check = false;
                    }
                }

            }
            if (!check)
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng! Vui lòng thử lại";

            }
            return View();
        }

        public async Task<List<T>> GetUngCuVien<T>(string url)
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

    

    }
}
