using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class LuuTinTuyenDung
{
    public int IdLuuTinTuyenDung { get; set; }

    public DateTime ThoiGianLuuTin { get; set; }

    public int IdChiTietTuyenDung { get; set; }

    public int IdUngVien { get; set; }

    public virtual ChiTietTuyenDung IdChiTietTuyenDungNavigation { get; set; } = null!;

    public virtual UngVien IdUngVienNavigation { get; set; } = null!;
}
