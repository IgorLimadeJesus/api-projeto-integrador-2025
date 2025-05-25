using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Controllers
{
    [Route("Mrp/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        private readonly MrpDBContext _dbContext;

        public UserController(IUserRepositorio userRepositorio, MrpDBContext dbContext)
        {
            _userRepositorio = userRepositorio;
            _dbContext = dbContext;
        }

        [HttpGet("/Users")]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepositorio.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("/Users/{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            UserModel user = await _userRepositorio.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<UserModel>> RegisterUser([FromForm] RegisterModelUsers registerUsers)
        {

            var Users = new UserModel
            {
                nome = registerUsers.nome,
                matricula = registerUsers.matricula,
                senha = registerUsers.senha,
                id_Maquina = registerUsers.id_Maquina,
                id_Cargo = registerUsers.id_Cargo,
                id_Setor = registerUsers.id_Setor,
                hierarquia = registerUsers.hierarquia,
                status = registerUsers.status
            };

            UserModel user = await _userRepositorio.AddUser(Users);
            return Ok(new { message = "Usuario Registrado com sucesso" });
        }

        [HttpPost("/Login")]
        public async Task<ActionResult> Login([FromForm] LoginModel login)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.matricula == login.matricula && x.senha == login.senha);

            if (user == null)
                return Unauthorized("Matricula ou Senha incorretas");

            return Ok( new { message = "Login Realizado com sucesso" } );
        }
    }
}
