using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class KinhNghiemLamViec
{
    public int IdKinhNghiemLamViec { get; set; }

    public string? BatDau { get; set; }

    public string? KetThuc { get; set; }

    public string? TenCongTy { get; set; }

    public string? ViTriCongViec { get; set; }

    public string? MoTaKinhNghiemLamViec { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
