using FluentValidation.Results;
using LeilaoWeb.Business.Models.Validations;
using System;

namespace LeilaoWeb.Business.Models
{
    public class Leilao : Entity
    {
        public string Nome { get; set; }
        public decimal ValorInicial { get; set; }
        public Condicao Condicao { get; set; }
        public string NomeResponsavel { get; set; }
        public Guid UserId { get; set; }
        public DateTime DataAbetura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
