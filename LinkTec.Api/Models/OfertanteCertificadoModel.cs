using LinkTec.Api.Entities;
using LinkTec.Api.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace LinkTec.Api.Models
{
    public class OfertanteCertificadoModel
    {
        public IFormFile CertificadoFile { get; set; }

        public ETipoServico ServicosPrestados { get; set; }

        internal static OfertanteCertificadoModel FromOfertanteCertificadoEntity(OfertanteCertificado ofertanteCertificado)
        {
            var stream = new MemoryStream(ofertanteCertificado.Imagem);

            return new OfertanteCertificadoModel
            {
                CertificadoFile = new FormFile(stream, 0, ofertanteCertificado.Imagem.Length, new Guid().ToString(), new Guid().ToString()),
                ServicosPrestados = ofertanteCertificado.TipoServico
            };
        }
    }
}
