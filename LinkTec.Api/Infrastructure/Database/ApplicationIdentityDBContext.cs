using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkTec.Api.Infrastructure.Database
{
    public class ApplicationIdentityDBContext : IdentityDbContext
    {
        public ApplicationIdentityDBContext(DbContextOptions<ApplicationIdentityDBContext> options) : base(options)
        {
        }
    }
}
