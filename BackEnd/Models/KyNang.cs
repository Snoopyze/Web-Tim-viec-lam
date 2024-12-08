using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class KyNang
{
    public int IdKyNang { get; set; }

    public string? TenKyNang { get; set; }

    public string? MoTa { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
