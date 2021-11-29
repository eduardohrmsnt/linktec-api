using LinkTec.Api.Entities;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using LinkTec.Api.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkTec.Api.Services
{
    public class SolicitacaoDeServicoService : ISolicitacaoDeServicoService
    {
        private  INotificador _notificador { get; set; }
        private ISolicitacaoServicoRepository _solicitacaoServicoRepository { get; set; }
        private IPropostaSolicitacaoRepository _propostaSolicitacaoRepository { get; set; }
        private IEmailTemplateRepository _emailTemplateRepository { get; set; }

        public SolicitacaoDeServicoService(INotificador notificador,
            ISolicitacaoServicoRepository solicitacaoServicoRepository,
            IEmailTemplateRepository emailTemplateRepository,
            IPropostaSolicitacaoRepository propostaSolicitacaoRepository)
        {
            _notificador = notificador;
            _emailTemplateRepository = emailTemplateRepository;
            _solicitacaoServicoRepository = solicitacaoServicoRepository;
            _propostaSolicitacaoRepository = propostaSolicitacaoRepository;
        }

        public async Task InserirSolicitacaoDeServico(SolicitacaoDeServicoModel ordemDeServico)
        {
            var validator = new SolicitacaoDeServicoModelValidator();

            var valid = validator.Validate(ordemDeServico);

            if (!valid.IsValid)
            {
                foreach (var error in valid.Errors)
                    _notificador.Handle(new Notificacao(error.ErrorMessage));

                return;
            }

            await _solicitacaoServicoRepository.Adicionar(SolicitacaoDeServicoModel.ToSolicitacaoDeServicoEntity(ordemDeServico));
        }

        public async Task<IEnumerable<SolicitacaoDeServicoModel>> ObterSolicitacoesDeServico(Guid? solicitanteId, Guid? ofertanteId, Guid? id, bool? ativa)
        {
            var retorno = new List<SolicitacaoDeServicoModel>();

            var solicitacoes = new List<SolicitacaoDeServico>();

            if (solicitanteId is not null)
                solicitacoes.AddRange(await _solicitacaoServicoRepository.Buscar(p => p.SolicitanteId == solicitanteId));

            if (ofertanteId is not null)
                solicitacoes.AddRange(await _solicitacaoServicoRepository.Buscar(p => p.OfertanteId == ofertanteId));

            if (id is not null)
                solicitacoes.AddRange(await _solicitacaoServicoRepository.Buscar(p => p.Id == id));


            if (ativa is not null)
                solicitacoes.AddRange(await _solicitacaoServicoRepository.Buscar(p => p.Ativa == ativa));


            foreach(var solicitacao in solicitacoes)
            {
                retorno.Add(SolicitacaoDeServicoModel.FromSolicitacaoDeServicoEntity(solicitacao));
            }

            return retorno;
        }

        public async Task OfertarPropostaParaSolicitacao(PropostaSolicitacaoModel propostaSolicitacao)
        {
            var validator = new PropostaSolicitacaoValidator();

            var valid = validator.Validate(propostaSolicitacao);

            if (!valid.IsValid)
            {
                foreach (var erro in valid.Errors)
                    _notificador.Handle(new Notificacao(erro.ErrorMessage));
            }

            await _propostaSolicitacaoRepository.Adicionar(PropostaSolicitacaoModel.ToPropostaSolicitacaoEntity(propostaSolicitacao));
        }

        public Task RecusarSolicitacaoDeServico(Guid solicitacaoServicoId)
        {
            throw new NotImplementedException();
        }

        public Task AceitarSolicitacaoDeServico(Guid solicitacaoServicoId)
        {
            throw new NotImplementedException();
        }

        public Task RecusarPropostaSolicitacaoDeServico(Guid propostaId)
        {
            throw new NotImplementedException();
        }

        public Task AceitarPropostaSolicitacaoDeServico(Guid propostaId)
        {
            throw new NotImplementedException();
        }
    }
}
