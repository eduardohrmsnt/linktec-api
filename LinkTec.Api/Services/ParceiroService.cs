using AutoMapper;
using LinkTec.Api.Entities;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using LinkTec.Api.Models.Validations;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinkTec.Api.Services
{
    public class ParceiroService : IParceiroService
    {
        public INotificador _notificador { get; set; }
        public IParceiroRepository _parceiroRepository { get; set; }
        public IOfertanteCertificadoRepository _ofertanteCertificadoRepository { get; set; }

        public ParceiroService(INotificador notificador, IParceiroRepository parceiroRepository, IOfertanteCertificadoRepository ofertanteCertificadoRepository)
        {
            _parceiroRepository = parceiroRepository;
            _notificador = notificador;
            _ofertanteCertificadoRepository = ofertanteCertificadoRepository;
        }


        public async Task EditarParceiro(ParceiroModel parceiro, Guid parceiroId)
        {

            var existe = await _parceiroRepository.ParceiroExiste(parceiroId);

            if (!existe)
            {
                _notificador.Handle(new Notificacao("O parceiro solicitado nao existe"));
                return;
            }

            ParceiroValidator validator = new ParceiroValidator();

            var valid = validator.Validate(parceiro);

            if (!valid.IsValid)
            {
                foreach (var erro in valid.Errors)
                    _notificador.Handle(new Notificacao(erro.ErrorMessage));
                return;
            }

            await _parceiroRepository.Atualizar(ParceiroModel.ToParceiroEntity(parceiro));
        }

        public async Task InserirParceiro(ParceiroModel parceiro)
        {
            ParceiroValidator validator = new ParceiroValidator();

            var valid = validator.Validate(parceiro);

            if (!valid.IsValid)
            {
                foreach (var erro in valid.Errors)
                    _notificador.Handle(new Notificacao(erro.ErrorMessage));
            }

            var id = await _parceiroRepository.Adicionar(ParceiroModel.ToParceiroEntity(parceiro));

            if (parceiro.Ofertante is not null)
            {
                var validatorCertificado = new OfertanteCertificadoValidator();

                var validCertificado = validatorCertificado.Validate(parceiro.Ofertante);

                if (!validCertificado.IsValid)
                {
                    foreach (var erro in valid.Errors)
                        _notificador.Handle(new Notificacao(erro.ErrorMessage));
                    return;
                }
                var ofertanteCertificado = new OfertanteCertificado();


                byte[] p1 = null;
                using (var fs1 = parceiro.Ofertante.CertificadoFile.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }

                ofertanteCertificado.Imagem = p1;
                ofertanteCertificado.TipoServico = parceiro.Ofertante.ServicosPrestados;
                ofertanteCertificado.OfertanteId = id;

                await _ofertanteCertificadoRepository.Adicionar(ofertanteCertificado);

            }
        }

        public async Task<ParceiroModel> ObterParceiroPorId(Guid id)
        {
            var parceiro = await _parceiroRepository.ObterPorId(id);

            if (parceiro is null)
            {
                _notificador.Handle(new Notificacao("Parceiro não encontrado"));
                return null;
            }

            var parceiroModel = ParceiroModel.FromParceiroEntity(parceiro);

            if (parceiro.TipoParceiro == Enums.ETipoParceiro.Ofertante)
                parceiroModel.Ofertante = OfertanteCertificadoModel.FromOfertanteCertificadoEntity((await _ofertanteCertificadoRepository.Buscar(p => p.OfertanteId == id)).FirstOrDefault());

            return parceiroModel;
        }
    }
}
