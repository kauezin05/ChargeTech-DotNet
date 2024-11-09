using ChargeTechApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public interface IConsumoEnergeticoRepository
    {
        Task<IEnumerable<ConsumoEnergetico>> ObterTodos();
        Task<ConsumoEnergetico> ObterPorId(int id);
        Task Adicionar(ConsumoEnergetico consumoEnergetico);
        Task Atualizar(ConsumoEnergetico consumoEnergetico);
        Task Remover(int id);
    }
}
