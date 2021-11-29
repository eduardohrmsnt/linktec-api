using System;

namespace LinkTec.Api.Entities
{
    public class PropostaSolicitacao : Entity
    {
        public virtual SolicitacaoDeServico SolicitacaoDeServico { get; set; }

        public Guid SolicitacaoId { get; set; }

        public virtual Parceiro Ofertante { get; set; }

        public Guid OfertanteId { get; set; }

        public decimal ValorHora { get; set; }

        public decimal HoraProposta { get; set; }

        public bool Aceitada { get; set; }

        public bool Recusada { get; set; }
    }
}
