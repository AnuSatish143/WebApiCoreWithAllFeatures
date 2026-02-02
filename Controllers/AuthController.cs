using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreWithAllFeatures.Data;
using WebApiCoreWithAllFeatures.Repositories.Interfaces;
using WebApiCoreWithAllFeatures.Models;
using WebApiCoreWithAllFeatures.DTOs;
namespace WebApiCoreWithAllFeatures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_context.users.Any(u => u.Username == dto.Username))
            {
                return BadRequest("Username already exists.");
            }
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password, // (hash later)
                Role = dto.Role
            };
            _context.users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.users
                .FirstOrDefault(u => u.Username == dto.Username
                                  && u.Password == dto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _tokenService.CreateToken(user);

            return Ok(new { token });
        }
    }
}
