using HumanResource.Dto;
using HumanResource.View;

namespace HumanResource.IService
{
    public interface INhanVienService
    {
        void Delete(string id);
        List<NhanVienDto> GetAll();
        NhanVienDto GetById(string id);
        NhanVienDto Add(NhanVienView nhanVien);
        void Update(NhanVienDto nhanVien);
    }
}
