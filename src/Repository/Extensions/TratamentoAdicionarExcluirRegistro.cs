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
            entidade.Property("CriadoEm").IsModified = false;
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

        public static EntityEntry ConfigurarAtualizacao(this EntityEntry entidade)
        {
            entidade.Property("Excluido").IsModified = false;
            entidade.Property("CriadoEm").IsModified = false;
            return entidade;
        }
    }
}
