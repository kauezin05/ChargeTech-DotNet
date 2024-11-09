using ChargeTechApi.Models;
using ChargeTechApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosEnergeticosController : ControllerBase
    {
        private readonly IConsumoEnergeticoRepository _consumoEnergeticoRepository;

        public ConsumosEnergeticosController(IConsumoEnergeticoRepository consumoEnergeticoRepository)
        {
            _consumoEnergeticoRepository = consumoEnergeticoRepository;
        }

        // GET: api/ConsumosEnergeticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoEnergetico>>> GetConsumosEnergeticos()
        {
            var consumos = await _consumoEnergeticoRepository.ObterTodos();
            return Ok(consumos);
        }

        // GET: api/ConsumosEnergeticos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoEnergetico>> GetConsumoEnergetico(int id)
        {
            var consumoEnergetico = await _consumoEnergeticoRepository.ObterPorId(id);

            if (consumoEnergetico == null)
            {
                return NotFound();
            }

            return Ok(consumoEnergetico);
        }

        // PUT: api/ConsumosEnergeticos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoEnergetico(int id, ConsumoEnergetico consumoEnergetico)
        {
            if (id != consumoEnergetico.ID_CONSUMO_ENERGETICO)
            {
                return BadRequest();
            }

            await _consumoEnergeticoRepository.Atualizar(consumoEnergetico);

            return NoContent();
        }

        // POST: api/ConsumosEnergeticos
        [HttpPost]
        public async Task<ActionResult<ConsumoEnergetico>> PostConsumoEnergetico(ConsumoEnergetico consumoEnergetico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _consumoEnergeticoRepository.Adicionar(consumoEnergetico);

            return CreatedAtAction("GetConsumoEnergetico", new { id = consumoEnergetico.ID_CONSUMO_ENERGETICO }, consumoEnergetico);
        }

        // DELETE: api/ConsumosEnergeticos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoEnergetico(int id)
        {
            var consumoEnergetico = await _consumoEnergeticoRepository.ObterPorId(id);
            if (consumoEnergetico == null)
            {
                return NotFound();
            }

            await _consumoEnergeticoRepository.Remover(id);

            return NoContent();
        }
    }
}
