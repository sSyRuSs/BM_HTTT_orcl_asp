using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly INhanvienRepository _nvRepos;
        public NhanvienController(INhanvienRepository nvRepos)
        {
            _nvRepos = nvRepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _nvRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var nv = await _nvRepos.GetById(id);
            return nv == null ? NotFound():Ok(nv);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(VM_Nhanvien nhanvien)
        {
            await _nvRepos.Add(nhanvien);
            return StatusCode(201,nhanvien);
            //return //StatusCode(StatusCode.Status201Created, dongsp);
            //return CreatedAtAction("GetDongsp", new {id = dongsp.Madong }, dongsp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAll(ViewModels.VM_Nhanvien nhanvien)
        {
            var nv = await _nvRepos.GetById(nhanvien.Manv);
            if (nv == null)
                return NotFound();
            await _nvRepos.Update(nv);
            return Ok(nv);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(ViewModels.VM_Nhanvien nhanvien)
        {
            var nv = await _nvRepos.GetById(nhanvien.Manv);
            if(nv == null)
                return NotFound();
            await _nvRepos.Update(nhanvien);
            return Ok(nhanvien);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var dsp = await _nvRepos.GetById(id);
            if(dsp == null)
                return NotFound();
            await _nvRepos.Delete(id);
            return Ok();
        }
    }
}