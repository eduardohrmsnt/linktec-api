using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;

namespace LinkTec.Api.Repository
{
    public class SolicitacaoServicoRepository : Repository<SolicitacaoDeServico>, ISolicitacaoServicoRepository
    {
        public SolicitacaoServicoRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
