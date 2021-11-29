using LinkTec.Api.Enums;
using System;

namespace LinkTec.Api.Entities
{
    public class OfertanteCertificado : Entity
    {
        public virtual Parceiro Parceiro { get; set; }

        public Guid ParceiroId { get; set; }

        public byte[] Imagem { get; set; }

        public ETipoServico TipoServico { get; set; }

        public Parceiro Ofertante { get; set; }
        public Guid OfertanteId { get; set; }
    }
}
