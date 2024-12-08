using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class ThongTinCaNhan
{
    public int IdThongTinCaNhan { get; set; }

    public string? HoTen { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? UrlLink { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public string? ViTriUngTuyen { get; set; }

    public string? MucTieuNgheNghiep { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
