using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SubtitleRed.Infrastructure.Identity;

public class IdentityDatabaseContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}