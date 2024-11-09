using ChargeTechApi.Models;
using ChargeTechApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbientesController : ControllerBase
    {
        private readonly IAmbienteRepository _ambienteRepository;

        public AmbientesController(IAmbienteRepository ambienteRepository)
        {
            _ambienteRepository = ambienteRepository;
        }

        // GET: api/Ambientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambiente>>> GetAmbientes()
        {
            var ambientes = await _ambienteRepository.ObterTodos();
            return Ok(ambientes);
        }

        // GET: api/Ambientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ambiente>> GetAmbiente(int id)
        {
            var ambiente = await _ambienteRepository.ObterPorId(id);

            if (ambiente == null)
            {
                return NotFound();
            }

            return Ok(ambiente);
        }

        // PUT: api/Ambientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbiente(int id, Ambiente ambiente)
        {
            if (id != ambiente.ID_AMBIENTE)
            {
                return BadRequest();
            }

            await _ambienteRepository.Atualizar(ambiente);

            return NoContent();
        }

        // POST: api/Ambientes
        [HttpPost]
        public async Task<ActionResult<Ambiente>> PostAmbiente(Ambiente ambiente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ambienteRepository.Adicionar(ambiente);

            return CreatedAtAction("GetAmbiente", new { id = ambiente.ID_AMBIENTE }, ambiente);
        }

        // DELETE: api/Ambientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbiente(int id)
        {
            var ambiente = await _ambienteRepository.ObterPorId(id);
            if (ambiente == null)
            {
                return NotFound();
            }

            await _ambienteRepository.Remover(id);

            return NoContent();
        }
    }
}
