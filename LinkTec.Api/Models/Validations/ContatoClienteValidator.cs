using FluentValidation;
using FluentValidation.Validators;

namespace LinkTec.Api.Models.Validations
{
    public class ContatoClienteValidator : AbstractValidator<ContatoClienteModel>
    {
        public ContatoClienteValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("E-mail deve ser preenchido.").EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(p => p.Telefone).NotEmpty().WithMessage("Telefone deve ser preenchido").MaximumLength(12).MinimumLength(12).WithMessage("Telefone está em formato invalido.");

            RuleFor(p => p.Mensagem).NotEmpty().WithMessage("Informe a mensagem que deseja nos enviar.");
        }
    }
}
