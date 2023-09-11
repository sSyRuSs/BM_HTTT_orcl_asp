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
    public class DongspController : ControllerBase
    {
        private readonly IDongspRepository _dongspRepos;
        public DongspController(IDongspRepository dongspRepos)
        {
            _dongspRepos = dongspRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dongspRepos.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var dsp = await _dongspRepos.GetById(id);
            return dsp == null ? NotFound() : Ok(dsp);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(VM_Dongsp dongsp)
        {
            await _dongspRepos.Add(dongsp);
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created, dongsp);
            //return //StatusCode(StatusCode.Status201Created, dongsp);
            //return CreatedAtAction("GetDongsp", new {id = dongsp.Madong }, dongsp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAll(VM_Dongsp dongsp)
        {
            var dsp = await _dongspRepos.GetById(dongsp.Madong);
            if (dsp == null)
                return NotFound();
            await _dongspRepos.Update(dsp);
            return Ok(dsp);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(VM_Dongsp dongsp)
        {
            var dsp = await _dongspRepos.GetById(dongsp.Madong);
            if (dsp == null)
                return NotFound();
            await _dongspRepos.Update(dsp);
            return Ok(dsp);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(decimal id)
        {
            var dsp = await _dongspRepos.GetById(id);
            if (dsp == null)
                return NotFound();
            await _dongspRepos.Delete(id);
            return Ok();
        }
    }
}
