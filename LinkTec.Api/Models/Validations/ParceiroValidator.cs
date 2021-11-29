using FluentValidation;
using System;

namespace LinkTec.Api.Models.Validations
{
    public class ParceiroValidator : AbstractValidator<ParceiroModel>
    {
        public ParceiroValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage("O campo nome não pode estar vazio.")
                .MinimumLength(5).WithMessage("O tamanho minimo para nome é de 5 caracteres.")
                .MaximumLength(100).WithMessage("O tamanho máximo para nome é de 100 caracteres.");

            RuleFor(p => p.FormaPagamentoAceita).NotEmpty().WithMessage("Pelo menos uma forma de pagamento deve ser escolhida");

            RuleFor(p => p.Documento).MinimumLength(14).MaximumLength(11).WithMessage("O campo Documento nao possui os campos necessarios para cadastro.");

        }
    }
}
