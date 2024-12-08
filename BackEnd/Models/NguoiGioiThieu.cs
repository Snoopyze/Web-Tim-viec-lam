using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class NguoiGioiThieu
{
    public int IdNguoiGioiThieu { get; set; }

    public string? ThongTinNguoiGioiThieu { get; set; }

    public int? IdCv { get; set; }

    public virtual HoSoCv? IdCvNavigation { get; set; }
}
