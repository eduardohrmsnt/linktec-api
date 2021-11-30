using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using System;

namespace LinkTec.Api.Models
{
    public class PropostaSolicitacaoModel
    {
        public Guid Id { get; set; }

        public Guid SolicitacaoId { get; set; }

        public Guid OfertanteId { get; set; }

        public decimal ValorHora { get; set; }

        public decimal Horas { get; set; }


        internal static PropostaSolicitacao ToPropostaSolicitacaoEntity(PropostaSolicitacaoModel propostaSolicitacao)
        {
            return new PropostaSolicitacao
            {
                HoraProposta = propostaSolicitacao.Horas,
                ValorHora = propostaSolicitacao.ValorHora,
                SolicitacaoDeServicoId = propostaSolicitacao.SolicitacaoId,
                OfertanteId = propostaSolicitacao.OfertanteId,
            };
        }
    }
}
