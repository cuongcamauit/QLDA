using HumanResource.Dto;
using HumanResource.View;

namespace HumanResource.IService
{
    public interface IMucLuongService
    {
        MucLuongDto Add(MucLuongView mucLuongView);
        void Delete(string id);
        List<MucLuongDto> GetAll();
        MucLuongDto GetById(string id);
        void Update(MucLuongDto mucLuongDto);
    }
}
