using benefits.Models;
using Microsoft.EntityFrameworkCore;

namespace benefits.Models
{
public class TablesDbContext:DbContext
    {
        
            public TablesDbContext(DbContextOptions<TablesDbContext> options) : base(options)
            {
            }
                public DbSet<Groups> groups { get; set; }
                public DbSet<Policies> policy { get; set; }
                public DbSet<Benefits> benefit { get; set; }
            
        
    }
}
