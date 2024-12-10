using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class PhuongXa
{
    public int IdPhuongXa { get; set; }

    public string TenPhuongXa { get; set; } = null!;

    public int IdQuanHuyen { get; set; }

    public virtual ICollection<DiaChiChiTiet> DiaChiChiTiets { get; set; } = new List<DiaChiChiTiet>();

    public virtual QuanHuyen IdQuanHuyenNavigation { get; set; } = null!;
}
