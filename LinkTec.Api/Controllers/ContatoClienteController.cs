using AutoMapper;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LinkTec.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContatoClienteController : MainController
    {
        private readonly IContatoClienteService _contatoClienteService;

        public ContatoClienteController(INotificador notificador,
                                        IUser user,
                                        IContatoClienteService contatoClienteService) : base(notificador, user)
        {
            _contatoClienteService = contatoClienteService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> InserirContatoCliente(ContatoClienteModel contatoCliente)
        {
            await _contatoClienteService.InserirContatoCliente(contatoCliente);
            return CustomResponse();
        }

    }
}
