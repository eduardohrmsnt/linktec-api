using LinkTec.Api.Enums;
using System;
using System.Collections.Generic;

namespace LinkTec.Api.Entities
{
    public class SolicitacaoDeServico : Entity
    {
        public virtual Parceiro Solicitante { get; set; }
        public Guid SolicitanteId { get; set; }

        public virtual Parceiro Ofertante { get; set; }
        public Guid? OfertanteId { get; set; }

        public ETipoServico TipoServico { get; set; }

        public string Enunciado { get; set; }

        public string DescricaoServico { get; set; }

        public bool Ativa { get; set; }

        public bool Aceita { get; set; }

        public bool Recusada { get; set; }

        public EFormaPagamento FormaPagamentoAceita { get; set; }

        public virtual IEnumerable<PropostaSolicitacao> PropostasSolicitacao { get; set; }
    }
}
