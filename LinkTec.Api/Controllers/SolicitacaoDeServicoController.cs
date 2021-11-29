using AutoMapper;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkTec.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SolicitacaoDeServicoController : MainController
    {
        private readonly ISolicitacaoDeServicoService _solicitacaoDeServicoService;

        public SolicitacaoDeServicoController(INotificador notificador, IUser user, ISolicitacaoDeServicoService ordemDeServicoService, IMapper mapper) : base(notificador,user)
        {
            _solicitacaoDeServicoService = ordemDeServicoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SolicitacaoDeServicoModel>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> ObterOrdensDeServico([FromQuery] Guid? solicitanteId, [FromQuery] Guid? ofertanteId, [FromQuery]Guid? id, [FromQuery] bool? ativa)
        {
            return CustomResponse(await _solicitacaoDeServicoService.ObterSolicitacoesDeServico(solicitanteId, ofertanteId, id, ativa));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> InserirSolicitacaoDeServico(SolicitacaoDeServicoModel solicitacaoDeServico)
        {
            await _solicitacaoDeServicoService.InserirSolicitacaoDeServico(solicitacaoDeServico);


            return CustomResponse();
        }

        [HttpPost("proposta")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> OfertarServicoParaSolicitacao(PropostaSolicitacaoModel propostaSolicitacao)
        {
            await _solicitacaoDeServicoService.OfertarPropostaParaSolicitacao(propostaSolicitacao);

            return CustomResponse();
        }

        [HttpPost("aceitar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> AceitarSolicitacaoDeServico([FromBody]Guid solicitacaoServicoId)
        {
            await _solicitacaoDeServicoService.AceitarSolicitacaoDeServico(solicitacaoServicoId);

            return CustomResponse();
        }

        [HttpPost("recusar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> RecusarSolicitacaoDeServico([FromBody] Guid solicitacaoServicoId)
        {
            await _solicitacaoDeServicoService.RecusarSolicitacaoDeServico(solicitacaoServicoId);

            return CustomResponse();
        }


        [HttpPost("proposta/aceitar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> AceitarPropostaSolicitacaoDeServico([FromBody] Guid propostaId)
        {
            await _solicitacaoDeServicoService.AceitarPropostaSolicitacaoDeServico(propostaId);

            return CustomResponse();
        }

        [HttpPost("proposta/recusar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> RecusarPropostaSolicitacaoDeServico([FromBody] Guid propostaId)
        {
            await _solicitacaoDeServicoService.RecusarPropostaSolicitacaoDeServico(propostaId);

            return CustomResponse();
        }
    }
}
