namespace HumanResource.Models
{
    public class NhanVien
    {
        public string? MaNV { get; set; }
        public string? HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? MaPhongBan { get; set; }
        public string? TenMucLuong { get; set; }
        public PhongBan? PhongBan { get; set; }
        public MucLuong? MucLuong { get; set; }
    }
}
