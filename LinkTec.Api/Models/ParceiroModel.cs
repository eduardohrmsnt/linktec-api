using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using System;

namespace LinkTec.Api.Models
{
    public class ParceiroModel
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public EFormaPagamento FormaPagamentoAceita { get; set; }

        public OfertanteCertificadoModel Ofertante { get; set; }

        internal static Parceiro ToParceiroEntity(ParceiroModel parceiro)
        {
            return new Parceiro
            {
                UsuarioId = parceiro.UsuarioId,
                Nome = parceiro.Nome,
                Documento = parceiro.Documento,
                FormaPagamento = parceiro.FormaPagamentoAceita,
                TipoParceiro = parceiro.Ofertante is not null ? ETipoParceiro.Ofertante : ETipoParceiro.Contratante,
                TipoDocumento = parceiro.Documento.Length > 11 ? ETipoDocumento.CNPJ : ETipoDocumento.CPF
            };
        }

        internal static ParceiroModel FromParceiroEntity(Parceiro parceiro)
        {
            return new ParceiroModel
            {
                Id = parceiro.Id,
                Nome = parceiro.Nome,
                Documento = parceiro.Documento,
                FormaPagamentoAceita = parceiro.FormaPagamento,
                UsuarioId = parceiro.UsuarioId
            };
        }
    }
}