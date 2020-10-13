using System;
using System.ComponentModel.DataAnnotations;

namespace LeilaoWeb.Api.ViewModels
{
    public class LeilaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorInicial { get; set; }

        public int Condicao { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataAbetura { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataFinalizacao { get; set; }
        
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

    }
}
