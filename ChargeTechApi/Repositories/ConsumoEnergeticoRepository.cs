using ChargeTechApi.Data;
using ChargeTechApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public class ConsumoEnergeticoRepository : IConsumoEnergeticoRepository
    {
        private readonly AppDbContext _context;

        public ConsumoEnergeticoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConsumoEnergetico>> ObterTodos()
        {
            return await _context.ConsumosEnergeticos.ToListAsync();
        }

        
        public async Task<ConsumoEnergetico> ObterPorId(int id)
        {
            return await _context.ConsumosEnergeticos.FindAsync(id);
        }
       
        public async Task Adicionar(ConsumoEnergetico consumoEnergetico)
        {
            await _context.ConsumosEnergeticos.AddAsync(consumoEnergetico);
            await _context.SaveChangesAsync();
        }

       
        public async Task Atualizar(ConsumoEnergetico consumoEnergetico)
        {
            _context.ConsumosEnergeticos.Update(consumoEnergetico);
            await _context.SaveChangesAsync();
        }

       
        public async Task Remover(int id)
        {
            var consumo = await _context.ConsumosEnergeticos.FindAsync(id);
            if (consumo != null)
            {
                _context.ConsumosEnergeticos.Remove(consumo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
