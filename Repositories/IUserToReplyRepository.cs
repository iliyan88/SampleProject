using SimpleEchoBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Repositories
{
    public interface IUserToReplyRepository
    {
        Task<UserToReply> GetByIDAsync(int id);
        Task<IReadOnlyList<UserToReply>> GetAsync();
        void Insert(UserToReply user);
        void Update(UserToReply user);
        void Delete(UserToReply user);
        Task<IReadOnlyList<UserToReply>> GetActiveUsers();
        Task<UserToReply> GetUserByIdAndName(string skypeUserId, string skypeName);
    }
}