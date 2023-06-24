using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> Obter();

        Task<Marca?> Obter(Guid id);
        Task Adicionar(Marca marca);

        Task Atualizar(Marca marca);

        Task Remover(Guid id);
    }
}
