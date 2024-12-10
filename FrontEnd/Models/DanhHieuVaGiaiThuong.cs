using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class DanhHieuVaGiaiThuong
{
    public int IdDanhHieuVaGiaiThuong { get; set; }

    public string? ThoiGian { get; set; }

    public string? TenGiaiThuong { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
