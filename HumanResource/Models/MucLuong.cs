namespace HumanResource.Models
{
    public class MucLuong
    {
        public string? TenMucLuong { get; set; }
        public float SoTien { get; set; }
        public string? MoTa { get; set; }
        public ICollection<NhanVien>? NhanViens { get; set;}
    }
}
