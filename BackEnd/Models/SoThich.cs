using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class SoThich
{
    public int IdSoThich { get; set; }

    public string? TenSoThich { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
