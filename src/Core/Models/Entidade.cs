namespace Core.Models
{
    public class Entidade
    {
        public Guid Id { get; set; }

        public bool Excluido { get; set; }

        public DateTime CriadoEm { get; set; }

        public Entidade()
        {
            Id = new Guid();
        }
    }
}
