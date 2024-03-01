using Microsoft.EntityFrameworkCore;

namespace Booking.Models
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
        public virtual DbSet<Slots> Slots { get; set; }
    }
}
