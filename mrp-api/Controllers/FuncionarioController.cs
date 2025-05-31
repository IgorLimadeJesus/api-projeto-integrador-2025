using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.DTOs;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Controllers
{
    [Route("Mrp/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _userRepositorio;
        private readonly MrpDBContext _dbContext;

        public FuncionarioController(IFuncionarioRepositorio userRepositorio, MrpDBContext dbContext)
        {
            _userRepositorio = userRepositorio;
            _dbContext = dbContext;
        }

        [HttpGet("/Users")]
        public async Task<ActionResult<List<FuncionarioModel>>> GetAllFuncionario()
        {
            List<FuncionarioModel> users = await _userRepositorio.GetAllFuncionario();
            return Ok(users);
        }

        [HttpGet("/Users/{id}")]
        public async Task<ActionResult<FuncionarioModel>> GetUserById(int id)
        {
            FuncionarioModel user = await _userRepositorio.GetFuncionarioById(id);
            return Ok(user);
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<FuncionarioModel>> RegisterUser([FromForm] RegisterFuncionarioDTO registerFuncionario)
        {

            var Users = new FuncionarioModel
            {
                nome = registerFuncionario.nome,
                matricula = registerFuncionario.matricula,
                senha = registerFuncionario.senha,
                id_Maquina = registerFuncionario.id_Maquina,
                id_Cargo = registerFuncionario.id_Cargo,
                id_Setor = registerFuncionario.id_Setor,
                hierarquia = registerFuncionario.hierarquia,
                status = registerFuncionario.status
            };

            FuncionarioModel user = await _userRepositorio.AddFuncionario(Users);
            return Ok(new { message = "Usuario Registrado com sucesso" });
        }

        [HttpGet("Funcionario/Consulta/Total")]
        public async Task<ActionResult<int>> GetTotalUsers()
        {
            int totalUsers = await _dbContext.Funcionario.CountAsync();
            return Ok(totalUsers);
        }
    }
}
