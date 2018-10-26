using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EFCore_Sqlite_JoinIssue
{
    class Program
    {
        public static async Task Main()
        {
            if (File.Exists("test.db"))
            {
                File.Delete("test.db");
            }
            using (var db = new BloggingContext())
            {
                var creationScript = db.Database.GenerateCreateScript();
                await db.Database.ExecuteSqlCommandAsync(creationScript);

                var createdBy = new User { Name = "created" };
                var assignedTo = new User { Name = "assigned" };

                db.Users.Add(assignedTo);
                db.Users.Add(createdBy);

                db.Tickets.Add(new Ticket { Summary = "http://blogs.msdn.com/adonet", CreatedBy = createdBy, AssignedTo = assignedTo });
                var count = await db.SaveChangesAsync();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All posts in database:");
                var query = db.Tickets
                    .Include(x => x.CreatedBy)
                    .Include(x => x.AssignedTo);

                var tickets = await query.ToListAsync();

                foreach (var post in tickets)
                {
                    Console.WriteLine(" - {0}", post.Summary);
                }
            }
        }
    }
}
