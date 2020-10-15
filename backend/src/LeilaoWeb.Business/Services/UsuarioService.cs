using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Models;
using LeilaoWeb.Business.Models.Validations;
using LeilaoWeb.Business.Services;
using System;
using System.Threading.Tasks;

namespace UsuarioWeb.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUser _user;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador, 
                              IUser user) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _user = user;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}