using LinkTec.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface ISolicitacaoDeServicoService
    {
        Task InserirSolicitacaoDeServico(Models.SolicitacaoDeServicoModel ordemDeServico);
        Task<IEnumerable<SolicitacaoDeServicoModel>> ObterSolicitacoesDeServico(Guid? solicitanteId, Guid? ofertanteId, Guid? id, bool? ativa);
        Task OfertarPropostaParaSolicitacao(PropostaSolicitacaoModel propostaSolicitacao);
        Task RecusarSolicitacaoDeServico(Guid solicitacaoServicoId);
        Task AceitarSolicitacaoDeServico(Guid solicitacaoServicoId);
        Task RecusarPropostaSolicitacaoDeServico(Guid propostaId);
        Task AceitarPropostaSolicitacaoDeServico(Guid propostaId);
    }
}
