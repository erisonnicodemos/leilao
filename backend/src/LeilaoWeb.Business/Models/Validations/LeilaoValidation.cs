using FluentValidation;

namespace LeilaoWeb.Business.Models.Validations
{
    public class LeilaoValidation : AbstractValidator<Leilao>
    {
        public LeilaoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
                       
            RuleFor(c => c.ValorInicial)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(m => m.DataAbetura)
                .NotEmpty()
                .WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(m => m.DataFinalizacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(d => d.DataAbetura)
                .WithMessage("O campo {PropertyName} precisa ser maior que {DataAbetura}");



        }
    }
}