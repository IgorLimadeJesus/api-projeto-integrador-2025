using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.DTOs;
using mrp_api.Objects.Models;
using mrp_api.Services.Interface;

namespace mrp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly MrpDBContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthController(MrpDBContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {

            if (_dbContext.Users.Any(u => u.Email == registerUser.Email))
            {
                return BadRequest(new { message = "Email já cadastrado" });
            }

            var Senha = BCrypt.Net.BCrypt.HashPassword(registerUser.SenhaHash);

            var User = new UserModel
            {
                Nome = registerUser.Nome,
                Email = registerUser.Email,
                SenhaHash = Senha
            };

            await _dbContext.Users.AddAsync(User);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Usuario Registrado com sucesso" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginUser)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Senha, user.SenhaHash))       
                return Unauthorized(new { message = "Email ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });

        }
    }
}
