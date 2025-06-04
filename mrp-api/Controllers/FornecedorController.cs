using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.DTOs.Models;
using mrp_api.Objects.DTOs;

namespace mrp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly MrpDBContext _dbContext;

        public FornecedorController(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Fornecedor/Consulta/Total")]
        public async Task<ActionResult<int>> GetTotalFornecedores()
        {
            int totalFornecedores = await _dbContext.Fornecedor.CountAsync();
            return Ok(totalFornecedores);
        }

        [HttpGet("Fornecedor/Consulta")]
        public async Task<ActionResult<List<FornecedorModel>>> GetFornecedores()
        {
            List<FornecedorModel> fornecedores = await _dbContext.Fornecedor.ToListAsync();
            return Ok(fornecedores);
        }

        [HttpPost("Fornecedor/Cadastro")]
        public async Task<ActionResult<FornecedorModel>> CadastroFornecedor([FromForm] FornecedorDTO dto)
        {
            var fornecedor = new FornecedorModel
            {
                nome = dto.nome,
                contato = dto.contato,
                cpf_cnpj = dto.cpf_cnpj,
                cep = dto.cep,
                rua = dto.rua,
                bairro = dto.bairro,
                numero = dto.numero,
                complemento = dto.complemento,
                cidade = dto.cidade,
                pais = dto.pais,
                estado = dto.estado

            };

            await _dbContext.Fornecedor.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();
            return Ok(new { Success = "Fornecedor cadastrado com sucesso", Fornecedor = fornecedor });
        }
    }
}
