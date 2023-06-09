namespace Core.Models
{
    public abstract class Veiculo : Entidade
    {
        public Marca Marca { get; set; } = new Marca();

        public Modelo Modelo { get; set; } = new Modelo();

        public bool Status { get; set; }

    }
}
