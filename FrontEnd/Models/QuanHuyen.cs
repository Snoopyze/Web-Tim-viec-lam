using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class QuanHuyen
{
    public int IdQuanHuyen { get; set; }

    public string TenQuanHuyen { get; set; } = null!;

    public int IdThanhPho { get; set; }

    public virtual ThanhPho IdThanhPhoNavigation { get; set; } = null!;

    public virtual ICollection<PhuongXa> PhuongXas { get; set; } = new List<PhuongXa>();
}
