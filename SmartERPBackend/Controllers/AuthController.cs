using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SmartERPBackend.Data;
using SmartERPBackend.DTOs;
using SmartERPBackend.Models;
using SmartERPBackend.Services;

namespace SmartERPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(ApplicationDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register (Register register)
        {
            var userExists = await _context.Users.AnyAsync(x => x.Email == register.Email);
            if (userExists)
                return BadRequest("User already exists");
            var hasher = new PasswordHasher<Users>();
            var user = new Users
            {
                FullName = register.FullName,
                Email = register.Email
            };

            user.PasswordHash = hasher.HashPassword(user, register.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User Registered Successfully");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login (Login login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            var passwordHasher = new PasswordHasher<Users>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);
            if(result == PasswordVerificationResult.Success)
            {
                var token = _tokenService.CreateToken(user);
                return Ok(token);
            }
            return Unauthorized("Invalid email or password");
        }
    }
}
