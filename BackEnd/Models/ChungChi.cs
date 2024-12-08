using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class ChungChi
{
    public int IdChungChi { get; set; }

    public string? ThoiGian { get; set; }

    public string? TenChungChi { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
