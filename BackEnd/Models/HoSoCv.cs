using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class HoSoCv
{
    public int IdCv { get; set; }

    public string TenCv { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string? TenFile { get; set; }

    public string LoaiCv { get; set; } = null!;

    public DateTime LanCapNhapCuoiCung { get; set; }

    public int IdUngVien { get; set; }

    public virtual ICollection<ChungChi> ChungChis { get; set; } = new List<ChungChi>();

    public virtual ICollection<DanhHieuVaGiaiThuong> DanhHieuVaGiaiThuongs { get; set; } = new List<DanhHieuVaGiaiThuong>();

    public virtual ICollection<DuAn> DuAns { get; set; } = new List<DuAn>();

    public virtual ICollection<HoatDong> HoatDongs { get; set; } = new List<HoatDong>();

    public virtual ICollection<HocVan> HocVans { get; set; } = new List<HocVan>();

    public virtual UngVien IdUngVienNavigation { get; set; } = null!;

    public virtual ICollection<KinhNghiemLamViec> KinhNghiemLamViecs { get; set; } = new List<KinhNghiemLamViec>();

    public virtual ICollection<KyNang> KyNangs { get; set; } = new List<KyNang>();

    public virtual ICollection<NguoiGioiThieu> NguoiGioiThieus { get; set; } = new List<NguoiGioiThieu>();

    public virtual ICollection<SoThich> SoThiches { get; set; } = new List<SoThich>();

    public virtual ICollection<ThongTinCaNhan> ThongTinCaNhans { get; set; } = new List<ThongTinCaNhan>();
}
