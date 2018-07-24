using SimpleEchoBot.Entities;
using System.Data.Entity;

namespace SimpleEchoBot
{
    public class AppDbContext : DbContext
    {
        public DbSet<SearchKey> SearchKeys { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<UserToReply> UserToReplies { get; set; }
    }
}