using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;

namespace LinkTec.Api.Repository
{
    public class OfertanteCertificadoRepository : Repository<OfertanteCertificado>, IOfertanteCertificadoRepository
    {
        public OfertanteCertificadoRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
