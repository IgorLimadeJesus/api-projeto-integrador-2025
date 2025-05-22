using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mrp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {

        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly MrpDBContext _dbContext;

        public CargoController(ICargoRepositorio cargoRepositorio, MrpDBContext dbContext)
        {
            _cargoRepositorio = cargoRepositorio;
            _dbContext = dbContext;
        }

        [HttpGet("/Cargos")]
        public async Task<ActionResult<List<CargoModel>>> GetCargo()
        {
            List<CargoModel> cargos = await _cargoRepositorio.GetCargo();
            return Ok(cargos);
        }

        [HttpPost("/Cargos/AddCargo")]
        public async Task<ActionResult<CargoModel>> AddCargo([FromBody] CargoModel cargo)
        {
            CargoModel cargoModel = await _cargoRepositorio.AddCargo(cargo);
            return Ok( new { Sucess = "Cargo adicionado com sucesso" } );
        }

        // DELETE api/<CargoController>/5
        [HttpDelete("/Cargo/Delete/{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            CargoModel cargo = await _dbContext.Cargo.FirstOrDefaultAsync(x => x.id == id);

            if (cargo == null)
                return NotFound( new { Erro = "404. Cargo não encontrado" } );

            _dbContext.Cargo.Remove(cargo);
            _dbContext.SaveChangesAsync();

            return Ok( new { Sucesso = "Cargo Deletado com sucesso" } );
        }
    }
}
