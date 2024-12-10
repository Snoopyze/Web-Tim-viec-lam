using System.Security.Policy;

namespace FrontEnd.Models
{
    public class ApplyJobs
    {
        public int idChiTietTuyenDung {  get; set; }
        public String tieuDeTin {  get; set; }
        public String tenCongTy { get; set; }
        public DateTime thoiGianNop { get; set; }
        public String diaDiemLamViec { get; set; }
        public String mucLuongTu { get; set; }
        public String mucLuongToi { get; set; }
        public int idCongTy { get; set; }
        public String logoUrl { get; set; }
        public String trangThai { get; set; }
        public String cvUrl { get; set; }
    }
}
