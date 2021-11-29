using LinkTec.Api.Entities;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;

namespace LinkTec.Api.Repository
{
    public class EmailTemplateRepository : Repository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
