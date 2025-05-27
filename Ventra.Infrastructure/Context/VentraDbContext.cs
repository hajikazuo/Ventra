using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Domain.Entities.Users;

namespace Ventra.Infrastructure.Context
{
    public class VentraDbContext : IdentityDbContext<User, Role, Guid>
    {
        public VentraDbContext(DbContextOptions<VentraDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
