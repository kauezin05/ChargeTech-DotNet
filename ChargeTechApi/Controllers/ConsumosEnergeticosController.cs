using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChargeTechApi.Data;
using ChargeTechApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ChargeTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosEnergeticosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsumosEnergeticosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsumosEnergeticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoEnergetico>>> GetConsumosEnergeticos()
        {
            return await _context.ConsumosEnergeticos.ToListAsync();
        }

        // GET: api/ConsumosEnergeticos/
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoEnergetico>> GetConsumoEnergetico(int id)
        {
            var consumoEnergetico = await _context.ConsumosEnergeticos.FindAsync(id);

            if (consumoEnergetico == null)
            {
                return NotFound();
            }

            return consumoEnergetico;
        }

        // PUT: api/ConsumosEnergeticos/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoEnergetico(int id, ConsumoEnergetico consumoEnergetico)
        {
            if (id != consumoEnergetico.ID_CONSUMO_ENERGETICO)
            {
                return BadRequest();
            }

            _context.Entry(consumoEnergetico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoEnergeticoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

            _context.ConsumosEnergeticos.Add(consumoEnergetico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumoEnergetico", new { id = consumoEnergetico.ID_CONSUMO_ENERGETICO }, consumoEnergetico);
        }

        // DELETE: api/ConsumosEnergeticos/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoEnergetico(int id)
        {
            var consumoEnergetico = await _context.ConsumosEnergeticos.FindAsync(id);
            if (consumoEnergetico == null)
            {
                return NotFound();
            }

            _context.ConsumosEnergeticos.Remove(consumoEnergetico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumoEnergeticoExists(int id)
        {
            return _context.ConsumosEnergeticos.Any(e => e.ID_CONSUMO_ENERGETICO == id);
        }
    }
}
