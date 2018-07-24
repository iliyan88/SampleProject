using SimpleEchoBot.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Repositories
{
    public class UserToReplyRepository : IUserToReplyRepository
    {
        private readonly AppDbContext dbContext;

        public UserToReplyRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(UserToReply user)
        {
            dbContext.UserToReplies.Add(user);
        }

        public void Update(UserToReply user)
        {
            dbContext.UserToReplies.Attach(user);
        }

        public void Delete(UserToReply user)
        {
            dbContext.UserToReplies.Remove(user);
        }

        public async Task<IReadOnlyList<UserToReply>> GetAsync()
        {
            return await dbContext.UserToReplies.ToListAsync();
        }

        public async Task<IReadOnlyList<UserToReply>> GetActiveUsers()
        {
            return await dbContext.UserToReplies.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<UserToReply> GetByIDAsync(int id)
        {
            return await dbContext.UserToReplies.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<UserToReply> GetUserByIdAndName(string skypeUserId, string skypeName)
        {
            return await dbContext.UserToReplies.FirstOrDefaultAsync(x => x.SkypeUserId == skypeUserId && x.SkypeUserName == skypeName);
        }
    }
}