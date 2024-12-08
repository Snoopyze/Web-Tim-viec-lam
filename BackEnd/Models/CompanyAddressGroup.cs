using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class CompanyAddressGroup
{
    public int IdNhom { get; set; }

    public int IdCongTy { get; set; }

    public int IdDiaChi { get; set; }

    public virtual CongTy IdCongTyNavigation { get; set; } = null!;

    public virtual DiaChiChiTiet IdDiaChiNavigation { get; set; } = null!;
}
