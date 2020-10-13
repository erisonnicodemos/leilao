using System;
using System.Threading.Tasks;
using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Models;
using LeilaoWeb.Business.Models.Validations;

namespace LeilaoWeb.Business.Services
{
    public class LeilaoService : BaseService, ILeilaoService
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly IUser _user;

        public LeilaoService(ILeilaoRepository leilaoRepository,
                              INotificador notificador, 
                              IUser user) : base(notificador)
        {
            _leilaoRepository = leilaoRepository;
            _user = user;
        }

        public async Task Adicionar(Leilao leilao)
        {
            if (!ExecutarValidacao(new LeilaoValidation(), leilao)) return;

            await _leilaoRepository.Adicionar(leilao);
        }

        public async Task Atualizar(Leilao leilao)
        {
            if (!ExecutarValidacao(new LeilaoValidation(), leilao)) return;

            await _leilaoRepository.Atualizar(leilao);
        }

        public async Task Remover(Guid id)
        {
            await _leilaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _leilaoRepository?.Dispose();
        }
    }
}