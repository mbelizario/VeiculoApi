namespace Core.Notificacoes
{
    public interface INotificador
    {
        void AdicionarNotificacao(string mensagem);

        bool ExisteNotificacoes();

        IEnumerable<string?> ObterNotificacoes();
    }
}
