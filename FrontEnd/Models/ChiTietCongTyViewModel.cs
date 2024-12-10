using FrontEnd.Controllers;

namespace FrontEnd.Models
{
    public class ChiTietCongTyViewModel
    {
        public Company CongTy { get; set; } // Thông tin công ty
        public List<ChiTietTuyenDung> ChiTietTuyenDungs { get; set; }

        public List<City> City { get; set; }
        public bool IsFollow {  get; set; }
    }
}
