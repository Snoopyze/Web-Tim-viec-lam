using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class ThanhPho
{
    public int IdThanhPho { get; set; }

    public string TenThanhPho { get; set; } = null!;

    public virtual ICollection<QuanHuyen> QuanHuyens { get; set; } = new List<QuanHuyen>();
}
