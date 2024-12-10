using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class TheoDoiCongTy
{
    public int IdTheoDoiCongTy { get; set; }

    public DateTime ThoiGianTheoGioi { get; set; }

    public int IdUngVien { get; set; }

    public int IdCongTy { get; set; }

    public virtual CongTy IdCongTyNavigation { get; set; } = null!;

    public virtual UngVien IdUngVienNavigation { get; set; } = null!;
}
