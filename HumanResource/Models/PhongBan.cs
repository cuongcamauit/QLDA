namespace HumanResource.Models
{
    public class PhongBan
    {
        public string? MaPhongBan { get; set; }
        public string? TenPhongBan { get; set; }
        public int SoLuongNhanVien { get; set; } = 0;
        public string? MaNguoiTruong { get; set; }
        public ICollection<NhanVien>? NhanViens { get; set;}
        public NhanVien? NguoiTruong { get; set; }
    }
}
