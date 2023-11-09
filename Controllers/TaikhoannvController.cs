using WebApplication1.Models;
using WebApplication1.ViewModels;
//using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.CodeDom.Compiler;
using System.Security.Cryptography;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoannvController : ControllerBase
    {
        private readonly ITaikhoannvRepository _tkRepos;
        private readonly IConfiguration _configuration;
        public TaikhoannvController(ITaikhoannvRepository tkRpepos, IConfiguration configuration)
        {
            _tkRepos = tkRpepos;
            _configuration = configuration;
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
        public async Task<IActionResult> Insert(VM_Taikhoannv taikhoannv)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(taikhoannv.Matkhau);
            taikhoannv.Manv = taikhoannv.Manv;
            taikhoannv.Matkhau = passwordHash;
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
        [HttpPost("Login")]
        public async Task<ActionResult<Taikhoannv>> Login(VM_Taikhoannv taikhoannv)
        {
            var tk = await _tkRepos.GetById(taikhoannv.Manv);
            if (tk == null)
                return NotFound();

            if (BCrypt.Net.BCrypt.Verify(taikhoannv.Matkhau, tk.Matkhau))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            string token = CreateToken(taikhoannv);
            //var RefreshToken = GeneratedCodeAttribute();
            return Ok(token);
        }

        // private object GeneratedCodeAttribute()
        // {
        //     throw new NotImplementedException();
        // }


        // private RefreshToken GetRefreshToken()
        // {
        //     var refreshToken = new RefreshToken
        //     {
        //         Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //         Expire = DateTime.Now.AddDays(7)
        //     };
        //     return refreshToken;
        // }
        // private void SetRefreshToken(RefreshToken newRefresh)
        // {
        //     var cookieOption = new CookieOptions
        //     {
        //         HttpOnly = true,
        //         Expires = newRefresh.Expire
        //     };
        //     Response.Cookies.Append("refreshToken", newRefresh.Token, cookieOption);
            
        // }

        private string CreateToken(VM_Taikhoannv user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Manv.ToString())
                // new Claim(ClaimTypes.Role, "Admin"),
                // new Claim(ClaimTypes.Role, "User"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
