using FluentValidation;

namespace LinkTec.Api.Models.Validations
{
    public class OfertanteCertificadoValidator : AbstractValidator<OfertanteCertificadoModel>
    {
        public OfertanteCertificadoValidator()
        {
            RuleFor(p => p.ServicosPrestados).NotEmpty().NotNull().WithMessage("Pelo menos um serviço deve ser vinculado.");
        }
    }
}
