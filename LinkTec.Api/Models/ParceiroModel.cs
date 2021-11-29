using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using System;

namespace LinkTec.Api.Models
{
    public class ParceiroModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public EFormaPagamento FormaPagamentoAceita { get; set; }

        public OfertanteCertificadoModel Ofertante { get; set; }

        internal static Parceiro ToParceiroEntity(ParceiroModel parceiro)
        {
            return new Parceiro
            {
                Nome = parceiro.Nome,
                Documento = parceiro.Documento,
                FormaPagamento = parceiro.FormaPagamentoAceita,
                TipoParceiro = parceiro.Ofertante is not null ? ETipoParceiro.Ofertante : ETipoParceiro.Contratante
            };
        }

        internal static ParceiroModel FromParceiroEntity(Parceiro parceiro)
        {
            throw new NotImplementedException();
        }
    }
}