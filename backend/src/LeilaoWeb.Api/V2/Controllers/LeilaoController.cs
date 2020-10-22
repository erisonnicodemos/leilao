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

namespace LeilaoWeb.Api.V2.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
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
        public async Task<IEnumerable<LeilaoViewModel>> ObterPorNone(string nome)
        {
            return _mapper.Map<IEnumerable<LeilaoViewModel>>(await _leilaoRepository.ObterLeliloesPorNome(nome));
        }

    }
}