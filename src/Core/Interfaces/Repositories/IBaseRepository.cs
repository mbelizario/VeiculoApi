using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entidade
    {
        Task Adicionar(TEntity entity);
        Task<TEntity?> Obter(Guid id);
        Task<IEnumerable<TEntity>> Obter();
        Task Atualizar(TEntity entity);
        Task Remover(TEntity entity);
        Task<int> SaveChanges();
    }
}
