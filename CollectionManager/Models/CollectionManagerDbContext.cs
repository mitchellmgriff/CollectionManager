using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Models
{
    public class CollectionManagerDbContext : DbContext
    {
        public CollectionManagerDbContext(DbContextOptions<CollectionManagerDbContext> options) : base(options) { }

        public DbSet<Links> Links { get; set; }

    }
}
