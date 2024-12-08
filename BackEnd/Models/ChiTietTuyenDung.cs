using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class ChiTietTuyenDung
{
    public int IdChiTietTuyenDung { get; set; }

    public string TieuDeTin { get; set; } = null!;

    public string KinhNghiem { get; set; } = null!;

    public string MoTaCongViec { get; set; } = null!;

    public string YeuCauUngVien { get; set; } = null!;

    public string QuyenLoiUngVien { get; set; } = null!;

    public string CachThucUngTuyen { get; set; } = null!;

    public string LoaiCongViec { get; set; } = null!;

    public string MucLuongTu { get; set; } = null!;

    public string MucLuongToi { get; set; } = null!;

    public string LoaiTienTe { get; set; } = null!;

    public DateOnly HanNopHoSo { get; set; }

    public string SoLuongUngTuyen { get; set; } = null!;

    public string DiaDiemLamViecCuThe { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string ThoiGianLamViecTuThu { get; set; } = null!;

    public string ThoiGianLamViecDenThu { get; set; } = null!;

    public TimeOnly ThoiGianLamViecTuGio { get; set; }

    public TimeOnly ThoiGianLamViecDenGio { get; set; }

    public string HoTenNguoiNhan { get; set; } = null!;

    public string SoDienThoaiNguoiNhan { get; set; } = null!;

    public string EmailNguoiNhan { get; set; } = null!;

    public int IdNhaTuyenDung { get; set; }

    public int ViTriChuyenMon { get; set; }

    public int ChiTietDiaDiemLamViec { get; set; }

    public virtual ICollection<HoSoDaNop> HoSoDaNops { get; set; } = new List<HoSoDaNop>();

    public virtual NhaTuyenDung IdNhaTuyenDungNavigation { get; set; } = null!;

    public virtual ICollection<LuuTinTuyenDung> LuuTinTuyenDungs { get; set; } = new List<LuuTinTuyenDung>();
}
