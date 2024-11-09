using ChargeTechApi.Models;

namespace ChargeTechApi.Repositories
{
    public interface IAmbienteRepository
    {
        Task<IEnumerable<Ambiente>> ObterTodos();
        Task<Ambiente> ObterPorId(int id);
        Task Adicionar(Ambiente ambiente);
        Task Atualizar(Ambiente ambiente);
        Task Remover(int id);
    }
}
