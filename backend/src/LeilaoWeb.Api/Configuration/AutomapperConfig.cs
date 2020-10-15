using AutoMapper;
using LeilaoWeb.Api.ViewModels;
using LeilaoWeb.Business.Models;

namespace LeilaoWeb.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Leilao, LeilaoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

        }
    }
}