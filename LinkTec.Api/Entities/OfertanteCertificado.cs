using LinkTec.Api.Enums;
using System;

namespace LinkTec.Api.Entities
{
    public class OfertanteCertificado : Entity
    {
        public virtual Parceiro Parceiro { get; set; }

        public Guid ParceiroId { get; set; }

        public ETipoServico TipoServico { get; set; }
    }
}
