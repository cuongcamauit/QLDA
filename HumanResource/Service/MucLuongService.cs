using AutoMapper;
using HumanResource.Data;
using HumanResource.Dto;
using HumanResource.IService;
using HumanResource.Models;
using HumanResource.View;

namespace HumanResource.Service
{
    public class MucLuongService : IMucLuongService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MucLuongService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(MucLuongView mucLuongView)
        {
            _context.Add(_mapper.Map<MucLuong>(mucLuongView));
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var mucLuong = _context.MucLuongs.FirstOrDefault(o => o.TenMucLuong == id);
            if (mucLuong != null)
            {
                _context.Remove(mucLuong);
                _context.SaveChanges();
            }
        }

        public List<MucLuongDto> GetAll()
        {
            var mucLuongs = _context.MucLuongs.ToList();
            return _mapper.Map<List<MucLuongDto>>(mucLuongs);
        }

        public MucLuongDto GetById(string id)
        {
            var mucLuong = _context.MucLuongs.FirstOrDefault(o => o.TenMucLuong == id);
            return _mapper.Map<MucLuongDto>(mucLuong);
        }

        public void Update(MucLuongDto mucLuongDto)
        {
            _context.Update(_mapper.Map<MucLuong>(mucLuongDto));
            _context.SaveChanges();
        }

        MucLuongDto IMucLuongService.Add(MucLuongView mucLuongView)
        {
            var mucLuong = _mapper.Map<MucLuong>(mucLuongView);
            _context.Add(mucLuong);
            _context.SaveChanges();

            return _mapper.Map<MucLuongDto>(mucLuong);
        }
    }
}
