using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entidade
    {
        public readonly IBaseRepository<TEntity> baseRepository;
        public BaseService(IBaseRepository<TEntity> BaseRepository)
        {
            baseRepository = BaseRepository;
        }
        public async Task Adicionar(TEntity entity) => await baseRepository.Adicionar(entity);

        public async Task Atualizar(TEntity entity) => await baseRepository.Atualizar(entity);

        public async Task<TEntity?> Obter(Guid id) => await baseRepository.Obter(id);

        public async Task<IEnumerable<TEntity>> Obter() => await baseRepository.Obter();
        public async Task Remover(Guid id) => await baseRepository.Remover(id);
    }
}
