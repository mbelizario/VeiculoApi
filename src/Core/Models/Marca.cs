namespace Core.Models
{
    public class Marca : Entidade
    {
        public string Nome { get; set; } = string.Empty;

        public IEnumerable<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
