using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class NhaTuyenDung
{
    public int IdNhaTuyenDung { get; set; }

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string AnhHoSoUrl { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public int IdCongTy { get; set; }

    public virtual ICollection<BaoCaoViPham> BaoCaoViPhams { get; set; } = new List<BaoCaoViPham>();

    public virtual ICollection<ChiTietTuyenDung> ChiTietTuyenDungs { get; set; } = new List<ChiTietTuyenDung>();

    public virtual ICollection<GopYsanPham> GopYsanPhams { get; set; } = new List<GopYsanPham>();

    public virtual CongTy IdCongTyNavigation { get; set; } = null!;
}
