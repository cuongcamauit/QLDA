using AutoMapper;
using HumanResource.Data;
using HumanResource.Dto;
using HumanResource.IService;
using HumanResource.Models;
using HumanResource.View;

namespace HumanResource.Service
{
    public class PhongBanService : IPhongBanService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PhongBanService(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public PhongBanDto Add(PhongBanView phongBanView)
        {
            var phongBan = _mapper.Map<PhongBan>(phongBanView);
            _context.Add(phongBan);
            _context.SaveChanges();

            return _mapper.Map<PhongBanDto>(phongBan);
        }

        public void Delete(string id)
        {
            var phongBan = _context.PhongBans.FirstOrDefault(o => o.MaPhongBan == id);
            if (phongBan != null)
            {
                _context.Remove(phongBan);
                _context.SaveChanges();
            }
        }

        public List<PhongBanDto> GetAll()
        {
            var phongBans = _context.PhongBans.ToList();
            return _mapper.Map<List<PhongBanDto>>(phongBans);
        }

        public PhongBanDto GetById(string id)
        {
            var phongBan = _context.PhongBans.FirstOrDefault(o => o.MaPhongBan == id);
            return _mapper.Map<PhongBanDto>(phongBan);
        }

        public void Update(PhongBanDto phongBan)
        {
            _context.Update(_mapper.Map<PhongBan>(phongBan));
            _context.SaveChanges();
        }
    }
}
