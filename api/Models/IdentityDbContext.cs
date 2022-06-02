using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
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