using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using LinkTec.Api.Models.Validations;
using System.Threading.Tasks;

namespace LinkTec.Api.Services
{
    public class ContatoClienteService : IContatoClienteService
    {
        public INotificador _notificador { get; set; }
        public IContatoClienteRepository _contatoClienteRepository { get; set; }
        public ContatoClienteService(IContatoClienteRepository contatoClienteRepository, INotificador notificador)
        {
            _contatoClienteRepository = contatoClienteRepository;
            _notificador = notificador;

        }
        public async Task InserirContatoCliente(ContatoClienteModel contatoCliente)
        {
            var contatoClienteValidator = new ContatoClienteValidator();

            var valido = contatoClienteValidator.Validate(contatoCliente);

            if (!valido.IsValid)
            {
                foreach (var error in valido.Errors)
                    _notificador.Handle(new Notificacao(error.ErrorMessage));

                return;
            }

            await _contatoClienteRepository.Adicionar(ContatoClienteModel.ToContatoClienteEntity(contatoCliente));
        }
    }
}
