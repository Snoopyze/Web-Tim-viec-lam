using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class HoatDong
{
    public int IdHoatDong { get; set; }

    public string? BatDau { get; set; }

    public string? KetThuc { get; set; }

    public string? TenToChuc { get; set; }

    public string? ViTriCuaBan { get; set; }

    public string? MoTaHoatDong { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
