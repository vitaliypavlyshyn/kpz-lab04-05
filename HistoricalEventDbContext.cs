using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QQQQ
{
    public class HistoricalEventDbContext : DbContext
    {
        public HistoricalEventDbContext(DbContextOptions<HistoricalEventDbContext> options) : base(options) {
            Database.Migrate();
        }
        
        public DbSet<HistoricalEventEntity> HistoricalEvents { get; set; }
        public DbSet<ReasonEntity> Reasons { get; set; }
        public DbSet<ConsequenceEntity> Consequences { get; set; }
    }
}
