using FluentValidation;

namespace LinkTec.Api.Models.Validations
{
    public class PropostaSolicitacaoValidator : AbstractValidator<PropostaSolicitacaoModel>
    {
        public PropostaSolicitacaoValidator()
        {
            RuleFor(p => p.SolicitacaoId).NotEmpty().NotNull().WithMessage("Deve ser informada o id da solicitacao para a proposta");
            RuleFor(p => p.OfertanteId).NotEmpty().NotNull().WithMessage("O id do ofertante deve ser preenchido");
            RuleFor(p => p.ValorHora).NotNull().NotEmpty().NotEqual(0).WithMessage("O valor por hora deve ser maior que zero.");
            RuleFor(p => p.Horas).NotNull().NotEmpty().NotEqual(0).WithMessage("As horas devem ser maior que zero.");
        }
    }
}
