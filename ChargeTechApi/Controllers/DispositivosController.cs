using ChargeTechApi.Models;
using ChargeTechApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly IDispositivoRepository _dispositivoRepository;

        public DispositivosController(IDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        // GET: api/Dispositivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispositivo>>> GetDispositivos()
        {
            var dispositivos = await _dispositivoRepository.ObterTodos();
            return Ok(dispositivos);
        }

        // GET: api/Dispositivos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispositivo>> GetDispositivo(int id)
        {
            var dispositivo = await _dispositivoRepository.ObterPorId(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return Ok(dispositivo);
        }

        // PUT: api/Dispositivos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispositivo(int id, Dispositivo dispositivo)
        {
            if (id != dispositivo.ID_DISPOSITIVO)
            {
                return BadRequest();
            }

            await _dispositivoRepository.Atualizar(dispositivo);

            return NoContent();
        }

        // POST: api/Dispositivos
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> PostDispositivo(Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dispositivoRepository.Adicionar(dispositivo);

            return CreatedAtAction("GetDispositivo", new { id = dispositivo.ID_DISPOSITIVO }, dispositivo);
        }

        // DELETE: api/Dispositivos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispositivo(int id)
        {
            var dispositivo = await _dispositivoRepository.ObterPorId(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            await _dispositivoRepository.Remover(id);

            return NoContent();
        }
    }
}
