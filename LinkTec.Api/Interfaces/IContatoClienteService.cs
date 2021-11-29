using LinkTec.Api.Models;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface IContatoClienteService
    {
        Task InserirContatoCliente(ContatoClienteModel contatoCliente);
    }
}
