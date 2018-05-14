using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.ViewModesl;
using System.Security.Claims;
using WebApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private JwtSettings _jwtSettings;
        public AuthorizeController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
        [HttpPost]
        public IActionResult Token(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!(viewModel.User == "zp" && viewModel.Password == "123456"))
                {
                    return BadRequest();
                }
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,"zp"),
                new Claim(ClaimTypes.Role,"admin"), 
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _jwtSettings.Issuer,
                    _jwtSettings.Audience,
                    claims,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    creds);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }
    }
}