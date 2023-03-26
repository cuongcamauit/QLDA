using AutoMapper;
using HumanResource.Data;
using HumanResource.Dto;
using HumanResource.IService;
using HumanResource.Models;
using HumanResource.View;

namespace HumanResource.Service
{
    public class NhanVienService : INhanVienService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NhanVienService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public NhanVienDto Add(NhanVienView nhanVienView)
        {
            var nhanVien = _mapper.Map<NhanVien>(nhanVienView);
            _context.Add(nhanVien);

            var phongBan = _context.PhongBans.FirstOrDefault(o => o.MaPhongBan == nhanVienView.MaPhongBan);
            phongBan.SoLuongNhanVien += 1;
            _context.Update(phongBan);

            _context.SaveChanges();

            return _mapper.Map<NhanVienDto>(nhanVien);
        }

        public void Delete(string id)
        {
            var nhanVien = _context.NhanViens.FirstOrDefault(o => o.MaNV == id);
            if (nhanVien != null)
            {
                _context.Remove(nhanVien);
                _context.SaveChanges();
            }
        }

        public List<NhanVienDto> GetAll()
        {
            var nhanViens = _context.NhanViens.ToList();
            return _mapper.Map<List<NhanVienDto>>(nhanViens);
        }

        public NhanVienDto GetById(string id)
        {
            var nhanVien = _context.NhanViens.FirstOrDefault(o => o.MaNV == id);
            return _mapper.Map<NhanVienDto>(nhanVien);
        }

        public void Update(NhanVienDto nhanVien)
        {
            _context.Update(_mapper.Map<NhanVien>(nhanVien));
            _context.SaveChanges();
        }
    }
}
