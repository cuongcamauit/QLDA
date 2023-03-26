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
    public class PhongBansController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;

        public PhongBansController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }

        // GET: api/PhongBans
        [HttpGet]
        public async Task<IActionResult> GetPhongBans()
        {
            List<PhongBanDto> phongBanDtos = _phongBanService.GetAll();
            return Ok(phongBanDtos);
        }

        // GET: api/PhongBans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongBan(string id)
        {
            PhongBanDto phongBanDto = _phongBanService.GetById(id);
            return Ok(phongBanDto);
        }

        // PUT: api/PhongBans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhongBan(string id, PhongBanDto phongBan)
        {
            if (id != phongBan.MaPhongBan)
            {
                return BadRequest();
            }

            _phongBanService.Update(phongBan);

            return NoContent();
        }

        // POST: api/PhongBans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPhongBan(PhongBanView phongBan)
        {
            PhongBanDto phongBanDto = _phongBanService.Add(phongBan);
            return Ok(phongBanDto); 
        }

        // DELETE: api/PhongBans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhongBan(string id)
        {
            _phongBanService.Delete(id);
            return NoContent();
        }
    }
}
