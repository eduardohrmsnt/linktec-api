using LinkTec.Api.Entities;
using LinkTec.Api.Models;
using System;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface IParceiroService
    {
        Task InserirParceiro(ParceiroModel parceiro);

        Task<ParceiroModel> ObterParceiroPorId(Guid id);

        Task EditarParceiro(ParceiroModel parceiro, Guid parceiroId);
    }
}
