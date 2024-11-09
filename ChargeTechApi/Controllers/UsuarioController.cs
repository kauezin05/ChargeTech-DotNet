using ChargeTechApi.Models;
using ChargeTechApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.ObterTodos();
            return Ok(usuarios);
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.ID_USUARIO)
            {
                return BadRequest();
            }

            await _usuarioRepository.Atualizar(usuario);

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioRepository.Adicionar(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.ID_USUARIO }, usuario);
        }

        // DELETE: api/Usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioRepository.Remover(id);

            return NoContent();
        }
    }
}
