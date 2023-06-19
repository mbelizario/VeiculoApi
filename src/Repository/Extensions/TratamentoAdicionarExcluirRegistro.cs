using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository.Extensions
{
    public static class TratamentoAdicionarExcluirRegistro
    {

        public static EntityEntry ConfigurarRemocaoLogica(this EntityEntry entidade)
        {
            entidade.State = EntityState.Modified;
            var registro = (Entidade)entidade.Entity;
            registro.Excluido = true;
            return entidade;
        }

        public static EntityEntry ConfigurarNovoRegistro(this EntityEntry entidade)
        {
            var registro = (Entidade)entidade.Entity;
            registro.Excluido = false;
            registro.CriadoEm = DateTime.Now;
            return entidade;
        }
    }
}
