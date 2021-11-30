using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace LinkTec.Api.Models
{
    public class OfertanteCertificadoModel
    {
        public ETipoServico ServicosPrestados { get; set; }

        internal static OfertanteCertificadoModel FromOfertanteCertificadoEntity(OfertanteCertificado ofertanteCertificado)
        {


            return new OfertanteCertificadoModel
            {
                ServicosPrestados = ofertanteCertificado.TipoServico
            };
        }
    }
}
