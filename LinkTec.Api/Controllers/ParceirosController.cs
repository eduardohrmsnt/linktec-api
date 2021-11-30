using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace LinkTec.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ParceirosController : MainController
    {
        private readonly IParceiroService _parceiroService;

        public ParceirosController(INotificador notificador, IUser user, IParceiroService parceiroService) : base(notificador, user)
        {
            _parceiroService = parceiroService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParceiroModel), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> ObterParceiroPorId(Guid id)
        {
            return CustomResponse(await _parceiroService.ObterParceiroPorId(id));
        }

        [HttpGet("ofertantes")]
        [ProducesResponseType(typeof(ParceiroModel), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> ObterParceirosOfertantes(Guid id)
        {
            return CustomResponse(await _parceiroService.ObterParceiroPorId(id));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> InserirParceiro(ParceiroModel parceiro)
        {
            await _parceiroService.InserirParceiro(parceiro);

            return CustomResponse();
        }

        [HttpPost("edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> EditarParceiro(ParceiroModel parceiro, [FromQuery]Guid parceiroId)
        {
            await _parceiroService.EditarParceiro(parceiro, parceiroId);

            return CustomResponse();
        }
    }
}
