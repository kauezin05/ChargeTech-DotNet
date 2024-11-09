using ChargeTechApi.Data;
using ChargeTechApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public class AmbienteRepository : IAmbienteRepository
    {
        private readonly AppDbContext _context;

        public AmbienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ambiente>> ObterTodos()
        {
            return await _context.Ambientes.ToListAsync();
        }

        public async Task<Ambiente> ObterPorId(int id)
        {
            return await _context.Ambientes.FindAsync(id);
        }

        public async Task Adicionar(Ambiente ambiente)
        {
            await _context.Ambientes.AddAsync(ambiente);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Ambiente ambiente)
        {
            _context.Ambientes.Update(ambiente);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var ambiente = await _context.Ambientes.FindAsync(id);
            if (ambiente != null)
            {
                _context.Ambientes.Remove(ambiente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
