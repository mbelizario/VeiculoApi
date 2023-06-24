namespace WebApi.ViewModels
{
    public class MarcaViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
    }
}
