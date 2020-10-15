using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LeilaoWeb.Api.Controllers;
using LeilaoWeb.Api.Extensions;
using LeilaoWeb.Api.ViewModels;
using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoWeb.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/leiloes")]
    public class LeiloesController : MainController
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly ILeilaoService _leilaoService;
        private readonly IMapper _mapper;

        public LeiloesController(INotificador notificador,
                                  ILeilaoRepository leilaoRepository,
                                  ILeilaoService leilaoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _leilaoRepository = leilaoRepository;
            _leilaoService = leilaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LeilaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<LeilaoViewModel>>(await _leilaoRepository.ObterLeliloes());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LeilaoViewModel>> ObterPorId(Guid id)
        {
            var leilaoViewModel = await ObterLeilao(id);

            if (leilaoViewModel == null) return NotFound();

            return leilaoViewModel;
        }

        [ClaimsAuthorize("Leilao", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<LeilaoViewModel>> Adicionar(LeilaoViewModel leilaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _leilaoService.Adicionar(_mapper.Map<Leilao>(leilaoViewModel));

            return CustomResponse(leilaoViewModel);
        }

        [ClaimsAuthorize("Leilao", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, LeilaoViewModel leilaoViewModel)
        {
            if (id != leilaoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var leilaoAtualizacao = await ObterLeilao(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            leilaoAtualizacao.Nome = leilaoViewModel.Nome;
            leilaoAtualizacao.ValorInicial = leilaoViewModel.ValorInicial;
            leilaoAtualizacao.Condicao = leilaoViewModel.Condicao;
            leilaoAtualizacao.NomeResponsavel = leilaoViewModel.NomeResponsavel;
            leilaoAtualizacao.UserId = leilaoViewModel.UserId;
            leilaoAtualizacao.DataAbetura = leilaoViewModel.DataAbetura;
            leilaoAtualizacao.DataFinalizacao = leilaoViewModel.DataFinalizacao;
            leilaoAtualizacao.Ativo = leilaoViewModel.Ativo;

            await _leilaoService.Atualizar(_mapper.Map<Leilao>(leilaoAtualizacao));

            return CustomResponse(leilaoViewModel);
        }

        [ClaimsAuthorize("Leilao", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LeilaoViewModel>> Excluir(Guid id)
        {
            var leilao = await ObterLeilao(id);

            if (leilao == null) return NotFound();

            await _leilaoService.Remover(id);

            return CustomResponse(leilao);
        }
        private async Task<LeilaoViewModel> ObterLeilao(Guid id)
        {
            return _mapper.Map<LeilaoViewModel>(await _leilaoRepository.ObterLeilao(id));
        }
    }
}