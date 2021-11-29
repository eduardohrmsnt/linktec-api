using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LinkTec.Api.Repository
{
    public class ParceiroRepository : Repository<Parceiro>, IParceiroRepository
    {
        private readonly ApplicationDBContext _context;

        public ParceiroRepository(ApplicationDBContext context) : base(context)
        {
        }


        public async Task<bool> ParceiroExiste(Guid parceiroId)
        {
            return await Db.Parceiros.AnyAsync(p => p.Id == parceiroId);
        }
    }
}
