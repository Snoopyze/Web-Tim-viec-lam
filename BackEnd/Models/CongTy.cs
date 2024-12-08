using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class CongTy
{
    public int IdCongTy { get; set; }

    public string LogoUrl { get; set; } = null!;

    public string TenCongTy { get; set; } = null!;

    public string MaSoThue { get; set; } = null!;

    public string WebsiteUrl { get; set; } = null!;

    public string SoLuongNguoiTheoDoi { get; set; } = null!;

    public string QuyMoCongTy { get; set; } = null!;

    public string MoTaCongTy { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<CompanyAddressGroup> CompanyAddressGroups { get; set; } = new List<CompanyAddressGroup>();

    public virtual ICollection<NhaTuyenDung> NhaTuyenDungs { get; set; } = new List<NhaTuyenDung>();

    public virtual ICollection<TheoDoiCongTy> TheoDoiCongTies { get; set; } = new List<TheoDoiCongTy>();
}
