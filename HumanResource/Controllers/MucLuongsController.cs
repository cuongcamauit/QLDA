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
using HumanResource.View;
using HumanResource.Dto;

namespace HumanResource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MucLuongsController : ControllerBase
    {
        private readonly IMucLuongService _mucLuongService;

        public MucLuongsController(IMucLuongService mucLuongService)
        {
            _mucLuongService = mucLuongService;
        }

        // GET: api/MucLuongs
        [HttpGet]
        public async Task<IActionResult> GetMucLuongs()
        {
            List<MucLuongDto> mucLuongs = _mucLuongService.GetAll(); 
            
            return Ok(mucLuongs);
        }

        // GET: api/MucLuongs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMucLuong(string id)
        {
            MucLuongDto mucLuong = _mucLuongService.GetById(id);

            return Ok(mucLuong);
        }

        // PUT: api/MucLuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMucLuong(string id, MucLuongDto mucLuongDto)
        {

            if (id != mucLuongDto.TenMucLuong)
            {
                return BadRequest();
            }
            _mucLuongService.Update(mucLuongDto);

            return NoContent();
        }

        // POST: api/MucLuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostMucLuong(MucLuongView mucLuongView)
        {
            MucLuongDto mucLuongDto = _mucLuongService.Add(mucLuongView);
            return Ok(mucLuongDto);
        }

        // DELETE: api/MucLuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMucLuong(string id)
        {
            _mucLuongService.Delete(id);
            return NoContent();
        }
    }
}
