using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LinkTec.Api.Repository
{
    public class SolicitacaoServicoRepository : Repository<SolicitacaoDeServico>, ISolicitacaoServicoRepository
    {
        public SolicitacaoServicoRepository(ApplicationDBContext db) : base(db)
        {
        }

        public async Task<IEnumerable<SolicitacaoDeServico>> BuscarComProposta(Expression<Func<SolicitacaoDeServico, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).Include(p => p.PropostasSolicitacao).ToListAsync();
        }
    }
}
