namespace Core.Notificacoes
{
    public class Notificador : INotificador
    {
        public List<Notificacao> Notificacoes;
        public Notificador()
        {
            Notificacoes = new List<Notificacao>();
        }
        public void AdicionarNotificacao(string mensagem)
        {
            Notificacoes.Add(new Notificacao(mensagem));
        }

        public bool ExisteNotificacoes()
        {
            return Notificacoes.Any();
        }

        public IEnumerable<string?> ObterNotificacoes()
        {
            return Notificacoes.Select(x => x.ToString());
        }
    }
}
