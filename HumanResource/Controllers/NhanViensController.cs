using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumanResource.Data;
using HumanResource.Models;
using HumanResource.IService;
using HumanResource.Dto;
using HumanResource.View;

namespace HumanResource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;

        public NhanViensController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<IActionResult> GetNhanViens()
        {
            List<NhanVienDto> nhanVienDtos = _nhanVienService.GetAll();
            return Ok(nhanVienDtos);
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanVien(string id)
        {
            NhanVienDto nhanVien = _nhanVienService.GetById(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(string id, NhanVienDto nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return BadRequest();
            }

            _nhanVienService.Update(nhanVien);

            return NoContent();
        }

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVienView nhanVien)
        {
            NhanVienDto nhanVienDto = _nhanVienService.Add(nhanVien);

            return CreatedAtAction("GetNhanVien", new { id = nhanVienDto.MaNV }, nhanVienDto);
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            _nhanVienService.Delete(id);

            return NoContent();
        }
    }
}
