using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public object ObterNotificacoes()
        {
            return new { Mensagens = _notificacoes.Select(x => x.Mensagem) };
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}