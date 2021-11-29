using LinkTec.Api.Entities;
using LinkTec.Api.Models;
using System;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface IParceiroRepository : IRepository<Parceiro>
    {
        Task<bool> ParceiroExiste(Guid parceiroId);
    }
}
