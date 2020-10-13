using System.Collections.Generic;
using LeilaoWeb.Business.Notificacoes;

namespace LeilaoWeb.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}