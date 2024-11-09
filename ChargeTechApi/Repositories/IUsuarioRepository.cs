using ChargeTechApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChargeTechApi.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(int id);
    }
}
