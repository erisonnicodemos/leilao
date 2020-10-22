using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Models;
using LeilaoWeb.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilaoWeb.Data.Repository
{
    public class LeilaoRepository : Repository<Leilao>, ILeilaoRepository
    {
        public LeilaoRepository(MeuDbContext context) : base(context) { }

        public async Task<Leilao> ObterLeilao(Guid id)
        {
            return await Db.Leiloes.AsNoTracking()
                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Leilao>> ObterLeliloes()
        {
            return await Db.Leiloes.AsNoTracking()
                .OrderBy(p => p.DataAbetura).ToListAsync();
        }

        public async Task<IEnumerable<Leilao>> ObterLeliloesPorNome(string nome)
        {
            return await Db.Leiloes.AsNoTracking()
                    .Where(l => l.Nome.Contains(nome))
                    .OrderBy(p => p.DataAbetura).ToListAsync();
        }

        public async Task<IEnumerable<Leilao>> ObterLeliloesPorUsuario(Guid userId)
        {
            return await Db.Leiloes.AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderBy(p => p.DataAbetura).ToListAsync();
        }
    }
}
