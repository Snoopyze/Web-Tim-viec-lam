using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class ViTriChuyenMon
{
    public int IdViTriChuyenMon { get; set; }

    public string TenViTriChuyenMon { get; set; } = null!;

    public int IdNghe { get; set; }

    public virtual Nghe IdNgheNavigation { get; set; } = null!;
}
