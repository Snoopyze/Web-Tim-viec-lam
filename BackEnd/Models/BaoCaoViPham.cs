using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class BaoCaoViPham
{
    public int IdBaoCaoViPham { get; set; }

    public string TieuDe { get; set; } = null!;

    public string LoaiBaoCao { get; set; } = null!;

    public string MoTa { get; set; } = null!;

    public string TaiLieuChungMinhUrl { get; set; } = null!;

    public int IdNhaTuyenDung { get; set; }

    public virtual NhaTuyenDung IdNhaTuyenDungNavigation { get; set; } = null!;
}
