using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoannvController : ControllerBase
    {
        private readonly ITaikhoannvRepository _tkRepos;
        public TaikhoannvController(ITaikhoannvRepository tkRpepos)
        {
            _tkRepos = tkRpepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tkRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var tk = await _tkRepos.GetById(id);
            return tk == null ? NotFound() : Ok(tk);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(ViewModels.VM_Taikhoannv taikhoannv)
        {
            await _tkRepos.Add(taikhoannv);
            return StatusCode(201, taikhoannv);
        }
        [HttpPut]
        public async Task<IActionResult> Update(VM_Taikhoannv taikhoannv)
        {
            var tk = await _tkRepos.GetById(taikhoannv.Manv);
            if (tk == null)
                return NotFound();
            await _tkRepos.Update(taikhoannv);
            return Ok(taikhoannv);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var dsp = await _tkRepos.GetById(id);
            if (dsp == null)
                return NotFound();
            await _tkRepos.Delete(id);
            return Ok();
        }
    }
}
