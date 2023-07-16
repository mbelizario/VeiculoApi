namespace Core.Models
{
    public class Modelo : Entidade
    {
        public string Nome { get; set; } = string.Empty;

        public Guid MarcaId { get; set; }

        public Marca Marca { get; set; } = new Marca();
    }
}
