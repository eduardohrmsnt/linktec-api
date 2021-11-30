using LinkTec.Api.Entities;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using LinkTec.Api.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkTec.Api.Services
{
    public class SolicitacaoDeServicoService : ISolicitacaoDeServicoService
    {
        private INotificador _notificador { get; set; }
        private ISolicitacaoServicoRepository _solicitacaoServicoRepository { get; set; }
        private IPropostaSolicitacaoRepository _propostaSolicitacaoRepository { get; set; }
        private IParceiroRepository _parceiroRepository { get; set; }
        private IEmailService _emailService { get; set; }

        public SolicitacaoDeServicoService(INotificador notificador,
            ISolicitacaoServicoRepository solicitacaoServicoRepository,
            IPropostaSolicitacaoRepository propostaSolicitacaoRepository,
            IEmailService emailService,
            IParceiroRepository parceiroRepository)
        {
            _notificador = notificador;
            _solicitacaoServicoRepository = solicitacaoServicoRepository;
            _propostaSolicitacaoRepository = propostaSolicitacaoRepository;
            _emailService = emailService;
            _parceiroRepository = parceiroRepository;
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

            ordemDeServico.Ativa = true;

            await _solicitacaoServicoRepository.Adicionar(SolicitacaoDeServicoModel.ToSolicitacaoDeServicoEntity(ordemDeServico));
        }

        public async Task<IEnumerable<SolicitacaoDeServicoModel>> ObterSolicitacoesDeServico(Guid? solicitanteId, Guid? ofertanteId, Guid? id, bool? ativa)
        {
            var retorno = new List<SolicitacaoDeServicoModel>();

            var solicitacoes = new List<SolicitacaoDeServico>();

            if (solicitanteId is not null)
                solicitacoes.AddRange(await _solicitacaoServicoRepository.BuscarComProposta(p => p.SolicitanteId == solicitanteId));

            if (ofertanteId is not null)
                if (!solicitacoes.Any())
                    solicitacoes.AddRange(await _solicitacaoServicoRepository.BuscarComProposta(p => p.OfertanteId == ofertanteId));
                else
                    solicitacoes = solicitacoes.Where(p => p.OfertanteId == ofertanteId).ToList();

            if (id is not null)
                if (!solicitacoes.Any())
                    solicitacoes.AddRange(await _solicitacaoServicoRepository.BuscarComProposta(p => p.Id == id));
                else
                    solicitacoes = solicitacoes.Where(p => p.OfertanteId == ofertanteId).ToList();


            if (ativa is not null)
                if (!solicitacoes.Any())
                    solicitacoes.AddRange(await _solicitacaoServicoRepository.BuscarComProposta(p => p.Ativa == ativa));
                else
                    solicitacoes = solicitacoes.Where(p => p.OfertanteId == ofertanteId).ToList();


            foreach (var solicitacao in solicitacoes)
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

        public async Task RecusarSolicitacaoDeServico(Guid solicitacaoServicoId)
        {
            var solicitacaoServico = await _solicitacaoServicoRepository.ObterPorId(solicitacaoServicoId);

            if (solicitacaoServico == null)
            {
                _notificador.Handle(new Notificacao("Solicitacao de serviço não encontrada."));
                return;
            }

            solicitacaoServico.Recusada = true;



            await _solicitacaoServicoRepository.Atualizar(solicitacaoServico);

            solicitacaoServico.Ofertante = await _parceiroRepository.ObterPorId((Guid)solicitacaoServico.OfertanteId);

            var parceiro = await _parceiroRepository.ObterPorId(solicitacaoServico.SolicitanteId);

            if (parceiro == null)
            {
                _notificador.Handle(new Notificacao("Parceiro não encontrado."));
                return;
            }

            await _emailService.EmailSolicitacaoRecusada(solicitacaoServico, parceiro);

        }

        public async Task AceitarSolicitacaoDeServico(Guid solicitacaoServicoId)
        {
            var solicitacaoServico = await _solicitacaoServicoRepository.ObterPorId(solicitacaoServicoId);

            if (solicitacaoServico == null)
            {
                _notificador.Handle(new Notificacao("Solicitacao de serviço não encontrada."));
                return;
            }

            solicitacaoServico.Aceita = true;

            await _solicitacaoServicoRepository.Atualizar(solicitacaoServico);

            solicitacaoServico.Ofertante = await _parceiroRepository.ObterPorId((Guid)solicitacaoServico.OfertanteId);


            var parceiro = await _parceiroRepository.ObterPorId(solicitacaoServico.SolicitanteId);

            if (parceiro == null)
            {
                _notificador.Handle(new Notificacao("Parceiro não encontrado."));
                return;
            }

            await _emailService.EmailSolicitacaoAceita(solicitacaoServico, parceiro);

        }

        public async Task RecusarPropostaSolicitacaoDeServico(Guid propostaId)
        {
            var propostaSolicitacao = await _propostaSolicitacaoRepository.ObterPorId(propostaId);

            if (propostaSolicitacao == null)
            {
                _notificador.Handle(new Notificacao("Solicitacao de serviço não encontrada."));
                return;
            }

            propostaSolicitacao.Recusada = true;

            await _propostaSolicitacaoRepository.Atualizar(propostaSolicitacao);

            var parceiro = await _parceiroRepository.ObterPorId(propostaSolicitacao.OfertanteId);

            if (parceiro == null)
            {
                _notificador.Handle(new Notificacao("Parceiro não encontrado."));
                return;
            }

            await _emailService.EmailPropostaRecusada(propostaSolicitacao, parceiro);
        }

        public async Task AceitarPropostaSolicitacaoDeServico(Guid propostaId)
        {
            var propostaSolicitacao = await _propostaSolicitacaoRepository.ObterPorId(propostaId);

            if (propostaSolicitacao == null)
            {
                _notificador.Handle(new Notificacao("Solicitacao de serviço não encontrada."));
                return;
            }

            propostaSolicitacao.Aceitada = true;

            await _propostaSolicitacaoRepository.Atualizar(propostaSolicitacao);

            var solicitacaoDeServico = await _solicitacaoServicoRepository.ObterPorId(propostaSolicitacao.SolicitacaoDeServicoId);

            solicitacaoDeServico.Ativa = false;

            var parceiro = await _parceiroRepository.ObterPorId(propostaSolicitacao.OfertanteId);

            if (parceiro == null)
            {
                _notificador.Handle(new Notificacao("Parceiro não encontrado."));
                return;
            }

            await _emailService.EmailPropostaAceita(propostaSolicitacao, parceiro);
        }
    }
}
