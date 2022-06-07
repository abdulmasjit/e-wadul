using Ewadul.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
