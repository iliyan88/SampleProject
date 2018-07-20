using SimpleEchoBot.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleEchoBot
{
    public class AppDbContext : DbContext
    {
        public DbSet<SearchKey> SearchKeys { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<UserToReply> UserToReplies { get; set; }
    }
}