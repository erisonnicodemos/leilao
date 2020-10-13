using System;
using System.Threading.Tasks;
using LeilaoWeb.Business.Models;

namespace LeilaoWeb.Business.Intefaces
{
    public interface ILeilaoService : IDisposable
    {
        Task Adicionar(Leilao produto);
        Task Atualizar(Leilao produto);
        Task Remover(Guid id);
    }
}