using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepositorio _setorRepositorio;

        public SetorController(ISetorRepositorio setorRepositorio)
        {
            _setorRepositorio = setorRepositorio;
        }

        [HttpPost("Setor/AddSetor")]
        public async Task<ActionResult<SetorModel>> AddSetor([FromBody] SetorModel setor)
        {

            SetorModel addedSetor = await _setorRepositorio.AddSetor(setor);
            return Ok(new { Success = "Setor adicionado com sucesso", Setor = addedSetor });
        }

        [HttpGet("Setor")]
        public async Task<ActionResult<List<SetorModel>>> GetSetor()
        {
            List<SetorModel> setor = await _setorRepositorio.GetSetor();
            return Ok(setor);
        }

        [HttpDelete("Setor/Delete/{id}")]
        public async Task<IActionResult> DeleteSetor(int id)
        {
            bool isDeleted = await _setorRepositorio.DeleteSetor(id);
            if (!isDeleted)
            {
                return NotFound(new { Error = "Setor não encontrado" });
            }
            return Ok(new { Success = "Setor deletado com sucesso" });

        }
    }
}
