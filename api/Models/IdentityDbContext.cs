using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class IdentityDbContext
    {
        private DbContextOptions options;

        public IdentityDbContext(DbContextOptions options)
        {
            this.options = options;
        }
    }
}