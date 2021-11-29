using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using System;
using System.Collections.Generic;

namespace LinkTec.Api.Models
{
    public class SolicitacaoDeServicoModel
    {
        public Guid Id { get; set; }

        public Guid SolicitanteId { get; set; }

        public Guid? OfertanteId { get; set; }

        public ETipoServico TipoServico { get; set; }

        public string Enunciado { get; set; }

        public string DescricaoServico { get; set; }

        public bool Ativa { get; set; }

        public bool Aceita { get; set; }

        public bool Recusada { get; set; }

        public List<PropostaSolicitacaoModel> PropostasSolicitacao { get; set; }

        public EFormaPagamento FormaPagamentoAceita { get; set; }

        internal static SolicitacaoDeServico ToSolicitacaoDeServicoEntity(SolicitacaoDeServicoModel ordemDeServico)
        {
            return new SolicitacaoDeServico
            {
                DescricaoServico = ordemDeServico.DescricaoServico,
                Enunciado = ordemDeServico.Enunciado,
                FormaPagamentoAceita = ordemDeServico.FormaPagamentoAceita,
                OfertanteId = ordemDeServico.OfertanteId,
                SolicitanteId = ordemDeServico.SolicitanteId,
                Ativa = ordemDeServico.Ativa,
                TipoServico = ordemDeServico.TipoServico,
                Recusada = ordemDeServico.Recusada,
                Aceita = ordemDeServico.Aceita,
                Id = ordemDeServico.Id,
            };
        }

        internal static SolicitacaoDeServicoModel FromSolicitacaoDeServicoEntity(SolicitacaoDeServico solicitacao)
        {
            var solicitacaoModel = new SolicitacaoDeServicoModel
            {
                DescricaoServico = solicitacao.DescricaoServico,
                Enunciado = solicitacao.Enunciado,
                FormaPagamentoAceita = solicitacao.FormaPagamentoAceita,
                OfertanteId = solicitacao.OfertanteId,
                SolicitanteId = solicitacao.SolicitanteId,
                Ativa = solicitacao.Ativa,
                TipoServico = solicitacao.TipoServico,
                PropostasSolicitacao = new List<PropostaSolicitacaoModel>()

            };


            foreach(var proposta in solicitacao.PropostasSolicitacao)
            {
                solicitacaoModel.PropostasSolicitacao.Add(new PropostaSolicitacaoModel { Horas = proposta.HoraProposta, ValorHora = proposta.ValorHora, OfertanteId = proposta.OfertanteId, SolicitacaoId = proposta.SolicitacaoId });
            }

            return solicitacaoModel;
        }
    }
}
