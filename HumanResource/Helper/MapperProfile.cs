using AutoMapper;
using HumanResource.Dto;
using HumanResource.Models;
using HumanResource.View;

namespace HumanResource.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MucLuongView, MucLuong>().ReverseMap();
            CreateMap<MucLuongDto, MucLuong>().ReverseMap();

            CreateMap<PhongBanView, PhongBan>().ReverseMap(); 
            CreateMap<PhongBan, PhongBanDto>().ReverseMap();

            CreateMap<NhanVienView, NhanVien>().ReverseMap();
            CreateMap<NhanVien, NhanVienDto>().ReverseMap();

        }
    }
}
