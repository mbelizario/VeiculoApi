using Core.Models;

namespace Core.Interfaces.Services
{
    public  interface IBaseService<TEntity>  where TEntity : Entidade
    {
        Task Adicionar(TEntity entity);
        Task<TEntity?> Obter(Guid id);
        Task<IEnumerable<TEntity>> Obter();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
    }
}
