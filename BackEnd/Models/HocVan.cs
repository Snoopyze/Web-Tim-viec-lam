using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class HocVan
{
    public int IdHocVan { get; set; }

    public string? TenTruongHoc { get; set; }

    public string? NganhHoc { get; set; }

    public string? BatDau { get; set; }

    public string? KetThuc { get; set; }

    public string? ThanhTich { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
