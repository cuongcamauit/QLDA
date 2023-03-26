using HumanResource.Dto;
using HumanResource.View;

namespace HumanResource.IService
{
    public interface IPhongBanService
    {
        List<PhongBanDto> GetAll();
        PhongBanDto GetById(string id);
        void Update(PhongBanDto phongBan);
        PhongBanDto Add(PhongBanView phongBanView);
        void Delete(string id);
    }
}
