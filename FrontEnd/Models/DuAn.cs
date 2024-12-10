using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class DuAn
{
    public int IdDuAn { get; set; }

    public string? BatDau { get; set; }

    public string? KetThuc { get; set; }

    public string? TenDuAn { get; set; }

    public string? TenKhachHang { get; set; }

    public string? SoLuongThamGia { get; set; }

    public string? ViTriTrongDuAn { get; set; }

    public string? MoTaVaiTro { get; set; }

    public string? CongNgheSuDung { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
