using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class UngVien
{
    public int IdUngVien { get; set; }

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string AnhHoSo { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public virtual ICollection<HoSoCv> HoSoCvs { get; set; } = new List<HoSoCv>();

    public virtual ICollection<HoSoDaNop> HoSoDaNops { get; set; } = new List<HoSoDaNop>();

    public virtual ICollection<LuuTinTuyenDung> LuuTinTuyenDungs { get; set; } = new List<LuuTinTuyenDung>();

    public virtual ICollection<TheoDoiCongTy> TheoDoiCongTies { get; set; } = new List<TheoDoiCongTy>();
}
