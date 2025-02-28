using Microsoft.EntityFrameworkCore;

namespace MP.Api.Context
{
    public class MPContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public MPContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
