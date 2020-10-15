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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

        public async Task<Usuario> ObterUsuario(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                           .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
