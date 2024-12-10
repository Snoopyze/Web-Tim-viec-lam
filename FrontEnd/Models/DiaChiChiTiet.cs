using System;
using System.Collections.Generic;

namespace FrontEnd.Models;

public partial class DiaChiChiTiet
{
    public int IdDiaChi { get; set; }

    public string MoTaChiTiet { get; set; } = null!;

    public int IdPhuongXa { get; set; }

    public virtual ICollection<CompanyAddressGroup> CompanyAddressGroups { get; set; } = new List<CompanyAddressGroup>();

    public virtual PhuongXa IdPhuongXaNavigation { get; set; } = null!;
}
