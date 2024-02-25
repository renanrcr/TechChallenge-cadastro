using Domain.Notificacoes;

namespace Domain.Adapters
{
    public interface INotificador
    {
        bool TemNotificacao();

        object ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}