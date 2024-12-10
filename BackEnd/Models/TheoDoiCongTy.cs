using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public partial class TheoDoiCongTy
{
    [Key] // Đảm bảo rằng đây là khóa chính
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTheoDoiCongTy { get; set; }

    public DateTime ThoiGianTheoGioi { get; set; }

    public int IdUngVien { get; set; }

    public int IdCongTy { get; set; }

    public virtual CongTy IdCongTyNavigation { get; set; } = null!;

    public virtual UngVien IdUngVienNavigation { get; set; } = null!;
}
