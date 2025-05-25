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
    public class MachinesController : ControllerBase
    {
        private readonly IMachineRepositorio _machineRepositorio;
        private readonly MrpDBContext _dbContext;

        public MachinesController(IMachineRepositorio machineRepositorio, MrpDBContext dBContext)
        {
            _machineRepositorio = machineRepositorio;
            _dbContext = dBContext;
        }

        [HttpPost("/Maquinas/Cadastrar")]
        public async Task<ActionResult<MachineModel>> AddMachines([FromBody] MachineModel model)
        {
            MachineModel machines = await _machineRepositorio.AddMaquinas(model);
            return Ok("Maquina Cadastrada com sucesso");
        }

        [HttpGet("/Maquinas")]
        public async Task<ActionResult<List<MachineModel>>> GetMachines()
        {
            List<MachineModel> machines = await _machineRepositorio.GetMaquinas();
            return Ok(machines);
        }

        [HttpGet("/Maquinas/{id}")]
        public async Task<ActionResult<MachineModel>> GetMachineById(int id)
        {
            MachineModel machine = await _machineRepositorio.GetMaquinasById(id);
            return Ok(machine);
        }

        [HttpPut("/Maquinas/Manutencao")]
        public async Task<ActionResult> Manutencao([FromBody] definirManutencao manutencao, int id)
        {
            var machine = await _dbContext.Machines.FirstOrDefaultAsync(x => x.id == id);

            if (machine == null)
            {
                return NotFound("Máquina não encontrada");
            }

            machine.previsao_Manutencao = manutencao.previsao;
            machine.status = manutencao.status;

            await _dbContext.SaveChangesAsync();

            return Ok("Atulizado");
        }
    }
}
