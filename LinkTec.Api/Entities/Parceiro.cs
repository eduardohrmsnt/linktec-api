using LinkTec.Api.Enums;
using System;
using System.Net.Mail;

namespace LinkTec.Api.Entities
{
    public class Parceiro : Entity
    {
        public string Nome { get; set; }

        public ETipoDocumento TipoDocumento { get; set; }

        public string Documento { get; set; }

        public ETipoParceiro TipoParceiro { get; set; }

        public EFormaPagamento FormaPagamento { get; set; }
        public string Email { get; internal set; }
        public Guid UsuarioId { get; internal set; }
    }
}
