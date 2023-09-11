using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace WebApplication1.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangController : ControllerBase
    {
        private readonly IKhachangRepository _khRepos;
        public KhachhangController(IKhachangRepository khRepos)
        {
            _khRepos = khRepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _khRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var kh = await _khRepos.GetById(id);
            return kh == null ? NotFound() : Ok(kh);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ViewModels.VM_Khachhang khachhang)
        {
            await _khRepos.Add(khachhang);
            return StatusCode(201, khachhang);
            //return //StatusCode(StatusCode.Status201Created, dongsp);
            //return CreatedAtAction("GetDongsp", new {id = dongsp.Madong }, dongsp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAll(ViewModels.VM_Khachhang khachhang)
        {
            var kh = await _khRepos.GetById(khachhang.Makh);
            if (kh == null)
                return NotFound();
            await _khRepos.Update(kh);
            return Ok(kh);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(ViewModels.VM_Khachhang khachhang)
        {
            var kh = await _khRepos.GetById(khachhang.Makh);
            if (kh == null)
                return NotFound();
            await _khRepos.Update(kh);
            return Ok(kh);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var dsp = await _khRepos.GetById(id);
            if (dsp == null)
                return NotFound();
            await _khRepos.Delete(id);
            return Ok();
        }
    }
}