using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class HoSoDaNop
{
    public int IdHoSoDaNop { get; set; }

    public DateTime ThoiGianNop { get; set; }

    public string TrangThai { get; set; } = null!;

    public int IdChiTietTuyenDung { get; set; }

    public int IdUngVien { get; set; }

    public virtual ChiTietTuyenDung IdChiTietTuyenDungNavigation { get; set; } = null!;

    public virtual UngVien IdUngVienNavigation { get; set; } = null!;
}
