using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class Nghe
{
    public int IdNghe { get; set; }

    public string TenNghe { get; set; } = null!;

    public int IdNhomNghe { get; set; }

    public virtual NhomNghe IdNhomNgheNavigation { get; set; } = null!;

    public virtual ICollection<ViTriChuyenMon> ViTriChuyenMons { get; set; } = new List<ViTriChuyenMon>();
}
