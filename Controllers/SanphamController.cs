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

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        private readonly ISanphamRepository _sanphamRepos;
        public SanphamController(ISanphamRepository sanphamRepos)
        {
            _sanphamRepos = sanphamRepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sanphamRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var dsp = await _sanphamRepos.GetById(id);
            return dsp == null ? NotFound() : Ok(dsp);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ViewModels.VM_Sanpham dongsp)
        {
            await _sanphamRepos.Add(dongsp);
            return StatusCode(201, dongsp);
            //return //StatusCode(StatusCode.Status201Created, dongsp);
            //return CreatedAtAction("GetDongsp", new { id = dongsp.Masp }, dongsp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAll(ViewModels.VM_Sanpham dongsp)
        {
            var dsp = await _sanphamRepos.GetById(dongsp.Masp);
            if (dsp == null)
                return NotFound();
            await _sanphamRepos.Update(dsp);
            return Ok(dsp);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(ViewModels.VM_Sanpham dongsp)
        {
            var dsp = await _sanphamRepos.GetById(dongsp.Masp);
            if (dsp == null)
                return NotFound();
            await _sanphamRepos.Update(dsp);
            return Ok(dsp);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var dsp = await _sanphamRepos.GetById(id);
            if (dsp == null)
                return NotFound();
            await _sanphamRepos.Delete(id);
            return Ok();
        }
    }
}