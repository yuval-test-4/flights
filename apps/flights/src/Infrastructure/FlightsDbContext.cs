using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure;

public class FlightsDbContext : IdentityDbContext<IdentityUser>
{
    public FlightsDbContext(DbContextOptions<FlightsDbContext> options)
        : base(options) { }
}
