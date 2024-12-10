using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public partial class DbQlcvContext : DbContext
{
    public DbQlcvContext()
    {
    }

    public DbQlcvContext(DbContextOptions<DbQlcvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoCaoViPham> BaoCaoViPhams { get; set; }

    public virtual DbSet<ChiTietTuyenDung> ChiTietTuyenDungs { get; set; }

    public virtual DbSet<ChungChi> ChungChis { get; set; }

    public virtual DbSet<CompanyAddressGroup> CompanyAddressGroups { get; set; }

    public virtual DbSet<CongTy> CongTies { get; set; }

    public virtual DbSet<DanhHieuVaGiaiThuong> DanhHieuVaGiaiThuongs { get; set; }

    public virtual DbSet<DiaChiChiTiet> DiaChiChiTiets { get; set; }

    public virtual DbSet<DuAn> DuAns { get; set; }

    public virtual DbSet<GopYsanPham> GopYsanPhams { get; set; }

    public virtual DbSet<HoSoCv> HoSoCvs { get; set; }

    public virtual DbSet<HoSoDaNop> HoSoDaNops { get; set; }

    public virtual DbSet<HoatDong> HoatDongs { get; set; }

    public virtual DbSet<HocVan> HocVans { get; set; }

    public virtual DbSet<KinhNghiemLamViec> KinhNghiemLamViecs { get; set; }

    public virtual DbSet<KyNang> KyNangs { get; set; }

    public virtual DbSet<LuuTinTuyenDung> LuuTinTuyenDungs { get; set; }

    public virtual DbSet<Nghe> Nghes { get; set; }

    public virtual DbSet<NguoiGioiThieu> NguoiGioiThieus { get; set; }

    public virtual DbSet<NhaTuyenDung> NhaTuyenDungs { get; set; }

    public virtual DbSet<NhomNghe> NhomNghes { get; set; }

    public virtual DbSet<PhuongXa> PhuongXas { get; set; }

    public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }

    public virtual DbSet<SoThich> SoThiches { get; set; }

    public virtual DbSet<ThanhPho> ThanhPhos { get; set; }

    public virtual DbSet<TheoDoiCongTy> TheoDoiCongTies { get; set; }

    public virtual DbSet<ThongTinCaNhan> ThongTinCaNhans { get; set; }

    public virtual DbSet<UngVien> UngViens { get; set; }

    public virtual DbSet<ViTriChuyenMon> ViTriChuyenMons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5TSOTHIM\\MHANG;Initial Catalog=dbQLCV;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoCaoViPham>(entity =>
        {
            entity.HasKey(e => e.IdBaoCaoViPham).HasName("PK__baoCaoVi__54C15F2543B3F65B");

            entity.ToTable("baoCaoViPham");

            entity.Property(e => e.IdBaoCaoViPham)
                .ValueGeneratedNever()
                .HasColumnName("id_baoCaoViPham");
            entity.Property(e => e.IdNhaTuyenDung).HasColumnName("id_nhaTuyenDung");
            entity.Property(e => e.LoaiBaoCao)
                .HasMaxLength(255)
                .HasColumnName("loaiBaoCao");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.TaiLieuChungMinhUrl).HasColumnName("taiLieuChungMinhURL");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasColumnName("tieuDe");

            entity.HasOne(d => d.IdNhaTuyenDungNavigation).WithMany(p => p.BaoCaoViPhams)
                .HasForeignKey(d => d.IdNhaTuyenDung)
                .HasConstraintName("FK__baoCaoViP__id_nh__6B24EA82");
        });

        modelBuilder.Entity<ChiTietTuyenDung>(entity =>
        {
            entity.HasKey(e => e.IdChiTietTuyenDung).HasName("PK__chiTietT__09A6AF7387901C6B");

            entity.ToTable("chiTietTuyenDung");

            entity.Property(e => e.IdChiTietTuyenDung)
                .ValueGeneratedNever()
                .HasColumnName("id_chiTietTuyenDung");
            entity.Property(e => e.CachThucUngTuyen).HasColumnName("cachThucUngTuyen");
            entity.Property(e => e.ChiTietDiaDiemLamViec).HasColumnName("chiTietDiaDiemLamViec");
            entity.Property(e => e.DiaDiemLamViecCuThe).HasColumnName("diaDiemLamViecCuThe");
            entity.Property(e => e.EmailNguoiNhan)
                .HasMaxLength(255)
                .HasColumnName("emailNguoiNhan");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(255)
                .HasColumnName("gioiTinh");
            entity.Property(e => e.HanNopHoSo).HasColumnName("hanNopHoSo");
            entity.Property(e => e.HoTenNguoiNhan)
                .HasMaxLength(255)
                .HasColumnName("hoTenNguoiNhan");
            entity.Property(e => e.IdNhaTuyenDung).HasColumnName("id_nhaTuyenDung");
            entity.Property(e => e.KinhNghiem)
                .HasMaxLength(255)
                .HasColumnName("kinhNghiem");
            entity.Property(e => e.LoaiCongViec)
                .HasMaxLength(255)
                .HasColumnName("loaiCongViec");
            entity.Property(e => e.LoaiTienTe)
                .HasMaxLength(255)
                .HasColumnName("loaiTienTe");
            entity.Property(e => e.MoTaCongViec).HasColumnName("moTaCongViec");
            entity.Property(e => e.MucLuongToi)
                .HasMaxLength(255)
                .HasColumnName("mucLuongToi");
            entity.Property(e => e.MucLuongTu)
                .HasMaxLength(255)
                .HasColumnName("mucLuongTu");
            entity.Property(e => e.QuyenLoiUngVien).HasColumnName("quyenLoiUngVien");
            entity.Property(e => e.SoDienThoaiNguoiNhan)
                .HasMaxLength(255)
                .HasColumnName("soDienThoaiNguoiNhan");
            entity.Property(e => e.SoLuongUngTuyen)
                .HasMaxLength(255)
                .HasColumnName("soLuongUngTuyen");
            entity.Property(e => e.ThoiGianLamViecDenGio).HasColumnName("thoiGianLamViecDenGio");
            entity.Property(e => e.ThoiGianLamViecDenThu)
                .HasMaxLength(255)
                .HasColumnName("thoiGianLamViecDenThu");
            entity.Property(e => e.ThoiGianLamViecTuGio).HasColumnName("thoiGianLamViecTuGio");
            entity.Property(e => e.ThoiGianLamViecTuThu)
                .HasMaxLength(255)
                .HasColumnName("thoiGianLamViecTuThu");
            entity.Property(e => e.TieuDeTin)
                .HasMaxLength(255)
                .HasColumnName("tieuDeTin");
            entity.Property(e => e.ViTriChuyenMon).HasColumnName("viTriChuyenMon");
            entity.Property(e => e.YeuCauUngVien).HasColumnName("yeuCauUngVien");

            entity.HasOne(d => d.IdNhaTuyenDungNavigation).WithMany(p => p.ChiTietTuyenDungs)
                .HasForeignKey(d => d.IdNhaTuyenDung)
                .HasConstraintName("FK__chiTietTu__id_nh__6C190EBB");
        });

        modelBuilder.Entity<ChungChi>(entity =>
        {
            entity.HasKey(e => e.IdChungChi).HasName("PK__chungChi__42693434B24E1B29");

            entity.ToTable("chungChi");

            entity.Property(e => e.IdChungChi)
                .ValueGeneratedNever()
                .HasColumnName("id_chungChi");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.TenChungChi)
                .HasMaxLength(255)
                .HasColumnName("tenChungChi");
            entity.Property(e => e.ThoiGian)
                .HasMaxLength(255)
                .HasColumnName("thoiGian");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.ChungChis)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__chungChi__id_CV__6D0D32F4");
        });

        modelBuilder.Entity<CompanyAddressGroup>(entity =>
        {
            entity.HasKey(e => e.IdNhom).HasName("PK__CompanyA__284B2F9C32861B35");

            entity.Property(e => e.IdNhom)
                .ValueGeneratedNever()
                .HasColumnName("id_nhom");
            entity.Property(e => e.IdCongTy).HasColumnName("id_congTy");
            entity.Property(e => e.IdDiaChi).HasColumnName("id_diaChi");

            entity.HasOne(d => d.IdCongTyNavigation).WithMany(p => p.CompanyAddressGroups)
                .HasForeignKey(d => d.IdCongTy)
                .HasConstraintName("FK__CompanyAd__id_co__6E01572D");

            entity.HasOne(d => d.IdDiaChiNavigation).WithMany(p => p.CompanyAddressGroups)
                .HasForeignKey(d => d.IdDiaChi)
                .HasConstraintName("FK__CompanyAd__id_di__6EF57B66");
        });

        modelBuilder.Entity<CongTy>(entity =>
        {
            entity.HasKey(e => e.IdCongTy).HasName("PK__congTy__8E55AAFDC6852E99");

            entity.ToTable("congTy");

            entity.Property(e => e.IdCongTy)
                .ValueGeneratedNever()
                .HasColumnName("id_congTy");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LogoUrl).HasColumnName("logoURL");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(255)
                .HasColumnName("maSoThue");
            entity.Property(e => e.MoTaCongTy).HasColumnName("moTaCongTy");
            entity.Property(e => e.QuyMoCongTy)
                .HasMaxLength(255)
                .HasColumnName("quyMoCongTy");
            entity.Property(e => e.SoLuongNguoiTheoDoi)
                .HasMaxLength(255)
                .HasColumnName("soLuongNguoiTheoDoi");
            entity.Property(e => e.TenCongTy)
                .HasMaxLength(255)
                .HasColumnName("tenCongTy");
            entity.Property(e => e.WebsiteUrl).HasColumnName("websiteURL");
        });

        modelBuilder.Entity<DanhHieuVaGiaiThuong>(entity =>
        {
            entity.HasKey(e => e.IdDanhHieuVaGiaiThuong).HasName("PK__danhHieu__7067C7B164FCF7CB");

            entity.ToTable("danhHieuVaGiaiThuong");

            entity.Property(e => e.IdDanhHieuVaGiaiThuong)
                .ValueGeneratedNever()
                .HasColumnName("id_danhHieuVaGiaiThuong");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.TenGiaiThuong)
                .HasMaxLength(255)
                .HasColumnName("tenGiaiThuong");
            entity.Property(e => e.ThoiGian)
                .HasMaxLength(255)
                .HasColumnName("thoiGian");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.DanhHieuVaGiaiThuongs)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__danhHieuV__id_CV__6FE99F9F");
        });

        modelBuilder.Entity<DiaChiChiTiet>(entity =>
        {
            entity.HasKey(e => e.IdDiaChi).HasName("PK__diaChiCh__6717CFC584CC448D");

            entity.ToTable("diaChiChiTiet");

            entity.Property(e => e.IdDiaChi)
                .ValueGeneratedNever()
                .HasColumnName("id_diaChi");
            entity.Property(e => e.IdPhuongXa).HasColumnName("id_phuongXa");
            entity.Property(e => e.MoTaChiTiet)
                .HasMaxLength(255)
                .HasColumnName("moTaChiTiet");

            entity.HasOne(d => d.IdPhuongXaNavigation).WithMany(p => p.DiaChiChiTiets)
                .HasForeignKey(d => d.IdPhuongXa)
                .HasConstraintName("FK__diaChiChi__id_ph__70DDC3D8");
        });

        modelBuilder.Entity<DuAn>(entity =>
        {
            entity.HasKey(e => e.IdDuAn).HasName("PK__duAn__9FEEC94D5B305E8A");

            entity.ToTable("duAn");

            entity.Property(e => e.IdDuAn)
                .ValueGeneratedNever()
                .HasColumnName("id_duAn");
            entity.Property(e => e.BatDau)
                .HasMaxLength(255)
                .HasColumnName("batDau");
            entity.Property(e => e.CongNgheSuDung)
                .HasMaxLength(255)
                .HasColumnName("congNgheSuDung");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.KetThuc)
                .HasMaxLength(255)
                .HasColumnName("ketThuc");
            entity.Property(e => e.MoTaVaiTro)
                .HasMaxLength(255)
                .HasColumnName("moTaVaiTro");
            entity.Property(e => e.SoLuongThamGia)
                .HasMaxLength(255)
                .HasColumnName("soLuongThamGia");
            entity.Property(e => e.TenDuAn)
                .HasMaxLength(255)
                .HasColumnName("tenDuAn");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(255)
                .HasColumnName("tenKhachHang");
            entity.Property(e => e.ViTriTrongDuAn)
                .HasMaxLength(255)
                .HasColumnName("viTriTrongDuAn");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.DuAns)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__duAn__id_CV__71D1E811");
        });

        modelBuilder.Entity<GopYsanPham>(entity =>
        {
            entity.HasKey(e => e.IdGopYsanPham).HasName("PK__gopYSanP__0B79301D1942B650");

            entity.ToTable("gopYSanPham");

            entity.Property(e => e.IdGopYsanPham)
                .ValueGeneratedNever()
                .HasColumnName("id_gopYSanPham");
            entity.Property(e => e.DoiTuongGopY)
                .HasMaxLength(255)
                .HasColumnName("doiTuongGopY");
            entity.Property(e => e.IdNhaTuyenDung).HasColumnName("id_nhaTuyenDung");
            entity.Property(e => e.NoiDungGopY).HasColumnName("noiDungGopY");
            entity.Property(e => e.TaiLieuMinhHoaUrl).HasColumnName("taiLieuMinhHoaURL");

            entity.HasOne(d => d.IdNhaTuyenDungNavigation).WithMany(p => p.GopYsanPhams)
                .HasForeignKey(d => d.IdNhaTuyenDung)
                .HasConstraintName("FK__gopYSanPh__id_nh__72C60C4A");
        });

        modelBuilder.Entity<HoSoCv>(entity =>
        {
            entity.HasKey(e => e.IdCv).HasName("PK__hoSoCV__0148D53D030CDE72");

            entity.ToTable("hoSoCV");

            entity.Property(e => e.IdCv)
                .ValueGeneratedNever()
                .HasColumnName("id_CV");
            entity.Property(e => e.FileUrl).HasColumnName("fileURL");
            entity.Property(e => e.IdUngVien).HasColumnName("id_ungVien");
            entity.Property(e => e.LanCapNhapCuoiCung)
                .HasColumnType("datetime")
                .HasColumnName("lanCapNhapCuoiCung");
            entity.Property(e => e.LoaiCv)
                .HasMaxLength(255)
                .HasColumnName("loaiCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(255)
                .HasColumnName("tenCV");
            entity.Property(e => e.TenFile)
                .HasMaxLength(255)
                .HasColumnName("tenFile");

            entity.HasOne(d => d.IdUngVienNavigation).WithMany(p => p.HoSoCvs)
                .HasForeignKey(d => d.IdUngVien)
                .HasConstraintName("FK__hoSoCV__id_ungVi__75A278F5");
        });

        modelBuilder.Entity<HoSoDaNop>(entity =>
        {
            entity.HasKey(e => e.IdHoSoDaNop).HasName("PK__hoSoDaNo__E3421FB540FCA509");

            entity.ToTable("hoSoDaNop");

            entity.Property(e => e.IdHoSoDaNop)
                .ValueGeneratedNever()
                .HasColumnName("id_hoSoDaNop");
            entity.Property(e => e.IdChiTietTuyenDung).HasColumnName("id_chiTietTuyenDung");
            entity.Property(e => e.IdUngVien).HasColumnName("id_ungVien");
            entity.Property(e => e.ThoiGianNop)
                .HasColumnType("datetime")
                .HasColumnName("thoiGianNop");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(255)
                .HasColumnName("trangThai");

            entity.HasOne(d => d.IdChiTietTuyenDungNavigation).WithMany(p => p.HoSoDaNops)
                .HasForeignKey(d => d.IdChiTietTuyenDung)
                .HasConstraintName("FK__hoSoDaNop__id_ch__76969D2E");

            entity.HasOne(d => d.IdUngVienNavigation).WithMany(p => p.HoSoDaNops)
                .HasForeignKey(d => d.IdUngVien)
                .HasConstraintName("FK__hoSoDaNop__id_un__778AC167");
        });

        modelBuilder.Entity<HoatDong>(entity =>
        {
            entity.HasKey(e => e.IdHoatDong).HasName("PK__hoatDong__C602DF2141234D1C");

            entity.ToTable("hoatDong");

            entity.Property(e => e.IdHoatDong)
                .ValueGeneratedNever()
                .HasColumnName("id_hoatDong");
            entity.Property(e => e.BatDau)
                .HasMaxLength(255)
                .HasColumnName("batDau");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.KetThuc)
                .HasMaxLength(255)
                .HasColumnName("ketThuc");
            entity.Property(e => e.MoTaHoatDong).HasColumnName("moTaHoatDong");
            entity.Property(e => e.TenToChuc)
                .HasMaxLength(255)
                .HasColumnName("tenToChuc");
            entity.Property(e => e.ViTriCuaBan)
                .HasMaxLength(255)
                .HasColumnName("viTriCuaBan");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.HoatDongs)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__hoatDong__id_CV__73BA3083");
        });

        modelBuilder.Entity<HocVan>(entity =>
        {
            entity.HasKey(e => e.IdHocVan).HasName("PK__hocVan__4CD14F9A93A05683");

            entity.ToTable("hocVan");

            entity.Property(e => e.IdHocVan)
                .ValueGeneratedNever()
                .HasColumnName("id_hocVan");
            entity.Property(e => e.BatDau)
                .HasMaxLength(255)
                .HasColumnName("batDau");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.KetThuc)
                .HasMaxLength(255)
                .HasColumnName("ketThuc");
            entity.Property(e => e.NganhHoc)
                .HasMaxLength(255)
                .HasColumnName("nganhHoc");
            entity.Property(e => e.TenTruongHoc)
                .HasMaxLength(255)
                .HasColumnName("tenTruongHoc");
            entity.Property(e => e.ThanhTich).HasColumnName("thanhTich");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.HocVans)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__hocVan__id_CV__74AE54BC");
        });

        modelBuilder.Entity<KinhNghiemLamViec>(entity =>
        {
            entity.HasKey(e => e.IdKinhNghiemLamViec).HasName("PK__kinhNghi__C3A1777E721C4BDC");

            entity.ToTable("kinhNghiemLamViec");

            entity.Property(e => e.IdKinhNghiemLamViec)
                .ValueGeneratedNever()
                .HasColumnName("id_kinhNghiemLamViec");
            entity.Property(e => e.BatDau)
                .HasMaxLength(255)
                .HasColumnName("batDau");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.KetThuc)
                .HasMaxLength(255)
                .HasColumnName("ketThuc");
            entity.Property(e => e.MoTaKinhNghiemLamViec).HasColumnName("moTaKinhNghiemLamViec");
            entity.Property(e => e.TenCongTy)
                .HasMaxLength(255)
                .HasColumnName("tenCongTy");
            entity.Property(e => e.ViTriCongViec)
                .HasMaxLength(255)
                .HasColumnName("viTriCongViec");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.KinhNghiemLamViecs)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__kinhNghie__id_CV__787EE5A0");
        });

        modelBuilder.Entity<KyNang>(entity =>
        {
            entity.HasKey(e => e.IdKyNang).HasName("PK__kyNang__0737F3095A7A5422");

            entity.ToTable("kyNang");

            entity.Property(e => e.IdKyNang)
                .ValueGeneratedNever()
                .HasColumnName("id_kyNang");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.TenKyNang)
                .HasMaxLength(255)
                .HasColumnName("tenKyNang");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.KyNangs)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__kyNang__id_CV__797309D9");
        });

        modelBuilder.Entity<LuuTinTuyenDung>(entity =>
        {
            entity.HasKey(e => e.IdLuuTinTuyenDung).HasName("PK__luuTinTu__EF94723B913800C0");

            entity.ToTable("luuTinTuyenDung");

            entity.Property(e => e.IdLuuTinTuyenDung)
                .ValueGeneratedNever()
                .HasColumnName("id_luuTinTuyenDung");
            entity.Property(e => e.IdChiTietTuyenDung).HasColumnName("id_chiTietTuyenDung");
            entity.Property(e => e.IdUngVien).HasColumnName("id_ungVien");
            entity.Property(e => e.ThoiGianLuuTin)
                .HasColumnType("datetime")
                .HasColumnName("thoiGianLuuTin");

            entity.HasOne(d => d.IdChiTietTuyenDungNavigation).WithMany(p => p.LuuTinTuyenDungs)
                .HasForeignKey(d => d.IdChiTietTuyenDung)
                .HasConstraintName("FK__luuTinTuy__id_ch__7A672E12");

            entity.HasOne(d => d.IdUngVienNavigation).WithMany(p => p.LuuTinTuyenDungs)
                .HasForeignKey(d => d.IdUngVien)
                .HasConstraintName("FK__luuTinTuy__id_un__7B5B524B");
        });

        modelBuilder.Entity<Nghe>(entity =>
        {
            entity.HasKey(e => e.IdNghe).HasName("PK__nghe__391BF63C6443192D");

            entity.ToTable("nghe");

            entity.Property(e => e.IdNghe)
                .ValueGeneratedNever()
                .HasColumnName("id_nghe");
            entity.Property(e => e.IdNhomNghe).HasColumnName("id_nhomNghe");
            entity.Property(e => e.TenNghe)
                .HasMaxLength(255)
                .HasColumnName("tenNghe");

            entity.HasOne(d => d.IdNhomNgheNavigation).WithMany(p => p.Nghes)
                .HasForeignKey(d => d.IdNhomNghe)
                .HasConstraintName("FK__nghe__id_nhomNgh__7C4F7684");
        });

        modelBuilder.Entity<NguoiGioiThieu>(entity =>
        {
            entity.HasKey(e => e.IdNguoiGioiThieu).HasName("PK__nguoiGio__A91C9321E221CFEC");

            entity.ToTable("nguoiGioiThieu");

            entity.Property(e => e.IdNguoiGioiThieu)
                .ValueGeneratedNever()
                .HasColumnName("id_nguoiGioiThieu");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.ThongTinNguoiGioiThieu).HasColumnName("thongTinNguoiGioiThieu");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.NguoiGioiThieus)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__nguoiGioi__id_CV__7D439ABD");
        });

        modelBuilder.Entity<NhaTuyenDung>(entity =>
        {
            entity.HasKey(e => e.IdNhaTuyenDung).HasName("PK__nhaTuyen__54ABECC06C6BC58F");

            entity.ToTable("nhaTuyenDung");

            entity.Property(e => e.IdNhaTuyenDung)
                .ValueGeneratedNever()
                .HasColumnName("id_nhaTuyenDung");
            entity.Property(e => e.AnhHoSoUrl).HasColumnName("anhHoSoURL");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.IdCongTy).HasColumnName("id_congTy");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("matKhau");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(255)
                .HasColumnName("soDienThoai");

            entity.HasOne(d => d.IdCongTyNavigation).WithMany(p => p.NhaTuyenDungs)
                .HasForeignKey(d => d.IdCongTy)
                .HasConstraintName("FK__nhaTuyenD__id_co__7E37BEF6");
        });

        modelBuilder.Entity<NhomNghe>(entity =>
        {
            entity.HasKey(e => e.IdNhomNghe).HasName("PK__nhomNghe__865F6A7A6165CA1D");

            entity.ToTable("nhomNghe");

            entity.Property(e => e.IdNhomNghe)
                .ValueGeneratedNever()
                .HasColumnName("id_nhomNghe");
            entity.Property(e => e.TenNhomNghe)
                .HasMaxLength(255)
                .HasColumnName("tenNhomNghe");
        });

        modelBuilder.Entity<PhuongXa>(entity =>
        {
            entity.HasKey(e => e.IdPhuongXa).HasName("PK__phuongXa__98DDE181D7AF5D52");

            entity.ToTable("phuongXa");

            entity.Property(e => e.IdPhuongXa)
                .ValueGeneratedNever()
                .HasColumnName("id_phuongXa");
            entity.Property(e => e.IdQuanHuyen).HasColumnName("id_quanHuyen");
            entity.Property(e => e.TenPhuongXa)
                .HasMaxLength(255)
                .HasColumnName("tenPhuongXa");

            entity.HasOne(d => d.IdQuanHuyenNavigation).WithMany(p => p.PhuongXas)
                .HasForeignKey(d => d.IdQuanHuyen)
                .HasConstraintName("FK__phuongXa__id_qua__7F2BE32F");
        });

        modelBuilder.Entity<QuanHuyen>(entity =>
        {
            entity.HasKey(e => e.IdQuanHuyen).HasName("PK__quanHuye__A07B6690B8134853");

            entity.ToTable("quanHuyen");

            entity.Property(e => e.IdQuanHuyen)
                .ValueGeneratedNever()
                .HasColumnName("id_quanHuyen");
            entity.Property(e => e.IdThanhPho).HasColumnName("id_thanhPho");
            entity.Property(e => e.TenQuanHuyen)
                .HasMaxLength(255)
                .HasColumnName("tenQuanHuyen");

            entity.HasOne(d => d.IdThanhPhoNavigation).WithMany(p => p.QuanHuyens)
                .HasForeignKey(d => d.IdThanhPho)
                .HasConstraintName("FK__quanHuyen__id_th__00200768");
        });

        modelBuilder.Entity<SoThich>(entity =>
        {
            entity.HasKey(e => e.IdSoThich).HasName("PK__soThich__DB07DE5308FF9FCF");

            entity.ToTable("soThich");

            entity.Property(e => e.IdSoThich)
                .ValueGeneratedNever()
                .HasColumnName("id_soThich");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.TenSoThich)
                .HasMaxLength(255)
                .HasColumnName("tenSoThich");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.SoThiches)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__soThich__id_CV__01142BA1");
        });

        modelBuilder.Entity<ThanhPho>(entity =>
        {
            entity.HasKey(e => e.IdThanhPho).HasName("PK__thanhPho__63AFC1F6A0F42624");

            entity.ToTable("thanhPho");

            entity.Property(e => e.IdThanhPho)
                .ValueGeneratedNever()
                .HasColumnName("id_thanhPho");
            entity.Property(e => e.TenThanhPho)
                .HasMaxLength(255)
                .HasColumnName("tenThanhPho");
        });

        modelBuilder.Entity<TheoDoiCongTy>(entity =>
        {
            entity.HasKey(e => e.IdTheoDoiCongTy).HasName("PK__theoDoiC__9E136BC280C3A694");

            entity.ToTable("theoDoiCongTy");

            entity.Property(e => e.IdTheoDoiCongTy)
                .ValueGeneratedNever()
                .HasColumnName("id_theoDoiCongTy");
            entity.Property(e => e.IdCongTy).HasColumnName("id_congTy");
            entity.Property(e => e.IdUngVien).HasColumnName("id_ungVien");
            entity.Property(e => e.ThoiGianTheoGioi)
                .HasColumnType("datetime")
                .HasColumnName("thoiGianTheoGioi");

            entity.HasOne(d => d.IdCongTyNavigation).WithMany(p => p.TheoDoiCongTies)
                .HasForeignKey(d => d.IdCongTy)
                .HasConstraintName("FK__theoDoiCo__id_co__02FC7413");

            entity.HasOne(d => d.IdUngVienNavigation).WithMany(p => p.TheoDoiCongTies)
                .HasForeignKey(d => d.IdUngVien)
                .HasConstraintName("FK__theoDoiCo__id_un__02084FDA");
        });

        modelBuilder.Entity<ThongTinCaNhan>(entity =>
        {
            entity.HasKey(e => e.IdThongTinCaNhan).HasName("PK__thongTin__30D1480E12E587B1");

            entity.ToTable("thongTinCaNhan");

            entity.Property(e => e.IdThongTinCaNhan)
                .ValueGeneratedNever()
                .HasColumnName("id_thongTinCaNhan");
            entity.Property(e => e.DiaChiThuongTru).HasColumnName("diaChiThuongTru");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.IdCv).HasColumnName("id_CV");
            entity.Property(e => e.MucTieuNgheNghiep).HasColumnName("mucTieuNgheNghiep");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(255)
                .HasColumnName("soDienThoai");
            entity.Property(e => e.UrlLink).HasColumnName("urlLink");
            entity.Property(e => e.ViTriUngTuyen)
                .HasMaxLength(255)
                .HasColumnName("viTriUngTuyen");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.ThongTinCaNhans)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__thongTinC__id_CV__03F0984C");
        });

        modelBuilder.Entity<UngVien>(entity =>
        {
            entity.HasKey(e => e.IdUngVien).HasName("PK__ungVien__EE70B4636A5AE7B0");

            entity.ToTable("ungVien");

            entity.Property(e => e.IdUngVien)
                .ValueGeneratedNever()
                .HasColumnName("id_ungVien");
            entity.Property(e => e.AnhHoSo).HasColumnName("anhHoSo");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("matKhau");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(255)
                .HasColumnName("soDienThoai");
        });

        modelBuilder.Entity<ViTriChuyenMon>(entity =>
        {
            entity.HasKey(e => e.IdViTriChuyenMon).HasName("PK__viTriChu__636B9648A30C1F50");

            entity.ToTable("viTriChuyenMon");

            entity.Property(e => e.IdViTriChuyenMon)
                .ValueGeneratedNever()
                .HasColumnName("id_viTriChuyenMon");
            entity.Property(e => e.IdNghe).HasColumnName("id_nghe");
            entity.Property(e => e.TenViTriChuyenMon)
                .HasMaxLength(255)
                .HasColumnName("tenViTriChuyenMon");

            entity.HasOne(d => d.IdNgheNavigation).WithMany(p => p.ViTriChuyenMons)
                .HasForeignKey(d => d.IdNghe)
                .HasConstraintName("FK__viTriChuy__id_ng__04E4BC85");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
