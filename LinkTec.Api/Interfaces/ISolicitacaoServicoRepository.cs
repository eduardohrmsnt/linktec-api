using LinkTec.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface ISolicitacaoServicoRepository : IRepository<SolicitacaoDeServico>
    {
        Task<IEnumerable<SolicitacaoDeServico>> BuscarComProposta(Expression<Func<SolicitacaoDeServico, bool>> predicate);
    }
}
