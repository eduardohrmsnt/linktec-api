using FluentValidation;

namespace LinkTec.Api.Models.Validations
{
    public class SolicitacaoDeServicoModelValidator : AbstractValidator<SolicitacaoDeServicoModel>
    {
        public SolicitacaoDeServicoModelValidator()
        {
            RuleFor(p => p.Enunciado).MaximumLength(200).MinimumLength(10).WithMessage("O campo enunciado deve ter entre 10 e 200 caracteres");

            RuleFor(p => p.DescricaoServico).MinimumLength(200).MaximumLength(1000).WithMessage("A descrição do serviço deve ter entre 200 e 1000 caracteres");

            RuleFor(p => p.TipoServico).NotEmpty().NotNull().WithMessage("Pelo menos um serviço deve ser escolhido.");

            RuleFor(p => p.FormaPagamentoAceita).NotEmpty().NotNull().WithMessage("Pelo menos uma forma de pagamento deve ser escolhida.");
        }
    }
}
