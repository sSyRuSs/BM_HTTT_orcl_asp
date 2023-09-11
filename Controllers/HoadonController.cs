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
    public class HoadonController : ControllerBase
    {
        private readonly IHoadonRepository _hdRepos;
        public HoadonController(IHoadonRepository hdRepos)
        {
            _hdRepos = hdRepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hdRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var kh = await _hdRepos.GetById(id);
            return kh == null ? NotFound() : Ok(kh);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ViewModels.VM_Hoadon hoadon)
        {
            await _hdRepos.Add(hoadon);
            return StatusCode(201, hoadon);
            //return //StatusCode(StatusCode.Status201Created, dongsp);
            //return CreatedAtAction("GetDongsp", new {id = dongsp.Madong }, dongsp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAll(ViewModels.VM_Hoadon hoadon)
        {
            var hd = await _hdRepos.GetById(hoadon.Mahd);
            if (hd == null)
                return NotFound();
            await _hdRepos.Update(hd);
            return Ok(hd);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(ViewModels.VM_Hoadon hoadon)
        {
            var hd = await _hdRepos.GetById(hoadon.Mahd);
            if (hd == null)
                return NotFound();
            await _hdRepos.Update(hd);
            return Ok(hd);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var hd = await _hdRepos.GetById(id);
            if (hd == null)
                return NotFound();
            await _hdRepos.Delete(id);
            return Ok();
        }
    }
}
