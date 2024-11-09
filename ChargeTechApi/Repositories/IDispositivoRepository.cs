using ChargeTechApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public interface IDispositivoRepository
    {
        Task<IEnumerable<Dispositivo>> ObterTodos();
        Task<Dispositivo> ObterPorId(int id);
        Task Adicionar(Dispositivo dispositivo);
        Task Atualizar(Dispositivo dispositivo);
        Task Remover(int id);
    }
}
