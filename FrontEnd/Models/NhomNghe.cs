using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class NhomNghe
{
    public int IdNhomNghe { get; set; }

    public string TenNhomNghe { get; set; } = null!;

    public virtual ICollection<Nghe> Nghes { get; set; } = new List<Nghe>();
}
