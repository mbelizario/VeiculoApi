using Core.Interfaces.Repositories;
using Core.Models;
using Repository.Context;

namespace Repository.Repository
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(VeiculoDbContext db) : base(db)
        {
        }
    }
}
