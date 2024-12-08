using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class GopYsanPham
{
    public int IdGopYsanPham { get; set; }

    public string DoiTuongGopY { get; set; } = null!;

    public string NoiDungGopY { get; set; } = null!;

    public string TaiLieuMinhHoaUrl { get; set; } = null!;

    public int IdNhaTuyenDung { get; set; }

    public virtual NhaTuyenDung IdNhaTuyenDungNavigation { get; set; } = null!;
}
