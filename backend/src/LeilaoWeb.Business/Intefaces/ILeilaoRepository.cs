using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeilaoWeb.Business.Models;

namespace LeilaoWeb.Business.Intefaces
{
    public interface ILeilaoRepository : IRepository<Leilao>
    {
        Task<IEnumerable<Leilao>> ObterLeliloes();
        Task<IEnumerable<Leilao>> ObterLeliloesPorUsuario(Guid userId);
        Task<IEnumerable<Leilao>> ObterLeliloesPorNome(string nome);
        Task<Leilao> ObterLeilao(Guid id);
    }
}