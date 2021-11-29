using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;
using System.Threading.Tasks;

namespace LinkTec.Api.Repository
{
    public class ContatoClienteRepository : Repository<ContatoCliente>, IContatoClienteRepository
    {
        private readonly ApplicationDBContext _context;

        public ContatoClienteRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
