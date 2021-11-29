using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;

namespace LinkTec.Api.Repository
{
    public class PropostaSolicitacaoRepository : Repository<PropostaSolicitacao>, IPropostaSolicitacaoRepository
    {
        public PropostaSolicitacaoRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
