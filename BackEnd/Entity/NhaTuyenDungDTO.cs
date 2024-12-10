namespace BackEnd.Entity
{
    public class NhaTuyenDungDTO
    {

        public string Email { get; set; } = null!;

        public string SoDienThoai { get; set; } = null!;

        public string MatKhau { get; set; } = null!;

        public string AnhHoSoUrl { get; set; } = null!;

        public string HoTen { get; set; } = null!;

        public bool GioiTinh { get; set; }

        public int IdCongTy { get; set; }
    }
}
