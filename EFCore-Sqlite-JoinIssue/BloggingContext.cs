using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Sqlite_JoinIssue
{
    public class BloggingContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory().AddConsole());
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
}
