using ChargeTechApi.Data;
using ChargeTechApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly AppDbContext _context;

        public DispositivoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dispositivo>> ObterTodos()
        {
            return await _context.Dispositivos.ToListAsync();
        }

        
        public async Task<Dispositivo> ObterPorId(int id)
        {
            return await _context.Dispositivos.FindAsync(id);
        }

        
        public async Task Adicionar(Dispositivo dispositivo)
        {
            _context.Dispositivos.Add(dispositivo);
            await _context.SaveChangesAsync();
        }

        
        public async Task Atualizar(Dispositivo dispositivo)
        {
            _context.Entry(dispositivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo != null)
            {
                _context.Dispositivos.Remove(dispositivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
